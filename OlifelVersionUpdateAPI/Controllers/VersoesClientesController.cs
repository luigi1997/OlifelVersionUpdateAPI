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
    public class VersoesClientesController : ControllerBase
    {
        public class VersaoClienteNomes : VersaoCliente
        {
            public string Cliente_nome { get; set; }
            public string Versao_nome { get; set; }
        }

        private DapperConnections _dapperConnections;

        public VersoesClientesController(IOptions<ConnectionsStrings> connectionConfig)
        {
            _dapperConnections = new DapperConnections(connectionConfig: connectionConfig);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetVersoesClientes")]
        public ActionResult<IEnumerable<VersaoCliente>> GetVersoesClientes()
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            List<VersaoCliente> result = connection.Query<VersaoCliente>("SELECT * FROM VersoesClientes").ToList();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_c"></param>
        /// <param name="id_v"></param>
        /// <returns></returns>
        [HttpGet, Route("GetVersaoCliente")]
        public ActionResult<VersaoCliente> GetVersaoCliente(string id_c, string id_v)
        {
            if (!VersaoClienteExists(id_c, id_v))
            {
                return NotFound();
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            VersaoCliente versaoCliente = connection.Query<VersaoCliente>("SELECT * FROM VersoesClientes WHERE Cliente_ID LIKE @Cliente_ID AND Versao_ID LIKE @Versao_ID", new { Cliente_ID = id_c, Versao_ID = id_v }).FirstOrDefault();

            return versaoCliente;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_c"></param>
        /// <returns></returns>
        [HttpGet, Route("GetVersoesDoCliente")]
        public ActionResult<IEnumerable<VersaoCliente>> GetVersoesDoCliente(string id_c)
        {
            if (!ClienteExists(id_c))
            {
                return NotFound();
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            List<VersaoCliente> versoesCliente = connection.Query<VersaoCliente>("SELECT * FROM VersoesClientes WHERE Cliente_ID LIKE @Cliente_ID", new { Cliente_ID = id_c }).ToList();

            return versoesCliente;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_c"></param>
        /// <returns></returns>
        [HttpGet, Route("GetVersaoMaisRecenteDoCliente")]
        public ActionResult<Versao> GetVersaoMaisRecenteDoCliente(string id_c)
        {
            if (!ClienteExists(id_c))
            {
                return NotFound();
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            string id_versao_mais_recente = connection.Query<string>("SELECT MAX(Versao_ID) FROM VersoesClientes WHERE Cliente_ID LIKE @Cliente_ID", new { Cliente_ID = id_c }).FirstOrDefault();

            Versao versao = connection.Query<Versao>("SELECT * FROM Versoes WHERE Id LIKE @Id", new { Id = id_versao_mais_recente }).FirstOrDefault();

            return versao;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetVersaoMaisRecenteParaCadaCliente")]
        public ActionResult<IEnumerable<VersaoClienteNomes>> GetVersaoMaisRecenteParaCadaCliente()
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            List<Cliente> clientes = connection.Query<Cliente>("SELECT * FROM Terceiros").ToList();

            List<VersaoClienteNomes> listaVersoesClientes = new List<VersaoClienteNomes>();

            foreach (var cliente in clientes)
            {
                string id_versao_mais_recente = connection.Query<string>("SELECT MAX(Versao_ID) FROM VersoesClientes WHERE Cliente_ID LIKE @Cliente_ID", new { Cliente_ID = cliente.Id }).FirstOrDefault();

                VersaoClienteNomes versaoClienteNomes = connection.Query<VersaoClienteNomes>("SELECT * FROM VersoesClientes WHERE Cliente_ID LIKE @Cliente_ID AND Versao_ID LIKE @Versao_ID", new { Cliente_ID = cliente.Id, Versao_ID = id_versao_mais_recente }).FirstOrDefault();

                if (versaoClienteNomes != null)
                {
                    versaoClienteNomes.Cliente_nome = cliente.Nome;
                    versaoClienteNomes.Versao_nome = connection.Query<string>("SELECT Tag_name FROM Versoes WHERE Id = @ID", new { ID = id_versao_mais_recente }).FirstOrDefault();

                    listaVersoesClientes.Add(versaoClienteNomes);
                }
            }
            return listaVersoesClientes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_c"></param>
        /// <param name="id_v"></param>
        /// <param name="versaoCliente"></param>
        /// <returns></returns>
        [HttpPut, Route("PutVersaoCliente")]
        public IActionResult PutVersaoCliente(string id_c, string id_v, VersaoCliente versaoCliente)
        {
            if (!string.Equals(id_c, versaoCliente.Cliente_ID.ToString(), StringComparison.CurrentCultureIgnoreCase) || !string.Equals(id_v, versaoCliente.Versao_ID.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                return BadRequest();
            }

            if (!VersaoClienteExists(id_c, id_v))
            {
                return NotFound();
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            try
            {
                connection.Query("UPDATE VersoesClientes SET Data_distribuicao = @Data_distribuicao WHERE Cliente_ID LIKE @Cliente_ID AND Versao_ID LIKE @Versao_ID", new { versaoCliente.Data_distribuicao, versaoCliente.Cliente_ID, versaoCliente.Versao_ID });
                return Ok("Ok. VersaoCliente atualizada.");
            }
            catch (Exception)
            {
                return Conflict("Conflito de valores. Update da versaoCliente falhou.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="versaoCliente"></param>
        /// <returns></returns>
        [HttpPost, Route("PostVersaoCliente")]
        public ActionResult<VersaoCliente> PostVersaoCliente(VersaoCliente versaoCliente)
        {
            if (VersaoClienteExists(versaoCliente.Cliente_ID.ToString(), versaoCliente.Versao_ID))
            {
                PutVersaoCliente(versaoCliente.Cliente_ID.ToString(), versaoCliente.Versao_ID, versaoCliente);
                return Ok("Ok. VersaoCliente atualizada.");
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            connection.Query("INSERT INTO VersoesClientes(Cliente_ID, Versao_ID, Data_distribuicao) VALUES(@Cliente_ID, @Versao_ID, @Data_distribuicao)",
                    new { versaoCliente.Cliente_ID, versaoCliente.Versao_ID, versaoCliente.Data_distribuicao });

            return Ok("Ok. VersaoCliente inserida.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="versaoCliente"></param>
        /// <param name="hora"></param>
        /// <returns></returns>
        [HttpPost, Route("PostDistribuirVersaoCliente")]
        public ActionResult<VersaoCliente> PostDistribuirVersaoCliente(VersaoCliente versaoCliente, string hora)
        {
            //verifica se a hora é valida
            if (hora != "" && hora != null)
                if (hora.Split(":").Length != 2)
                    return BadRequest();
                else if (hora.Split(":")[0].Length == 0 || hora.Split(":")[1].Length == 0)
                    return BadRequest();
                else if (!int.TryParse(hora.Split(":")[0], out int n) || !int.TryParse(hora.Split(":")[1], out int m))
                    return BadRequest();
                else if (Int16.Parse(hora.Split(":")[0]) < 0 || Int16.Parse(hora.Split(":")[0]) > 23 || Int16.Parse(hora.Split(":")[1]) < 0 || Int16.Parse(hora.Split(":")[1]) > 59)
                    return BadRequest();
            
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            Cliente cliente = connection.Query<Cliente>("SELECT * FROM Terceiros WHERE ID LIKE @Id", new { Id = versaoCliente.Cliente_ID }).FirstOrDefault();

            if (cliente == null)
            {
                return NotFound();
            }

            //verificar se o grupo existe
            Grupo grupo = connection.Query<Grupo>("SELECT * FROM Grupos WHERE Id LIKE @ID", new { ID = cliente.Grupo }).FirstOrDefault();

            if (grupo == null)
            {
                return NotFound(); //grupo nao existe
            }

            //verificar se a versao existe
            Versao versao = connection.Query<Versao>("SELECT * FROM Versoes WHERE Id LIKE @ID", new { ID = versaoCliente.Versao_ID }).FirstOrDefault();

            if (versao == null)
            {
                return NotFound(); //versao nao existe
            }

            DateTime dateTimeNow = DateTime.Now;
            DateTime horaDataDistribuicao;

            if (hora == null || hora == "")
            {
                horaDataDistribuicao = new DateTime(dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day, Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]), Int32.Parse(grupo.Hora_distribuicao.Split(":")[1]), 0);

                if (dateTimeNow.Hour > Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]) || (dateTimeNow.Hour == Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]) && dateTimeNow.Minute >= Int32.Parse(grupo.Hora_distribuicao.Split(":")[1])))
                    horaDataDistribuicao = new DateTime(dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day + 1, Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]), Int32.Parse(grupo.Hora_distribuicao.Split(":")[1]), 0);
            }
            else
            {
                horaDataDistribuicao = new DateTime(dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day, Int32.Parse(hora.Split(":")[0]), Int32.Parse(hora.Split(":")[1]), 0);

                if (dateTimeNow.Hour > Int32.Parse(hora.Split(":")[0]) || (dateTimeNow.Hour == Int32.Parse(hora.Split(":")[0]) && dateTimeNow.Minute >= Int32.Parse(hora.Split(":")[1])))
                    horaDataDistribuicao = new DateTime(dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day + 1, Int32.Parse(hora.Split(":")[0]), Int32.Parse(hora.Split(":")[1]), 0);
            }

            versaoCliente.Data_distribuicao = horaDataDistribuicao;

            if (VersaoClienteExists(versaoCliente.Cliente_ID.ToString(), versaoCliente.Versao_ID))
            {
                PutVersaoCliente(versaoCliente.Cliente_ID.ToString(), versaoCliente.Versao_ID, versaoCliente);
                return Ok("Ok. VersaoCliente atualizada.");
            }

            connection.Query("INSERT INTO VersoesClientes(Cliente_ID, Versao_ID, Data_distribuicao) VALUES(@Cliente_ID, @Versao_ID, @Data_distribuicao)",
                    new { versaoCliente.Cliente_ID, versaoCliente.Versao_ID, versaoCliente.Data_distribuicao });

            return Ok("Ok. VersaoCliente inserida.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_c"></param>
        /// <param name="id_v"></param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteVersaoCliente")]
        public ActionResult<VersaoCliente> DeleteVersaoCliente(string id_c, string id_v)
        {
            if (!VersaoClienteExists(id_c, id_v))
            {
                return NotFound();
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            try
            {
                connection.Query("DELETE FROM VersoesClientes WHERE Cliente_ID LIKE @Cliente_ID AND Versao_ID LIKE @Versao_ID", new { Cliente_ID = id_c, Versao_ID = id_v });
                return Ok("ok");
            }
            catch (Exception)
            {
                return Conflict("Conflito de valores. Delete da versaoCliente falhou.");
            }
        }

        private bool VersaoClienteExists(string id_c, string id_v)
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            try
            {
                var item = connection.Query("SELECT Cliente_ID, Versao_ID FROM VersoesClientes WHERE Cliente_ID LIKE @Cliente_ID AND Versao_ID LIKE @Versao_ID", new { Cliente_ID = id_c, Versao_ID = id_v }).FirstOrDefault();
                return item != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool VersaoExists(string id_v)
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            try
            {
                var item = connection.Query("SELECT Cliente_ID, Versao_ID FROM VersoesClientes WHERE Versao_ID LIKE @Versao_ID", new { Versao_ID = id_v }).FirstOrDefault();
                return item != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ClienteExists(string id_c)
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            try
            {
                var item = connection.Query("SELECT Cliente_ID, Versao_ID FROM VersoesClientes WHERE Cliente_ID LIKE @Cliente_ID", new { Cliente_ID = id_c }).FirstOrDefault();
                return item != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
