using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IDocLinDescResiduos
    { 
        string TipoDoc { get; set; }

        int Ano { get; set; }

        short Mes { get; set; }

        int NumDoc { get; set; }

        int LinhaID { get; set; }

        int NumLinha { get; set; }

        string Artigo { get; set; }

        string Designacao { get; set; }

        double? Quantidade { get; set; }

        double? Preco { get; set; }

        int? MovPos { get; set; }

        int? LinTmp { get; set; }

    }

}

