using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("ArtPrecos")]
    public class ArtPreco : IArtPreco
    {
        [ExplicitKey]
        public string Artigo { get; set; }
        [ExplicitKey]
        public int Tam { get; set; }
        [ExplicitKey]
        public int Cor { get; set; }
        [ExplicitKey]
        public short NumPreco { get; set; }
        public double? Preco { get; set; }
        public short? PrecoRef { get; set; }
        public short? MargCalc { get; set; }
        public double? Margem { get; set; }
    }
}
