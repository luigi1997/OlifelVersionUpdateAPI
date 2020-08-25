using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("TBIsentoIVA")]
    public class TBIsentoIVA
    {
        public int IsentoIVA { get; set; }

        public string Descritivo { get; set; }

        public string Codigo { get; set; }

    }

}