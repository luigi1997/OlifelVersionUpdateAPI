using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VgNetDapperDataExtended.Helpers;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using VgNetDapperModels.RSAEncryption;
using Newtonsoft.Json;

namespace VgNetDapperDataExtended
{
    [Table("AmbGuiasModeGar")]
    public class AmbGuiasModeGar : VgNetDapperModels.BaseModels.AmbGuiasModeGar
    {
        public static AmbGuiasModeGar findByNumeroGuia(string numeroGuia, string codigoVerificacao, IDbConnection connection)
        {
            return connection.QueryFirstOrDefault<AmbGuiasModeGar>(
                "SELECT * FROM AmbGuiasModeGar WHERE NumeroGuia = @numeroGuia and CodigoVerificacao = @codigoVerificacao",
                new { NumeroGuia = numeroGuia, CodigoVerificacao = codigoVerificacao });
        }
    }

}