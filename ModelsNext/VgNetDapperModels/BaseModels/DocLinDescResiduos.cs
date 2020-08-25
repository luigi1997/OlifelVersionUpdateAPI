using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("DocLinDescResiduos")]
    public class DocLinDescResiduos : IDocLinDescResiduos
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
        public int LinhaID { get; set; }

        [ExplicitKey]
        public int NumLinha { get; set; }

        public string Artigo { get; set; }

        public string Designacao { get; set; }

        public double? Quantidade { get; set; }

        public double? Preco { get; set; }

        public int? MovPos { get; set; }

        public int? LinTmp { get; set; }
}

}
