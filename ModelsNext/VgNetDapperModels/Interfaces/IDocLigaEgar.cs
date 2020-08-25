using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IDocLigaEgar
    {
         string TipoDoc { get; set; }
         int Ano { get; set; }
         short Mes { get; set; }
         int NumDoc { get; set; }
         string NumeroGuia { get; set; }

    }

}