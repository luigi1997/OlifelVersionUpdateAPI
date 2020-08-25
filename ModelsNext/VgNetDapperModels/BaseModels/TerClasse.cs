using Dapper.Contrib.Extensions;
using System;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("TerClasses")]
    public class TerClasse
    {
        public string Classe { get; set; }

        public string Designacao { get; set; }

        public int? Contador { get; set; }

        public int? CondPag { get; set; }

        public int? FormPag { get; set; }

        public string Vendedor { get; set; }

        public int? Expedicao { get; set; }

        public string Carga { get; set; }

        public string Descarga { get; set; }

        public int? CodDesconto { get; set; }

        public short? TipoPrecoVenda { get; set; }

        public short? TipoPrecoCusto { get; set; }

        public TiposCliente TipoCliente { get; set; }

        public short? NumVias { get; set; }

        public bool? IVA { get; set; }

        public bool? LigaCC { get; set; }

        public bool? ControlaCredito { get; set; }

        public short? LimDias { get; set; }

        public double? Plafond1 { get; set; }

        public double? Plafond2 { get; set; }

        public DateTime? DataCria { get; set; }

        public DateTime? DtUpdate { get; set; }

        public DateTime? HrUpdate { get; set; }

        public short? IconPeq { get; set; }

        public short? IconGra { get; set; }

        public string Moeda { get; set; }

        public bool? TemIRS { get; set; }

        public float? TaxIRS { get; set; }

        public string obs { get; set; }

        public string txtBotao { get; set; }

        public string ImgBotao { get; set; }

        public string CorBotao { get; set; }

        public string CorTexto { get; set; }

        public string FntName { get; set; }

        public bool? FoiEnviado { get; set; }

        public int? Generico { get; set; }

        public bool? isCustomer { get; set; }

        public bool? isSupplier { get; set; }

        public bool? isTransport { get; set; }

        public bool? isAprovado { get; set; }

        public string RazaoCTA { get; set; }

    }

}