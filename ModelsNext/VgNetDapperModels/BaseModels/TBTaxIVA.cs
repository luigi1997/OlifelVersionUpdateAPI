using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("TBTaxIVA")]
    public class TBTaxIVA
    {
        public int TabIVA { get; set; }

        public int CodIVA { get; set; }

        public DateTime Data { get; set; }

        public double Taxa { get; set; }

        public string obs { get; set; }
    }
}