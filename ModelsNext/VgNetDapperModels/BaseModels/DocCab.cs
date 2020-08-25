using System;
using System.Collections.Generic;
using System.Linq;
using VgNetDapperModels.AbstractModels;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    public class DocCab : DocCab<DocLin, DocLiga, VgDocLinSortido, VgDocLinTamCor, DocLinSortItem, DocLigaTamCor, VgDocPag, DocFile, DocIVA, DocLinDescResiduos, DocLigaEgar, DocLigaEmb, DocLigaPlanos, DocLigaPlanosTamCor>
    {

        public DocCab()
        {
            Lines = new List<DocLin>();            
            ValorPago = 0;
            Troco = 0;
            TotalPortes = 0;
            TotalDiversos = 0;
            NumPrint = 0;
            TotalCom = 0;
            TotalEcovalor = 0;
            RetIRS = 0;
            FoiEnviado = false;
            SujIRS = 0;
            TotalReg = 0;
            Cambio = 1;

            TotalDoc = 0;
            TotalMercadoria = 0;
            ValDescCom = 0;
            TotalSujeito = 0;
            TotalIVA = 0;
            ValDescFin = 0;
        }

        public DocCab(VgTipoDoc tipoDoc, VgTerceiro terceiro) : this()
        {
            SetTipoDoc(tipoDoc);
            SetTerceiro(terceiro);
        }

        /// <summary>
        /// Inicializa DocCab com um Tipo de Documento
        /// </summary>
        /// <param name="tipoDoc"></param>
        public DocCab(VgTipoDoc tipoDoc) : this()
        {
            SetTipoDoc(tipoDoc);
        }

        /// <summary>
        /// Inicializa DocCab com um terceiro
        /// </summary>
        /// <param name="terceiro"></param>
        public DocCab(VgTerceiro terceiro) : this()
        {
            SetTerceiro(terceiro);
        }

        /// <summary>
        /// Preenche o cabeçalho do documento com o terceiro especificado
        /// </summary>
        /// <param name="terceiro"></param>
        /// <returns></returns>
        public void SetTerceiro(VgTerceiro terceiro)
        {
            Classe = terceiro.Classe;
            Terceiro = terceiro.Terceiro;
            Nome = terceiro.Nome;
            NIF = terceiro.NIF;
            MoradaDoc = terceiro.MoradaPrincipalObj?.ToString();
        }



        public void SetTipoDoc(VgTipoDoc tipoDoc)
        {
            TipoDoc = tipoDoc.TipoDoc;
            Natureza = tipoDoc.Natureza;
            Armazem = tipoDoc.Armazem;
            FormPag = tipoDoc.FormPag;
            DesMov = tipoDoc.DesMov;

            TDActCC = tipoDoc.getTDActCC();
            TDActStk = tipoDoc.getTDActStk();
            TDActTar = tipoDoc.getTDActTar();
            TDActBase = tipoDoc.getTDActBase();
            
            if (tipoDoc.MovCCCre == true)
            {
                MovCC = "C";
            }
            else if (tipoDoc.MovCCDeb == true)
            {
                MovCC = "D";
            }
            else if (tipoDoc.MovCCVD == true)
            {
                MovCC = "V";
            }
            else
            {
                MovCC = "";
            }
        }

        /// <summary>
        /// Atribui uma morada ao documento (MoradaDoc)
        /// </summary>
        /// <param name="morada"></param>
        /// <returns></returns>
        public bool SetMoradaDoc(VgMorada morada)
        {
            MoradaDoc = morada.ToString();
            LocalDoc = morada.LocalidadeDesc;
            CodPostDoc = morada.CodPostal;
            LocPostDoc = morada.LocPostal;
            MorPaisDoc = morada.PaisDesc;
            MorDoc = MoradaDoc;
            return true;
        }

        /// <summary>
        /// Atribui uma morada de descarga ao documento
        /// </summary>
        /// <param name="morada"></param>
        /// <returns></returns>
        public bool SetMoradaDescarga(VgMorada morada)
        {
            MorDescargaID = morada.MoradaID;
            MoradaDescarga = morada.ToString();
            LocalDescarga = morada.LocalidadeDesc;
            CodPostDescarga = morada.CodPostal;
            LocPostDescarga = morada.LocPostal;
            MorPaisDescarga = morada.PaisDesc;
            MorDescarga = MoradaDescarga;
            NomDescarga = morada.Nome;
            return true;
        }

        /// <summary>
        /// Atribui uma morada de carga ao documento
        /// </summary>
        /// <param name="morada"></param>
        /// <returns></returns>
        public bool SetMoradaCarga(VgMorada morada)
        {
            MorCargaID = morada.MoradaID;
            MoradaCarga = morada.ToString();
            LocalCarga = morada.LocalidadeDesc;
            CodPostCarga = morada.CodPostal;
            LocPostCarga = morada.LocPostal;
            MorPaisCarga = morada.PaisDesc;
            MorCarga = MoradaCarga;
            NomCarga = morada.Nome;
            return true;
        }

        /// <summary>
        /// Adiciona uma linha nova ao documento
        /// </summary>
        /// <param name="linha"></param>
        /// <returns></returns>
        public void AddDocLin(DocLin linha)
        {
            if (Lines == null) { Lines = new List<DocLin>(); }
            Lines.Add(linha);
        }


        /// <summary>
        /// Recalcula data de vencimento do documento baseado nas condições de pagamento
        /// </summary>
        /// <param name="condPag"></param>
        /// <returns></returns>
        public bool RecalculaDataVencimento(TBCondPag condPag)
        {
            if (condPag == null)
                return false;

            DateTime? dataFim = null;
            if (DataDoc == null) DataDoc = DateTime.Now.Date;

            // data documento atual
            int docDia = DataDoc.Value.Day;
            int docMes = DataDoc.Value.Month;
            int docAno = DataDoc.Value.Year;

            // inicializa com data do documento
            int iniDia = docDia;
            int iniMes = docMes;
            int iniAno = docAno;

            // dados de CondPag
            int nDias = condPag.dias > 0 ? condPag.dias.Value : 0;
            int diaIni = condPag.DiaIni > 0 ? condPag.DiaIni.Value : 0;
            int mesIni = condPag.MesIni > 0 ? condPag.MesIni.Value : 0;
            int diaFim = condPag.DiaFim > 0 ? condPag.DiaFim.Value : 0;

            if (diaIni != 0)
            {
                //tem dia inicial
                if (diaIni < docDia)
                    iniMes = docMes + 1;
                iniDia = diaIni;
            }
            if (mesIni != 0)
                iniMes = docMes + mesIni;
            if (iniMes < 1)
            {
                iniMes = 12 + iniMes;
                iniAno = iniAno - 1;
            }
            if (iniMes > 12)
            {
                iniMes = iniMes - 12;
                iniAno = iniAno + 1;
            }

            DateTime dataIni = DateTime.MinValue;
            bool dataIniOK = false;
            while (!dataIniOK)
            {
                try
                {
                    dataIni = DateTime.Parse(iniAno.ToString() + "-" + iniMes.ToString() + "-" + iniDia.ToString());
                    dataIniOK = true;
                }
                catch (Exception)
                {
                    iniDia = iniDia - 1;
                }
            }
            dataFim = dataIni.AddDays(nDias);
            if (diaFim != 0)
            {
                //tem dia de pagamento
                int fimDia = dataFim.Value.Day;
                int fimMes = dataFim.Value.Month;
                int fimAno = dataFim.Value.Year;
                if (diaFim < fimDia)
                {
                    fimMes = fimMes + 1;
                    if (fimMes > 12)
                    {
                        fimMes = fimMes - 12;
                        fimAno = fimAno + 1;
                    }
                }
                fimDia = diaFim;
                dataFim = DateTime.Parse(fimAno.ToString() + "-" + fimMes.ToString() + "-" + fimDia.ToString());
            }

            DataVnc = dataFim;

            return true;
        }
    }
}
