using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    public class ArtModPI
    {
        public string Modelo { get; set; }

        public int Fase { get; set; }

        public string Produto { get; set; }

        public double? Preco1 { get; set; }

        public double? Preco2 { get; set; }

        public double? Preco3 { get; set; }

        public double? Preco4 { get; set; }

        public double? Preco5 { get; set; }

        public double? Preco6 { get; set; }

        public double? Preco7 { get; set; }

        public double? Preco8 { get; set; }

        public double? Preco9 { get; set; }

        public double? CapacidadeDiaria { get; set; }

        public double? CustosMaoObra { get; set; }

        public double? IntervaloFases { get; set; }

        public double? CustoMateriaPrima { get; set; }

        public double? CapacidadeDiariaTotal { get; set; }

    }

}
