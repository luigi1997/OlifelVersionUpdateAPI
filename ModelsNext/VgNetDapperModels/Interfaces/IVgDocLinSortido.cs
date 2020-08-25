using System.Collections.Generic;
using VgNetDapperModels.AbstractModels;

namespace VgNetDapperModels.Interfaces
{
    public interface IVgDocLinSortido
    {
         string TipoDoc { get; set; }

         int Ano { get; set; }

         short Mes { get; set; }

         int NumDoc { get; set; }

         int LinhaID { get; set; }

         int LinSortido { get; set; }

         int Sortido { get; set; }

         int Cor { get; set; }

         string Artigo { get; set; }

         int? NEmb { get; set; }

         double? Quant { get; set; }

         int? EmbReg1 { get; set; }

         int? EmbReg2 { get; set; }

         int? EmbReg3 { get; set; }

         int? EmbReg4 { get; set; }

         int? EmbReg5 { get; set; }

         int? Embalagem { get; set; }

         int? IniEmb { get; set; }

         double? QtdEmb { get; set; }

         double? MinEmb { get; set; }

         bool? Embalado { get; set; }

         string Nota1 { get; set; }

         string Nota2 { get; set; }

         string Nota3 { get; set; }

         double? Tara { get; set; }

         double? Volume { get; set; }

         double? PesoLiquido { get; set; }

         int? Sequencia { get; set; }
    }
}

