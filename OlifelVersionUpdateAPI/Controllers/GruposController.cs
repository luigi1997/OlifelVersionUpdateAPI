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
    public class GruposController : ControllerBase
    {
        private DapperConnections _dapperConnections;

        public GruposController(IOptions<ConnectionsStrings> connectionConfig)
        {
            _dapperConnections = new DapperConnections(connectionConfig);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetGrupos")]
        public ActionResult<IEnumerable<Grupo>> GetGrupos()
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            List<Grupo> result = connection.Query<Grupo>("SELECT * FROM Grupos").ToList();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("GetGrupo")]
        public ActionResult<Grupo> GetGrupo(string id)
        {
            if (!GrupoExists(id))
            {
                return NotFound();
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            Grupo grupo = connection.Query<Grupo>("SELECT * FROM Grupos WHERE Id LIKE @ID", new { ID = id }).FirstOrDefault();

            return grupo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="grupo"></param>
        /// <returns></returns>
        [HttpPut, Route("PutGrupo")]
        public IActionResult PutGrupo(string id, Grupo grupo)
        {
            string hora = grupo.Hora_distribuicao;

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

            if (id.Equals(grupo.Id))
            {
                return BadRequest();
            }

            if (!GrupoExists(id))
            {
                return NotFound();
            }

            using (IDbConnection connection = _dapperConnections.getLicencasConnection())
            {
                try
                {
                    connection.Query("UPDATE Grupos SET Nome = @Nome, Hora_distribuicao = @Hora_distribuicao WHERE Id LIKE @id", new { grupo.Nome, grupo.Hora_distribuicao, id });
                    return Ok("Ok");
                }
                catch (Exception)
                {
                    return Conflict("Conflito de valores. Update do grupo falhou.");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        [HttpPost, Route("PostGrupo")]
        public ActionResult<Grupo> PostGrupo(Grupo grupo)
        {
            string hora = grupo.Hora_distribuicao;

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
            try
            {
                connection.Query("INSERT INTO Grupos(Nome, Hora_distribuicao) VALUES(@Nome, @Hora_distribuicao)",
                        new { grupo.Nome, Hora_Distribuicao = grupo.Hora_distribuicao });

                return Ok("ok");
            }
            catch (Exception)
            {
                return Conflict("Conflito de valores. Insert do grupo falhou.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteGrupo")]
        public ActionResult<Grupo> DeleteGrupo(string id)
        {
            if (!GrupoExists(id))
            {
                return NotFound();
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            var result = connection.Query("SELECT * FROM Terceiros").ToList().Where(c => c.Grupo.ToString() == id).ToList();

            if (result.Count > 0)
            {
                return Conflict("Grupo nao pode ser apagado. Tem Clientes que pertencem a esse grupo."); //grupo tem clientes ligados a ele
            }

            try
            {
                connection.Query("DELETE FROM Grupos WHERE Id LIKE @ID", new { ID = id });
                return Ok("Ok");
            }
            catch (Exception)
            {
                return Conflict("Conflito de valores. Delete do grupo falhou.");
            }
        }

        private bool GrupoExists(string id)
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            try
            {
                var item = connection.Query("SELECT ID FROM Grupos WHERE Id LIKE @ID", new { ID = id }).FirstOrDefault();
                return item != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
