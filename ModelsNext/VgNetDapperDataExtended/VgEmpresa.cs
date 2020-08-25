using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using VgNetDapperDataExtended.Helpers;

namespace VgNetDapperDataExtended
{
    [Table("Empresas")]
    public class VgEmpresa : VgNetDapperModels.BaseModels.VgEmpresa
    {
        public static VgEmpresa findByKey(string empresa, IDbConnection connection)
        {
            return connection.QueryFirstOrDefault<VgEmpresa>(
                "SELECT * FROM Empresas where Empresa = @Empresa",
                new { Empresa = empresa });
        }
        public static VgEmpresa getEmpresaFromConnection(IDbConnection connection)
        {
            return connection.QueryFirstOrDefault<VgEmpresa>(
                "SELECT * FROM Empresas where Empresa = @Empresa",
                new { Empresa = DapperConnections.getEmpresaFromConnection(connection) });
        }
    }
}