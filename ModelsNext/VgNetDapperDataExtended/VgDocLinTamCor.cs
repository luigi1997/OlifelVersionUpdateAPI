using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace VgNetDapperDataExtended
{
    [Table("DocLinTamCor")]
    public class VgDocLinTamCor : VgNetDapperModels.AbstractModels.VgDocLinTamCor<DocLigaTamCor>
    {
        public VgDocLinTamCor()
        {
            DocLigaTamCor = new List<DocLigaTamCor>();
            DocLigaTamCorBase = new List<DocLigaTamCor>();
        }
    }
}