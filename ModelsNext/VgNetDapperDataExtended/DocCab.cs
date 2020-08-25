using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VgNetDapperDataExtended.Helpers;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using VgNetDapperModels.RSAEncryption;
using Newtonsoft.Json;
//using CryptoSysPKI;

namespace VgNetDapperDataExtended
{
    [Table("DocCab")]
    public class DocCab : VgNetDapperModels.AbstractModels.DocCab<DocLin, DocLiga, VgDocLinSortido, VgDocLinTamCor, DocLinSortItem, DocLigaTamCor, VgDocPag, DocFile, DocIVA, DocLinDescResiduos, DocLigaEgar, DocLigaEmb, DocLigaPlanos, DocLigaPlanosTamCor>
    {


        /// <summary>
        /// Retorna Lista de linhas de compoem o documento
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public List<DocLin> getLines(IDbConnection connection, IDbTransaction transaction= null)
        {
            return connection.Query<DocLin>(
                "SELECT * FROM DocLin WHERE TipoDoc = @TipoDoc and Ano = @Ano and Mes = @Mes and NumDoc = @NumDoc",
                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes, NumDoc = NumDoc }, transaction).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public List<DocLigaEgar> getDocEgars(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<DocLigaEgar>(
                "SELECT * FROM DocLigaEgar WHERE TipoDoc = @TipoDoc and Ano = @Ano and Mes = @Mes and NumDoc = @NumDoc",
                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes, NumDoc = NumDoc }, transaction).ToList();
        }

