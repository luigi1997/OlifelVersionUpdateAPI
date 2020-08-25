using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IDocsHist
    {
        string TipoDoc { get; set; }
        DateTime DataDoc { get; set; }
        int? DocsDeHoje { get; set; }
    }
}
