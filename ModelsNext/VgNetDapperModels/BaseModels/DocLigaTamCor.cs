using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("DocLigaTamCor")]
    public class DocLigaTamCor : IDocLigaTamCor

    {
        public string TipoDoc { get; set; }

        public int Ano { get; set; }

        public short Mes { get; set; }

        public int NumDoc { get; set; }
        [ExplicitKey]
        public int LinhaID { get; set; }
        [ExplicitKey]
        public string Local { get; set; }
        [ExplicitKey]
        public string Lote { get; set; }
        [ExplicitKey]
        public int Tam { get; set; }
        [ExplicitKey]
        public int Cor { get; set; }

        public string TipoDocBase { get; set; }

        public int AnoBase { get; set; }

        public short MesBase { get; set; }

        public int NumDocBase { get; set; }
        [ExplicitKey]
        public int LinhaBaseID { get; set; }
        [ExplicitKey]
        public string LocalBase { get; set; }
        [ExplicitKey]
        public string LoteBase { get; set; }
        [ExplicitKey]
        public int TamBase { get; set; }
        [ExplicitKey]
        public int CorBase { get; set; }

        public double? QtdBase { get; set; }

        public double? QtdLiga { get; set; }

        public bool? FAnulaDoc { get; set; }

        public bool? FAnulaBase { get; set; }

        public string ChaveDocCab { get; set; }

        public string ChaveTamCor { get; set; }

        public string ChaveDocBase { get; set; }

        public string ChaveLTCBase { get; set; }

        public int? QtdRegNum { get; set; }

        public string QtdRegOp { get; set; }

        public double? QtdExc { get; set; }

    }

}