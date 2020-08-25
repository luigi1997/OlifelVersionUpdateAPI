using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IDocLigaEmb
    {
        string TipoDoc { get; set; }

        int Ano { get; set; }

        short Mes { get; set; }
        int NumDoc { get; set; }

        int LinhaID { get; set; }

        string TipoDocEmb { get; set; }

        int AnoEmb { get; set; }

        short MesEmb { get; set; }

        int NumDocEmb { get; set; }

        int NumEmb { get; set; }

        int LinhaEmbID { get; set; }

        double? Quant { get; set; }

        double? PesoLiquido { get; set; }

        double? Tara { get; set; }

        double? Volume { get; set; }
    }
}
