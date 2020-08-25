using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("TGLocalidades")]
    public class TGLocalidade
    {
        public string Pais { get; set; }
        [Key]
        public int Localidade { get; set; }

        public string Designacao { get; set; }

        public string Obs { get; set; }

        public int? LocalidadeCode { get; set; }

    }
}