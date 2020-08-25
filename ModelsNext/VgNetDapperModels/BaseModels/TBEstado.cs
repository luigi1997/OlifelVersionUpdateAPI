using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("TBEstados")]
    public class TBEstado
    {
        [Key]
        public int Estado { get; set; }
        public string Descritivo { get; set; }
    }
}