using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("ArtEscTam")]
    public class VgArtEscTam : IArtEscTam
    {
        public string Artigo { get; set; }

        public int Tam { get; set; }

        public string Descritivo { get; set; }

        public short? GrupoTam { get; set; }

        public short? Sequencia { get; set; }
    }
}