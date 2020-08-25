using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.VgTabModels
{
    [Table("Postos")]
    public class Posto
    {
        public string UserID { get; set; }
        public string PostoSN { get; set; }
        public DateTime? Entrada { get; set; }
        public string Produto { get; set; }
    }
}
