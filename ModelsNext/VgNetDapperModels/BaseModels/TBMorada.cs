using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("TBMoradas")]
    public class TBMorada
    {
        [Key]
        public int Morada { get; set; }

        public string Descritivo { get; set; }

        public string obs { get; set; }

    }
}