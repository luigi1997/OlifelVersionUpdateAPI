using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IVgTDGera
    {       
        string TipoDoc { get; set; }

        string Empresa { get; set; }
        
        string TDGera { get; set; }
    }
}
