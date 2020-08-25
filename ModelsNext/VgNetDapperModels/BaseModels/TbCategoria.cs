using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.BaseModels
{
    [Table("TbCategoria")]
    public class TbCategoria
    {
        public string Categoria { get; set; }
        public string Descritivo { get; set; }
        public double? CustoHora { get; set; }
        public string obs { get; set; }
        public double? CustoHora2 { get; set; }
    }
}
