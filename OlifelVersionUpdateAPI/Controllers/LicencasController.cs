using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OlifelVersionUpdateAPI.Helpers;
using OlifelVersionUpdateAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VgNetDapperDataExtended;

namespace OlifelVersionUpdateAPI.Controllers
{
    [Route("api/Licencas")]
    [ApiController]
    public class LicencasController : ControllerBase
    {
        private DapperConnections _dapperConnections;
        private readonly ILogger<LicencasController> _logger;

        /// <summary>
        /// Metodo Construtor de controller que recebe um connectionConfig para fazer a ligação à bd
        /// </summary>
        /// <param name="connectionConfig"></param>
        /// <param name="logger"></param>
        public LicencasController(IOptions<ConnectionsStrings> connectionConfig, ILogger<LicencasController> logger)
        {
            _dapperConnections = new DapperConnections(connectionConfig);
            _logger = logger;
        }

        /// <summary>
        /// Verificar se tem licenças para importar
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("TemLicencasNovas/{guid}")]
        public IActionResult TemLicencasNovas(string guid)
        {
            using (IDbConnection connection = _dapperConnections.getLicencasConnection())
            {
                try
                {
                    bool temLicencaNova = connection.ExecuteScalar<bool>(@"select count(1) FROM Licencas l
                                                                            INNER JOIN Terceiros t on l.ID = t.ID
                                                                            WHERE t.ID = @ID AND l.isNew = 1 ", new { ID = guid });

                    return Ok(temLicencaNova);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro Verificar se tem licenças novas");
                    return UnprocessableEntity();
                }
            }
        }

        /// <summary>
        /// Marca licenca como não sendo nova
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("LicencaImportada/{licId}")]
        public IActionResult ImportaLicenca(int licId)
        {
            using (IDbConnection connection = _dapperConnections.getLicencasConnection())
            {
                try
                {
                    connection.Execute(
                                   $@"
                                    UPDATE Licencas SET 
                                           [isNew] = 0
                                    WHERE Lic_Id = @Lic_Id",
                                   new
                                   {
                                       Lic_Id = licId
                                   });

                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro marcar licença importada");
                    return UnprocessableEntity();
                }
            }
        }

        /// <summary>
        /// Obtem licenças novas atraves do NIF da empresa
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("ObterLicencas/{guid}")]
        public IActionResult ObterLicencas(string guid)
        {
            using (IDbConnection connection = _dapperConnections.getLicencasConnection())
            {
                try
                {
                    List<Licenca> listaLicencas = connection.Query<Licenca>(@"select l.Lic_Id,l.FileBin FROM Licencas l
                                                                            INNER JOIN Terceiros t on l.ID = t.ID
                                                                            WHERE t.ID = @ID AND l.isNew = 1
                                                                            order by l.dtupdate desc ", new { ID = guid }).ToList();

                    return Ok(listaLicencas);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro importacao de licencas");
                    return UnprocessableEntity();
                }
            }
        }

        /// <summary>
        /// Importa licenças
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("ImportaLicencas/{guid}")]
        public IActionResult ImportaLicencas(string guid)
        {
            using (IDbConnection connection = _dapperConnections.getLicencasConnection())
            {
                try
                {
                    List<Licenca> listaLicencas = connection.Query<Licenca>(@"select l.Lic_Id,l.FileBin FROM Licencas l
                                                                            INNER JOIN Terceiros t on l.ID = t.ID
                                                                            WHERE t.ID = @ID AND l.isNew = 1
                                                                            order by l.dtupdate desc ", new { ID = guid }).ToList();

                    //string strData = Encoding.Default.GetString(byteData);
                    bool result = true;
                    using (IDbConnection connectionVGTab = _dapperConnections.getVgTabConnection())
                    {
                        connectionVGTab.Open();
                        using (var transaction = connectionVGTab.BeginTransaction())
                        {
                            foreach (Licenca item in listaLicencas)
                            {
                                result &= VgLicenca.insertLicenses(item.FileBin, connectionVGTab, transaction);
                            }
                            transaction.Commit();
                        }
                    }

                    if (result)
                    {
                        foreach (Licenca item2upd in listaLicencas)
                        {
                            connection.Execute(
                                    $@"
                                    UPDATE Licencas SET 
                                           [isNew] = 0
                                    WHERE Lic_Id = @Lic_Id",
                                    new
                                    {
                                        item2upd.Lic_Id
                                    });
                        }
                    }

                    return Ok(result);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro importacao de licencas");
                    return UnprocessableEntity();
                }
            }
        }
    }
}