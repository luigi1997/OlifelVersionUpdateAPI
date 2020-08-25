using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IVgArtigo
        
    {
        string Artigo { get; set; }

        string Classificacao { get; set; }

        string CodBarras { get; set; }

        string Referencia { get; set; }

        int Familia { get; set; }

        string Designacao { get; set; }

        string Abreviatura { get; set; }

        short? TipoArtigo { get; set; }

        short? EntDec { get; set; }

        string EntUM { get; set; }

        short? SaiDec { get; set; }

        string SaiUM { get; set; }

        int? CondPag { get; set; }

        float? MargMin { get; set; }

        int? DescBase { get; set; }

        int? DescQtd { get; set; }

        int? DescVal { get; set; }

        int? Comissao { get; set; }

        int? CodIVA { get; set; }

        string CodTara { get; set; }

        double? RelTara { get; set; }

        int? Equivalencia { get; set; }

        double? Imposto { get; set; }

        bool? TemReservas { get; set; }

        bool? TemDevolucao { get; set; }

        bool? TemRuptura { get; set; }

        bool? TemPesoVar { get; set; }

        bool? TemIVA { get; set; }

        bool? TemComp { get; set; }

        bool? TemLarg { get; set; }

        bool? TemAlt { get; set; }

        double? Peso { get; set; }

        double? PCR { get; set; }

        double? PCU { get; set; }

        double? PCM { get; set; }

        double? CMP { get; set; }

        double? PCP { get; set; }

        DateTime? UltEntDat { get; set; }

        double? UltEntQtd { get; set; }

        DateTime? UltSaiDat { get; set; }

        double? UltSaiQtd { get; set; }

        DateTime? UltDatPCU { get; set; }

        DateTime? UltDatPCP { get; set; }

        double? StkMin { get; set; }

        double? StkMax { get; set; }

        double? StkEnc { get; set; }

        double? LotEnc { get; set; }

        double? StkQtd { get; set; }

        bool? FoiRetirado { get; set; }

        string ClasseFor { get; set; }

        string CodigoFor { get; set; }

        short? PrazMedEnt { get; set; }

        DateTime? DataCria { get; set; }

        short? IconPeq { get; set; }

        short? IconGra { get; set; }

        short? CtbTipo { get; set; }

        short? DecUni { get; set; }

        string CodJoin { get; set; }

        double? RelJoin { get; set; }

        string obs { get; set; }

        int recno { get; set; }

        short? EtqNum { get; set; }

        short? EtqNumRef { get; set; }

        bool? FoiEnviado { get; set; }

        string PaisOrigem { get; set; }

        short? DiasValidade { get; set; }

        bool? AvisaQuant { get; set; }

        bool? AvisaPreco { get; set; }

        double? EntConv { get; set; }

        double? SaiConv { get; set; }

        bool? TemTerminal { get; set; }

        int? CodTerminal { get; set; }

        string TxtTerminal { get; set; }

        string FldPOS { get; set; }

        int? Rubrica { get; set; }

        bool? TemPontosVal { get; set; }

        bool? TemPontosQtd { get; set; }

        double? EURPontos { get; set; }

        double? PontosVal { get; set; }

        double? QtdPontos { get; set; }

        double? PontosQtd { get; set; }

        bool? TemLotes { get; set; }

        bool? AskQtdLote { get; set; }

        bool? AskDatLote { get; set; }

        double? QtdLote { get; set; }

        string txtLote { get; set; }

        bool? isResiduo { get; set; }

        string LERVersao { get; set; }

        string LERCodigo { get; set; }

        string OCDEVersao { get; set; }

        string OCDECodigo { get; set; }

        string BasVersao { get; set; }

        string BasCodigo { get; set; }

        string DesVersao { get; set; }

        string DesCodigo { get; set; }

        string Geral0 { get; set; }

        string Geral1 { get; set; }

        string Geral2 { get; set; }

        string Geral3 { get; set; }

        string Geral4 { get; set; }

        string Geral5 { get; set; }

        string Geral6 { get; set; }

        string Geral7 { get; set; }

        string Geral8 { get; set; }

        string Geral9 { get; set; }

        bool? TemStock { get; set; }

        bool? TemEcoTaxa { get; set; }

        double? Volume { get; set; }

        double? AcumPCMQtd { get; set; }

        double? AcumPCMVal { get; set; }

        double? AcumEntQtd { get; set; }

        double? AcumEntVal { get; set; }

        double? AcumSaiQtd { get; set; }

        double? AcumSaiVal { get; set; }

        double? SaiEnc { get; set; }

        double? SaiRes { get; set; }

        double? SaiDev { get; set; }

        double? EntEnc { get; set; }

        double? EntRes { get; set; }

        double? EntDev { get; set; }

        bool? TemRequisicao { get; set; }

        bool? IsPrioritario { get; set; }

        int? DiasPrzEnt { get; set; }

        int? DiasMrgSeg { get; set; }

        int? OptRequisicao { get; set; }

        double? MrgQtdReq { get; set; }

        double? MrgQtdLig { get; set; }

        bool? TemMrgReq { get; set; }

        bool? TemMrgLig { get; set; }

        double? PCRSai { get; set; }

        double? PCUSai { get; set; }

        double? PCMSai { get; set; }

        double? CMPSai { get; set; }

        double? PCPSai { get; set; }

        short? DecUniEnt { get; set; }

        double? AcumPCMQtdEnt { get; set; }

        bool? ReqUsaDisponivel { get; set; }

        bool? ReqUsaEncomenda { get; set; }

        short? Variacao { get; set; }

        bool? isAprovado { get; set; }

        int? Estado { get; set; }

        bool? EstadoFlag { get; set; }

        string CodIntrastat { get; set; }

        string DescrDetalhada { get; set; }

        bool? TemPOS { get; set; }

        string ArtigoBase { get; set; }

        int? TipoCodBarras { get; set; }

        bool? AskTarLote { get; set; }

        bool? LotesTerceiro { get; set; }

        string Calibre { get; set; }

        string Variedade { get; set; }

        string CorPolpa { get; set; }

        bool? TemCusto { get; set; }

        double? AcumPCMCusto { get; set; }

        double? AcumEntCusto { get; set; }

        double? AcumSaiCusto { get; set; }

        double? CustoUlt { get; set; }

        double? CustoMed { get; set; }

        int? ProcLote { get; set; }

        double? QtdTaraLote { get; set; }

        int? ValDiasLote { get; set; }

        bool? EditaComponentes { get; set; }

        double? Fator { get; set; }

        double? StkTara { get; set; }

        double? AcumEntTara { get; set; }

        double? AcumSaiTara { get; set; }

        bool? isModeloBase { get; set; }

        string CriadoPor { get; set; }

        string AtualizadoPor { get; set; }

        DateTime? DtUpdate { get; set; }

        int? CtbContaDebito { get; set; }

        int? CtbContaCredito { get; set; }

        string CtbRadicalTxD { get; set; }

        string CtbRadicalTxC { get; set; }

        int? CtbContaPlanoIvaD { get; set; }

        int? CtbContaPlanoIvaC { get; set; }

        int? CtbContaDebito1 { get; set; }

        int? CtbContaCredito1 { get; set; }

        float? PercDesconto { get; set; }

        bool? OnPromocao { get; set; }
        string EmbModelo { get; set; }
    }
}
