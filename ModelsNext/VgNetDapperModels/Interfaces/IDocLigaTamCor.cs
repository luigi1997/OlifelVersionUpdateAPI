using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IDocLigaTamCor
    {
        string TipoDoc { get; set; }

        int Ano { get; set; }

        short Mes { get; set; }

        int NumDoc { get; set; }

        int LinhaID { get; set; }

        string Local { get; set; }

        string Lote { get; set; }

        int Tam { get; set; }

        int Cor { get; set; }

        string TipoDocBase { get; set; }

        int AnoBase { get; set; }

        short MesBase { get; set; }

        int NumDocBase { get; set; }

        int LinhaBaseID { get; set; }

        string LocalBase { get; set; }

        string LoteBase { get; set; }

        int TamBase { get; set; }

        int CorBase { get; set; }

        double? QtdBase { get; set; }

        double? QtdLiga { get; set; }

        bool? FAnulaDoc { get; set; }

        bool? FAnulaBase { get; set; }

        string ChaveDocCab { get; set; }

        string ChaveTamCor { get; set; }

        string ChaveDocBase { get; set; }

        string ChaveLTCBase { get; set; }

        int? QtdRegNum { get; set; }

        string QtdRegOp { get; set; }

        double? QtdExc { get; set; }
    }
}
