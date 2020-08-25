using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("TDClasses")]
    public class TDClasse : ITDClasse
    {
        [ExplicitKey]
        public string TipoDoc { get; set; }
        [ExplicitKey]
        public string Classe { get; set; }
    }
}
