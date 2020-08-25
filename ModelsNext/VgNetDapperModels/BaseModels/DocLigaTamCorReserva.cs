using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("DocLigaTamCorReservas")]
    public class DocLigaTamCorReserva
    {
        public string TDDoc { get; set; }

        public int ADDoc { get; set; }

        public short MDDoc { get; set; }

        public int NDDoc { get; set; }

        public int LinhaDocID { get; set; }

        public string LocalDoc { get; set; }

        public string LoteDoc { get; set; }

        public int TamDocID { get; set; }

        public int CorDocID { get; set; }

        public string TDRes { get; set; }

        public int ADRes { get; set; }

        public short MDRes { get; set; }

        public int NDRes { get; set; }

        public int LinhaResID { get; set; }

        public string LocalRes { get; set; }

        public string LoteRes { get; set; }

        public int TamResID { get; set; }

        public int CorResID { get; set; }

        public double? Reservado { get; set; }

        public double? Requisitado { get; set; }

        public double? Entregue { get; set; }

        public double? Saida { get; set; }

        public bool? FAnulaDoc { get; set; }

        public bool? FAnulaRes { get; set; }

        public string ChaveDocCab { get; set; }

        public string ChaveTamCor { get; set; }

        public string ChaveResCab { get; set; }

        public string ChaveResLTC { get; set; }

        public double? AcertoRes { get; set; }

        public double? AcertoReq { get; set; }

        public double? AcertoEnt { get; set; }

        public double? AcertoSai { get; set; }
    }
}
