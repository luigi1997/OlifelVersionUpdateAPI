using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.AbstractModels
{
    [Table("Terceiros")]
    public abstract class VgTerceiro<M, TBCP, TBFP>  : IVgTerceiro
                where M : IVgMorada
                where TBCP : ITBCondPag
                where TBFP : ITBFormPag
    {
        

        [ExplicitKey]
        public string Classe { get; set; }
        [ExplicitKey]
        public string Terceiro { get; set; }

        public string Classificacao { get; set; }

        public string NIF { get; set; }

        public string Nome { get; set; }

        public string SegNome { get; set; }

        public int? MoradaPrincipal { get; set; }
        [Computed]
        public M MoradaPrincipalObj { get; set; }

        public int? MoradaCarga { get; set; }
        [Computed]
        public M MoradaCargaObj { get; set; }

        public int? MoradaDescarga { get; set; }
        [Computed]
        public M MoradaDescargaObj { get; set; }

        [Computed]
        public IList<M> Moradas { get; set; }

        public string Moeda { get; set; }
        
        public int? CondPag { get; set; }

        [Computed]
        public TBCP CondPagObj { get; set; }

        public int? FormPag { get; set; }
        [Computed]
        public TBFP FormPagObj { get; set; }

        public int? CodDesconto { get; set; }

        public int? TabIVA { get; set; }

        public string Vendedor { get; set; }

        public int? ModExp { get; set; }

        public short? TipoPreco { get; set; }

        public TiposCliente TipoCliente { get; set; }

        public short? NumVias { get; set; }

        public bool? IVA { get; set; }

        public bool? LigaCC { get; set; }

        public bool? ControlaCredito { get; set; }

        public short? LimDias { get; set; }

        public double? Plafond1 { get; set; }

        public double? Plafond2 { get; set; }

        public double? PlafondRes { get; set; }

        public short? Bloqueado { get; set; }

        public DateTime? DataCria { get; set; }


        //public string DtUpdate { get; set; }

        public DateTime? DataUltMov { get; set; }

        public int? CodCAE { get; set; }

        public string Actividade { get; set; }

        public short? DiaPag1 { get; set; }

        public short? DiaPag2 { get; set; }

        public short? DiaPag3 { get; set; }

        public string DescFin { get; set; }

        public short? IconPeq { get; set; }

        public short? IconGra { get; set; }

        public bool? TemIRS { get; set; }

        public double? TaxIRS { get; set; }

        public string Informacoes { get; set; }

        public string NIFKey { get; set; }

        public string obs { get; set; }
        [Computed]
        public int recno { get; set; }

        public bool? TemEDI { get; set; }

        public string CodEDI { get; set; }

        public bool? FoiEnviado { get; set; }

        public bool? FoiRetirado { get; set; }

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

        public bool? TemIntrastat { get; set; }

        public string CtbConta { get; set; }

        public string CtbCCusto { get; set; }

        public string CtbAnalitica { get; set; }

        public short? AmbTipo { get; set; }

        public string DesVersao { get; set; }

        public string DesCodigo { get; set; }

        public bool? TemAutoFactura { get; set; }

        public int? Idioma { get; set; }

        public double? TotalDebito { get; set; }

        public double? TotalCredito { get; set; }

        public double? AcumVnd { get; set; }

        public double? AcumCmp { get; set; }

        public double? AcumPOS { get; set; }

        public double? PontosVal { get; set; }

        public double? PontosQtd { get; set; }

        public int? TabPrecos { get; set; }

        public int? MeioComunica { get; set; }

        public int? IsentoIVA { get; set; }

        public string NIFPais { get; set; }

        public bool? isAprovado { get; set; }

        public bool? TemIVACaixa { get; set; }

        public int? Destino { get; set; }

        public short? WebTipoPreco { get; set; }

        public bool? ExcluiNotificaEMail { get; set; }

        public string Alvara { get; set; }
    }
}