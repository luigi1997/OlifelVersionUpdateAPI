using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("UserStockNotifications")]
    public class UserStockNotification
    {
        [ExplicitKey]
        public string Email { get; set; }
        [ExplicitKey]
        public string Artigo { get; set; }
        [ExplicitKey]
        public int Tam { get; set; }
        [ExplicitKey]
        public int Cor { get; set; }
        public string Classe { get; set; }
        public string Terceiro { get; set; }
    }
}