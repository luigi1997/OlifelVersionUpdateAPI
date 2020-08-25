using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IDocLigaPlanosTamCor
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

        int Ordem { get; set; }

        int Etapa { get; set; }

        int Fase { get; set; }

        string Artigo { get; set; }

        double? Saida { get; set; }

        double? Desvio { get; set; }

        double? Sobra { get; set; }

        int? Estado { get; set; }

        bool? FAnulaDoc { get; set; }

        string ChaveDocCab { get; set; }

        string ChaveTamCor { get; set; }

        double? Reservado { get; set; }

        double? Requisitado { get; set; }

        double? Entregue { get; set; }

        double? AcertoRes { get; set; }

        double? AcertoReq { get; set; }

        double? AcertoEnt { get; set; }

        double? AcertoSai { get; set; }

    }
}


