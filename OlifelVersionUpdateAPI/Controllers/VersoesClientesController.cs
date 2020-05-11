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
    public class VersoesClientesController : ControllerBase
    {
        public class VersaoClienteIDS
        {
            public string Cliente_ID { get; set; }
            public string Versao_ID { get; set; }
        }
        private readonly ProjectContext _context;

        public VersoesClientesController(ProjectContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetVersoesClientes")]
        public async Task<ActionResult<IEnumerable<VersaoCliente>>> GetVersoesClientes()
        {
            return await _context.VersoesClientes.ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_v"></param>
        /// <param name="id_c"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetVersaoCliente")]
        public async Task<ActionResult<VersaoCliente>> GetVersaoCliente(string id_v, string id_c)
        {
            var versaoCliente = await _context.VersoesClientes.FindAsync(id_c, id_v);

            if (versaoCliente == null)
            {
                return NotFound();
            }

            return versaoCliente;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_c"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetVersoesDoCliente")]
        public ActionResult<IEnumerable<VersaoCliente>> GetVersoesDoCliente(string id_c)
        {
            List<VersaoCliente> versoesClientes = _context.VersoesClientes.Where(vc => vc.Cliente_ID == id_c).ToList();

            return versoesClientes;
        }

        [HttpGet]
        [Route("GetVersaoMaisRecenteDoCliente")]
        public async Task<ActionResult<Versao>> GetVersaoMaisRecenteDoClienteAsync(string id_c)
        {
            List<VersaoCliente> versoesClientes = _context.VersoesClientes.Where(vc => vc.Cliente_ID == id_c).ToList();

            Versao versao_mais_recente = null;

            foreach (var objeto in versoesClientes)
            {

                var versao = await _context.Versoes.FindAsync(objeto.Versao_ID);

                if (versao_mais_recente == null || versao.Published_at > versao_mais_recente.Published_at)
                {
                    versao_mais_recente = versao;
                }
            }

            return versao_mais_recente;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_v"></param>
        /// <param name="id_c"></param>
        /// <param name="versaoCliente"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("PutVersaoCliente")]
        public async Task<IActionResult> PutVersaoCliente(string id_v, string id_c, VersaoCliente versaoCliente)
        {
            if (id_v != versaoCliente.Versao_ID && id_c != versaoCliente.Cliente_ID)
            {
                return BadRequest();
            }

            _context.Entry(versaoCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VersaoClienteExists(id_v, id_c))
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
        /// <param name="versaoCliente"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostVersaoCliente")]
        public async Task<ActionResult<VersaoCliente>> PostVersaoCliente(VersaoCliente versaoCliente)
        {
            _context.VersoesClientes.Add(versaoCliente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VersaoClienteExists(versaoCliente.Versao_ID, versaoCliente.Cliente_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVersaoCliente", new { id_v = versaoCliente.Versao_ID, id_c = versaoCliente.Cliente_ID }, versaoCliente);
        }

        [HttpPost]
        [Route("PostDistribuirVersaoCliente")]
        public async Task<ActionResult<VersaoClienteIDS>> PostDistribuirVersaoCliente(VersaoClienteIDS versaoClienteIDS, string hora)
        //public async Task PostDistribuirVersaoClienteAsync(VersaoClienteIDS versaoClienteIDS, string hora)
        {
            var cliente = await _context.Clientes.FindAsync(versaoClienteIDS.Cliente_ID);
            if (cliente == null)
            {
                return NotFound();
            }
            else
            {
                //Console.WriteLine(cliente.Nome);
            }

            var versao = await _context.Versoes.FindAsync(versaoClienteIDS.Versao_ID);
            if (versao == null)
            {
                return NotFound();
            }
            else
            {
                //Console.WriteLine(versao.Tag_name);
            }

            var grupo = await _context.Grupos.FindAsync(cliente.Grupo);
            if (grupo == null)
            {
                return NotFound();
            }
            else
            {
                //Console.WriteLine(grupo.Nome);
                //Console.WriteLine(grupo.Hora_distribuicao);
            }

            DateTime dateTime = DateTime.Now;

            if (hora == "" || hora == null)
            {
                Console.WriteLine("nao recebeu hora: " + grupo.Hora_distribuicao);
                if (dateTime.Hour < Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]) || (dateTime.Hour == Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]) && dateTime.Minute < Int32.Parse(grupo.Hora_distribuicao.Split(":")[1])))
                {
                    dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]), Int32.Parse(grupo.Hora_distribuicao.Split(":")[1]), 0);
                }
                else
                {
                    dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day + 1, Int32.Parse(grupo.Hora_distribuicao.Split(":")[0]), Int32.Parse(grupo.Hora_distribuicao.Split(":")[1]), 0);
                }
            }
            else
            {
                Console.WriteLine("hora recebida: " + hora);
                if (dateTime.Hour < Int32.Parse(hora.Split(":")[0]) || (dateTime.Hour == Int32.Parse(hora.Split(":")[0]) && dateTime.Minute < Int32.Parse(hora.Split(":")[1])))
                {
                    dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, Int32.Parse(hora.Split(":")[0]), Int32.Parse(hora.Split(":")[1]), 0);
                }
                else
                {
                    dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day + 1, Int32.Parse(hora.Split(":")[0]), Int32.Parse(hora.Split(":")[1]), 0);
                }
            }
            Console.WriteLine("data de distribuicao: " + dateTime);

            VersaoCliente versaoCliente = new VersaoCliente { Cliente_ID = versaoClienteIDS.Cliente_ID, Versao_ID = versaoClienteIDS.Versao_ID, Data_distribuicao = dateTime };
            Console.WriteLine("\n" + versaoCliente.Cliente_ID + "\n" + versaoCliente.Versao_ID + "\n" + versaoCliente.Data_distribuicao);

            
            _context.VersoesClientes.Add(versaoCliente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VersaoClienteExists(versaoCliente.Versao_ID, versaoCliente.Cliente_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVersaoCliente", new { id_v = versaoCliente.Versao_ID, id_c = versaoCliente.Cliente_ID }, versaoCliente);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_v"></param>
        /// <param name="id_c"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteVersaoCliente")]
        public async Task<ActionResult<VersaoCliente>> DeleteVersaoCliente(string id_v, string id_c)
        {
            var versaoCliente = await _context.VersoesClientes.FindAsync(id_v, id_c);
            if (versaoCliente == null)
            {
                return NotFound();
            }

            _context.VersoesClientes.Remove(versaoCliente);
            await _context.SaveChangesAsync();

            return versaoCliente;
        }

        private bool VersaoClienteExists(string id_v, string id_c)
        {
            return _context.VersoesClientes.Any(vc => vc.Versao_ID == id_v && vc.Cliente_ID == id_c);
        }
    }
}
