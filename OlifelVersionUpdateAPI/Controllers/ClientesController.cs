using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlifelVersionUpdateAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlifelVersionUpdateAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ProjectContext _context;

        public ClientesController(ProjectContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Devolve todos os Clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetClientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCliente")]
        public async Task<ActionResult<Cliente>> GetCliente(string id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cliente"></param>
        /// <param name="hora"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("PutCliente")]
        public async Task<IActionResult> PutCliente(string id, Cliente cliente, string hora)
        {
            if (hora == "" || hora == null)
            {
                cliente.Data_ultima_alteracao = DateTime.Now;

                if (id != cliente.Id)
                {
                    return BadRequest();
                }

                List<Grupo> grupos = _context.Grupos.Where(g => g.Id == cliente.Grupo).ToList();

                if (grupos.Count == 0)
                {
                    return NotFound(); //grupo nao existe
                }

                List<Versao> versoes = _context.Versoes.Where(v => v.Id == cliente.Versao_atual).ToList();

                if (versoes.Count == 0)
                {
                    return NotFound(); //versao nao existe
                }

                _context.Entry(cliente).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                DateTime dateTime = DateTime.Now;
                DateTime horaData = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[0]), Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[1]), 0);

                //hora de distribuicao
                if (grupos.Count > 0)
                {

                    if (dateTime.Hour < Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[0]) || (dateTime.Hour == Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[0]) && dateTime.Minute < Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[1])))
                    {
                        horaData = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[0]), Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[1]), 0);
                    }
                    else
                    {
                        horaData = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day + 1, Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[0]), Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[1]), 0);
                    }
                }


                List<VersaoCliente> versoesClientes = _context.VersoesClientes.Where(vc => vc.Cliente_ID == id && vc.Versao_ID == cliente.Versao_atual).ToList();
                if(versoesClientes.Count > 0)
                {
                    return Ok("Versao_ja_foi_distribuida_para_este_cliente");
                }

                try
                {
                    //adiciona versao e cliente à tabela VersaoCliente onde é guarda todas as versoes que cada cliente tem acesso
                    VersaoCliente versaoCliente = new VersaoCliente { Cliente_ID = cliente.Id, Versao_ID = cliente.Versao_atual, Data_distribuicao = horaData };
                    _context.VersoesClientes.Add(versaoCliente);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                }

                return NoContent();
            }
            else
            {

                cliente.Data_ultima_alteracao = DateTime.Now;

                if (id != cliente.Id)
                {
                    return BadRequest();
                }

                List<Grupo> grupos = _context.Grupos.Where(g => g.Id == cliente.Grupo).ToList();

                if (grupos.Count == 0)
                {
                    return NotFound(); //grupo nao existe
                }

                List<Versao> versoes = _context.Versoes.Where(v => v.Id == cliente.Versao_atual).ToList();

                if (versoes.Count == 0)
                {
                    return NotFound(); //versao nao existe
                }

                _context.Entry(cliente).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                DateTime dateTime = DateTime.Now;
                DateTime horaData = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, Int32.Parse(hora.Split(":")[0]), Int32.Parse(hora.Split(":")[1]), 0);

                //hora de distribuicao
                if (grupos.Count > 0)
                {
                    if (dateTime.Hour < Int32.Parse(hora.Split(":")[0]) || (dateTime.Hour == Int32.Parse(hora.Split(":")[0]) && dateTime.Minute < Int32.Parse(hora.Split(":")[1])))
                    {
                        horaData = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, Int32.Parse(hora.Split(":")[0]), Int32.Parse(hora.Split(":")[1]), 0);
                    }
                    else
                    {
                        horaData = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day + 1, Int32.Parse(hora.Split(":")[0]), Int32.Parse(hora.Split(":")[1]), 0);
                    }
                }

                try
                {
                    //adiciona versao e cliente à tabela VersaoCliente onde é guarda todas as versoes que cada cliente tem acesso
                    VersaoCliente versaoCliente = new VersaoCliente { Cliente_ID = cliente.Id, Versao_ID = cliente.Versao_atual, Data_distribuicao = horaData };
                    _context.VersoesClientes.Add(versaoCliente);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return NotFound(); //ligacao ja existe?
                }

                return NoContent();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostCliente")]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            cliente.Data_criacao = DateTime.Now;
            cliente.Data_ultima_alteracao = DateTime.Now;

            List<Grupo> grupos = _context.Grupos.Where(g => g.Id == cliente.Grupo).ToList();

            if (grupos.Count == 0)
            {
                return NotFound(); //grupo nao existe
            }

            List<Versao> versoes = _context.Versoes.Where(v => v.Id == cliente.Versao_atual).ToList();

            if (versoes.Count == 0)
            {
                return NotFound(); //versao nao existe
            }

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            DateTime dateTime = DateTime.Now;
            DateTime horaData = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[0]), Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[1]), 0);

            //hora de distribuicao
            if (grupos.Count > 0)
            {

                if (dateTime.Hour < Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[0]) || (dateTime.Hour == Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[0]) && dateTime.Minute < Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[1])))
                {
                    horaData = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[0]), Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[1]), 0);
                }
                else
                {
                    horaData = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day + 1, Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[0]), Int32.Parse(grupos[0].Hora_distribuicao.Split(":")[1]), 0);
                }
            }

            try
            {
                //adiciona versao e cliente à tabela VersaoCliente onde é guarda todas as versoes que cada cliente tem acesso
                VersaoCliente versaoCliente = new VersaoCliente { Cliente_ID = cliente.Id, Versao_ID = cliente.Versao_atual, Data_distribuicao = horaData };
                _context.VersoesClientes.Add(versaoCliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return NotFound(); //ligacao ja existe?
            }

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteCliente")]
        public async Task<ActionResult<Cliente>> DeleteCliente(string id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        private bool ClienteExists(string id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
