namespace VgNetDapperModels.BaseModels
{
    public class ProdConfig
    {
        public int? UltOrdem { get; set; }

        public short? DigOrdem { get; set; }

        public short? DigPlano { get; set; }

        public short? DigSub { get; set; }

        public string DocReserva { get; set; }

        public int? PrnOrdem { get; set; }

        public int? PrnPlano { get; set; }

        public int? PrnValeMaterial { get; set; }

        public int? PrnSub { get; set; }

        public int? PrnLote { get; set; }

        public int? PrnOperLote { get; set; }

        public int? PrnOperFicha { get; set; }

        public string DocRequisicao { get; set; }

        public short? ColPlano { get; set; }

        public short? ColPreco { get; set; }

        public string DocBloco { get; set; }

        public string DocEncomenda { get; set; }

        public int ProdID { get; set; }

        public int? Formas { get; set; }

        public string ArmFormas { get; set; }

        public int? UltBloco { get; set; }

        public string ArmMP { get; set; }

        public string ArmPA { get; set; }

        public int? OptRequisicao { get; set; }

        public string DocEntrega { get; set; }

        public string DocSaida { get; set; }

        public string DocDesvio { get; set; }

        public string DocSobra { get; set; }

        public string CodComp { get; set; }

        public short? PrcOrcMod { get; set; }

        public string DocAmostra { get; set; }

        public bool? TemContador { get; set; }

        public byte[] CanvasImg { get; set; }

        public byte[] CanvasMin { get; set; }

        public int? Estado { get; set; }

        public string DocStkEnt { get; set; }

        public string DocStkSai { get; set; }

        public byte[] CanvasWeb { get; set; }

        public bool? temAprovArtDoc { get; set; }

        public bool? temAprovArtFT { get; set; }

        public bool? temAprovArtOrc { get; set; }

        public bool? temAprovArtAmt { get; set; }

        public bool? temCtrlQuantFT { get; set; }

        public bool? temCtrlPrecoFT { get; set; }

        public bool? temCtrlQuantOrc { get; set; }

        public bool? temCtrlPrecoOrc { get; set; }

        public bool? temCtrlQuantAmt { get; set; }

        public bool? temCtrlPrecoAmt { get; set; }

        public int? Cortantes { get; set; }

        public bool? temAprovaFT { get; set; }

        public string DocPK { get; set; }

        public int? FaseExp { get; set; }

        public string DocExp { get; set; }

        public string DocFTBase { get; set; }

        public string DocFTConsumo { get; set; }

        public int? AgrupaConsumo { get; set; }

        public string MecanicoDoc { get; set; }

        public bool? ligaSaidaMP_AcpInterno { get; set; }

        public bool? ligaSaidaMP_AcpSC { get; set; }

        public bool? varianteAdiciona { get; set; }

        public short? varianteNumDigitos { get; set; }

        public string varianteSeparador { get; set; }

        public bool? varianteSelecionaTodos { get; set; }

        public string MPClasseProd { get; set; }

        public string MPTerceiroProd { get; set; }

        public bool? MPJuntaDesvioSaida { get; set; }

        public string SCDocSaida { get; set; }

        public string SCDocDesvio { get; set; }

        public string SCDocSobra { get; set; }

        public bool? MPTemRuptura { get; set; }

        public bool? ControlaStockPA { get; set; }

        public string MecanicoOrc { get; set; }

        public bool? AcpPorPlano { get; set; }

        public bool? AcpPorEnc { get; set; }

        public string DocEncomendaPrev { get; set; }

        public bool? PlanosStockPA_parciais { get; set; }

        public string DocEmbalamento { get; set; }

        public bool? ligaEmbala_AcpSC { get; set; }

        public bool? ligaEmbala_AcpInterno { get; set; }

        public string ArmPrev { get; set; }

        public bool? AdminAnulaAcp { get; set; }

        public short? DocFTConsumoTipo { get; set; }

        public bool? GuardaImagemOriginal { get; set; }

        public bool? AcpEncQtdFecha { get; set; }

        public bool? AcpGeraDocs { get; set; }

        public int? Solas { get; set; }

        public bool? UsaPlaneamento { get; set; }

        public bool? GuardaImagemFicheiro { get; set; }

        public int? NumSemanasVisiveis { get; set; }

        public string LinkLinhadoTempo { get; set; }

        public string PlaneamentoUser { get; set; }

        public string PlaneamentoPwd { get; set; }

        public string EndPointAPI { get; set; }

        public string PlaneiaTodasFases { get; set; }

        public string TipoDocPlaneamento { get; set; }

        public bool Plan_SoEncComPlano { get; set; }

        public int PDATipoLeitura { get; set; }

    }

}