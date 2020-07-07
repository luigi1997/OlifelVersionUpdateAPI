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
    public class VersoesController : ControllerBase
    {
        private DapperConnections _dapperConnections;

        public VersoesController(IOptions<ConnectionsStrings> connectionConfig)
        {
            _dapperConnections = new DapperConnections(connectionConfig);
        }

        /// <summary>
        /// Obter todas as versoes
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetVersoes")]
        public ActionResult<IEnumerable<Versao>> GetVersoes()
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            List<Versao> result = connection.Query<Versao>("SELECT * FROM Versoes").ToList();

            return result;
        }

        /// <summary>
        /// Obter um versao, dado o id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("GetVersao")]
        public ActionResult<Versao> GetVersao(string id)
        {
            if (!VersaoExists(id))
            {
                return NotFound();
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            Versao versao = connection.Query<Versao>("SELECT * FROM Versoes WHERE Id LIKE @ID", new { ID = id }).FirstOrDefault();

            return versao;
        }

        /// <summary>
        /// Editar uma versao
        /// </summary>
        /// <param name="id"></param>
        /// <param name="versao"></param>
        /// <returns></returns>
        [HttpPut, Route("PutVersao")]
        public IActionResult PutVersao(string id, Versao versao)
        {
            if (!string.Equals(id, versao.Id.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                return BadRequest();
            }

            if (!VersaoExists(id))
            {
                return NotFound();
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            try
            {
                connection.Query("UPDATE Versoes SET Tag_name = @Tag_name, Name = @Name, Body = @Body, Published_at = @Published_at WHERE Id LIKE @id", new { versao.Tag_name, versao.Name, versao.Body, versao.Published_at, id });
                return Ok("Ok");
            }
            catch (Exception)
            {
                return Conflict("Conflito de valores. Update da versao falhou.");
            }
        }

        /// <summary>
        /// Inserir uma versao
        /// </summary>
        /// <param name="versao"></param>
        /// <returns></returns>
        [HttpPost, Route("PostVersao")]
        public ActionResult<Versao> PostVersao(Versao versao)
        {
            if (VersaoExists(versao.Id))
            {
                return Ok("Versao ja foi distribuida.");
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            try
            {
                connection.Query("INSERT INTO Versoes(Id, Tag_name, Name, Body, Published_at) VALUES(@Id, @Tag_name, @Name, @Body, @Published_at)",
                    new { versao.Id, versao.Tag_name, versao.Name, versao.Body, versao.Published_at });
                return Ok("Ok");
            }
            catch (Exception)
            {
                return Conflict("Conflito de valores. Insert da versao falhou.");
            }
        }

        /// <summary>
        /// Apagar uma versao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteVersao")]
        public ActionResult<Versao> DeleteVersao(string id)
        {
            if (!VersaoExists(id))
            {
                return NotFound();
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            try
            {
                connection.Query("DELETE FROM Versoes WHERE Id LIKE @ID", new { ID = id });
                return Ok("Ok");
            }
            catch (Exception)
            {
                return Conflict("Conflito de valores. Delete da versao falhou.");
            }
        }

        private bool VersaoExists(string id)
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            try
            {
                var item = connection.Query("SELECT ID FROM Versoes WHERE Id LIKE @ID", new { ID = id }).FirstOrDefault();
                return item != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
