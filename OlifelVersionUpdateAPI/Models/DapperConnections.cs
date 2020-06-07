using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using OlifelVersionUpdateAPI.Helpers;
using System.Data;

namespace OlifelVersionUpdateAPI.Models
{
    public class DapperConnections
    {
        private ConnectionsStrings _connectionString;

        public DapperConnections(IOptions<ConnectionsStrings> connectionConfig)
        {
            _connectionString = connectionConfig.Value;
        }

        //public string getTMPConnectionString()
        //{
        //    SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder(_connectionString.Default);
        //    string drive = "C";
        //    ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
        //    disk.Get();
        //    conn.InitialCatalog = "TMP" + disk["VolumeSerialNumber"].ToString();
        //    return conn.ConnectionString;
        //}
        public string getDefaultConnectionString(string empresa)
        {
            SqlConnectionStringBuilder a = new SqlConnectionStringBuilder(_connectionString.Default);
            if (empresa != null)
            {
                using (IDbConnection vgTabConnection = getVgTabConnection())
                {
                    var dbInstance = vgTabConnection.QueryFirstOrDefault<string>(
                        "SELECT DirEmpresa from Empresas where Empresa = @Empresa",
                        new { Empresa = empresa });
                    if (!string.IsNullOrEmpty(dbInstance))
                        a.DataSource = dbInstance;
                }
                a.InitialCatalog = a.InitialCatalog.Substring(0, a.InitialCatalog.Length - 3) + empresa;
            }
            return a.ToString();
        }
        public string getVgTabConnectionString()
        {
            return _connectionString.VgTab;
        }
        public SqlConnection getDefaultConnection(string empresa = null)
        {
            return new SqlConnection(getDefaultConnectionString(empresa));
        }

        public string getLicencasConnectionString()
        {
            return _connectionString.Licencas;
        }

        public SqlConnection getVgTabConnection()
        {
            return new SqlConnection(getVgTabConnectionString());
        }

        public SqlConnection getLicencasConnection()
        {
            return new SqlConnection(getLicencasConnectionString());
        }
        public string getEmpresaFromConnection()
        {
            SqlConnectionStringBuilder a = new SqlConnectionStringBuilder(_connectionString.Default);
            string calatog = a.InitialCatalog;
            return calatog.Substring(calatog.Length - 3);
        }
    }
}