using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VgNetDapperDataExtended
{
    [Table("DocLinSortido")]
    public class VgDocLinSortido : VgNetDapperModels.AbstractModels.VgDocLinSortido<DocLinSortItem>
    {
        public VgDocLinSortido()
        {
            ArtSortidoItems = new List<VgNetDapperModels.AbstractModels.ArtSortidoItemWeb>();
            DocLinSortItems = new List<DocLinSortItem>();
        }
    }
}