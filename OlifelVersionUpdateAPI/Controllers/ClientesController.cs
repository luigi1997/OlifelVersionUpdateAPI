    using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OlifelVersionUpdateAPI.Helpers;
using OlifelVersionUpdateAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OlifelVersionUpdateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        public class ClienteDados : Cliente
        {
            public string Grupo_nome { get; set; }
            public string Versao_nome { get; set; }
        }

        public class ClienteLicenca : ClienteDados
        {
            public string Lic_ID { get; set; }
            public string VersaoAutorizada { get; set; }
        }

        private readonly DapperConnections _dapperConnections;

        public ClientesController(IOptions<ConnectionsStrings> connectionConfig)
        {
            _dapperConnections = new DapperConnections(connectionConfig);
        }

        /// <summary>
        /// Devolve todos os Clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetClientes")]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            List<Cliente> clientes = connection.Query<Cliente>("SELECT * FROM Terceiros").ToList();

            return clientes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetClientesDados")]
        public ActionResult<IEnumerable<ClienteDados>> GetClientesDados()
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            List<ClienteDados> clientes = connection.Query<ClienteDados>("SELECT t.*, g.Nome AS Grupo_nome, v.Tag_name AS Versao_nome FROM Terceiros t LEFT JOIN Versoes v ON t.Versao_atual = v.Id LEFT JOIN Grupos g ON t.Grupo = g.ID").ToList();

            return clientes;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="versao_tag_name"></param>
        /// <returns></returns>
        [HttpGet, Route("GetClientesAutorizadosParaVersao")]
        public ActionResult<IEnumerable<ClienteLicenca>> GetClientesDados(string versao_tag_name)
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            List<ClienteLicenca> clientes = connection.Query<ClienteLicenca>("SELECT teri.*, lili.Lic_ID, lili.VersaoAutorizada, g.Nome AS Grupo_nome, v.Tag_name AS Versao_nome FROM Terceiros teri LEFT JOIN Grupos g ON teri.Grupo = g.ID LEFT JOIN Versoes v ON teri.Versao_atual = v.Id LEFT JOIN (SELECT lic.Lic_ID, lic.VersaoAutorizada, lic.ID FROM Licencas lic INNER JOIN (SELECT ID, MAX(Lic_ID) AS MaxLic_ID FROM Licencas GROUP BY ID) AS maxi ON lic.ID = maxi.ID AND lic.Lic_ID = maxi.MaxLic_ID) AS lili ON lili.ID = teri.ID WHERE lili.Lic_ID IS NOT NULL").ToList();

            foreach (var cliente in clientes.ToList())
            {
                if (cliente.VersaoAutorizada.Split(".").Length != 2 || versao_tag_name.Split("V").Length != 2 || versao_tag_name.Split("V")[1].Split(".").Length != 3)
                    continue;

                if (Int16.Parse(cliente.VersaoAutorizada.Split(".")[0]) < Int16.Parse(versao_tag_name.Split("V")[1].Split(".")[0]) || (Int16.Parse(cliente.VersaoAutorizada.Split(".")[0]) == Int16.Parse(versao_tag_name.Split("V")[1].Split(".")[0]) && Int16.Parse(cliente.VersaoAutorizada.Split(".")[1]) < Int16.Parse(versao_tag_name.Split("V")[1].Split(".")[1])))
                    clientes.Remove(cliente);
            }

            return clientes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("GetCliente")]
        public ActionResult<Cliente> GetCliente(string id)
        {
            if (!ClienteExists(id))
            {
                return NotFound();
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            Cliente cliente = connection.Query<Cliente>("SELECT * FROM Terceiros WHERE Id LIKE @ID", new { ID = id }).FirstOrDefault();

            if (cliente == null)
                return NotFound();

            return cliente;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetClienteDados")]
        public ActionResult<ClienteDados> GetClienteDados(string id)
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            ClienteDados cliente = connection.Query<ClienteDados>("SELECT t.*, g.Nome AS Grupo_nome, v.Tag_name AS Versao_nome FROM Terceiros t LEFT JOIN Versoes v ON t.Versao_atual = v.Id LEFT JOIN Grupos g ON t.Grupo = g.ID WHERE t.Id LIKE @ID", new { ID = id }).FirstOrDefault();

            if (cliente == null)
                return NotFound();

            return cliente;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPut, Route("PutCliente")]
        public IActionResult PutCliente(string id, Cliente cliente)
        {
            if (!string.Equals(id, cliente.Id.ToString(), StringComparison.CurrentCultureIgnoreCase))
                return BadRequest();

            if (!ClienteExists(id))
                return NotFound();

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            try
            {
                connection.Query("UPDATE Terceiros SET Classe = @Classe, Terceiro = @Terceiro, Nome = @Nome, Morada = @Morada, Localidade = @Localidade, CPostal = @CPostal, email = @Email, Telefone = @Telefone, Fax = @Fax, NIF = @NIF, obs = @Obs, Grupo = @Grupo, Versao_atual = @Versao_atual, Contrato_assistencia = @Contrato_assistencia WHERE Id LIKE @id",
                    new { cliente.Classe, cliente.Terceiro, cliente.Nome, cliente.Morada, cliente.Localidade, cliente.CPostal, cliente.Email, cliente.Telefone, cliente.Fax, cliente.NIF, cliente.Obs, cliente.Grupo, cliente.Versao_atual, cliente.Contrato_assistencia, id });
                return Ok("ok");
            }
            catch (Exception)
            {
                return Conflict("Conflito de valores. Update do cliente falhou.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost, Route("PostCliente")]
        public ActionResult<Cliente> PostCliente(Cliente cliente)
        {
            //todo - falta inserir data de criacao e data de ultima altereacao

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            //verificar se o grupo existe
            Grupo grupo = connection.Query<Grupo>("SELECT * FROM Grupos WHERE Id LIKE @ID", new { ID = cliente.Grupo }).FirstOrDefault();

            if (grupo == null)
                return NotFound(); //grupo nao existe

            //verificar se a versao existe
            if (cliente.Versao_atual != null)
            {
                Versao versao = connection.Query<Versao>("SELECT * FROM Versoes WHERE Id LIKE @ID", new { ID = cliente.Versao_atual }).FirstOrDefault();

                if (versao == null)
                    return NotFound(); //versao nao existe
            }

            //adicionar cliente a base de dados
            try
            {
                List<Guid> old_ids = connection.Query<Guid>("SELECT ID FROM Terceiros").ToList();

                connection.Query("INSERT INTO Terceiros(Classe, Terceiro, Nome, Morada, Localidade, CPostal, email, Telefone, Fax, NIF, obs, Grupo, Versao_atual, Contrato_assistencia, Data_criacao)" +
                    "VALUES(@Classe, @Terceiro, @Nome, @Morada, @Localidade, @CPostal, @email, @Telefone, @Fax, @NIF, @obs, @Grupo, @Versao_atual, @Contrato_assistencia, @Data_criacao)",
                    new { cliente.Classe, cliente.Terceiro, cliente.Nome, cliente.Morada, cliente.Localidade, cliente.CPostal, email = cliente.Email, cliente.Telefone, cliente.Fax, cliente.NIF, obs = cliente.Obs, cliente.Grupo, cliente.Versao_atual, cliente.Contrato_assistencia, Data_criacao = DateTime.Now });

                cliente.Id = connection.Query<Guid>("SELECT ID FROM Terceiros").Except(old_ids).FirstOrDefault();
            }
            catch (Exception)
            {
                return Conflict("Conflito de valores. Insert do cliente falhou.");
            }

            //
            if (cliente.Versao_atual != null)
            {
                DateTime dateTimeNow = DateTime.Now;
                DateTime horaDataDistribuicao = new DateTime(dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day, Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]), Int32.Parse(grupo.Hora_distribuicao.Split(":")[1]), 0);

                //se hora de distribuicao ja tiver passado nesse dia, muda pra o dia seguinte
                if (dateTimeNow.Hour > Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]) || (dateTimeNow.Hour == Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]) && dateTimeNow.Minute >= Int32.Parse(grupo.Hora_distribuicao.Split(":")[1])))
                {
                    horaDataDistribuicao = new DateTime(dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day + 1, Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]), Int32.Parse(grupo.Hora_distribuicao.Split(":")[1]), 0);
                }

                //adiciona versao e cliente à tabela VersaoCliente onde é guarda todas as versoes que cada cliente tem acesso
                try
                {
                    VersaoCliente versaoCliente = new VersaoCliente { Cliente_ID = cliente.Id, Versao_ID = cliente.Versao_atual, Data_distribuicao = horaDataDistribuicao };

                    connection.Query("INSERT INTO VersoesClientes(Cliente_ID, Versao_ID, Data_distribuicao) VALUES(@Cliente_ID, @Versao_ID, @Data_distribuicao)",
                        new { Cliente_ID = cliente.Id, Versao_ID = cliente.Versao_atual, Data_distribuicao = horaDataDistribuicao });

                    return Ok("ok");
                }
                catch (Exception)
                {
                    return Conflict("Distribuicao da versao nao foi guardada.");
                }
            }

            return Ok(cliente);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteCliente")]
        public IActionResult DeleteCliente(string id)
        {
            if (!ClienteExists(id))
            {
                return NotFound();
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            try
            {
                connection.Query("DELETE FROM Terceiros WHERE Id LIKE @ID", new { ID = id });
                return Ok("ok");
            }
            catch (Exception)
            {
                return Conflict("Conflito de valores. Delete do cliente falhou.");
            }
        }

        private bool ClienteExists(string id)
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

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
