using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("TBCodPostal")]
    public class TBCodPostal
    {
        [Key]
        public int recno { get; set; }
        
        public string Pais { get; set; }
        public string CPCodigo { get; set; }
        public string CPLocal { get; set; }
        public int? DistritoID { get; set; }
        public int? ConcelhoID { get; set; }
        public int? LocalidadeID { get; set; }
        public string Morada { get; set; }

    }
}