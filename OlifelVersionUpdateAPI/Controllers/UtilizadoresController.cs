using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlifelVersionUpdateAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlifelVersionUpdateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizadoresController : ControllerBase
    {
        private readonly ProjectContext _context;

        public UtilizadoresController(ProjectContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUtilizadores")]
        public async Task<ActionResult<IEnumerable<Utilizador>>> GetUtilizadores()
        {
            return await _context.Utilizadores.ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUtilizador")]
        public async Task<ActionResult<Utilizador>> GetUtilizador(string id)
        {
            var utilizador = await _context.Utilizadores.FindAsync(id);

            if (utilizador == null)
            {
                return NotFound();
            }

            return utilizador;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="utilizador"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CheckUtilizador")]
        public ActionResult<Utilizador> CheckUtilizador(UserData utilizador)
        {
            List<Utilizador> utilizadores = _context.Utilizadores.Where(u => u.Email == utilizador.Email && u.Password == utilizador.Password).ToList();

            if (utilizadores.Count == 0)
            {
                return NotFound();
            }

            return Ok(utilizadores[0].Admin.ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="utilizador"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("PutUtilizador")]
        public async Task<IActionResult> PutUtilizador(string id, Utilizador utilizador)
        {
            if (id != utilizador.Id)
            {
                return BadRequest();
            }

            List<Utilizador> utilizadores = _context.Utilizadores.Where(u => u.Email == utilizador.Email).ToList();

            if (utilizadores.Count > 0)
            {
                return BadRequest(); //email ja existe
            }

            utilizador.Data_ultima_alteracao = DateTime.Now;

            _context.Entry(utilizador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilizadorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="utilizador"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostUtilizador")]
        public async Task<ActionResult<Utilizador>> PostUtilizador(Utilizador utilizador)
        {
            utilizador.Data_criacao = DateTime.Now;
            utilizador.Data_ultima_alteracao = DateTime.Now;

            List<Utilizador> utilizadores = _context.Utilizadores.Where(u => u.Email == utilizador.Email).ToList();

            if(utilizadores.Count > 0)
            {
                return BadRequest(); //email ja existe
            }

            _context.Utilizadores.Add(utilizador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilizador", new { id = utilizador.Id }, utilizador);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteUtilizador")]
        public async Task<ActionResult<Utilizador>> DeleteUtilizador(string id)
        {

            List<Utilizador> admins = _context.Utilizadores.Where(u => u.Admin == true).ToList();

            if(admins.Count >= 2)
            {
                //ok
            } else
            {
                if(admins[0].Id == id)
                {
                    return BadRequest(); //nao pode apagar o ultimo admin
                }
            }

            var utilizador = await _context.Utilizadores.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }

            _context.Utilizadores.Remove(utilizador);
            await _context.SaveChangesAsync();

            return utilizador;
        }

        private bool UtilizadorExists(string id)
        {
            return _context.Utilizadores.Any(e => e.Id == id);
        }

        public class UserData
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
