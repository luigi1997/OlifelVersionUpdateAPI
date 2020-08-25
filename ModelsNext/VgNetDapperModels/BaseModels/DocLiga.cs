using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("DocLiga")]
    public class DocLiga : IDocLiga
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
        public string TipoDocBase { get; set; }
        [ExplicitKey]
        public int AnoBase { get; set; }
        [ExplicitKey]
        public short MesBase { get; set; }
        [ExplicitKey]
        public int NumDocBase { get; set; }
        [ExplicitKey]
        public int LinhaBaseID { get; set; }
        public double? QtdBase { get; set; }

        public double? QtdLiga { get; set; }

        public string UnMedBase { get; set; }

        public string UnMedLiga { get; set; }

        public double? ConvBase { get; set; }

        public double? ConvLiga { get; set; }

        public bool? FActBase { get; set; }

        public bool? FAnulaDoc { get; set; }

        public bool? FAnulaBase { get; set; }

        public string ChaveDocCab { get; set; }

        public string ChaveDocLin { get; set; }

        public string ChaveDocBase { get; set; }

        public string ChaveLinBase { get; set; }

        public bool? ConcluiLiga { get; set; }

        public int? QtdRegNum { get; set; }

        public string QtdRegOp { get; set; }

        public double? QtdExc { get; set; }

        public bool? TemTamCor { get; set; }
    }
}