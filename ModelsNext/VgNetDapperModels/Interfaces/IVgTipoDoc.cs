using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IVgTipoDoc
    {
         string TipoDoc { get; set; }

         string Designacao { get; set; }

         string Abreviatura { get; set; }

         int? ClasseTD { get; set; }

         short? Natureza { get; set; }

         short? NumDigitos { get; set; }

         int? NumVias { get; set; }

         string Armazem { get; set; }

         string Classe { get; set; }

         string Terceiro { get; set; }

         string Mensagem { get; set; }

         double? MargLin { get; set; }

         double? MargDoc { get; set; }

         bool? DocActivo { get; set; }

         bool? CtrlCredito { get; set; }

         bool? CtrlStock { get; set; }

         bool? CtrlMargArt { get; set; }

         bool? NaoSugereQtdPos { get; set; }

         bool? CtrlDatas { get; set; }

         bool? AcumTer { get; set; }

         bool? AcumArt { get; set; }

         bool? AcumVen { get; set; }

         bool? ActPCU { get; set; }

         bool? ActPCM { get; set; }

         bool? ActPCP { get; set; }

         bool? IsentoIVA { get; set; }

         bool? TemIVA { get; set; }

         bool? MovCCDeb { get; set; }

         bool? MovCCCre { get; set; }

         bool? MovCCVD { get; set; }

         bool? TemTabDesc { get; set; }

         bool? TemPoliCom { get; set; }

         bool? TemTVD { get; set; }

         bool? TemServico { get; set; }

         bool? TemPortes { get; set; }

         string ActStock { get; set; }

         string ActEntEnc { get; set; }

         string ActEntRes { get; set; }

         string ActEntDev { get; set; }

         string ActSaiEnc { get; set; }

         string ActSaiRes { get; set; }

         string ActSaiDev { get; set; }

         string ActAcumCmp { get; set; }

         string ActAcumVnd { get; set; }

         string ActVend { get; set; }

         bool? IntVend { get; set; }

         bool? IntCondPag { get; set; }

         bool? IntFormPag { get; set; }

         bool? IntModExp { get; set; }

         bool? IntMoeda { get; set; }

         bool? IntDataVenc { get; set; }

         bool? IntDescFin { get; set; }

         bool? IntDescCom { get; set; }

         bool? IntArred { get; set; }

         bool? IntTroco { get; set; }

         bool? IntProcesso { get; set; }

         bool? IntDtEntrega { get; set; }

         bool? TemMovTaras { get; set; }

         bool? TemLotes { get; set; }

         short? TipoPreco { get; set; }

         string MovTaras { get; set; }

         string ValTaras { get; set; }

         short? VerPreco { get; set; }

         string obs { get; set; }

         string DesMov { get; set; }

         string TxtMov { get; set; }

         bool? RegIVA { get; set; }

         bool? TemConta { get; set; }

         string CtbDiario { get; set; }

         bool? TemDesNum { get; set; }

         bool? TemTerminal { get; set; }

         short? NumTerminal { get; set; }

         bool? MovCCP { get; set; }

         string DocCCP { get; set; }

         short? IntArtigo { get; set; }

         bool? TemIRS { get; set; }

         bool? TemArtJoin { get; set; }

         int? CondPag { get; set; }

         int? FormPag { get; set; }

         bool? DocPOS { get; set; }

         string Texto { get; set; }

         string Imagem { get; set; }

         int? Cor { get; set; }

         string FntName { get; set; }

         short? FntSize { get; set; }

         bool? FntBld { get; set; }

         bool? FntItl { get; set; }

         bool? FntUnd { get; set; }

         bool? FntStr { get; set; }

         string txtTer { get; set; }

         string txtVen { get; set; }

         int? CorTexto { get; set; }

         string ActAcumPOS { get; set; }

         int? BtnTer { get; set; }

         bool? CmmActivo { get; set; }

         int? Script { get; set; }

         bool? TemLista { get; set; }

         bool? AbreGaveta { get; set; }

         bool? DocProduz { get; set; }

         string TDProd { get; set; }

         string TDComp { get; set; }

         string TDDestino { get; set; }

         bool? AvisaQuant { get; set; }

         bool? AvisaPreco { get; set; }

         string IDScriptTD { get; set; }

         string ActPontosVal { get; set; }

         string ActPontosQtd { get; set; }

         string ActTarefaVal { get; set; }

         string ActTarefaQtd { get; set; }

         bool? CriaArtigo { get; set; }

         int? Familia { get; set; }

         bool? TemConcluiTarefa { get; set; }

         bool? TemConcluiDoc { get; set; }

         bool? PesqArtCod { get; set; }

         bool? PesqArtCodBar { get; set; }

         bool? PesqArtRef { get; set; }

         bool? PesqArtRecno { get; set; }

         bool? PesqArtTer { get; set; }

         bool? BloqAltPOS { get; set; }

         bool? BloqueiaPeso { get; set; }

         bool? CtbNumDiario { get; set; }

         bool? TemResiduos { get; set; }

         bool? ambGeraGuia { get; set; }

         bool? ambConfirma { get; set; }

         bool? CarCabObr { get; set; }

         bool? CarLinObr { get; set; }

         bool? DocValZero { get; set; }

         bool? DocValNeg { get; set; }

         string txtProcesso { get; set; }

         int? GenericoCab { get; set; }

         int? GenericoLin { get; set; }

         int? TabIVA { get; set; }

         short? IconPeq { get; set; }

         short? IconGra { get; set; }

         bool? TemTabPrecos { get; set; }

         int? Etiqueta { get; set; }

         bool? temSAFT { get; set; }

         bool? temAssinatura { get; set; }

         bool? isConferencia { get; set; }

         bool? temConcluiDocBase { get; set; }

         bool? temValores { get; set; }

         int? Tipologia { get; set; }

         bool? TemRegulariza { get; set; }

         string DocRegulariza { get; set; }

         bool? TemResTaras { get; set; }

         int? UnMedEntSai { get; set; }

         string InvoiceStatus { get; set; }

         string InvoiceType { get; set; }

         bool? isAutoFactura { get; set; }

         bool? ActTabPrecos { get; set; }

         bool? DescontoMargemForte { get; set; }

         bool? TemMinimiza { get; set; }

         string GrupoDoc { get; set; }

         int? TipoMorCarga { get; set; }

         int? TipoMorDescarga { get; set; }

         int? TipoGeraDocs { get; set; }

         bool? temNumMensal { get; set; }

         bool? temNumAnual { get; set; }

         bool? ArtCtbTipo0 { get; set; }

         bool? ArtCtbTipo1 { get; set; }

         bool? ArtCtbTipo2 { get; set; }

         bool? ArtCtbTipo6 { get; set; }

         bool? TemConsTamCor { get; set; }

         bool? TemLigaDocCab { get; set; }

         bool? TemLigaShowAll { get; set; }

         bool? TemInputGrid { get; set; }

         bool? ObrDocBase { get; set; }

         int? Estado { get; set; }

         int? Origem { get; set; }

         string CorFundo { get; set; }

         int? Rubrica { get; set; }

         bool? MovementStock { get; set; }

         int? MovementType { get; set; }

         int? MovementStatus { get; set; }

         int? intervaloCarga { get; set; }

         int? intervaloDescarga { get; set; }

         bool? TemIVACaixa { get; set; }

         string ValStock { get; set; }

         bool? TemPoliComDesc { get; set; }

         bool? TemAddTamCor { get; set; }

         string emailArquivo { get; set; }

         bool? emailArqPorTer { get; set; }

         string emailSendTo { get; set; }

         string emailCC { get; set; }

         string emailBCC { get; set; }

         string emailAssunto { get; set; }

         string emailCorpo { get; set; }

         string emailAssina { get; set; }
         bool? Pede2Pesagem { get; set; }

        bool? PermiteAssociarEgar { get; set; }

        int? TipoDePesagem { get; set; }
         bool? PermitePesagemManual { get; set; }
    }
}
