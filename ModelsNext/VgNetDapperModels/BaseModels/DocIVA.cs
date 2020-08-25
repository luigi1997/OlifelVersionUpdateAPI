using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("DocIva")]
    public class DocIVA : IDocIVA
    {
        [ExplicitKey]
        public string TipoDoc { get; set; }
        [ExplicitKey]
        public int Ano { get; set; }
        [ExplicitKey]
        public short Mes { get; set; }
        [ExplicitKey]
        public int NumDoc { get; set; }
        [ExplicitKey]
        public int CodIVA { get; set; }

        public double? TaxIVA { get; set; }

        public double? ValSuj { get; set; }

        public double? ValIVA { get; set; }

        public double? TotalMP { get; set; }

        public double? TotalPA { get; set; }

        public double? TotalSR { get; set; }

        public double? TotalOT { get; set; }

    }

}