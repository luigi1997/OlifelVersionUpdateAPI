using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("AmbGuiasModeGar")]
    public class AmbGuiasModeGar
    {
        public string NumeroGuia { get; set; }

        public string CodigoVerificacao { get; set; }

        public DateTime? DataCriacao { get; set; }

        public short? RecEnv { get; set; }

        public string ProdClasse { get; set; }

        public string ProdTerceiro { get; set; }

        public string ProdNome { get; set; }

        public string ProdMorada { get; set; }

        public string ProdTelefone { get; set; }

        public string ProdFax { get; set; }

        public string ProdTelex { get; set; }

        public string ProdContacto { get; set; }

        public string ProdNIF { get; set; }

        public string LERVersao { get; set; }

        public string LERCodigo { get; set; }

        public short? LEREstado { get; set; }

        public string DESVersao { get; set; }

        public string DESCodigo { get; set; }

        public double? ProdQuant { get; set; }

        public string ProdUnMed { get; set; }

        public DateTime? ProdData { get; set; }

        public string TranClasse { get; set; }

        public string TranTerceiro { get; set; }

        public string TranNome { get; set; }

        public string TranMorada { get; set; }

        public string TranTelefone { get; set; }

        public string TranFax { get; set; }

        public string TranTelex { get; set; }

        public string TranContacto { get; set; }

        public string TranNIF { get; set; }

        public string TranMeioTrans { get; set; }

        public int? TranNumEmb { get; set; }

        public bool? TranCheck01 { get; set; }

        public bool? TranCheck02 { get; set; }

        public bool? TranCheck03 { get; set; }

        public bool? TranCheck04 { get; set; }

        public bool? TranCheck05 { get; set; }

        public bool? TranCheck06 { get; set; }

        public bool? TranCheck07 { get; set; }

        public bool? TranCheck08 { get; set; }

        public bool? TranCheck09 { get; set; }

        public bool? TranCheck10 { get; set; }

        public bool? TranCheck11 { get; set; }

        public bool? TranCheck12 { get; set; }

        public bool? TranCheck13 { get; set; }

        public bool? TranCheck14 { get; set; }

        public bool? TranCheck15 { get; set; }

        public bool? TranCheck16 { get; set; }

        public bool? TranCheck17 { get; set; }

        public bool? TranCheck18 { get; set; }

        public bool? TranCheck19 { get; set; }

        public bool? TranCheck20 { get; set; }

        public string OutroTipo { get; set; }

        public string OutroMaterial { get; set; }

        public DateTime? TranData { get; set; }

        public string DestClasse { get; set; }

        public string DestTerceiro { get; set; }

        public string DestNome { get; set; }

        public string DestMorada { get; set; }

        public string DestTelefone { get; set; }

        public string DestFax { get; set; }

        public string DestTelex { get; set; }

        public string DestContacto { get; set; }

        public string DestNIF { get; set; }

        public DateTime? RecData { get; set; }

        public string DestMeioTrans { get; set; }

        public double? DestQuant { get; set; }

        public string DestUnMed { get; set; }

        public DateTime? DestData { get; set; }

        public string DestMotivo { get; set; }

        public string obs { get; set; }

        [Key]
        public int recno { get; set; }

        public string TDBase { get; set; }

        public short? SDBase { get; set; }

        public int? NDBase { get; set; }

        public bool? FoiEnviado { get; set; }

        public DateTime? DataCria { get; set; }

        public DateTime? DtUpdate { get; set; }

        public DateTime? HrUpdate { get; set; }

        public string TipoDoc { get; set; }

        public short? Serie { get; set; }

        public int? NumDoc { get; set; }

        public string ImgFileName { get; set; }

        public byte[] ImgImagem { get; set; }

        public string EstabelecimentoProd { get; set; }

        public string EstabProdMorada { get; set; }

        public string TipoInterveniente { get; set; }

        public string TipoProdutor { get; set; }

        public string EstabelecimentoDest { get; set; }

        public string EstabDestMorada { get; set; }

        public string EstadoGuia { get; set; }

        public string EstadoGuiaDesc { get; set; }

        public DateTime? DataEstado { get; set; }

        public DateTime? DestDataAceite { get; set; }

        public DateTime? DestHoraAceite { get; set; }

        public DateTime? DestDataRejeitada { get; set; }

        public DateTime? DestDataConcluida { get; set; }

        public DateTime? TransDataTransporte { get; set; }

        public DateTime? TransHoraIniTrans { get; set; }

        public string TransMatricula { get; set; }

        public string Url { get; set; }

        public string ResLerCorrigido { get; set; }

        public string ResOpCorrigido { get; set; }

        public double? ResQtdCorrigido { get; set; }

        public string ResLerDescCorrigido { get; set; }

        public string ResOpDescCorrigido { get; set; }

        public string ComentarioRem { get; set; }

        public string ComentarioDes { get; set; }

        public bool? PendenteAutoriza { get; set; }

        public DateTime? DataFimTrans { get; set; }

        public DateTime? HoraFimTrans { get; set; }

        public bool? lGuiaExterna { get; set; }
        public string LERDescritivo { get; set; }

    }

}
