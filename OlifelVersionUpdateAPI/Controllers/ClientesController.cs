using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OlifelVersionUpdateAPI.Helpers;
using OlifelVersionUpdateAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace OlifelVersionUpdateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ProjectContext _context;
        private DapperConnections _dapperConnections;

        public ClientesController(ProjectContext context, IOptions<ConnectionsStrings> connectionConfig)
        {
            _context = context;
            _dapperConnections = new DapperConnections(connectionConfig);
        }

        /// <summary>
        /// Devolve todos os Clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetClientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            using (IDbConnection connection = _dapperConnections.getLicencasConnection())
            {
                List<Cliente> result = connection.Query<Cliente>("SELECT * FROM Terceiros").ToList();

                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("GetCliente")]
        public async Task<ActionResult<Cliente>> GetCliente(string id)
        {
            if (!ClienteExists(id))
            {
                return NotFound();
            }

            using (IDbConnection connection = _dapperConnections.getLicencasConnection())
            {
                Cliente result = connection.Query<Cliente>("SELECT * FROM Terceiros WHERE Id = @ID", new { ID = id }).FirstOrDefault();

                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPut, Route("PutCliente")]
        public async Task<IActionResult> PutCliente(string id, Cliente cliente)
        {
            if (id.ToLower() != cliente.Id.ToString().ToLower())
            {
                return BadRequest();
            }

            if (!ClienteExists(id))
            {
                return NotFound();
            }

            using (IDbConnection connection = _dapperConnections.getLicencasConnection())
            {
                try
                {
                    connection.Query("UPDATE Terceiros SET Classe = @Classe, Terceiro = @Terceiro, Nome = @Nome, Morada = @Morada, Localidade = @Localidade, CPostal = @CPostal, email = @Email, Telefone = @Telefone, Fax = @Fax, NIF = @NIF, obs = @Obs, Grupo = @Grupo, Versao_atual = @Versao_atual, Contrato_assistencia = @Contrato_assistencia WHERE Id = @id", new { cliente.Classe, cliente.Terceiro, cliente.Nome, cliente.Morada, cliente.Localidade, cliente.CPostal, cliente.Email, cliente.Telefone, cliente.Fax, cliente.NIF, cliente.Obs, cliente.Grupo, cliente.Versao_atual, cliente.Contrato_assistencia, id });
                }
                catch (Exception)
                {
                    return Conflict("Conflito de valores. Update do cliente falhou.");
                }
            }
            return Ok("ok");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost, Route("PostCliente")]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            //todo - falta inserir data de criacao e data de ultima altereacao

            //verificar se o grupo existe
            var grupo = _context.Grupos.Where(g => g.Id == cliente.Grupo).FirstOrDefault();

            if (grupo == null)
            {
                return NotFound(); //grupo nao existe
            }

            //verificar se a versao existe
            var versao = _context.Versoes.Where(v => v.Id == cliente.Versao_atual).FirstOrDefault();

            if (versao == null)
            {
                return NotFound(); //versao nao existe
            }


            //adicionar cliente a base de dados
            using (IDbConnection connection = _dapperConnections.getLicencasConnection())
            {
                try
                {
                    List<Guid> old_ids = connection.Query<Guid>("SELECT ID FROM Terceiros").ToList();

                    connection.Query("INSERT INTO Terceiros(Classe, Terceiro, Nome, Morada, Localidade, CPostal, email, Telefone, Fax, NIF, obs, Grupo, Versao_atual, Contrato_assistencia, Data_criacao)" +
                        "VALUES(@Classe, @Terceiro, @Nome, @Morada, @Localidade, @CPostal, @email, @Telefone, @Fax, @NIF, @obs, @Grupo, @Versao_atual, @Contrato_assistencia, @Data_criacao);",
                        new { cliente.Classe, cliente.Terceiro, cliente.Nome, cliente.Morada, cliente.Localidade, cliente.CPostal, email = cliente.Email, cliente.Telefone, cliente.Fax, cliente.NIF, obs = cliente.Obs, cliente.Grupo, cliente.Versao_atual, cliente.Contrato_assistencia, Data_criacao = DateTime.Now });

                    cliente.Id = connection.Query<Guid>("SELECT ID FROM Terceiros").Except(old_ids).FirstOrDefault();
                }
                catch (Exception)
                {
                    return Conflict("Conflito de valores. Insert do cliente falhou.");
                }
            }

            DateTime dateTime = DateTime.Now;
            DateTime horaData = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]), Int32.Parse(grupo.Hora_distribuicao.Split(":")[1]), 0);

            //se hora de distribuicao ja tiver passado nesse dia, muda pra o dia seguinte
            if (dateTime.Hour > Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]) || (dateTime.Hour == Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]) && dateTime.Minute >= Int32.Parse(grupo.Hora_distribuicao.Split(":")[1])))
            {
                horaData = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day + 1, Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]), Int32.Parse(grupo.Hora_distribuicao.Split(":")[1]), 0);
            }

            //adiciona versao e cliente à tabela VersaoCliente onde é guarda todas as versoes que cada cliente tem acesso
            try
            {
                VersaoCliente versaoCliente = new VersaoCliente { Cliente_ID = cliente.Id.ToString(), Versao_ID = cliente.Versao_atual, Data_distribuicao = horaData };
                _context.VersoesClientes.Add(versaoCliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Conflict("Distribuicao da Versao nao foi guardada.");
            }

            return Ok("ok");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteCliente")]
        public async Task<IActionResult> DeleteCliente(string id)
        {
            if (!ClienteExists(id))
            {
                return NotFound();
            }

            using (IDbConnection connection = _dapperConnections.getLicencasConnection())
            {
                try
                {
                    connection.Query("DELETE FROM Terceiros WHERE Id = @ID", new { ID = id });
                }
                catch (Exception)
                {
                    return Conflict("Conflito de valores. Delete do cliente falhou.");
                }
            }
            return Ok("ok");
        }
        private bool ClienteExists(string id)
        {
            using (IDbConnection connection = _dapperConnections.getLicencasConnection())
            {
                try
                {
                    var item = connection.Query("SELECT ID FROM Terceiros WHERE Id LIKE @ID", new { ID = id }).FirstOrDefault();
                    return item != null;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
