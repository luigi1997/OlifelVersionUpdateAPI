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
    public class VersoesController : ControllerBase
    {
        private readonly ProjectContext _context;

        public VersoesController(ProjectContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetVersoes")]
        public async Task<ActionResult<IEnumerable<Versao>>> GetVersoes()
        {
            return await _context.Versoes.ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetVersao")]
        public async Task<ActionResult<Versao>> GetVersao(string id)
        {
            var versao = await _context.Versoes.FindAsync(id);

            if (versao == null)
            {
                return NotFound();
            }

            return versao;
        }

        [HttpPut]
        [Route("PutVersao")]
        public async Task<IActionResult> PutVersao(string id, Versao versao)
        {
            if (id != versao.Id)
            {
                return BadRequest();
            }

            _context.Entry(versao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VersaoExists(id))
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
        /// <param name="versao"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostVersao")]
        public async Task<ActionResult<Versao>> PostVersao(Versao versao)
        {
            versao.Distribuida = true;

            List<Versao> versoes = _context.Versoes.Where(v => v.Id == versao.Id).ToList();
            if (versoes.Count > 0)
            {
                return Ok("Versao_ja_existe_na_BD");
            }

            try
            {
                _context.Versoes.Add(versao);
                await _context.SaveChangesAsync();
            }
            catch (Exception e) { Console.WriteLine(e); }
            return CreatedAtAction("GetVersao", new { id = versao.Id }, versao);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteVersao")]
        public async Task<ActionResult<Versao>> DeleteVersao(string id)
        {
            var versao = await _context.Versoes.FindAsync(id);

            if (versao == null)
            {
                return NotFound();
            }

            List<VersaoCliente> versoesclientes = _context.VersoesClientes.Where(vc => vc.Versao_ID.ToString() == id).ToList();

            if (versoesclientes.Count > 0)
            {
                return NotFound(); //versao tem clientes ligados a ele
            }

            _context.Versoes.Remove(versao);
            await _context.SaveChangesAsync();

            return versao;
        }

        private bool VersaoExists(string id)
        {
            return _context.Versoes.Any(e => e.Id == id);
        }
    }
}
