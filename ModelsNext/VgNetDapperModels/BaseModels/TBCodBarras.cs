using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.BaseModels
{
    [Table("TBCodBarras")]
    public class TBCodBarras
    {
        [Key]
        public int CodBarras { get; set; }

        public string Descritivo { get; set; }

        public string Prefixo { get; set; }

        public string Sufixo { get; set; }

    }

}
