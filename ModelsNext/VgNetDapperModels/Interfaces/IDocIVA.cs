using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IDocIVA
    {
         string TipoDoc { get; set; }

         int Ano { get; set; }

         short Mes { get; set; }

         int NumDoc { get; set; }

         int CodIVA { get; set; }

         double? TaxIVA { get; set; }

         double? ValSuj { get; set; }

         double? ValIVA { get; set; }

         double? TotalMP { get; set; }

         double? TotalPA { get; set; }

         double? TotalSR { get; set; }

         double? TotalOT { get; set; }
    }
}
