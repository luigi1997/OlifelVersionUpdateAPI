using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("ArtFamilias")]
    public class ArtFamilia
    {
        public int Familia { get; set; }

        public string Designacao { get; set; }

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

        public bool? TemReservas { get; set; }

        public bool? TemDevolucao { get; set; }

        public bool? TemRuptura { get; set; }

        public bool? TemPesoVar { get; set; }

        public bool? TemIVA { get; set; }

        public bool? TemComp { get; set; }

        public bool? TemLarg { get; set; }

        public bool? TemAlt { get; set; }

        public short? IconPeq { get; set; }

        public short? IconGra { get; set; }

        public short? CtbTipo { get; set; }

        public short? DecUni { get; set; }

        public string Obs { get; set; }

        public DateTime? DataCria { get; set; }

        public long DtUpdate { get; set; }

        public bool? FoiEnviado { get; set; }

        public bool? AvisaQuant { get; set; }

        public bool? AvisaPreco { get; set; }

        public double? EntConv { get; set; }

        public double? SaiConv { get; set; }

        public bool? AddRecno { get; set; }

        public short? DigRecno { get; set; }

        public int? Rubrica { get; set; }

        public bool? TemPontosVal { get; set; }

        public bool? TemPontosQtd { get; set; }

        public double? EURPontos { get; set; }

        public double? PontosVal { get; set; }

        public double? QtdPontos { get; set; }

        public double? PontosQtd { get; set; }

        public bool? CriaTarefa { get; set; }

        public double? HorasPrevistas { get; set; }

        public double? CustoPrevisto { get; set; }

        public short? NumPrecos { get; set; }

        public short? PrecoRef { get; set; }

        public short? MargCalc { get; set; }

        public double? Margem { get; set; }

        public bool? TemLotes { get; set; }

        public bool? AskQtdLote { get; set; }

        public bool? AskDatLote { get; set; }

        public double? QtdLote { get; set; }

        public string txtLote { get; set; }

        public int? Generico { get; set; }

        public int? Contador { get; set; }

        public bool? TemRequisicao { get; set; }

        public bool? IsPrioritario { get; set; }

        public bool? TemStock { get; set; }

        public bool? TemEcoTaxa { get; set; }

        public int? EscalaTam { get; set; }

        public int? EscalaCor { get; set; }

        public short? ContadorPos { get; set; }

        public string ContadorChar { get; set; }

        public int? OptRequisicao { get; set; }

        public double? MrgQtdReq { get; set; }

        public double? MrgQtdLig { get; set; }

        public bool? TemMrgReq { get; set; }

        public bool? TemMrgLig { get; set; }

        public bool? ReqUsaDisponivel { get; set; }

        public bool? ReqUsaEncomenda { get; set; }

        public short? DecUniEnt { get; set; }

        public short? Variacao { get; set; }

        public bool? isAprovado { get; set; }

        public bool? AllowCodeChange { get; set; }

        public bool? TemClassiConta { get; set; }

        public byte[] Imagem { get; set; }

        public bool? AskTarLote { get; set; }

        public bool? LotesTerceiro { get; set; }

        public bool? TemCusto { get; set; }

        public int? ProcLote { get; set; }

        public double? QtdTaraLote { get; set; }

        public int? ValDiasLote { get; set; }

        public bool? EditaComponentes { get; set; }

        public bool? TemPOS { get; set; }

        public int? Tecla { get; set; }

        public double? QtdPos { get; set; }

        public string txtBotao { get; set; }

        public int? CorBotao { get; set; }

        public int? CorTexto { get; set; }

        public string FntName { get; set; }

        public short? FntSize { get; set; }

        public bool? FntBld { get; set; }

        public bool? FntUnd { get; set; }

        public bool? FntStr { get; set; }

        public bool? FntItl { get; set; }

        public double? QtdTaraPOS { get; set; }

        public short? EtqNum { get; set; }

        public short? EtqNumRef { get; set; }

        public bool? ApenasQtdUm { get; set; }

        public bool? ObrigaNumeroSerie { get; set; }

        public bool? PermiteAssociarSortidos { get; set; }

        public int? MovPos { get; set; }

    }

}