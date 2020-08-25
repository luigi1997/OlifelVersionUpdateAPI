using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperDataExtended
{
    [Table("DocsHist")]
    public class DocsHist : VgNetDapperModels.BaseModels.DocsHist
    {
    }
}
