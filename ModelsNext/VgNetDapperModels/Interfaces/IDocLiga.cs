using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IDocLiga
    {
        string TipoDoc { get; set; }

        int Ano { get; set; }

        short Mes { get; set; }

        int NumDoc { get; set; }

        int LinhaID { get; set; }

        string TipoDocBase { get; set; }

        int AnoBase { get; set; }

        short MesBase { get; set; }

        int NumDocBase { get; set; }

        int LinhaBaseID { get; set; }

        double? QtdBase { get; set; }

        double? QtdLiga { get; set; }

        string UnMedBase { get; set; }

        string UnMedLiga { get; set; }

        double? ConvBase { get; set; }

        double? ConvLiga { get; set; }

        bool? FActBase { get; set; }

        bool? FAnulaDoc { get; set; }

        bool? FAnulaBase { get; set; }

        string ChaveDocCab { get; set; }

        string ChaveDocLin { get; set; }

        string ChaveDocBase { get; set; }

        string ChaveLinBase { get; set; }

        bool? ConcluiLiga { get; set; }

        int? QtdRegNum { get; set; }

        string QtdRegOp { get; set; }

        double? QtdExc { get; set; }

        bool? TemTamCor { get; set; }

    }
}


