using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("DocContadores")]
    public class DocContador
    {
        [ExplicitKey]
        public string TipoDoc { get; set; }
        [ExplicitKey]
        public int Ano { get; set; }
        [ExplicitKey]
        public short Mes { get; set; }
        [ExplicitKey]
        public int NumDoc { get; set; }
        [ExplicitKey]
        public int Contador { get; set; }

        public int? Numero { get; set; }

    }
}