﻿using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("DocLigaPlanosTamCor")]
    public class DocLigaPlanosTamCor : IDocLigaPlanosTamCor
    {
        public string TipoDoc { get; set; }

        public int Ano { get; set; }

        public short Mes { get; set; }

        public int NumDoc { get; set; }

        public int LinhaID { get; set; }

        public string Local { get; set; }

        public string Lote { get; set; }

        public int Tam { get; set; }

        public int Cor { get; set; }

        public int Ordem { get; set; }

        public int Etapa { get; set; }

        public int Fase { get; set; }

        public string Artigo { get; set; }

        public double? Saida { get; set; }

        public double? Desvio { get; set; }

        public double? Sobra { get; set; }

        public int? Estado { get; set; }

        public bool? FAnulaDoc { get; set; }

        public string ChaveDocCab { get; set; }

        public string ChaveTamCor { get; set; }

        public double? Reservado { get; set; }

        public double? Requisitado { get; set; }

        public double? Entregue { get; set; }

        public double? AcertoRes { get; set; }

        public double? AcertoReq { get; set; }

        public double? AcertoEnt { get; set; }

        public double? AcertoSai { get; set; }

    }

}