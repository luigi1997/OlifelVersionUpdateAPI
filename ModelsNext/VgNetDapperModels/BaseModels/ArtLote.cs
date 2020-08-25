using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("ArtLotes")]
    public class ArtLote
    {
        public string Artigo { get; set; }

        public string Lote { get; set; }

        public DateTime? DataFabrico { get; set; }

        public DateTime? DataValidade { get; set; }

        public string DocOrigem { get; set; }

        public string Localizacao { get; set; }

        public string obs { get; set; }

        public int recno { get; set; }

        public double? StkQtd { get; set; }

        public double? StkTara { get; set; }

        public double? AcumPCMQtd { get; set; }

        public double? AcumPCMVal { get; set; }

        public double? AcumEntQtd { get; set; }

        public double? AcumEntVal { get; set; }

        public double? AcumSaiQtd { get; set; }

        public double? AcumSaiVal { get; set; }

        public double? AcumEntCusto { get; set; }

        public double? AcumSaiCusto { get; set; }

        public double? AcumPCMCusto { get; set; }

        public double? PCU { get; set; }

        public double? PCM { get; set; }

        public double? CustoUlt { get; set; }

        public double? CustoMed { get; set; }

        public double? AcumEntTara { get; set; }

        public double? AcumSaiTara { get; set; }
    }

}