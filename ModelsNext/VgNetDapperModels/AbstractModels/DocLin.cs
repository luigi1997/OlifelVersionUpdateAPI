using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.AbstractModels
{
    [Table("DocLin")]
    public abstract class DocLin<DL, DLS, DLTC, DLSI, DocLigaTC, DLDR, AP, DLE, DLPlanos, DocLigaPlanosTC> : IDocLin
                where DL : IDocLiga
                where DLS : IVgDocLinSortido
                where DLSI : IDocLinSortItem
                where DLTC : IVgDocLinTamCor
                where DocLigaTC : IDocLigaTamCor
                where DLDR : IDocLinDescResiduos
                where DLPlanos : IDocLigaPlanos
                where DocLigaPlanosTC : IDocLigaPlanosTamCor
                where AP : IArtPreco
    {
        [ExplicitKey]
        public string TipoDoc { get; set; }
        [ExplicitKey]
        public int Ano { get; set; }
        [ExplicitKey]
        public short Mes { get; set; }
        [ExplicitKey]
        public int NumDoc { get; set; }
        [Key]
        public int LinhaID { get; set; }

        public int? NumLinha { get; set; }

        public string Artigo { get; set; }

        public string Designacao { get; set; }

        public double? Quantidade { get; set; }

        public double? Medida1 { get; set; }

        public double? Medida2 { get; set; }

        public double? Medida3 { get; set; }

        public double? Peso { get; set; }

        public double? Preco { get; set; }

        public string Tara { get; set; }

        public double? QtdTara { get; set; }

        public double? ValTara { get; set; }

        [Computed]
        public IList<DLTC> TamsCor { get; set; }
        [Computed]
        public IList<DL> DocLiga { get; set; }
        [Computed]
        public IList<DocLigaTC> DocLigaTamsCor { get; set; }
        [Computed]
        public IList<DLPlanos> DocLigaPlanos { get; set; }
        [Computed]
        public IList<DocLigaPlanosTC> DocLigaPlanosTamCor { get; set; }
        [Computed]
        public IList<DL> DocLigaBase { get; set; }
        [Computed]
        public bool? TemSortido { get; set; }
        [Computed]
        public IList<DLS> Sortidos { get; set; }
        [Computed]
        public bool DescontoEmValor { get; set; }

        [Computed]
        public IList<DLDR> DocLinDescResiduos { get; set; }
        [Computed]
        public IList<DLE> DocLigaEmbs { get; set; }

        public double? PCU { get; set; }

        public double? PCM { get; set; }

        public double? CMP { get; set; }

        public double? PCP { get; set; }

        public int? IVA { get; set; }

        public double? TaxIVA { get; set; }

        public string Desconto { get; set; }

        public double? ValDesconto { get; set; }

        public double? ValMercadoria { get; set; }

        public double? ValSujeito { get; set; }

        public double? ValIVA { get; set; }

        public double? ValTotal { get; set; }

        public string Comissao { get; set; }

        public double? ValComissao { get; set; }

        public double? QtdReg1 { get; set; }

        public double? QtdReg2 { get; set; }

        public double? QtdReg3 { get; set; }

        public double? QtdReg4 { get; set; }

        public double? QtdReg5 { get; set; }

        public string NumSerie { get; set; }

        public DateTime? DtEntrega { get; set; }

        public string Processo { get; set; }

        public bool? Okay { get; set; }

        public bool? Ligou { get; set; }

        public float? TaxIRS { get; set; }

        public double? ValIRS { get; set; }

        public string Referencia { get; set; }

        public string DescProd { get; set; }

        public double? QtdDescProd { get; set; }

        public int Recno { get; set; }

        public DateTime? DtUpdate { get; set; }

        public DateTime? HrUpdate { get; set; }

        public string Lote { get; set; }

        public DateTime? DatEmb { get; set; }

        public DateTime? DatVal { get; set; }

        public string PaisOrigem { get; set; }

        public int? NumPalete { get; set; }

        public int? Nivel { get; set; }

        public int? Lastro { get; set; }

        public double? QtdBase { get; set; }

        public int? QtdJoin { get; set; }

        public int? LinJoin { get; set; }

        public string CodJoin { get; set; }

        public double? RelJoin { get; set; }

        public bool? IsProd { get; set; }

        public bool? IsComp { get; set; }

        public double? QtdBar { get; set; }

        public string UnMed { get; set; }

        public short? CTACodIVA { get; set; }

        public float? CTATaxIVA { get; set; }

        public double? PontosVal { get; set; }

        public double? PontosQtd { get; set; }

        public int? Compromisso { get; set; }

        public int? Tarefa { get; set; }

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

        public double? EcoTaxa { get; set; }

        public double? EcoTaxaIVA { get; set; }

        public double? EcoTaxaTotal { get; set; }

        public string CodArtigo { get; set; }

        public DateTime? DtConfirma { get; set; }

        public string UnMedStk { get; set; }

        public double? ConvLin { get; set; }

        public double? ConvStk { get; set; }

        public double? QtdStk { get; set; }

        public string MotivoIsentoIVA { get; set; }

        public bool? ConcluiDocBase { get; set; }

        public int? FldJoin { get; set; }

        public int? DecQuant { get; set; }

        public int? DecPreco { get; set; }

        public double? Reservado { get; set; }

        public double? Requisitado { get; set; }

        public double? Entregue { get; set; }

        public double? Saida { get; set; }

        public string ChaveDocLin { get; set; }

        public string AutorizaMsg { get; set; }

        public string AutorizaUsr { get; set; }

        public bool? ConcluiLin { get; set; }

        public DateTime? ConcluiData { get; set; }

        public string ConcluiUser { get; set; }

        public string ActStock { get; set; }

        public int? Estado { get; set; }

        public bool? EstadoFlag { get; set; }

        public double? QtdExc1 { get; set; }

        public double? QtdExc2 { get; set; }

        public double? QtdExc3 { get; set; }

        public double? QtdExc4 { get; set; }

        public double? QtdExc5 { get; set; }

        public string ValStock { get; set; }

        public double? AcertoRes { get; set; }

        public double? AcertoReq { get; set; }

        public double? AcertoEnt { get; set; }

        public double? AcertoSai { get; set; }

        public double? CustoUni { get; set; }

        public double? CustoVal { get; set; }

        public double? CustoUlt { get; set; }

        public double? CustoMed { get; set; }

        public bool? LoteEditado { get; set; }

        public int? RecnoBase { get; set; }

        public short? TipoArtigo { get; set; }

        public bool? Componente { get; set; }

        public int? NumLinhaComposto { get; set; }

        public bool? AprovaLinha { get; set; }

        public string AprovaUser { get; set; }

        public double? QtdStkOrig { get; set; }

        public string Obs { get; set; }

        public bool? ConcluiRes { get; set; }

        public DateTime? ConcluiResData { get; set; }

        public string ConcluiResUser { get; set; }

        public double? QtdFecha { get; set; }

        public int? MRPStatus { get; set; }

        public string MotivoIsentoIVACode { get; set; }

        public DateTime? DataInicioProducao { get; set; }

        public string RFIDIni { get; set; }

        public string RFIDFim { get; set; }

        public int? MargemSegurancaDias { get; set; }

        public string FuncResp { get; set; }

        public string ObsFuncResp { get; set; }

        public string Geral10 { get; set; }

        public string NumeroSerie { get; set; }

        public double? QtdPrev { get; set; }
        
        public int? MovPos { get; set; }
        public int? TipoDePesagem { get; set; }
        public DateTime? DataHoraPesagem { get; set; }
        public bool? Pede2Pesagem { get; set; }
        public bool? Tem2Pesagem { get; set; }
        public string EDI_StandardProductCode { get; set; }
        public string EDI_BuyersProductCode { get; set; }


        /// <summary>
        /// Campo auxiliar para definir quantidade máxima possivel na linha (usano no caso dos QtdReG)
        /// </summary>
        [Computed]
        public double? QtdMax { get; set; }


        /// <summary>
        /// Assign new prices to current doclin
        /// </summary>
        /// <param name="artPrecos">List or artPrecos previously filtered by NumPreco</param>
        private void RecalculatePrice(List<AP> artPrecos)
        {
            Preco = artPrecos.Where(x => x.Tam == -1 && x.Cor == -1).FirstOrDefault()?.Preco;
            if (TamsCor != null && TamsCor.Any())
            {
                foreach (IVgDocLinTamCor tamCor in TamsCor)
                {
                    tamCor.Preco = artPrecos.Where(x => x.Tam == tamCor.Tam && x.Cor == tamCor.Cor).FirstOrDefault()?.Preco;
                }
            }
        }

        /// <summary>
        /// Recalcula valores de linha
        /// </summary>
        /// <param name="tipoDoc">TipoDoc relativo ao documento a ser processado</param>
        public void Recalculate(IVgTipoDoc tipoDoc, List<AP> artPrecos = null)
        {
            if (artPrecos != null && artPrecos.Any())
            {
                RecalculatePrice(artPrecos);
            }

            if (TamsCor != null && TamsCor.Any())
            {
                // assign artigo from lin to all it's tam cor
                TamsCor.Select(c => { c.Artigo = Artigo; return c; }).ToList();

                Quantidade = TamsCor.Sum(x => x.Quantidade);
                Preco = TamsCor.Average(x => (x.Preco == null ? 0 : x.Preco)); //* x.Quantidade
                if(Quantidade > 0)
                {
                    Peso = TamsCor.Sum(x => (x.Peso == null ? 0 : x.Peso) * x.Quantidade) / Quantidade;
                }
                else
                {
                    Peso = 0;
                }
                
            }

            // calculo de valor bruto para não estar sempre a calcular o mesmo
            double? valBruto = Quantidade * Preco;
            ValMercadoria = valBruto;

            if (tipoDoc.TemIVA == true)
            {
                ValMercadoria = valBruto / (1 + (TaxIVA / 100));
            }

            ValDesconto = getValDesconto(ValMercadoria, Desconto);
            ValSujeito = ValMercadoria - ValDesconto;

            // Calculo do valor do IVA
            ValIVA = (TaxIVA / 100) * ValSujeito;

            // arredondar a casas decimais
            ValMercadoria = Math.Round((double)ValMercadoria, 2);
            ValDesconto = Math.Round((double)ValDesconto, 2);
            ValSujeito = Math.Round((double)ValSujeito, 2);
            ValIVA = Math.Round((double)ValIVA, 2);

            // calculo de valor total
            ValTotal = ValSujeito + ValIVA;
            ValTotal = Math.Round((double)ValTotal, 2);
        }


        public double GetQtdRegEmFalta(int qtdRegNum)
        {
            switch (qtdRegNum)
            {
                case 1:
                    return (Quantidade > 0 ? Quantidade.Value : 0) - (QtdReg1 > 0 ? QtdReg1.Value : 0);
                case 2:
                    return (Quantidade > 0 ? Quantidade.Value : 0) - (QtdReg2 > 0 ? QtdReg2.Value : 0);
                case 3:
                    return (Quantidade > 0 ? Quantidade.Value : 0) - (QtdReg3 > 0 ? QtdReg3.Value : 0);
                case 4:
                    return (Quantidade > 0 ? Quantidade.Value : 0) - (QtdReg4 > 0 ? QtdReg4.Value : 0);
                case 5:
                    return (Quantidade > 0 ? Quantidade.Value : 0) - (QtdReg5 > 0 ? QtdReg5.Value : 0);
                default:
                    return 0;
            }
        }

        public double? AddToQtdReg(int qtdRegNum, double qtd)
        {
            switch (qtdRegNum)
            {
                case 1:
                    QtdReg1 = (QtdReg1 > 0 ? QtdReg1.Value : 0) + qtd;
                    return QtdReg1;
                case 2:
                    QtdReg2 = (QtdReg2 > 0 ? QtdReg2.Value : 0) + qtd;
                    return QtdReg2;
                case 3:
                    QtdReg3 = (QtdReg3 > 0 ? QtdReg3.Value : 0) + qtd;
                    return QtdReg3;
                case 4:
                    QtdReg4 = (QtdReg4 > 0 ? QtdReg4.Value : 0) + qtd;
                    return QtdReg4;
                case 5:
                    QtdReg5 = (QtdReg5 > 0 ? QtdReg5.Value : 0) + qtd;
                    return QtdReg5;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Calcula valor total de desconto
        /// </summary>
        /// <param name="value">Valor ao qual vai ser aplicado o desconto</param>
        /// <param name="percentagem">Percentagem de desconto</param>
        /// <returns>Valor de desconto relativo ao parametro value</returns>
        private double? getValDesconto(double? value, string percentagem)
        {
            double valPerc;
            if (value >= 0 && double.TryParse(percentagem, out valPerc))
            {
                return value * (valPerc / 100);
            }
            else
            {
                return 0;
            }
        }

    }

}