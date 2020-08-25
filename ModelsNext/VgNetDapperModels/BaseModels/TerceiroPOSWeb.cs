using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("TerceiroPOSWeb")]
    public class TerceiroPOSWeb
    {
        
        public string Classe { get; set; }
        public string Terceiro { get; set; }
        public string UsrOnline { get; set; }
        public string txtBotao { get; set; }
    }
}