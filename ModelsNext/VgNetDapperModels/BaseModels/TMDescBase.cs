using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("TMDescBase")]
    public class TMDescBase
    {
        public int EscArt { get; set; }

        public int EscTer { get; set; }

        public string Desconto { get; set; }

        public double? Valor { get; set; }

        public string obs { get; set; }
    }
}