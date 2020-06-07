using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OlifelVersionUpdateAPI.Helpers;
using OlifelVersionUpdateAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
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
        private DapperConnections _dapperConnections;

        public VersoesClientesController(ProjectContext context, IOptions<ConnectionsStrings> connectionConfig)
        {
            _context = context;
            _dapperConnections = new DapperConnections(connectionConfig: connectionConfig);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_c"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetVersaoMaisRecenteDoCliente")]
        public async Task<ActionResult<Versao>> GetVersaoMaisRecenteDoClienteAsync(string id_c)
        {
            List<VersaoCliente> versoesClientes = _context.VersoesClientes.Where(vc => vc.Cliente_ID == id_c).ToList();

            Versao versao_mais_recente = await _context.Versoes.FindAsync(versoesClientes[versoesClientes.Count - 1].Versao_ID);

            return versao_mais_recente;
        }

        public class VersaoClienteNomes : VersaoCliente
        {
            public string Cliente_nome { get; set; }
            public string Versao_nome { get; set; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetVersaoMaisRecenteParaCadaCliente")]
        public async Task<ActionResult<IEnumerable<VersaoClienteNomes>>> GetVersaoMaisRecenteParaCadaCliente()
        {

            using (IDbConnection connection = _dapperConnections.getLicencasConnection())
            {
                List<Cliente> clientes = connection.Query<Cliente>("SELECT * FROM Terceiros").ToList();

                //List<Cliente> clientes = _context.Clientes.ToListAsync().Result;

                List<VersaoClienteNomes> listaVersoesClientes = new List<VersaoClienteNomes>();

                foreach (var cliente in clientes)
                {
                    VersaoCliente versaoCliente = _context.VersoesClientes.Where(vc => vc.Cliente_ID == cliente.Id.ToString()).FirstOrDefault();
                    if (versaoCliente != null)
                    {
                        VersaoClienteNomes versaoClienteNomes = new VersaoClienteNomes { Cliente_ID = versaoCliente.Cliente_ID, Versao_ID = versaoCliente.Versao_ID, Data_distribuicao = versaoCliente.Data_distribuicao };

                        versaoClienteNomes.Cliente_nome = connection.Query<string>("SELECT Nome FROM Terceiros WHERE ID = @Id", new { Id = versaoCliente.Cliente_ID }).FirstOrDefault();
                        versaoClienteNomes.Versao_nome = _context.Versoes.Where(c => c.Id == versaoCliente.Versao_ID).FirstOrDefault().Tag_name;

                        listaVersoesClientes.Add(versaoClienteNomes);
                    }
                }
                return listaVersoesClientes;
            }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="versaoClienteIDS"></param>
        /// <param name="hora"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostDistribuirVersaoCliente")]
        public async Task<ActionResult<VersaoClienteIDS>> PostDistribuirVersaoCliente(VersaoClienteIDS versaoClienteIDS, string hora)
        {
            //verifica se a hora é valida
            if (hora != "" && hora != null)
                if (hora.Split(":").Length != 2)
                    return BadRequest();
                else if (hora.Split(":")[0].Length == 0 || hora.Split(":")[1].Length == 0)
                    return BadRequest();
                else if (!int.TryParse(hora.Split(":")[0], out int n) || !int.TryParse(hora.Split(":")[1], out int m))
                    return BadRequest();
            else if(Int16.Parse(hora.Split(":")[0]) < 0 || Int16.Parse(hora.Split(":")[0]) > 23 || Int16.Parse(hora.Split(":")[1]) < 0 || Int16.Parse(hora.Split(":")[1]) > 59)
                    return BadRequest();

            return Ok("x");

            if (!Regex.IsMatch(versaoClienteIDS.Cliente_ID.ToLower(), @"(?im)^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$"))
                return BadRequest();

            Cliente cliente = null;
            using (IDbConnection connection = _dapperConnections.getLicencasConnection())
            {
                cliente = connection.Query<Cliente>("SELECT * FROM Terceiros WHERE ID = @Id", new { Id = Guid.Parse(versaoClienteIDS.Cliente_ID) }).FirstOrDefault();
            }

            if (cliente == null)
            {
                return NotFound();
            }

            var versao = await _context.Versoes.FindAsync(versaoClienteIDS.Versao_ID);
            if (versao == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos.FindAsync(cliente.Grupo);
            if (grupo == null)
            {
                return NotFound();
            }

            DateTime dateTime = DateTime.Now;

            if (hora == "" || hora == null)
            {
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
                if (dateTime.Hour < Int32.Parse(hora.Split(":")[0]) || (dateTime.Hour == Int32.Parse(hora.Split(":")[0]) && dateTime.Minute < Int32.Parse(hora.Split(":")[1])))
                {
                    dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, Int32.Parse(hora.Split(":")[0]), Int32.Parse(hora.Split(":")[1]), 0);
                }
                else
                {
                    dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day + 1, Int32.Parse(hora.Split(":")[0]), Int32.Parse(hora.Split(":")[1]), 0);
                }
            }

            VersaoCliente versaoCliente = new VersaoCliente { Cliente_ID = versaoClienteIDS.Cliente_ID, Versao_ID = versaoClienteIDS.Versao_ID, Data_distribuicao = dateTime };

            _context.VersoesClientes.Add(versaoCliente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                _context.Entry(versaoCliente).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
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
