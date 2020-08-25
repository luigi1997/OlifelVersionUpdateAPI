using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("TGCopias")]
    public class TGCopia
    {
        public int NumVia { get; set; }
        public string Copia { get; set; }
    }
}