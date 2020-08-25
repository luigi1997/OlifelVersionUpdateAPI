using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("PFControloDefeitos")]
    public class PFControloDefeito : IPFControloDefeito
    {
        [Key]
        public int Defeito { get; set; }
        public int Controlo { get; set; }
        public byte[] Imagem { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
    }
}