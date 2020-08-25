using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IDocLin
    {
        string TipoDoc { get; set; }

        int Ano { get; set; }

        short Mes { get; set; }

        int NumDoc { get; set; }

        int LinhaID { get; set; }

        int? NumLinha { get; set; }

        string Artigo { get; set; }

        string Designacao { get; set; }

        double? Quantidade { get; set; }

        double? Medida1 { get; set; }

        double? Medida2 { get; set; }

        double? Medida3 { get; set; }

        double? Peso { get; set; }

        double? Preco { get; set; }

        string Tara { get; set; }

        double? QtdTara { get; set; }

        double? ValTara { get; set; }

        double? PCU { get; set; }

        double? PCM { get; set; }

        double? CMP { get; set; }

        double? PCP { get; set; }

        int? IVA { get; set; }

        double? TaxIVA { get; set; }

        string Desconto { get; set; }

        double? ValDesconto { get; set; }

        double? ValMercadoria { get; set; }

        double? ValSujeito { get; set; }

        double? ValIVA { get; set; }

        double? ValTotal { get; set; }

        string Comissao { get; set; }

        double? ValComissao { get; set; }

        double? QtdReg1 { get; set; }

        double? QtdReg2 { get; set; }

        double? QtdReg3 { get; set; }

        double? QtdReg4 { get; set; }

        double? QtdReg5 { get; set; }

        string NumSerie { get; set; }

        DateTime? DtEntrega { get; set; }

        string Processo { get; set; }

        bool? Okay { get; set; }

        bool? Ligou { get; set; }

        float? TaxIRS { get; set; }

        double? ValIRS { get; set; }

        string Referencia { get; set; }

        string DescProd { get; set; }

        double? QtdDescProd { get; set; }

        int Recno { get; set; }

        DateTime? DtUpdate { get; set; }

        DateTime? HrUpdate { get; set; }

        string Lote { get; set; }

        DateTime? DatEmb { get; set; }

        DateTime? DatVal { get; set; }

        string PaisOrigem { get; set; }

        int? NumPalete { get; set; }

        int? Nivel { get; set; }

        int? Lastro { get; set; }

        double? QtdBase { get; set; }

        int? QtdJoin { get; set; }

        int? LinJoin { get; set; }

        string CodJoin { get; set; }

        double? RelJoin { get; set; }

        bool? IsProd { get; set; }

        bool? IsComp { get; set; }

        double? QtdBar { get; set; }

        string UnMed { get; set; }

        short? CTACodIVA { get; set; }

        float? CTATaxIVA { get; set; }

        double? PontosVal { get; set; }

        double? PontosQtd { get; set; }

        int? Compromisso { get; set; }

        int? Tarefa { get; set; }

        string Geral0 { get; set; }

        string Geral1 { get; set; }

        string Geral2 { get; set; }

        string Geral3 { get; set; }

        string Geral4 { get; set; }

        string Geral5 { get; set; }

        string Geral6 { get; set; }

        string Geral7 { get; set; }

        string Geral8 { get; set; }

        string Geral9 { get; set; }

        double? EcoTaxa { get; set; }

        double? EcoTaxaIVA { get; set; }

        double? EcoTaxaTotal { get; set; }

        string CodArtigo { get; set; }

        DateTime? DtConfirma { get; set; }

        string UnMedStk { get; set; }

        double? ConvLin { get; set; }

        double? ConvStk { get; set; }

        double? QtdStk { get; set; }

        string MotivoIsentoIVA { get; set; }

        bool? ConcluiDocBase { get; set; }

        int? FldJoin { get; set; }

        int? DecQuant { get; set; }

        int? DecPreco { get; set; }

        double? Reservado { get; set; }

        double? Requisitado { get; set; }

        double? Entregue { get; set; }

        double? Saida { get; set; }

        string ChaveDocLin { get; set; }

        string AutorizaMsg { get; set; }

        string AutorizaUsr { get; set; }

        bool? ConcluiLin { get; set; }

        DateTime? ConcluiData { get; set; }

        string ConcluiUser { get; set; }

        string ActStock { get; set; }

        int? Estado { get; set; }

        bool? EstadoFlag { get; set; }

        double? QtdExc1 { get; set; }

        double? QtdExc2 { get; set; }

        double? QtdExc3 { get; set; }

        double? QtdExc4 { get; set; }

        double? QtdExc5 { get; set; }

        string ValStock { get; set; }

        double? AcertoRes { get; set; }

        double? AcertoReq { get; set; }

        double? AcertoEnt { get; set; }

        double? AcertoSai { get; set; }

        double? CustoUni { get; set; }

        double? CustoVal { get; set; }

        double? CustoUlt { get; set; }

        double? CustoMed { get; set; }

        bool? LoteEditado { get; set; }

        int? RecnoBase { get; set; }

        short? TipoArtigo { get; set; }

        bool? Componente { get; set; }

        int? NumLinhaComposto { get; set; }

        bool? AprovaLinha { get; set; }

        string AprovaUser { get; set; }

        double? QtdStkOrig { get; set; }

        string Obs { get; set; }

        bool? ConcluiRes { get; set; }

        DateTime? ConcluiResData { get; set; }

        string ConcluiResUser { get; set; }

        double? QtdFecha { get; set; }

        int? MRPStatus { get; set; }

        string MotivoIsentoIVACode { get; set; }

        DateTime? DataInicioProducao { get; set; }

        string RFIDIni { get; set; }

        string RFIDFim { get; set; }

        int? MargemSegurancaDias { get; set; }

        string FuncResp { get; set; }

        string ObsFuncResp { get; set; }

        string Geral10 { get; set; }

        string NumeroSerie { get; set; }

        double? QtdPrev { get; set; }
        int? MovPos { get; set; }
        int? TipoDePesagem { get; set; }
        DateTime? DataHoraPesagem { get; set; }
        bool? Pede2Pesagem { get; set; }
        bool? Tem2Pesagem { get; set; }

    }
}
