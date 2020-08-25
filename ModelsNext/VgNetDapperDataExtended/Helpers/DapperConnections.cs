using System.Data;
using System.Data.SqlClient;

namespace VgNetDapperDataExtended.Helpers
{
    public class DapperConnections
    {

        public static string getEmpresaFromConnection(IDbConnection connection)
        {
            SqlConnectionStringBuilder a = new SqlConnectionStringBuilder(connection.ConnectionString);
            string calatog = a.InitialCatalog;
            return calatog.Substring(calatog.Length - 3);
        }
    }
}
