using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("TBTabCodIVA")]
    public class TBTabCodIVA
    {
        public int TabIVA { get; set; }

        public int CodIVA { get; set; }

    }
}