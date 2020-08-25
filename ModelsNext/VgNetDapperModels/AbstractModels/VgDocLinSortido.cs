using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.AbstractModels
{
    [Table("DocLinSortido")]
    public abstract class VgDocLinSortido<DLSI> : IVgDocLinSortido
                           where DLSI : IDocLinSortItem
    {
        public string TipoDoc { get; set; }

        public int Ano { get; set; }

        public short Mes { get; set; }

        public int NumDoc { get; set; }

        public int LinhaID { get; set; }

        public int LinSortido { get; set; }

        public int Sortido { get; set; }

        public int Cor { get; set; }

        public string Artigo { get; set; }

        public int? NEmb { get; set; }

        public double? Quant { get; set; }

        public int? EmbReg1 { get; set; }

        public int? EmbReg2 { get; set; }

        public int? EmbReg3 { get; set; }

        public int? EmbReg4 { get; set; }

        public int? EmbReg5 { get; set; }

        public int? Embalagem { get; set; }

        public int? IniEmb { get; set; }

        public double? QtdEmb { get; set; }

        public double? MinEmb { get; set; }

        public bool? Embalado { get; set; }

        public string Nota1 { get; set; }

        public string Nota2 { get; set; }

        public string Nota3 { get; set; }

        public double? Tara { get; set; }

        public double? Volume { get; set; }

        public double? PesoLiquido { get; set; }

        public int? Sequencia { get; set; }
        [Computed]
        public IList<ArtSortidoItemWeb> ArtSortidoItems { get; set; }
        [Computed]
        public IList<DLSI> DocLinSortItems { get; set; }
    }
    public class ArtSortidoItemWeb
    {
        public int SortidoID { get; set; }
        public int TamID { get; set; }
        public string TamDesc { get; set; }
        public double? Quantidade { get; set; }
    }

}