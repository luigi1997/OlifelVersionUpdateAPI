using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("TMTabPrcTamCor")]
    public class VgTMTabPrcTamCor
    {
        public int TabPrecos { get; set; }

        public DateTime DatPrecos { get; set; }

        public string Artigo { get; set; }

        public int Tam { get; set; }

        public int Cor { get; set; }

        public double? PrecoDoc { get; set; }

    }
}