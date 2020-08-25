using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    public class VgArtEscCor :IArtEscCor
    {
        [ExplicitKey]
        public string Artigo { get; set; }
        [ExplicitKey]
        public int Cor { get; set; }

        public string Descritivo { get; set; }

        public short? Sequencia { get; set; }
    }
}