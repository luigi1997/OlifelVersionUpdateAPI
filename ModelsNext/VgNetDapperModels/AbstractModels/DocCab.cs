using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VgNetDapperModels.AbstractModels
{
    [Table("DocCab")]
    public abstract class DocCab<DLIN, DL, DLS, DLTC, DLSI, DocLigaTC, DP, DF, DIVA, DLDR, DLEG, DLE, DLPlanos, DLPlanosTC>
        where DLIN : Interfaces.IDocLin
        where DL : Interfaces.IDocLiga
        where DLS : Interfaces.IVgDocLinSortido
        where DLSI : Interfaces.IDocLinSortItem
        where DLTC : Interfaces.IVgDocLinTamCor
        where DocLigaTC : Interfaces.IDocLigaTamCor
        where DP : Interfaces.IVgDocPag
        where DF : Interfaces.IDocFile
        where DIVA : Interfaces.IDocIVA
        where DLDR : Interfaces.IDocLinDescResiduos
        where DLEG : Interfaces.IDocLigaEgar
        where DLE : Interfaces.IDocLigaEmb
        where DLPlanos : Interfaces.IDocLigaPlanos
        where DLPlanosTC : Interfaces.IDocLigaPlanosTamCor
    {

        #region Table fields

        [ExplicitKey]
        public string TipoDoc { get; set; }
        [ExplicitKey]
        public int Ano { get; set; }
        [ExplicitKey]
        public short Mes { get; set; }
        [ExplicitKey]
        public int NumDoc { get; set; }

        public int? Natureza { get; set; }

        public string Armazem { get; set; }

        public DateTime? DataDoc { get; set; }

        public DateTime? DataVnc { get; set; }

        public string Classe { get; set; }

        public string Terceiro { get; set; }

        public string Nome { get; set; }

        public string NIF { get; set; }

        public string MoradaDoc { get; set; }

        public string LocalDoc { get; set; }

        public string CodPostDoc { get; set; }

        public string LocPostDoc { get; set; }

        public string MorPaisDoc { get; set; }

        public string MorEANDoc { get; set; }

        public string Moeda { get; set; }

        public double? Cambio { get; set; }

        public int? CondPag { get; set; }

        public int? FormPag { get; set; }

        public int? ModExp { get; set; }

        public string Vendedor { get; set; }

        public string Processo { get; set; }

        public string ArmDest { get; set; }

        public string PerDescCom { get; set; }

        public double? ValDescCom { get; set; }

        public string PerDescFin { get; set; }

        public double? ValDescFin { get; set; }

        public double? Arredond { get; set; }

        public double? TotalMercadoria { get; set; }

        public double? TotalSujeito { get; set; }

        public double? TotalIVA { get; set; }

        public double? TotalDoc { get; set; }

        public double? TotalReg { get; set; }

        public DateTime? DataCarga { get; set; }

        public DateTime? HoraCarga { get; set; }

        public DateTime? DataDescarga { get; set; }

        public DateTime? HoraDescarga { get; set; }

        public int? MorCargaID { get; set; }

        public string MoradaCarga { get; set; }

        public string LocalCarga { get; set; }

        public string CodPostCarga { get; set; }

        public string LocPostCarga { get; set; }

        public string MorPaisCarga { get; set; }

        public string MorEANCarga { get; set; }

        public int? MorDescargaID { get; set; }

        public string MoradaDescarga { get; set; }

        public string LocalDescarga { get; set; }

        public string CodPostDescarga { get; set; }

        public string LocPostDescarga { get; set; }

        public string MorPaisDescarga { get; set; }

        public string MorEANDescarga { get; set; }

        public string ModoTrans { get; set; }

        public short? NumPrint { get; set; }

        public short? NumReg { get; set; }

        public DateTime? DataReg { get; set; }

        public DateTime? DataCria { get; set; }

        public DateTime? HoraCria { get; set; }

        public DateTime? DtUpdate { get; set; }

        public DateTime? HrUpdate { get; set; }

        public bool? FActStK { get; set; }

        public bool? FActTar { get; set; }

        public bool? FActCC { get; set; }

        public bool? FActVen { get; set; }

        public bool? FActCtb { get; set; }

        public bool? FAnulado { get; set; }

        public bool? FProcessa { get; set; }

        public bool? FGeracao { get; set; }

        public string ObsPrn { get; set; }

        public string Obs { get; set; }

        public double? ValorPago { get; set; }

        public double? Troco { get; set; }

        public double? TotalPortes { get; set; }

        public double? TotalDiversos { get; set; }

        public string DesMov { get; set; }

        public string CtbDiario { get; set; }

        public short? CtbTerTipo { get; set; }

        public double? TotalCom { get; set; }

        public double? RegCom { get; set; }

        public string DocOrig { get; set; }

        public DateTime? DatOrig { get; set; }

        public double? SujIRS { get; set; }

        public double? TaxIRS { get; set; }

        public double? RetIRS { get; set; }
        [Write(false)]
        public int recno { get; set; }

        public bool? FoiEnviado { get; set; }

        public bool? ConcluiDoc { get; set; }

        public DateTime? ConcluiData { get; set; }

        public string ConcluiUser { get; set; }

        public DateTime? AnulaData { get; set; }

        public string AnulaUser { get; set; }

        public string AnulaObs { get; set; }

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

        public int? Origem { get; set; }

        public int? Estado { get; set; }

        public double? TotalEcovalor { get; set; }

        public string Assinatura { get; set; }

        public string VersaoChave { get; set; }

        public string Certificado { get; set; }

        public DateTime? AssinadoEm { get; set; }

        public string AssinadoPor { get; set; }

        public string AssinaVGest { get; set; }

        public string TDActCC { get; set; }

        public string TDActStk { get; set; }

        public string TDActTar { get; set; }

        public string TDActBase { get; set; }

        public bool? TemResTaras { get; set; }

        public int? TabIVA { get; set; }

        public double? TotalDebito { get; set; }

        public double? TotalCredito { get; set; }

        public string MovCC { get; set; }

        public string CodPaisCarga { get; set; }

        public string CodPaisDescarga { get; set; }

        public string MorDoc { get; set; }

        public string MorCarga { get; set; }

        public string MorDescarga { get; set; }

        public string NomCarga { get; set; }

        public string NomDescarga { get; set; }

        public string AssinadoMsg { get; set; }

        public string ChaveDocCab { get; set; }

        public string AutorizaMsg { get; set; }

        public string AutorizaUsr { get; set; }

        public bool? EstadoFlag { get; set; }

        public string VersaoChave2 { get; set; }

        public string ATCodeID { get; set; }

        public int? ATSource { get; set; }

        public int? Rubrica { get; set; }

        public string ActStock { get; set; }

        public string CriadoPor { get; set; }

        public string GravadoPor { get; set; }

        public string ImpressoPor { get; set; }

        public DateTime? DataEnt { get; set; }
        [Write(false)]
        public byte[] Carimbo { get; set; }

        public byte[] QrCode { get; set; }

        public decimal? Distancia { get; set; }

        public int? MorDocID { get; set; }

        public string RepToken { get; set; }

        public DateTime? RepDtUpdate { get; set; }

        public DateTime? RepVisualizadoEm { get; set; }

        public bool? RepTemConfirmacao { get; set; }

        public bool? RepAlteraDataEntrega { get; set; }

        public DateTime? RepConfirmadoEm { get; set; }

        public DateTime? RepNovaDataEntrega { get; set; }

        public bool? ExportadoCTB { get; set; }

        public bool? ExportadoCtbResp { get; set; }

        public bool? RegularizadoSIni { get; set; }

        // tracker info
        public string NomeCargaTracker { get; set; }
        public string NomeDescargaTracker { get; set; }
        public DateTime? DataHoraTracker { get; set; }
        public byte[] AssinaturaTracker { get; set; }
        public string AspNetUserId { get; set; }
        //Matriculas Reciclagem
        public string Matricula1 { get; set; }
        public string Matricula2 { get; set; }
        public string MatriculaEGAR { get; set; }
        
        #endregion


        [Computed]
        public IList<DLIN> Lines { get; set; }

        [Computed]
        public IList<DF> DocFiles { get; set; }

        [Computed]
        public IList<DP> DocPagos { get; set; }

        [Computed]
        public IList<DLEG> DocEgars { get; set; }

        [Computed]
        public IList<DLE> DocLigaEmbs { get; set; }


        [Computed]
        public IList<DIVA> DocIVA { get; set; }

        [Computed]
        public IList<DL> DocLiga { get; set; }

        [Computed]
        public IList<DocLigaTC> DocLigaTamCor { get; set; }

        [Computed]
        public IList<DLPlanos> DocLigaPlanos { get; set; }

        [Computed]
        public IList<DLPlanosTC> DocLigaPlanosTamCor { get; set; }

        public string FmtDocID(short nDig, bool showtd = true, bool isFileName = false)
        {
            string result = "";

            if (showtd)
            {
                if (Mes.ToString().Equals("0"))
                    result = TipoDoc + " " + Ano + "/" + NumDoc.ToString().PadLeft(nDig, char.Parse("0"));
                else
                    result = TipoDoc + " " + Ano + Mes.ToString().PadLeft(2, char.Parse("0")) + "/" + NumDoc.ToString().PadLeft(nDig, char.Parse("0"));
            }
            else
            {
                if (Mes.ToString().Equals("0"))
                    result = Ano + "/" + NumDoc.ToString().PadLeft(nDig, char.Parse("0"));
                else
                    result = Ano + Mes.ToString().PadLeft(2, char.Parse("0")) + "/" + NumDoc.ToString().PadLeft(nDig, char.Parse("0"));
            }
            if (isFileName)
            {
                result = result.Replace(" ", "");
                result = result.Replace("/", "");
            }
            return result;
        }

        /// <summary>
        /// Recalcula somatorios do cabeçalho
        /// </summary>
        public void RecalculateTotals()
        {
            TotalMercadoria = Lines.ToList().Sum(x => x.ValMercadoria);
            TotalSujeito = Lines.ToList().Sum(x => x.ValSujeito);
            TotalIVA = Lines.ToList().Sum(x => x.ValIVA);
            ValDescCom = Lines.ToList().Sum(x => x.ValDesconto);
            TotalDoc = Lines.ToList().Sum(x => x.ValTotal);

            if (MovCC == "C")
            {
                TotalDebito = 0;
                TotalCredito = TotalDoc;
            }
            else if (MovCC == "D")
            {
                TotalDebito = TotalDoc;
                TotalCredito = 0;
            }
        }



    }

    public enum ATSource
    {
        NaoTem,
        Automatico,
        Manual
    }

}