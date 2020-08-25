using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("TSContadores")]
    public class TSContador
    {
        [Key]
        public int Contador { get; set; }

        public string Descritivo { get; set; }

        public int? UltNumero { get; set; }

        public DateTime? UltData { get; set; }

        public short? NumDigitos { get; set; }
    }
}