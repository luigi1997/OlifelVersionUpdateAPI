using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("EmbPicagens")]
    public class EmbPicagens
    {
        public string TipoDoc { get; set; }

        public int Ano { get; set; }

        public short Mes { get; set; }

        public int NumDoc { get; set; }

        public int NumEmb { get; set; }

        public int LinhaID { get; set; }

        public int Tam { get; set; }

        public int Cor { get; set; }

        public string TamDesc { get; set; }

        public string CorDesc { get; set; }

        public string Artigo { get; set; }

        public double? Quant { get; set; }

        public string PKTipoDoc { get; set; }

        public int PKAno { get; set; }

        public short PKMes { get; set; }

        public int PKNumDoc { get; set; }

        public int PKLinhaID { get; set; }
        public string DESTipoDoc { get; set; }

        public int DESAno { get; set; }

        public int DESNumDoc { get; set; }

        public int Palete { get; set; }
        public int Carga { get; set; }

    }
}