using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("DocFamilia")]
    public class DocFamilia
    {
        public int DocFamiliaId { get; set; }

        public int FamiliaId { get; set; }

        public string TipoDoc { get; set; }

    }

}