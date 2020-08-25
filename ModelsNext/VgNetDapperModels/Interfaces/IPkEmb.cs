using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IPkEmb
    {
        string TipoDoc { get; set; }

        int Ano { get; set; }

        short Mes { get; set; }

        int NumDoc { get; set; }

        int NumEmb { get; set; }

        int LinhaID { get; set; }

        string Local { get; set; }

        string Lote { get; set; }

        int Tam { get; set; }

        int Cor { get; set; }

        int? Embalagem { get; set; }

        string Artigo { get; set; }

        double? Quant { get; set; }

        double? PesoLiquido { get; set; }

        double? Tara { get; set; }

        double? Volume { get; set; }

        string Nota1 { get; set; }

        string Nota2 { get; set; }

        string Nota3 { get; set; }

        double? QtdEnt { get; set; }

        double? QtdSai { get; set; }

        int? NumLinha { get; set; }

        int? Sortido { get; set; }

        int? LinSortido { get; set; }

        short? NrResto { get; set; }

    }
}