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
    public class UtilizadoresController : ControllerBase
    {
        private readonly DapperConnections _dapperConnections;

        public UtilizadoresController(IOptions<ConnectionsStrings> connectionConfig)
        {
            _dapperConnections = new DapperConnections(connectionConfig);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetUtilizadores")]
        public ActionResult<IEnumerable<Utilizador>> GetUtilizadores()
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            List<Utilizador> result = connection.Query<Utilizador>("SELECT * FROM Utilizadores").ToList();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpGet, Route("GetUtilizador")]
        public ActionResult<Utilizador> GetUtilizador(string userID)
        {
            if (!UtilizadorExistsID(userID))
            {
                return NotFound();
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            Utilizador utilizador = connection.Query<Utilizador>("SELECT * FROM Utilizadores WHERE UserID LIKE @UserID", new { UserID = userID }).FirstOrDefault();

            return utilizador;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet, Route("CheckUtilizador")]
        public ActionResult<Utilizador> CheckUtilizador(string email, string password)
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            Utilizador user = connection.Query<Utilizador>("SELECT * FROM Utilizadores WHERE UserMail = @UserMail AND UserPwd = @UserPwd", new { UserMail = email, UserPwd = password }).FirstOrDefault();

            if (user != null)
                return Ok(user.IsAdmin.ToString());
            else
                return NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="utilizador"></param>
        /// <returns></returns>
        [HttpPut, Route("PutUtilizador")]
        public IActionResult PutUtilizador(string UserID, Utilizador utilizador)
        {
            if (UserID != utilizador.UserID)
            {
                return BadRequest();
            }

            if (!UtilizadorExistsID(UserID))
            {
                return NotFound();
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            //
            Utilizador result = connection.Query<Utilizador>("SELECT * FROM Utilizadores WHERE UserID != @UserID AND UserMail = @UserMail", new { UserID, utilizador.UserMail }).FirstOrDefault();

            if (result != null)
                return Conflict("Conflito de valores. Email ja esta atribuido.");

            //
            try
            {
                connection.Query("UPDATE Utilizadores SET UserName = @UserName, UserMail = @UserMail, UserPwd = @UserPwd, IsAdmin = @IsAdmin WHERE UserID LIKE @UserID", new { utilizador.UserName, utilizador.UserMail, utilizador.UserPwd, utilizador.IsAdmin, utilizador.UserID });
                return Ok("Ok");
            }
            catch (Exception)
            {
                return Conflict("Conflito de valores. Update do utilizador falhou.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="utilizador"></param>
        /// <returns></returns>
        [HttpPost, Route("PostUtilizador")]
        public ActionResult<Utilizador> PostUtilizador(Utilizador utilizador)
        {
            if (UtilizadorExistsID(utilizador.UserID))
            {
                return Conflict("Conflito de valores. UserID já existe");
            }

            if (UtilizadorExistsEmail(utilizador.UserMail))
            {
                return Conflict("Conflito de valores. UserMail já existe");
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();
            try
            {
                connection.Query("INSERT INTO Utilizadores(UserID, UserName, UserMail, UserPwd, IsAdmin) VALUES(@UserID, @UserName, @UserMail, @UserPwd, @IsAdmin)",
                    new { utilizador.UserID, utilizador.UserName, utilizador.UserMail, utilizador.UserPwd, utilizador.IsAdmin });

                return Ok("Ok");
            }
            catch (Exception)
            {
                return Conflict("Conflito de valores. Insert do utilizador falhou.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteUtilizador")]
        public ActionResult<Utilizador> DeleteUtilizador(string UserID)
        {
            if (!UtilizadorExistsID(UserID))
            {
                return NotFound();
            }

            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            try
            {
                connection.Query("DELETE FROM Utilizadores WHERE UserID LIKE @UserID", new { UserID });
                return Ok("Ok");
            }
            catch (Exception)
            {
                return Conflict("Conflito de valores. Delete do utilizador falhou.");
            }
        }

        private bool UtilizadorExistsID(string id)
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            try
            {
                var item = connection.Query("SELECT ID FROM Utilizadores WHERE UserID LIKE @UserID", new { UserID = id }).FirstOrDefault();
                return item != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool UtilizadorExistsEmail(string email)
        {
            using IDbConnection connection = _dapperConnections.getLicencasConnection();

            try
            {
                var item = connection.Query("SELECT UserMail FROM Utilizadores WHERE UserMail LIKE @UserMail", new { UserMail = email }).FirstOrDefault();
                return item != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
