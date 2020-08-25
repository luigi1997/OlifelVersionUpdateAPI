using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.BaseModels
{
    [Table("TBCodBarItem")]
    public class TBCodBarItem
    {
        [ExplicitKey]
        public int CodBarras { get; set; }

        public short? Dado { get; set; }
        [ExplicitKey]
        public short Inicio { get; set; }

        public short? Tamanho { get; set; }


        #region Dados
        public enum CodBarDadoID
        {
            CodArtigo = 0,
            Quantidade = 1,
            QuantidadeTaras = 3,
            CodigoTaras = 4,
            Tamanho = 5,
            Cor = 6,
            NumTam = 7,
            NumCor = 8,
            QuantidadeFormatada = 9,
            CodBarras = 10,
            Referencia = 11,
            NumOrdemArtigo = 12,
            QtdOriginal = 13,
            NumTipoDoc = 14,
            SerieDocumento = 15,
            NumDoc = 16,
            LinhaIdDoc = 17,
            LoteArtigo = 18,
            PlanoFabrico = 19,
            FaseProducao = 20,
            LinhaDocGeral0 = 21,
            LinhaDocGeral1 = 22,
            LinhaDocGeral2 = 23,
            LinhaDocGeral3 = 24,
            LinhaDocGeral4 = 25,
            LinhaDocGeral5 = 26,
            LinhaDocGeral6 = 27,
            LinhaDocGeral7 = 28,
            LinhaDocGeral8 = 29,
            LinhaDocGeral9 = 30,
            PesoArtigo = 31,
            NumEmbalagem = 32
        }

        public List<TBCodBarDado> GetDadosList()
        {
            return new List<TBCodBarDado> {
                new TBCodBarDado("Artigos",                         (int)CodBarDadoID.CodArtigo),
                new TBCodBarDado("Quantidade",                      (int)CodBarDadoID.Quantidade),
                new TBCodBarDado("Quantidade Taras",                (int)CodBarDadoID.QuantidadeTaras),
                new TBCodBarDado("Código Taras",                    (int)CodBarDadoID.CodigoTaras),
                new TBCodBarDado("Tamanho",                         (int)CodBarDadoID.Tamanho),
                new TBCodBarDado("Côr",                             (int)CodBarDadoID.Cor),
                new TBCodBarDado("Número do Tam",                   (int)CodBarDadoID.NumTam),
                new TBCodBarDado("Número da Cor",                   (int)CodBarDadoID.NumCor),
                new TBCodBarDado("Quantidade Formatada",            (int)CodBarDadoID.QuantidadeFormatada),
                new TBCodBarDado("Código Barras",                   (int)CodBarDadoID.CodigoTaras),
                new TBCodBarDado("Referência",                      (int)CodBarDadoID.Referencia),
                new TBCodBarDado("Número Ordem Artigo",             (int)CodBarDadoID.NumOrdemArtigo),
                new TBCodBarDado("Quantidade Original",             (int)CodBarDadoID.QtdOriginal),
                new TBCodBarDado("Número Tipo Documento",           (int)CodBarDadoID.NumTipoDoc),
                new TBCodBarDado("Serie Documento",                 (int)CodBarDadoID.SerieDocumento),
                new TBCodBarDado("Número Documento",                (int)CodBarDadoID.NumDoc),
                new TBCodBarDado("Número Linha Documento (linhaID)",(int)CodBarDadoID.LinhaIdDoc),
                new TBCodBarDado("Lote do Artigo",                  (int)CodBarDadoID.LoteArtigo),
                new TBCodBarDado("Plano de Fabrico",                (int)CodBarDadoID.PlanoFabrico),
                new TBCodBarDado("Fase de Produção",                (int)CodBarDadoID.FaseProducao),
                new TBCodBarDado("Linha Doc. Geral0",               (int)CodBarDadoID.LinhaDocGeral0),
                new TBCodBarDado("Linha Doc. Geral1",               (int)CodBarDadoID.LinhaDocGeral1),
                new TBCodBarDado("Linha Doc. Geral2",               (int)CodBarDadoID.LinhaDocGeral2),
                new TBCodBarDado("Linha Doc. Geral3",               (int)CodBarDadoID.LinhaDocGeral3),
                new TBCodBarDado("Linha Doc. Geral4",               (int)CodBarDadoID.LinhaDocGeral4),
                new TBCodBarDado("Linha Doc. Geral5",               (int)CodBarDadoID.LinhaDocGeral5),
                new TBCodBarDado("Linha Doc. Geral6",               (int)CodBarDadoID.LinhaDocGeral6),
                new TBCodBarDado("Linha Doc. Geral7",               (int)CodBarDadoID.LinhaDocGeral7),
                new TBCodBarDado("Linha Doc. Geral8",               (int)CodBarDadoID.LinhaDocGeral8),
                new TBCodBarDado("Linha Doc. Geral9",               (int)CodBarDadoID.LinhaDocGeral9),
                new TBCodBarDado("Peso do Artigo",                  (int)CodBarDadoID.PesoArtigo),
                new TBCodBarDado("Número da Embalagem",             (int)CodBarDadoID.NumEmbalagem)
            };
        }
        #endregion
    }

    public class TBCodBarDado
    {
        public TBCodBarDado(string description, int id)
        {
            Description = description;
            Id = id;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}
