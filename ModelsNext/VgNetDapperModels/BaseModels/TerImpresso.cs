using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("TerImpressos")]
    public class TerImpresso
    {
        public string Classe { get; set; }

        public string Terceiro { get; set; }

        public string TipoDoc { get; set; }

        public int Impresso { get; set; }

        public int? Destino { get; set; }

    }
}