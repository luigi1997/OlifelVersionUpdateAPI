using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("AppSettings")]
    public class AppSettings
    {
        [ExplicitKey]
        public string key { get; set; }
        public string value { get; set; }
    }
}