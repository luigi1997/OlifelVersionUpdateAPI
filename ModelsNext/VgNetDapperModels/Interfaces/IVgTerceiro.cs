using System;

namespace VgNetDapperModels.Interfaces
{
    public enum TiposCliente { Nacional = 1, Comunitario = 2, Externo = 3, Indiferenciado = 4 };

    public interface IVgTerceiro
    {
        
        string Classe { get; set; }

        string Terceiro { get; set; }

        string Classificacao { get; set; }

        string NIF { get; set; }

        string Nome { get; set; }

        string SegNome { get; set; }

        int? MoradaPrincipal { get; set; }
        
        int? MoradaCarga { get; set; }
        
        int? MoradaDescarga { get; set; }
        
        string Moeda { get; set; }

        int? CondPag { get; set; }
        
        int? FormPag { get; set; }

        int? CodDesconto { get; set; }

        int? TabIVA { get; set; }

        string Vendedor { get; set; }

        int? ModExp { get; set; }

        short? TipoPreco { get; set; }

        TiposCliente TipoCliente { get; set; }

        short? NumVias { get; set; }

        bool? IVA { get; set; }

        bool? LigaCC { get; set; }

        bool? ControlaCredito { get; set; }

        short? LimDias { get; set; }

        double? Plafond1 { get; set; }

        double? Plafond2 { get; set; }

        double? PlafondRes { get; set; }

        short? Bloqueado { get; set; }

        DateTime? DataCria { get; set; }
        
        // string DtUpdate { get; set; }

        DateTime? DataUltMov { get; set; }

        int? CodCAE { get; set; }

        string Actividade { get; set; }

        short? DiaPag1 { get; set; }

        short? DiaPag2 { get; set; }

        short? DiaPag3 { get; set; }

        string DescFin { get; set; }

        short? IconPeq { get; set; }

        short? IconGra { get; set; }

        bool? TemIRS { get; set; }

        double? TaxIRS { get; set; }

        string Informacoes { get; set; }

        string NIFKey { get; set; }

        string obs { get; set; }

        bool? TemEDI { get; set; }

        string CodEDI { get; set; }

        bool? FoiEnviado { get; set; }

        bool? FoiRetirado { get; set; }

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

        bool? TemIntrastat { get; set; }

        string CtbConta { get; set; }

        string CtbCCusto { get; set; }

        string CtbAnalitica { get; set; }

        short? AmbTipo { get; set; }

        string DesVersao { get; set; }

        string DesCodigo { get; set; }

        bool? TemAutoFactura { get; set; }

        int? Idioma { get; set; }

        double? TotalDebito { get; set; }

        double? TotalCredito { get; set; }

        double? AcumVnd { get; set; }

        double? AcumCmp { get; set; }

        double? AcumPOS { get; set; }

        double? PontosVal { get; set; }

        double? PontosQtd { get; set; }

        int? TabPrecos { get; set; }

        int? MeioComunica { get; set; }

        int? IsentoIVA { get; set; }

        string NIFPais { get; set; }

        bool? isAprovado { get; set; }

        bool? TemIVACaixa { get; set; }

        int? Destino { get; set; }

        short? WebTipoPreco { get; set; }

        bool? ExcluiNotificaEMail { get; set; }

        string Alvara { get; set; }
    }
}
