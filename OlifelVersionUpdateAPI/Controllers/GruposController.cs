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
    public class GruposController : ControllerBase
    {
        private readonly ProjectContext _context;

        public GruposController(ProjectContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetGrupos")]
        public async Task<ActionResult<IEnumerable<Grupo>>> GetGrupos()
        {
            return await _context.Grupos.ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetGrupo")]
        public async Task<ActionResult<Grupo>> GetGrupo(string id)
        {
            var grupo = await _context.Grupos.FindAsync(Int32.Parse(id));

            if (grupo == null)
            {
                return NotFound();
            }

            return grupo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="grupo"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("PutGrupo")]
        public async Task<IActionResult> PutGrupo(string id, Grupo grupo)
        {
            grupo.Data_ultima_alteracao = DateTime.Now;

            if (id != grupo.Id.ToString())
            {
                return BadRequest();
            }

            _context.Entry(grupo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoExists(id))
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
        /// <param name="grupo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostGrupo")]
        public async Task<ActionResult<Grupo>> PostGrupo(Grupo grupo)
        {
            grupo.Data_criacao = DateTime.Now;
            grupo.Data_ultima_alteracao = DateTime.Now;

            _context.Grupos.Add(grupo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrupo", new { id = grupo.Id }, grupo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteGrupo")]
        public async Task<ActionResult<Grupo>> DeleteGrupo(string id)
        {
            var grupo = await _context.Grupos.FindAsync(Int32.Parse(id));

            if (grupo == null)
            {
                return NotFound();
            }

            List<Cliente> clientes = _context.Clientes.Where(c => c.Grupo.ToString() == id).ToList();

            if (clientes.Count > 0)
            {
                return NotFound(); //grupo tem clientes ligados a ele
            }

            _context.Grupos.Remove(grupo);
            await _context.SaveChangesAsync();

            return grupo;
        }

        private bool GrupoExists(string id)
        {
            return _context.Grupos.Any(g => g.Id.ToString() == id);
        }
    }
}
