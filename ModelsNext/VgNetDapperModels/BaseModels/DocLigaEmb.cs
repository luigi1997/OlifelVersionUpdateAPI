using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("DocLigaEmb")]
    public class DocLigaEmb : IDocLigaEmb
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
        public int LinhaID { get; set; }
        [ExplicitKey]
        public string TipoDocEmb { get; set; }
        [ExplicitKey]
        public int AnoEmb { get; set; }
        [ExplicitKey]
        public short MesEmb { get; set; }
        [ExplicitKey]
        public int NumDocEmb { get; set; }
        [ExplicitKey]
        public int NumEmb { get; set; }
        [ExplicitKey]
        public int LinhaEmbID { get; set; }

        public double? Quant { get; set; }

        public double? PesoLiquido { get; set; }

        public double? Tara { get; set; }

        public double? Volume { get; set; }

    }
}
