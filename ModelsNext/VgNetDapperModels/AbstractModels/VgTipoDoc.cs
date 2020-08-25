using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using VgNetDapperModels.Helpers;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.AbstractModels
{
    public abstract class VgTipoDoc<TDC,TDL,TDG> : IVgTipoDoc
                where TDC : ITDClasse
                where TDL : ITDLiga
                where TDG : IVgTDGera
    {
        public enum TipoMorada
        {
            None = 0,
            Empresa = 1,
            Armazem = 2,
            Terceiro = 3
        }

        #region table fields

        public string TipoDoc { get; set; }

        public string Designacao { get; set; }

        public string Abreviatura { get; set; }

        public int? ClasseTD { get; set; }

        public short? Natureza { get; set; }

        public short? NumDigitos { get; set; }

        public int? NumVias { get; set; }

        public string Armazem { get; set; }

        public string Classe { get; set; }

        public string Terceiro { get; set; }

        public string Mensagem { get; set; }

        public double? MargLin { get; set; }

        public double? MargDoc { get; set; }

        public bool? DocActivo { get; set; }

        public bool? CtrlCredito { get; set; }

        public bool? CtrlStock { get; set; }

        public bool? CtrlMargArt { get; set; }

        public bool? NaoSugereQtdPos { get; set; }

        public bool? CtrlDatas { get; set; }

        public bool? AcumTer { get; set; }

        public bool? AcumArt { get; set; }

        public bool? AcumVen { get; set; }

        public bool? ActPCU { get; set; }

        public bool? ActPCM { get; set; }

        public bool? ActPCP { get; set; }

        public bool? IsentoIVA { get; set; }

        public bool? TemIVA { get; set; }

        public bool? MovCCDeb { get; set; }

        public bool? MovCCCre { get; set; }

        public bool? MovCCVD { get; set; }

        public bool? TemTabDesc { get; set; }

        public bool? TemPoliCom { get; set; }

        public bool? TemTVD { get; set; }

        public bool? TemServico { get; set; }

        public bool? TemPortes { get; set; }

        public string ActStock { get; set; }

        public string ActEntEnc { get; set; }

        public string ActEntRes { get; set; }

        public string ActEntDev { get; set; }

        public string ActSaiEnc { get; set; }

        public string ActSaiRes { get; set; }

        public string ActSaiDev { get; set; }

        public string ActAcumCmp { get; set; }

        public string ActAcumVnd { get; set; }

        public string ActVend { get; set; }

        public bool? IntVend { get; set; }

        public bool? IntCondPag { get; set; }

        public bool? IntFormPag { get; set; }

        public bool? IntModExp { get; set; }

        public bool? IntMoeda { get; set; }

        public bool? IntDataVenc { get; set; }

        public bool? IntDescFin { get; set; }

        public bool? IntDescCom { get; set; }

        public bool? IntArred { get; set; }

        public bool? IntTroco { get; set; }

        public bool? IntProcesso { get; set; }

        public bool? IntDtEntrega { get; set; }

        public bool? TemMovTaras { get; set; }

        public bool? TemLotes { get; set; }

        public short? TipoPreco { get; set; }

        public string MovTaras { get; set; }

        public string ValTaras { get; set; }

        public short? VerPreco { get; set; }

        public string obs { get; set; }

        public string DesMov { get; set; }

        public string TxtMov { get; set; }

        public bool? RegIVA { get; set; }

        public bool? TemConta { get; set; }

        public string CtbDiario { get; set; }

        public bool? TemDesNum { get; set; }

        public bool? TemTerminal { get; set; }

        public short? NumTerminal { get; set; }

        public bool? MovCCP { get; set; }

        public string DocCCP { get; set; }

        public short? IntArtigo { get; set; }

        public bool? TemIRS { get; set; }

        public bool? TemArtJoin { get; set; }

        public int? CondPag { get; set; }

        public int? FormPag { get; set; }

        public bool? DocPOS { get; set; }

        public string Texto { get; set; }

        public string Imagem { get; set; }

        public int? Cor { get; set; }

        public string FntName { get; set; }

        public short? FntSize { get; set; }

        public bool? FntBld { get; set; }

        public bool? FntItl { get; set; }

        public bool? FntUnd { get; set; }

        public bool? FntStr { get; set; }

        public string txtTer { get; set; }

        public string txtVen { get; set; }

        public int? CorTexto { get; set; }

        public string ActAcumPOS { get; set; }

        public int? BtnTer { get; set; }

        public bool? CmmActivo { get; set; }

        public int? Script { get; set; }

        public bool? TemLista { get; set; }

        public bool? AbreGaveta { get; set; }

        public bool? DocProduz { get; set; }

        public string TDProd { get; set; }

        public string TDComp { get; set; }

        public string TDDestino { get; set; }

        public bool? AvisaQuant { get; set; }

        public bool? AvisaPreco { get; set; }

        public string IDScriptTD { get; set; }

        public string ActPontosVal { get; set; }

        public string ActPontosQtd { get; set; }

        public string ActTarefaVal { get; set; }

        public string ActTarefaQtd { get; set; }

        public bool? CriaArtigo { get; set; }

        public int? Familia { get; set; }

        public bool? TemConcluiTarefa { get; set; }

        public bool? TemConcluiDoc { get; set; }

        public bool? PesqArtCod { get; set; }

        public bool? PesqArtCodBar { get; set; }

        public bool? PesqArtRef { get; set; }

        public bool? PesqArtRecno { get; set; }

        public bool? PesqArtTer { get; set; }

        public bool? BloqAltPOS { get; set; }

        public bool? BloqueiaPeso { get; set; }

        public bool? CtbNumDiario { get; set; }

        public bool? TemResiduos { get; set; }

        public bool? ambGeraGuia { get; set; }

        public bool? ambConfirma { get; set; }

        public bool? CarCabObr { get; set; }

        public bool? CarLinObr { get; set; }

        public bool? DocValZero { get; set; }

        public bool? DocValNeg { get; set; }

        public string txtProcesso { get; set; }

        public int? GenericoCab { get; set; }

        public int? GenericoLin { get; set; }

        public int? TabIVA { get; set; }

        public short? IconPeq { get; set; }

        public short? IconGra { get; set; }

        public bool? TemTabPrecos { get; set; }

        public int? Etiqueta { get; set; }

        public bool? temSAFT { get; set; }

        public bool? temAssinatura { get; set; }

        public bool? isConferencia { get; set; }

        public bool? temConcluiDocBase { get; set; }

        public bool? temValores { get; set; }

        public int? Tipologia { get; set; }

        public bool? TemRegulariza { get; set; }

        public string DocRegulariza { get; set; }

        public bool? TemResTaras { get; set; }

        public int? UnMedEntSai { get; set; }

        public string InvoiceStatus { get; set; }

        public string InvoiceType { get; set; }

        public bool? isAutoFactura { get; set; }

        public bool? ActTabPrecos { get; set; }

        public bool? DescontoMargemForte { get; set; }

        public bool? TemMinimiza { get; set; }

        public string GrupoDoc { get; set; }

        public int? TipoMorCarga { get; set; }

        public int? TipoMorDescarga { get; set; }

        public int? TipoGeraDocs { get; set; }

        public bool? temNumMensal { get; set; }

        public bool? temNumAnual { get; set; }

        public bool? ArtCtbTipo0 { get; set; }

        public bool? ArtCtbTipo1 { get; set; }

        public bool? ArtCtbTipo2 { get; set; }
        public bool? ArtCtbTipo3 { get; set; }
        public bool? ArtCtbTipo4 { get; set; }
        public bool? ArtCtbTipo5 { get; set; }
        public bool? ArtCtbTipo6 { get; set; }
        public bool? ArtCtbTipo7 { get; set; }       

        public bool? TemConsTamCor { get; set; }

        public bool? TemLigaDocCab { get; set; }

        public bool? TemLigaShowAll { get; set; }

        public bool? TemInputGrid { get; set; }

        public bool? ObrDocBase { get; set; }

        public int? Estado { get; set; }

        public int? Origem { get; set; }

        public string CorFundo { get; set; }

        public int? Rubrica { get; set; }

        public bool? MovementStock { get; set; }

        public int? MovementType { get; set; }

        public int? MovementStatus { get; set; }

        public int? intervaloCarga { get; set; }

        public int? intervaloDescarga { get; set; }

        public bool? TemIVACaixa { get; set; }

        public string ValStock { get; set; }

        public bool? TemPoliComDesc { get; set; }

        public bool? TemAddTamCor { get; set; }

        public string emailArquivo { get; set; }

        public bool? emailArqPorTer { get; set; }

        public string emailSendTo { get; set; }

        public string emailCC { get; set; }

        public string emailBCC { get; set; }

        public string emailAssunto { get; set; }

        public string emailCorpo { get; set; }

        public string emailAssina { get; set; }

        public bool? Pede2Pesagem { get; set; }

        public int? TipoDePesagem { get; set; }
        public bool? PermitePesagemManual { get; set; }

        public bool? PermiteAssociarEgar { get; set; }

        #endregion

        [Computed]
        public IList<TDC> TDClasses { get; set; }
        [Computed]
        public IList<TDL> TDLiga { get; set; }

        [Computed]
        public IList<TDG> TDGera { get; set; }

        public List<int> GetTiposArtigo()
        {
            List<int> result = new List<int>();
            bool[] tipoConfig = new bool[] {
                ArtCtbTipo0 == true,
                ArtCtbTipo1 == true,
                ArtCtbTipo2 == true,
                ArtCtbTipo3 == true,
                ArtCtbTipo4 == true,
                ArtCtbTipo5 == true,
                ArtCtbTipo6 == true,
                ArtCtbTipo7 == true
            };

            for (int i = 0; i < tipoConfig.Length; i++)
            {
                if (tipoConfig[i])
                    result.Add(i);
            }
            return result;
        }

        public string getTDActCC()
        {
            return Utils.getChar(MovCCCre) + Utils.getChar(MovCCDeb) + Utils.getChar(MovCCVD) +
                   Utils.getChar(ActAcumCmp) + Utils.getChar(ActAcumVnd) + Utils.getChar(ActAcumPOS) +
                   Utils.getChar(ActPontosQtd) + Utils.getChar(ActPontosVal);
        }

        public string getTDActStk()
        {
            return Utils.getChar(ActEntDev) + Utils.getChar(ActEntEnc) + Utils.getChar(ActEntRes) +
                   Utils.getChar(ActSaiDev) + Utils.getChar(ActSaiEnc) + Utils.getChar(ActSaiRes) +
                   Utils.getChar(ActPCM) + Utils.getChar(ActPCP) + Utils.getChar(ActPCU) + Utils.getChar(ActStock);
        }

        public string getTDActTar()
        {
            return Utils.getChar(MovTaras) + Utils.getChar(ValTaras);
        }

        public string getTDActBase()
        {
            return Utils.getChar(temConcluiDocBase);
        }

        public List<int> GetArtCtbTipos()
        {
            return GetArtCtbTipos(ArtCtbTipo0, ArtCtbTipo1, ArtCtbTipo2, ArtCtbTipo3, ArtCtbTipo4, ArtCtbTipo5, ArtCtbTipo6, ArtCtbTipo7);
        }

        public static List<int> GetArtCtbTipos(bool? ctbTipo0, bool? ctbTipo1, bool? ctbTipo2, bool? ctbTipo3, bool? ctbTipo4, bool? ctbTipo5, bool? ctbTipo6, bool? ctbTipo7)
        {
            List<int> rs = new List<int>();
            if (ctbTipo0 == true)
                rs.Add(0);
            if (ctbTipo1 == true)
                rs.Add(1);
            if (ctbTipo2 == true)
                rs.Add(2);
            if (ctbTipo3 == true)
                rs.Add(3);
            if (ctbTipo4 == true)
                rs.Add(4);
            if (ctbTipo5 == true)
                rs.Add(5);
            if (ctbTipo6 == true)
                rs.Add(6);
            if (ctbTipo7 == true)
                rs.Add(7);

            return rs;
        }
    }
}