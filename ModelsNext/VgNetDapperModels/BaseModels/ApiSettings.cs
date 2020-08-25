using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("ApiSettings")]
    public class ApiSettings
    {
        [ExplicitKey]
        public string Id { get; set; }
        public string Endereco { get; set; }
        public string SOCKET_SERVER_IP { get; set; }
        public string SOCKET_SERVER_PORT { get; set; }
    }
}