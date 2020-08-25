using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("ArtImagens")]
    public class ArtImagem : IArtImagem
    {
        [ExplicitKey]
        public string Artigo { get; set; }
        [Key]
        public int ImgID { get; set; }
        public int ImgNum { get; set; }
        public byte[] ImgOld { get; set; }
        public string Descritivo { get; set; }
        public byte[] Imagem { get; set; }
        public byte[] Web { get; set; }
        public int Cor { get; set; }
  
    }
}