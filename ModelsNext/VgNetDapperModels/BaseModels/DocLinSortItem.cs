using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("DocLinSortItems")]
    public class DocLinSortItem : IDocLinSortItem
    {
        public string TipoDoc { get; set; }

        public int Ano { get; set; }

        public short Mes { get; set; }

        public int NumDoc { get; set; }

        public int LinhaID { get; set; }

        public int LinSortido { get; set; }

        public int Cor { get; set; }

        public int Tam { get; set; }

        public string Artigo { get; set; }

        public double? Quant { get; set; }

        public double? Peso { get; set; }
    }
}