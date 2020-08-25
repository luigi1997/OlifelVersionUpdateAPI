using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.AbstractModels
{
    [Table("Artigos")]
    public abstract class VgArtigo<AI,ATC, AP, AET, AEC> : IVgArtigo
                where AI : IArtImagem
                where ATC : IVgArtTamCor
                where AP : IArtPreco
                where AET : IArtEscTam
                where AEC : IArtEscCor
    {
        public enum Tipos { MateriaPrima, Produtos, Servicos, ProdutoInterm, Imobilizado, FornServTerceiros, Outros, Notas };

        public string Artigo { get; set; }

        public string Classificacao { get; set; }

        public string CodBarras { get; set; }

        public string Referencia { get; set; }

        public int Familia { get; set; }

        public string Designacao { get; set; }

        public string Abreviatura { get; set; }

        public short? TipoArtigo { get; set; }

        public short? EntDec { get; set; }

        public string EntUM { get; set; }

        public short? SaiDec { get; set; }

        public string SaiUM { get; set; }

        public int? CondPag { get; set; }

        public float? MargMin { get; set; }

        public int? DescBase { get; set; }

        public int? DescQtd { get; set; }

        public int? DescVal { get; set; }

        public int? Comissao { get; set; }

        public int? CodIVA { get; set; }

        public string CodTara { get; set; }

        public double? RelTara { get; set; }

        public int? Equivalencia { get; set; }

        public double? Imposto { get; set; }

        public bool? TemReservas { get; set; }

        public bool? TemDevolucao { get; set; }

        public bool? TemRuptura { get; set; }

        public bool? TemPesoVar { get; set; }

        public bool? TemIVA { get; set; }

        public bool? TemComp { get; set; }

        public bool? TemLarg { get; set; }

        public bool? TemAlt { get; set; }

        public double? Peso { get; set; }

        public double? PCR { get; set; }

        public double? PCU { get; set; }

        public double? PCM { get; set; }

        public double? CMP { get; set; }

        public double? PCP { get; set; }

        public DateTime? UltEntDat { get; set; }

        public double? UltEntQtd { get; set; }

        public DateTime? UltSaiDat { get; set; }

        public double? UltSaiQtd { get; set; }

        public DateTime? UltDatPCU { get; set; }

        public DateTime? UltDatPCP { get; set; }

        public double? StkMin { get; set; }

        public double? StkMax { get; set; }

        public double? StkEnc { get; set; }

        public double? LotEnc { get; set; }

        public double? StkQtd { get; set; }

        public bool? FoiRetirado { get; set; }

        public string ClasseFor { get; set; }

        public string CodigoFor { get; set; }

        public short? PrazMedEnt { get; set; }

        public DateTime? DataCria { get; set; }

        public short? IconPeq { get; set; }

        public short? IconGra { get; set; }

        public short? CtbTipo { get; set; }

        public short? DecUni { get; set; }

        public string CodJoin { get; set; }

        public double? RelJoin { get; set; }

        public string obs { get; set; }

        public int recno { get; set; }

        public short? EtqNum { get; set; }

        public short? EtqNumRef { get; set; }

        public bool? FoiEnviado { get; set; }

        public string PaisOrigem { get; set; }

        public short? DiasValidade { get; set; }

        public bool? AvisaQuant { get; set; }

        public bool? AvisaPreco { get; set; }

        public double? EntConv { get; set; }

        public double? SaiConv { get; set; }

        public bool? TemTerminal { get; set; }

        public int? CodTerminal { get; set; }

        public string TxtTerminal { get; set; }

        public string FldPOS { get; set; }

        public int? Rubrica { get; set; }

        public bool? TemPontosVal { get; set; }

        public bool? TemPontosQtd { get; set; }

        public double? EURPontos { get; set; }

        public double? PontosVal { get; set; }

        public double? QtdPontos { get; set; }

        public double? PontosQtd { get; set; }

        public bool? TemLotes { get; set; }

        public bool? AskQtdLote { get; set; }

        public bool? AskDatLote { get; set; }

        public double? QtdLote { get; set; }

        public string txtLote { get; set; }

        public bool? isResiduo { get; set; }

        public string LERVersao { get; set; }

        public string LERCodigo { get; set; }

        public string OCDEVersao { get; set; }

        public string OCDECodigo { get; set; }

        public string BasVersao { get; set; }

        public string BasCodigo { get; set; }

        public string DesVersao { get; set; }

        public string DesCodigo { get; set; }

        public string Geral0 { get; set; }

        public string Geral1 { get; set; }

        public string Geral2 { get; set; }

        public string Geral3 { get; set; }

        public string Geral4 { get; set; }

        public string Geral5 { get; set; }

        public string Geral6 { get; set; }

        public string Geral7 { get; set; }

        public string Geral8 { get; set; }

        public string Geral9 { get; set; }

        public bool? TemStock { get; set; }

        public bool? TemEcoTaxa { get; set; }

        public double? Volume { get; set; }

        public double? AcumPCMQtd { get; set; }

        public double? AcumPCMVal { get; set; }

        public double? AcumEntQtd { get; set; }

        public double? AcumEntVal { get; set; }

        public double? AcumSaiQtd { get; set; }

        public double? AcumSaiVal { get; set; }

        public double? SaiEnc { get; set; }

        public double? SaiRes { get; set; }

        public double? SaiDev { get; set; }

        public double? EntEnc { get; set; }

        public double? EntRes { get; set; }

        public double? EntDev { get; set; }

        public bool? TemRequisicao { get; set; }

        public bool? IsPrioritario { get; set; }

        public int? DiasPrzEnt { get; set; }

        public int? DiasMrgSeg { get; set; }

        public int? OptRequisicao { get; set; }

        public double? MrgQtdReq { get; set; }

        public double? MrgQtdLig { get; set; }

        public bool? TemMrgReq { get; set; }

        public bool? TemMrgLig { get; set; }

        public double? PCRSai { get; set; }

        public double? PCUSai { get; set; }

        public double? PCMSai { get; set; }

        public double? CMPSai { get; set; }

        public double? PCPSai { get; set; }

        public short? DecUniEnt { get; set; }

        public double? AcumPCMQtdEnt { get; set; }

        public bool? ReqUsaDisponivel { get; set; }

        public bool? ReqUsaEncomenda { get; set; }

        public short? Variacao { get; set; }

        public bool? isAprovado { get; set; }

        public int? Estado { get; set; }

        public bool? EstadoFlag { get; set; }

        public string CodIntrastat { get; set; }

        public string DescrDetalhada { get; set; }

        public bool? TemPOS { get; set; }

        public string ArtigoBase { get; set; }

        public int? TipoCodBarras { get; set; }

        public bool? AskTarLote { get; set; }

        public bool? LotesTerceiro { get; set; }

        public string Calibre { get; set; }

        public string Variedade { get; set; }

        public string CorPolpa { get; set; }

        public bool? TemCusto { get; set; }

        public double? AcumPCMCusto { get; set; }

        public double? AcumEntCusto { get; set; }

        public double? AcumSaiCusto { get; set; }

        public double? CustoUlt { get; set; }

        public double? CustoMed { get; set; }

        public int? ProcLote { get; set; }

        public double? QtdTaraLote { get; set; }

        public int? ValDiasLote { get; set; }

        public bool? EditaComponentes { get; set; }

        public double? Fator { get; set; }

        public double? StkTara { get; set; }

        public double? AcumEntTara { get; set; }

        public double? AcumSaiTara { get; set; }

        public bool? isModeloBase { get; set; }

        public string CriadoPor { get; set; }

        public string AtualizadoPor { get; set; }

        public DateTime? DtUpdate { get; set; }

        public int? CtbContaDebito { get; set; }

        public int? CtbContaCredito { get; set; }

        public string CtbRadicalTxD { get; set; }

        public string CtbRadicalTxC { get; set; }

        public int? CtbContaPlanoIvaD { get; set; }

        public int? CtbContaPlanoIvaC { get; set; }

        public int? CtbContaDebito1 { get; set; }

        public int? CtbContaCredito1 { get; set; }

        public float? PercDesconto { get; set; }

        public bool? OnPromocao { get; set; }

        public string Modelo { get; set; }
        public string EmbModelo { get; set; }

        [Computed]
        public AI Imagem { get; set; }
        [Computed]
        public IList<ATC> TamCor { get; set; }
        [Computed]
        public IList<AP> ArtPrecos { get; set; }
        [Computed]
        public IList<AET> ArtEscTam { get; set; }
        [Computed]
        public IList<AEC> ArtEscCor { get; set; }

        [Computed]
        public double? ArtigoPOSWeb_QtdPOS { get; set; }

    }
}