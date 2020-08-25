using System;
using System.Collections.Generic;
using System.Linq;
using VgNetDapperModels.AbstractModels;

namespace VgNetDapperModels.BaseModels
{
    public class DocLin : DocLin<DocLiga, VgDocLinSortido, VgDocLinTamCor, DocLinSortItem, DocLigaTamCor, DocLinDescResiduos, ArtPreco, DocLigaEmb, DocLigaPlanos, DocLigaPlanosTamCor>
    {

        public DocLin()
        {
            TamsCor = new List<VgDocLinTamCor>();
        }
    }
}
