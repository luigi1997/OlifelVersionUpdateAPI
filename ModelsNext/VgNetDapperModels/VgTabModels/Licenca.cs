using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.VgTabModels
{
    [Table("Licenca")]
    public class Licenca
    {
        public int LicID { get; set; }
        public string Produto { get; set; }
        public int Postos { get; set; }
    }
}
