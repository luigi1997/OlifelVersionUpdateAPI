using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface ITBCondPag
    {
        int CondPag { get; set; }

        string Descritivo { get; set; }

        short? dias { get; set; }

        float? desconto { get; set; }

        short? Prestacoes { get; set; }

        float? JurosAnual { get; set; }

        short? AntRepPost { get; set; }

        short? DiaIni { get; set; }

        short? MesIni { get; set; }

        short? DiaFim { get; set; }

        string obs { get; set; }
    }
}
