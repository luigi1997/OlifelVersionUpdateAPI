using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IDocLinSortItem
    {
         string TipoDoc { get; set; }

         int Ano { get; set; }

         short Mes { get; set; }

         int NumDoc { get; set; }

         int LinhaID { get; set; }

         int LinSortido { get; set; }

         int Cor { get; set; }

         int Tam { get; set; }

         string Artigo { get; set; }

         double? Quant { get; set; }

         double? Peso { get; set; }
    }
}
