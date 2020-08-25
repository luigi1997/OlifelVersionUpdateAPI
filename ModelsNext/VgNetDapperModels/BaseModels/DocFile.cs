using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("DocFiles")]
    public class DocFile : IDocFile
    {
        [ExplicitKey]
        public string TipoDoc { get; set; }
        [ExplicitKey]
        public int Ano { get; set; }
        [ExplicitKey]
        public short Mes { get; set; }
        [ExplicitKey]
        public int NumDoc { get; set; }
        [Key]
        public int NumFile { get; set; }

        public string Descritivo { get; set; }

        public string OriginalFileName { get; set; }

        public string SavedFileName { get; set; }
    }
}