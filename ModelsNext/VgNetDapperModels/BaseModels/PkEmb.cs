using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("PkEmb")]
    public class PkEmb
    {
        public string TipoDoc { get; set; }

        public int Ano { get; set; }

        public short Mes { get; set; }

        public int NumDoc { get; set; }

        public int NumEmb { get; set; }

        public int LinhaID { get; set; }

        public string Local { get; set; }

        public string Lote { get; set; }

        public int Tam { get; set; }

        public int Cor { get; set; }

        public int? Embalagem { get; set; }

        public string Artigo { get; set; }

        public double? Quant { get; set; }

        public double? PesoLiquido { get; set; }

        public double? Tara { get; set; }

        public double? Volume { get; set; }

        public string Nota1 { get; set; }

        public string Nota2 { get; set; }

        public string Nota3 { get; set; }

        public double? QtdEnt { get; set; }

        public double? QtdSai { get; set; }

        public int? NumLinha { get; set; }

        public int? Sortido { get; set; }

        public int? LinSortido { get; set; }

        public short? NrResto { get; set; }

    }

}