        public List<DocLigaEmb> getDocLigaEmbs(IDbConnection connection)
        {
            return connection.Query<DocLigaEmb>(
                "SELECT * FROM DocLigaEmb WHERE TipoDoc = @TipoDoc and Ano = @Ano and Mes = @Mes and NumDoc = @NumDoc",
                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes, NumDoc = NumDoc }).ToList();
        }

        /// <summary>
        /// Retorna TODOS os campos de DocCab
        /// </summary>
        /// <param name="tipoDoc"></param>
        /// <param name="ano"></param>
        /// <param name="mes"></param>
        /// <param name="numdoc"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DocCab findByKey(string tipoDoc, int ano, int mes, int numdoc, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.QueryFirstOrDefault<DocCab>(
                "SELECT * FROM DocCab WHERE TipoDoc = @TipoDoc and Ano = @Ano and Mes = @Mes and NumDoc = @NumDoc",
                new { TipoDoc = tipoDoc, Ano = ano, Mes = mes, NumDoc = numdoc }, transaction);
        }


        /// <summary>
        /// Metodo que vai buscar Doccab Apenas mas sem os seguintes campos
        ///[QrCode]
        ///[NomeCargaTracker]
        ///[NomeDescargaTracker]
        ///[DataHoraTracker]
        ///[AssinaturaTracker]
        /// </summary>
        /// <param name="tipoDoc"></param>
        /// <param name="ano"></param>
        /// <param name="mes"></param>
        /// <param name="numdoc"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DocCab findByKeyLight(string tipoDoc, int ano, int mes, int numdoc, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.QueryFirstOrDefault<DocCab>(
                @"SELECT TipoDoc, Ano, Mes, NumDoc, Natureza, Armazem, DataDoc, DataVnc, Classe, 
                        Terceiro, Nome, NIF, MoradaDoc, LocalDoc, CodPostDoc, LocPostDoc, MorPaisDoc, 
                        MorEANDoc, Moeda, Cambio, CondPag, FormPag, ModExp, Vendedor, Processo, 
                        ArmDest, PerDescCom, ValDescCom, PerDescFin, ValDescFin, Arredond, TotalMercadoria, 
                        TotalSujeito, TotalIVA, TotalDoc, TotalReg, DataCarga, HoraCarga, DataDescarga, 
                        HoraDescarga, MoradaCarga, LocalCarga, CodPostCarga, LocPostCarga, MorPaisCarga, 
                        MorEANCarga, MoradaDescarga, LocalDescarga, CodPostDescarga, LocPostDescarga, 
                        MorPaisDescarga, MorEANDescarga, ModoTrans, NumPrint, NumReg, DataReg, DataCria, 
                        HoraCria, DtUpdate, HrUpdate, FActStK, FActTar, FActCC, FActVen, FActCtb, FAnulado, 
                        FProcessa, FGeracao, ObsPrn, Obs, ValorPago, Troco, TotalPortes, TotalDiversos, DesMov, 
                        CtbDiario, CtbTerTipo, TotalCom, RegCom, DocOrig, DatOrig, SujIRS, TaxIRS, RetIRS, recno, 
                        FoiEnviado, ConcluiDoc, ConcluiData, ConcluiUser, AnulaData, AnulaUser, AnulaObs, Geral0, 
                        Geral1, Geral2, Geral3, Geral4, Geral5, Geral6, Geral7, Geral8, Geral9, Origem, Estado, 
                        TotalEcovalor, Assinatura, VersaoChave, Certificado, AssinadoEm, AssinadoPor, AssinaVGest, 
                        TDActCC, TDActStk, TDActTar, TDActBase, TemResTaras, TabIVA, TotalDebito, TotalCredito, MovCC, 
                        CodPaisCarga, CodPaisDescarga, MorDoc, MorCarga, MorDescarga, NomCarga, NomDescarga, AssinadoMsg, 
                        ChaveDocCab, AutorizaMsg, AutorizaUsr, EstadoFlag, VersaoChave2, ATCodeID, ATSource, Rubrica, ActStock, 
                        CriadoPor, GravadoPor, ImpressoPor, DataEnt, Carimbo, Distancia, MorDocID, RepToken, RepDtUpdate, MorCargaID, 
                        MorDescargaID, RepVisualizadoEm, RepTemConfirmacao, RepAlteraDataEntrega, RepConfirmadoEm, RepNovaDataEntrega, 
                        ExportadoCTB, ExportadoCtbResp, RegularizadoSIni, DocsAdiantamento, isCtbDuvidoso, isCtbTitulos, DocRegCTB, 
                        isCtbOutrosDevCre, TotalRegC, TotalRegD, TotalRegO, ExportCtbUser, DataExportCtb, isCtbRegDuvidoso, 
                        isCtbRegTitulos, TotalRegTitulos, TotalRegDuvidosos, Matricula1, Matricula2, MatriculaEGAR 
                        FROM DocCab 
                        WHERE TipoDoc = @TipoDoc and Ano = @Ano and Mes = @Mes and NumDoc = @NumDoc",
                new { TipoDoc = tipoDoc, Ano = ano, Mes = mes, NumDoc = numdoc }, transaction);
        }

        /// <summary>
        /// This method can change at any time
        /// Please use only to demo or log pupose
        /// </summary>
        /// <returns></returns>
        public string getKeyAsString()
        {
            return $"{TipoDoc}-{Ano}-{Mes}-{NumDoc}";
        }
        public static short DocCab_getMes(VgTipoDoc myTipoDoc, DateTime myDate)
        {
            if (myTipoDoc.temNumMensal == true)
                return (short)myDate.Month;
            else
                return 0;
        }
        public VgTerceiro getTerceiro(IDbConnection connection)
        {
            return connection.QueryFirstOrDefault<VgTerceiro>(
                "SELECT * FROM Terceiros Where Classe = @Classe and Terceiro = @Terceiro",
                new { Classe = Classe, Terceiro = Terceiro });
        }
        public VgTipoDoc getTipoDoc(IDbConnection connection, IDbTransaction transaction = null)
        {
            return VgTipoDoc.findByKey(TipoDoc, connection, transaction);
        }

        public List<VgDocPag> GetDocPags(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<VgDocPag>(
                "select * from DocPag where TipoDoc = @TipoDoc and Ano = @Ano and Mes = @Mes and NumDoc = @NumDoc",
                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes, NumDoc = NumDoc }, transaction).ToList();
        }
        public List<DocLigaTamCor> getDocLigaTamCor(IDbConnection connection)
        {
            return connection.Query<DocLigaTamCor>(
                "SELECT * FROM DocLiga WHERE TipoDoc = @TipoDoc AND Ano = @Ano AND Mes = @Mes AND NumDoc = @NumDoc",
                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes, NumDoc = NumDoc }).ToList();
        }
        public List<DocLiga> getDocsLiga(IDbConnection connection)
        {
            return connection.Query<DocLiga>(
                "SELECT * FROM DocLiga WHERE TipoDoc = @TipoDoc AND Ano = @Ano AND Mes = @Mes AND NumDoc = @NumDoc",
                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes, NumDoc = NumDoc }).ToList();
        }

        public List<DocIVA> GetDocIVA(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<DocIVA>(
                "SELECT * FROM DocIVA WHERE TipoDoc = @TipoDoc AND Ano = @Ano AND Mes = @Mes AND NumDoc = @NumDoc",
                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes, NumDoc = NumDoc }, transaction).ToList();
        }

        public  List<TBTaxIVA> LoadTaxasIVA(IDbConnection connection, IDbConnection vgTabConnection, int? tabIVAID, string empresa)
        {
            string empresaFromConnection = empresa;
            using (vgTabConnection)
            {
                if (tabIVAID == null) tabIVAID = vgTabConnection.QueryFirstOrDefault<int?>(
                    "SELECT TabIva FROM Empresas WHERE Empresa = @Empresa",
                    new { Empresa = empresaFromConnection }); //VGGlobais.VGEmpresa.TabIVA;
            }
            if (tabIVAID == null) return null;

            
            DateTime dataDoc = DataDoc == null ? DateTime.Now : (DateTime)DataDoc;

            List <TBTaxIVA> taxas = new List<TBTaxIVA>();

            string tbTaxIVAQuery = "SELECT * FROM TBTaxIVA WHERE TabIVA = @TabIVA AND CodIVA = @CodIVA";
            if (TabIVA == tabIVAID && DocIVA.Count > 0)
            {
                foreach (DocIVA eachDocIVA in DocIVA)
                {

                    TBTaxIVA taxIVA = connection.QueryFirstOrDefault<TBTaxIVA>(tbTaxIVAQuery, new { TabIVA = tabIVAID, CodIVA = eachDocIVA.CodIVA });
                    if (taxIVA != null)
                        taxas.Add(taxIVA);
                }
            }
            else
            {
                TabIVA = tabIVAID;
                DocIVA.Clear();
                List<TBTabCodIVA> TBTabCodIVAFromDb = connection.Query<TBTabCodIVA>(
                    "SELECT * FROM TBTabCodIVA WHERE TabIVA = @TabIVA"
                    , new { TabIVA = tabIVAID }).ToList();
                foreach (TBTabCodIVA eachTabCodIVA in TBTabCodIVAFromDb)
                {

                    TBTaxIVA taxIVA = connection.QueryFirstOrDefault<TBTaxIVA>(tbTaxIVAQuery, new { TabIVA = tabIVAID, CodIVA = eachTabCodIVA.CodIVA });
                    if (taxIVA != null)
                    {
                        DocIVA newDocIVA = new DocIVA();
                        newDocIVA.TipoDoc = TipoDoc;
                        newDocIVA.Ano = Ano;
                        newDocIVA.Mes = Mes;
                        newDocIVA.NumDoc = NumDoc;
                        newDocIVA.CodIVA = eachTabCodIVA.CodIVA;
                        newDocIVA.TaxIVA = taxIVA.Taxa;
                        newDocIVA.TotalMP = 0;
                        newDocIVA.TotalOT = 0;
                        newDocIVA.TotalPA = 0;
                        newDocIVA.TotalSR = 0;
                        newDocIVA.ValIVA = 0;
                        newDocIVA.ValSuj = 0;
                        DocIVA.Add(newDocIVA);
                        taxas.Add(taxIVA);
                    }
                }
            }
            return taxas;
        }


        public bool GeraNumeração(IDbConnection connection, IDbTransaction transaction)
        {
            VgTipoDoc tipoDocObj = connection.QueryFirstOrDefault<VgTipoDoc>(
                @"select TipoDoc, temNumMensal, temAssinatura from TipoDoc where TipoDoc = @TipoDoc",
                new { TipoDoc = TipoDoc },
                transaction);

            if (tipoDocObj == null) return false;

            bool numeroProvisorio = tipoDocObj.temAssinatura == true && string.IsNullOrEmpty(Assinatura);

            if (DataDoc == null) DataDoc = DateTime.Now;
            Ano = DataDoc.Value.Year;
            if (tipoDocObj.temNumMensal == true)
                Mes = Convert.ToInt16(DataDoc.Value.Month);
            else
                Mes = 0;

            TDSerie docSerie = connection.QueryFirstOrDefault<TDSerie>(
                @"select [TipoDoc]
                        ,[Ano]
                        ,[Mes]
                        ,[Sequencial]
                        ,[Radical]
                        , ISNULL([PriNumero], 0) as [PriNumero]
                        ,[PriData]
                        , ISNULL([UltNumero], 0) as [UltNumero]
                        ,[UltData]
                        ,[Prefixo]
                        ,[Sufixo]
                        ,ISNULL([ContaDocs], 0) as [ContaDocs]
                        ,ISNULL([PriProvisorio], 0) as [PriProvisorio]
                        ,ISNULL([UltProvisorio], 0) as [UltProvisorio]
                        ,ISNULL([ContaProv], 0) as [ContaProv]  
                from TDSerie where TipoDoc = @TipoDoc and Ano = @Ano and Mes = @Mes",
                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes },
                transaction);

            if (docSerie == null)
            {
                docSerie = new TDSerie
                {
                    TipoDoc = TipoDoc,
                    Ano = Ano,
                    Mes = Mes,
                    UltNumero = 0,
                    UltProvisorio = 0,
                    PriNumero = 0,
                    PriProvisorio = 0,
                    Sequencial = Mes > 1,
                    ContaDocs = 0,
                    ContaProv = 0
                };

                connection.Insert(docSerie, transaction: transaction);
            }

            if (docSerie.ContaDocs == null) docSerie.ContaDocs = 0;
            if (docSerie.ContaProv == null) docSerie.ContaProv = 0;

            // verifica se existem documentos na serie atual
            if (docSerie.ContaDocs + docSerie.ContaProv == 0)
            {
                //1º doc do mês
                docSerie.PriData = DataDoc;
                if (docSerie.Sequencial == true)
                {
                    TDSerie prevSerie = connection.QueryFirstOrDefault<TDSerie>(
                        @"select TOP 1 
                                [TipoDoc]
                                ,[Ano]
                                ,[Mes]
                                ,[Sequencial]
                                ,[Radical]
                                , ISNULL([PriNumero], 0) as [PriNumero]
                                ,[PriData]
                                , ISNULL([UltNumero], 0) as [UltNumero]
                                ,[UltData]
                                ,[Prefixo]
                                ,[Sufixo]
                                ,ISNULL([ContaDocs], 0) as [ContaDocs]
                                ,ISNULL([PriProvisorio], 0) as [PriProvisorio]
                                ,ISNULL([UltProvisorio], 0) as [UltProvisorio]
                                ,ISNULL([ContaProv], 0) as [ContaProv] 
                            from TDSerie 
                            where TipoDoc = @TipoDoc and ((Ano = @Ano and Mes < @Mes) or Ano < @Ano) order by Ano, Mes DESC",
                        new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes }, 
                        transaction);

                    docSerie.UltNumero = prevSerie.UltNumero;
                    docSerie.UltProvisorio = prevSerie.UltProvisorio;
                }
                else
                {
                    docSerie.UltNumero = docSerie.PriNumero;
                    docSerie.UltProvisorio = docSerie.PriProvisorio;
                }
                docSerie.PriNumero = docSerie.UltNumero + 1;
                docSerie.PriProvisorio = docSerie.UltProvisorio + 1;
            }

            docSerie.UltData = DataDoc;

            int ultNum = 0;

            int docNum = Math.Abs(NumDoc);

            if (numeroProvisorio)
            {
                if (docSerie.UltProvisorio == null) docSerie.UltProvisorio = 0;
                ultNum = docSerie.UltProvisorio.Value + 1;
                //compara com o nº do documento para detetar colisões na numeração
                if (docNum >= ultNum)
                    ultNum = docNum + 1;
                docSerie.UltProvisorio = ultNum;
                docSerie.ContaProv = 1 + docSerie.UltProvisorio - docSerie.PriProvisorio;
                ultNum = -ultNum;
            }
            else
            {
                ultNum = docSerie.UltNumero.Value + 1;
                //compara com o nº do documento para detetar colisões na numeração
                if (docNum >= ultNum)
                    ultNum = docNum + 1;
                docSerie.UltNumero = ultNum;
                docSerie.ContaDocs = 1 + docSerie.UltNumero - docSerie.PriNumero;
            }
            NumDoc = ultNum;

            connection.Update(docSerie, transaction: transaction);

            return true;
        }

        /// <summary>
        /// Assina o documento
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="encodingPageNumber">por defeiro: "Windows-1252"</param>
        /// <returns></returns>
        public int AssinaDoc(IDbConnection connection, int encodingPageNumber = RSAEncriptionHelpers.VGEST_ENCODING_PAGE)
        {
            int result = -1;
            string errorText = "";
            try
            {
                VgTipoDoc myTipoDoc = connection.QueryFirstOrDefault<VgTipoDoc>("SELECT * FROM TipoDoc WHERE TipoDoc = @TipoDoc", new { TipoDoc = TipoDoc });

                string myTipoDocID = myTipoDoc.TipoDoc;
                string td = TipoDoc;
                int ad = Ano;
                short md = Mes;
                int nd = NumDoc;

                
                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    DocCab ultDocAssinado = connection.QueryFirstOrDefault<DocCab>(
                        "SELECT TOP 1 * from DocCab WHERE TipoDoc = @TipoDoc AND Ano = @Ano AND Assinatura != '' AND Assinatura IS NOT NULL " +
                        "ORDER BY AssinadoEm DESC, NumDoc DESC"
                        , new { TipoDoc = myTipoDocID, Ano = ad }, transaction);

                    string chaveAnt = "";
                    int newAD = ad;
                    int newND = nd;
                    short newMD = md;


                    DateTime dataAssina = connection.QuerySingle<DateTime>("SELECT GETDATE()", transaction: transaction);
                    DateTime ultDatAssina = dataAssina;
                    int ultNumAssina = 0;

                    if (ultDocAssinado != null)
                    {
                        chaveAnt = ultDocAssinado.Assinatura;
                        ultNumAssina = ultDocAssinado.NumDoc;
                        ultDatAssina = ultDocAssinado.AssinadoEm == null ? DateTime.Now : ultDocAssinado.AssinadoEm.Value;

                        if (ultDocAssinado.DataDoc > DataDoc)
                        {
                            DataDoc = ultDocAssinado.DataDoc;
                            newAD = ultDocAssinado.Ano;
                            newMD = ultDocAssinado.Mes;
                        }
                    }

                    if (nd < 0)
                    {
                        TDSerie thisSerie = connection.QueryFirstOrDefault<TDSerie>("SELECT * FROM TDSerie WHERE TipoDoc = @TipoDoc AND Ano = @Ano AND Mes = @Mes",
                                                                            new { TipoDoc = myTipoDocID, Ano = newAD, Mes = newMD }, transaction);

                        newND = (thisSerie.UltNumero >= 0 ? thisSerie.UltNumero.Value : 0) + 1;
                        if (newND != ultNumAssina + 1)
                        {
                            errorText = "Problemas na sequência de numeração dos documentos";
                            result = 0;
                        }
                        
                        int newDocAssinado = connection.QueryFirstOrDefault<int>(
                            "SELECT recno FROM DocCab WHERE TipoDoc = @TipoDoc AND Ano = @Ano AND Mes = @Mes AND NumDoc = @NumDoc",
                            new { TipoDoc = TipoDoc, Ano = newAD, Mes = newMD, NumDoc = newND }, transaction);

                        if (newDocAssinado != 0)
                        {
                            errorText = "Problemas na sequência de numeração dos documentos (" + newAD.ToString() + newMD.ToString() + "/" + newND.ToString() + " = " + newDocAssinado.ToString() + ")";
                            result = 0;
                        }
                        if (dataAssina < ultDatAssina)
                        {
                            errorText = "Data de assinatura do último documento posterior à data actual";
                            result = 0;
                        }

                        if (result != 0)
                        {
                            if (DataDoc > thisSerie.UltData) thisSerie.UltData = DataDoc;
                            thisSerie.UltNumero = newND;
                            connection.Update(thisSerie, transaction: transaction);
                        }
                    }
                    if (result != 0)
                    {
                        string assMessage = "";
                        Assinatura = SetAssinatura(TipoDoc, newAD, newMD, newND, DataDoc, DtUpdate, HrUpdate, TotalDoc, chaveAnt, ref assMessage, encodingPageNumber);
                        AssinadoPor = CriadoPor;
                        AssinadoMsg = assMessage;
                        AssinadoEm = dataAssina;
                        AssinaVGest = SetAssinaturaVisualGest(TipoDoc, newAD, newMD, newND, Classe, Terceiro, Nome, MoradaDoc, NIF, TotalDoc.HasValue ? TotalDoc.Value : 0, encodingPageNumber);
                        VersaoChave = vgChaveVersao;
                        Certificado = vgCertificado;

                        if (myTipoDoc.Tipologia == 7)
                        {
                            //documento manual
                            if (DocOrig == null || DocOrig == "")
                                DocOrig = newND.ToString().PadLeft((myTipoDoc.NumDigitos.HasValue ? myTipoDoc.NumDigitos.Value : 0), '0');
                            VersaoChave = vgChaveVersao + "-" + myTipoDoc.InvoiceType + "M" + " " + DocOrig;
                        }
                        else
                        {
                            //if (thisDocCab.DocOrig == "")                                   
                            if (DocOrig == null || DocOrig == "")
                                DocOrig = FmtDocID((myTipoDoc.NumDigitos.HasValue ? myTipoDoc.NumDigitos.Value : (short)0), false);

                            if (myTipoDoc.TemDesNum == true)
                                DesMov = myTipoDoc.DesMov + " " + DocOrig;
                        }

                        // TODO: GENERATE QR CODE2
                        //thisDocCab.QrCode = GetQrCode2(fmtDocID(thisDocCab.TipoDoc, newAD, newMD, newND, getShort(myTipoDoc.NumDigitos), true), scale: 2);
                        int docRecno = connection.QueryFirstOrDefault<int>(
                                "select recno from DocCab where TipoDoc = @TipoDoc and Ano = @Ano and Mes = @Mes and NumDoc = @NumDoc",
                                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes, NumDoc = NumDoc }, transaction: transaction);

                        //QrCode = GetQrCode2("90" + String.Format("{0:000000}", docRecno));

                        //throw new Exception("not implemented TransactionScope myTranScope = new TransactionScope");
                        //using (TransactionScope myTranScope = new TransactionScope())
                        //{
                        try
                        {
                            var queryParameters = new DynamicParameters();
                            queryParameters.Add("@TipoDoc", myTipoDoc.TipoDoc);
                            queryParameters.Add("@AnoDoc", Ano);
                            queryParameters.Add("@AnoNew", newAD);
                            queryParameters.Add("@MesDoc", Mes);
                            queryParameters.Add("@MesNew", newMD);
                            queryParameters.Add("@NumDoc", NumDoc);
                            queryParameters.Add("@NumNew", newND);

                            connection.Execute(
                                $@"UPDATE DocCab SET 
                                    DataDoc = @DataDoc,
                                    Assinatura = @Assinatura,
                                    AssinadoPor = @AssinadoPor,
                                    AssinadoMsg = @AssinadoMsg,
                                    AssinadoEm = @AssinadoEm,
                                    AssinaVGest = @AssinaVGest,
                                    VersaoChave = @VersaoChave,
                                    Certificado = @Certificado,
                                    DocOrig = @DocOrig,
                                    DesMov = @DesMov
                                WHERE TipoDoc = @TipoDoc and Ano = @Ano and Mes = @Mes and NumDoc = @NumDoc",
                                new {
                                    TipoDoc = TipoDoc,
                                    Ano = Ano,
                                    Mes = Mes,
                                    NumDoc = NumDoc,
                                    DataDoc = DataDoc,
                                    Assinatura = Assinatura,
                                    AssinadoPor = AssinadoPor,
                                    AssinadoMsg = AssinadoMsg,
                                    AssinadoEm = AssinadoEm,
                                    AssinaVGest = AssinaVGest,
                                    VersaoChave = VersaoChave,
                                    Certificado = Certificado,
                                    DocOrig = DocOrig,
                                    DesMov = DesMov
                                }, transaction: transaction);

                            var affectedRows = connection.Execute("UpdtDocCabKey", queryParameters,
                                commandType: CommandType.StoredProcedure, transaction: transaction);

                            transaction.Commit();

                            Ano = newAD;
                            Mes = newMD;
                            NumDoc = newND;
                        }
                        catch (Exception ex)
                        {
                            string exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                            errorText = "Problemas na atribuição do número definitivo ao documento.\r\nTente assinar novamente.\r\n" + exMessage;
                            Assinatura = "";
                            AssinadoPor = null;
                            AssinadoMsg = "";
                            AssinadoEm = null;
                            AssinaVGest = "";
                            VersaoChave = null;
                            Certificado = null;
                            result = 0;
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                errorText = ex.Message;
                return 0;
            }
        }
        private static string SetAssinatura(string TipoDocID, int AnoID, short MesID, int NumDocID, DateTime? DatDoc, DateTime? DtUpdate, DateTime? HrUpdate, double? TotalMercadoria, string ChaveAnterior, ref string strMessage, int encodingPageNumber)
        {
            string strSigBase64 = "";
            strMessage = SetAssinaturaMessage(TipoDocID, AnoID, MesID, NumDocID, DatDoc.HasValue ? DatDoc.Value : DateTime.Now, DtUpdate.HasValue ? DtUpdate.Value : DateTime.Now, HrUpdate.HasValue ? HrUpdate.Value : DateTime.Now, TotalMercadoria, ChaveAnterior);
            //strSigBase64 = rsaCreateSignatureInBase64(strMessage, vgChavePrivada);
            strSigBase64 = RSAEncriptionHelpers.Encrypt(strMessage, encodingPageNumber);
            return strSigBase64;
        }
        private static string SetAssinaturaMessage(string TipoDocID, int AnoID, short MesID, int NumDocID, DateTime DatDoc, DateTime DtUpdate, DateTime HrUpdate, double? TotalMercadoria, string ChaveAnterior)
        {
            string strMessage = DatDoc.ToString("yyyy-MM-dd");
            strMessage += ";";
            strMessage += DtUpdate.ToString("yyyy-MM-dd");
            strMessage += "T";
            strMessage += HrUpdate.ToString("HH:mm:ss");
            strMessage += ";";
            strMessage += TipoDocID;
            strMessage += " ";
            strMessage += AnoID.ToString();
            //strMessage += "-";
            //strMessage += MesID.ToString();
            strMessage += "/";
            strMessage += NumDocID.ToString();
            strMessage += ";";
            strMessage += FormataAssinaturaMessage(TotalMercadoria.HasValue ? TotalMercadoria.Value : 0);
            strMessage += ";";
            strMessage += ChaveAnterior;
            return strMessage;
        }
        private static string FormataAssinaturaMessage(double valor)
        {
            string result = valor.ToString("0.00");
            char sepdec = char.Parse(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
            if (sepdec != '.') result = result.Replace(sepdec, '.');
            return result;
        }

        
        static byte[] DecodeOpenSSLPublicKey(String instr)
        {
            const String pempubheader = "-----BEGIN PUBLIC KEY-----";
            const String pempubfooter = "-----END PUBLIC KEY-----";
            String pemstr = instr.Trim();
            byte[] binkey;
            if (!pemstr.StartsWith(pempubheader) || !pemstr.EndsWith(pempubfooter))
                return null;
            StringBuilder sb = new StringBuilder(pemstr);
            sb.Replace(pempubheader, "");  //remove headers/footers, if present
            sb.Replace(pempubfooter, "");

            String pubstr = sb.ToString().Trim();   //get string after removing leading/trailing whitespace

            try
            {
                binkey = Convert.FromBase64String(pubstr);
            }
            catch (System.FormatException)
            {       //if can't b64 decode, data is not valid
                return null;
            }
            return binkey;
        }
        public const string vgChaveVersao = "1";
        public const string vgChaveVersao2 = "1";
        public const string vgCertificado = "1493";

        private static string SetAssinaturaVisualGest(string TipoDocID, int AnoID, short MesID, int NumDocID, string ClaTer, string CodTer, string NomTer, string MorTer, string NIFTer, double TotDoc, int encodingPageNumber)
        {
            string strSigBase64 = "";
            string strMessage = SetAssinaturaMessageVisualGest(TipoDocID, AnoID, MesID, NumDocID, ClaTer, CodTer, NomTer, MorTer, NIFTer, TotDoc);
            //strSigBase64 = rsaCreateSignatureInBase64(strMessage, vgChavePrivada);
            strSigBase64 = RSAEncriptionHelpers.Encrypt(strMessage, encodingPageNumber);
            return strSigBase64;
        }
        public static string rsaCreateSignatureInBase64(string strMessage)
        {
            // $GENERIC-FUNCTION$
            // INPUT:  Message string to be signed; filename of private RSA key file (unencrypted OpenSSL format)
            // OUTPUT: Signature in base64 format
            string strPrivateKey = null;
            byte[] abMessage = null;
            int nMsgLen = 0;
            byte[] abBlock = null;
            int nBlkLen = 0;
            string strSigBase64 = null;

            // 1. Convert message into unambigous array of bytes and compute length
            abMessage = System.Text.Encoding.Default.GetBytes(strMessage);
            nMsgLen = abMessage.Length;



            // Return base64 signature
            return strSigBase64;
        }
        
        private static string SetAssinaturaMessageVisualGest(string TipoDocID, int AnoID, short MesID, int NumDocID, string ClaTer, string CodTer, string NomTer, string MorTer, string NIFTer, double TotDoc)
        {
            string strMessage = TipoDocID;
            strMessage += " ";
            strMessage += AnoID.ToString();
            strMessage += "-";
            strMessage += MesID.ToString();
            strMessage += "/";
            strMessage += NumDocID.ToString();
            strMessage += ";";
            strMessage += ClaTer;
            strMessage += ";";
            strMessage += CodTer;
            strMessage += ";";
            strMessage += NomTer;
            strMessage += ";";
            strMessage += MorTer;
            strMessage += ";";
            strMessage += NIFTer;
            strMessage += ";";
            strMessage += FormataAssinaturaMessage(TotDoc);// VGGlobais.getDouble(TotDoc).ToString("0.00");
            return strMessage;
        }
    }

}