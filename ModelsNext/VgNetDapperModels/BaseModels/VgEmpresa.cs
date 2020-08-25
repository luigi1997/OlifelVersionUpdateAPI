using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("Empresas")]
    public class VgEmpresa
    {
        public string Empresa { get; set; }

        public string Abreviatura { get; set; }

        public string Nome { get; set; }

        public string NomeComercial { get; set; }

        public string Morada { get; set; }

        public string Localidade { get; set; }

        public string CodPostal { get; set; }

        public string CPLocal { get; set; }

        public string Telefone { get; set; }

        public string Fax { get; set; }

        public string HomePage { get; set; }

        public string eMail { get; set; }

        public string ActPrincipal { get; set; }

        public string NIF { get; set; }

        public string CAE { get; set; }

        public string Concelho { get; set; }

        public string BairroFiscal { get; set; }

        public string CodRepFin { get; set; }

        public string Conservatoria { get; set; }

        public string Matricula { get; set; }

        public string CapSocial { get; set; }

        public string Logotipo { get; set; }

        public short? AnoExercicio { get; set; }

        public DateTime? DtInicio { get; set; }

        public DateTime? DtFim { get; set; }

        public DateTime? DtIniActividade { get; set; }

        public bool? FechoAno { get; set; }

        public byte? FormatoBD { get; set; }

        public string MoedaBase { get; set; }

        public string DirEmpresa { get; set; }

        public string DirAReceber { get; set; }

        public string DirRecebidas { get; set; }

        public string DirAEnviar { get; set; }

        public string DirEnviadas { get; set; }

        public bool? GeralGestaoMoedas { get; set; }

        public bool? GeralGestaoCambial { get; set; }

        public bool? GeralGestaoObras { get; set; }

        public bool? GeralGestaoProducao { get; set; }

        public bool? GeralFaseArranque { get; set; }

        public byte? StkDigitos { get; set; }

        public byte? StkDecQuant { get; set; }

        public byte? StkDecValor { get; set; }

        public byte? StkDecArred { get; set; }

        public byte? StkRuptura { get; set; }

        public byte? StkMargem { get; set; }

        public bool? Stk2Unid { get; set; }

        public bool? StkNegativo { get; set; }

        public bool? StkMedidas { get; set; }

        public bool? StkModTamCor { get; set; }

        public bool? StkPrCustoPadrao { get; set; }

        public bool? StkConsultaMovs { get; set; }

        public bool? StkAprovisionamento { get; set; }

        public bool? StkFichaTecnica { get; set; }

        public bool? StkLotes { get; set; }

        public byte? DocRuptura { get; set; }

        public byte? DocMargLin { get; set; }

        public byte? DocMargDoc { get; set; }

        public bool? DocGestaoVend { get; set; }

        public byte? DocComissoes { get; set; }

        public byte? DocDescExtra { get; set; }

        public string DocVndCla { get; set; }

        public string DocVndCom { get; set; }

        public string DocQtdReg1 { get; set; }

        public string DocQtdReg2 { get; set; }

        public string DocQtdReg3 { get; set; }

        public string DocQtdReg4 { get; set; }

        public string DocQtdReg5 { get; set; }

        public byte? TerDigitos { get; set; }

        public bool? TerGestaoGrupos { get; set; }

        public bool? TerConsultaMovs { get; set; }

        public bool? TerMaisMoradas { get; set; }

        public bool? TerInfoComerciais { get; set; }

        public bool? TerPrecosTerceiro { get; set; }

        public bool? TerEventos { get; set; }

        public short? CtbApp { get; set; }

        public string CtbEmp { get; set; }

        public bool? CtbOnline { get; set; }

        public string CtbFxParam { get; set; }

        public bool? CtbOrdTer { get; set; }

        public bool? Activa { get; set; }

        public string Admin { get; set; }

        public DateTime? DatBackup { get; set; }

        public string Obs { get; set; }

        public int recno { get; set; }

        public DateTime? ProdDiaH { get; set; }

        public double? ProdDiaQ { get; set; }

        public bool? SQLBackup { get; set; }

        public string BackupPath { get; set; }

        public string BackUser { get; set; }

        public string BackPosto { get; set; }

        public short? DBBackMin { get; set; }

        public DateTime? DBBackData { get; set; }

        public DateTime? DBBackHora { get; set; }

        public byte? DiffBackNum { get; set; }

        public short? DiffBackMin { get; set; }

        public DateTime? DiffBackData { get; set; }

        public DateTime? DiffBackHora { get; set; }

        public short? LogBackMin { get; set; }

        public DateTime? LogBackData { get; set; }

        public DateTime? LogBackHora { get; set; }

        public byte? LogBackNum { get; set; }

        public string CodiporPais { get; set; }

        public string CodiporEmp { get; set; }

        public int? CodiporNum { get; set; }

        public short? CodiporCod { get; set; }

        public bool? StkClassCod { get; set; }

        public bool? StkClassDes { get; set; }

        public DateTime? DatDia { get; set; }

        public string ClassifCod { get; set; }

        public string ClassifDesc { get; set; }

        public string ClassifCar { get; set; }

        public short? ModeloNumCar { get; set; }

        public int? ModeloFiltro { get; set; }

        public short? ModeloVersaoNumCar { get; set; }

        public bool? RegularizaRetIRS { get; set; }

        public string ambRecProdCla { get; set; }

        public string ambRecProdTer { get; set; }

        public string ambRecTransCla { get; set; }

        public string ambRecTransTer { get; set; }

        public string ambRecDestCla { get; set; }

        public string ambRecDestTer { get; set; }

        public string ambEnvProdCla { get; set; }

        public string ambEnvProdTer { get; set; }

        public string ambEnvTransCla { get; set; }

        public string ambEnvTransTer { get; set; }

        public string ambEnvDestCla { get; set; }

        public string ambEnvDestTer { get; set; }

        public byte? NivAutStkRuptura { get; set; }

        public byte? NivAutStkMargem { get; set; }

        public byte? NivAutDocRuptura { get; set; }

        public byte? NivAutDocMargLin { get; set; }

        public byte? NivAutDocMargDoc { get; set; }

        public byte? NivAutPesoInput { get; set; }

        public byte? NivAutDocElimina { get; set; }

        public byte? NivAutDocRecupera { get; set; }

        public byte? NivAutTerBloqueio { get; set; }

        public byte? NivAutTerRuptura { get; set; }

        public bool? TemSAFT { get; set; }

        public int? TabIVA { get; set; }

        public int? MoradaTerceiro { get; set; }

        public bool? isDemo { get; set; }

        public bool? isCertificada { get; set; }

        public DateTime? dtCertificada { get; set; }

        public string PathCertificado { get; set; }

        public string NomeCertificado { get; set; }

        public string EmissorCertificado { get; set; }

        public DateTime? DataCertificado { get; set; }

        public string smtpServer { get; set; }

        public string smtpPort { get; set; }

        public string smtpUser { get; set; }

        public string smtpPass { get; set; }

        public string smtpMail { get; set; }

        public bool? smtpEnableSSL { get; set; }

        public string anexosPastaArquivo { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string imagensPastaArquivo { get; set; }

        public int? FSPeriodo { get; set; }

        public int? FSMargem { get; set; }

        public int? FSAviso { get; set; }

        public int? FSNotifica { get; set; }

        public DateTime? FSAtivacao { get; set; }

        public bool? lUsaModeloBase { get; set; }

        public string sTokeneGar { get; set; }
        public string sPasswdeGar { get; set; }
        public string estabelecimento { get; set; }
        public string sPathPdfeGar { get; set; }
        public string EstApaProd { get; set; }
        public string EstApaDest { get; set; }
        public bool? leGarTestID { get; set; }
        public bool? isUsaProxy { get; set; }

    }

}