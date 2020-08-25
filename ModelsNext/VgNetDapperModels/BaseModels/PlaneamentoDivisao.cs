using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("PlaneamentoDivisao")]
    public class PlaneamentoDivisao
    {
        [ExplicitKey]
        public string TipoDoc { get; set; }
        [ExplicitKey]
        public int Ano { get; set; }
        [ExplicitKey]
        public int Mes { get; set; }
        [ExplicitKey]
        public int NumDoc { get; set; }
        [ExplicitKey]
        public int Fase { get; set; }
        [ExplicitKey]
        public int LinhaId { get; set; }
        /// <summary>
        /// Sequencia
        /// </summary>
        [ExplicitKey]
        public int Ordem { get; set; }
        public int OrdemPai { get; set; }
        public double? Quantidade { get; set; }
        public bool Planeada { get; set; }
        public string Classe { get; set; }
        public string Terceiro { get; set; }

        [ExplicitKey]
        public int LinhaFase { get; set; }
    }
}
