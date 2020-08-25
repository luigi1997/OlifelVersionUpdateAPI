using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.BaseModels
{
    [Table("ArtArmLocal")]
    public class ArtArmLocal
    {
        public string Armazem { get; set; }
        public string Local { get; set; }
        public string Artigo { get; set; }
        public double? StkQtd { get; set; }
        public DateTime? LocalData { get; set; }
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

    }

}
