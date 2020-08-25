using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("TerImpEmail")]
    public class TerImpEmail
    {
        public string Classe { get; set; }

        public string Terceiro { get; set; }

        public string TipoDoc { get; set; }

        public int Impresso { get; set; }

        public short SendToCC { get; set; }

        public string Email { get; set; }

    }
}