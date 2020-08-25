using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("ArtFamLotes")]
    public class ArtFamLote
    {
        public int Familia { get; set; }

        public int Sequencia { get; set; }

        public int? Dado { get; set; }

        public int? Inicio { get; set; }

        public int? Tamanho { get; set; }
    }
}