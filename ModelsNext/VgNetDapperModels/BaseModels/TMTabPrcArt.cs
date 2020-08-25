using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("TMTabPrcArt")]
    public class TMTabPrcArt
    {
        public int TabPrecos { get; set; }

        public DateTime DatPrecos { get; set; }

        public string Artigo { get; set; }

        public double? PrecoLiq { get; set; }

        public string Factor { get; set; }

        public double? PrecoDoc { get; set; }

        public string Desconto { get; set; }

        public string DescProd { get; set; }

        public double? BonusRef { get; set; }

        public double? BonusQtd { get; set; }

        public string BonusArt { get; set; }

    }

}