using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("TDGera")]
    public class VgTDGera: IVgTDGera
    {
        [ExplicitKey]
        public string TipoDoc { get; set; }

        [ExplicitKey]
        public string Empresa { get; set; }

        [ExplicitKey]
        public string TDGera { get; set; }

    }
}
