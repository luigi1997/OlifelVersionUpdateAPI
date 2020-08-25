using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("TBDistritos")]
    public class TBDistrito
    {
        [Key]
        public int DistritoID { get; set; }
        public int Distrito { get; set; }
        public string Nome { get; set; }
    }
}