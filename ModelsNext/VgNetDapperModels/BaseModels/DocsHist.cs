using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("DocsHist")]
    public class DocsHist : IDocsHist
    {
        [ExplicitKey]
        public string TipoDoc { get; set; }
        [ExplicitKey]
        public DateTime DataDoc { get; set; }
        [ExplicitKey]
        public int? DocsDeHoje { get; set; }

    }

}