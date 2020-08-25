using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    public class ArtModelo
    {
        public string Artigo { get; set; }

        public int? Rota { get; set; }

        public DateTime? DuraProd { get; set; }

        public double? VariaFT { get; set; }

        public int? TamBase { get; set; }

        public int? CorBase { get; set; }

        public int? Amostra { get; set; }

        public int? UltVariante { get; set; }

        public int? Montagem { get; set; }

        public int? Forma { get; set; }

        public int? Embalagem { get; set; }

        public int? Orcamento { get; set; }

        public double? ValorAprovado { get; set; }

        public double? PrecoAprovado { get; set; }

        public short? NumPreco { get; set; }

        public string Formeiro { get; set; }

        public string Cortante { get; set; }

        public string ModeloBase { get; set; }

        public int? MargemSegurancaDias { get; set; }

    }

}
