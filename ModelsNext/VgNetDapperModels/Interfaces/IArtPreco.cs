using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IArtPreco
    {
        string Artigo { get; set; }
        int Tam { get; set; }
        int Cor { get; set; }
        short NumPreco { get; set; }
        double? Preco { get; set; }
        short? PrecoRef { get; set; }
        short? MargCalc { get; set; }
        double? Margem { get; set; }
    }
}
