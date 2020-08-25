using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("ArtArmazem")]
    public class ArtArmazem
    {
        public string Armazem { get; set; }

        public string Artigo { get; set; }

        public string Localizacao { get; set; }

        public double? StkQtd { get; set; }

        public double? StkMin { get; set; }

        public double? StkMax { get; set; }

        public double? StkEnc { get; set; }

        public DateTime? UltEntDat { get; set; }

        public double? UltEntQtd { get; set; }

        public DateTime? UltSaiDat { get; set; }

        public double? UltSaiQtd { get; set; }

        public double? AcumEntQtd { get; set; }

        public double? AcumEntVal { get; set; }

        public double? AcumSaiQtd { get; set; }

        public double? AcumSaiVal { get; set; }

        public double? SaiEnc { get; set; }

        public double? SaiRes { get; set; }

        public double? SaiDev { get; set; }

        public double? EntEnc { get; set; }

        public double? EntRes { get; set; }

        public double? EntDev { get; set; }

        public double? StkTara { get; set; }

        public double? AcumEntTara { get; set; }

        public double? AcumSaiTara { get; set; }

    }

}