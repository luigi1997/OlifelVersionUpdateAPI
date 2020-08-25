using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("TerArtigos")]
    public class VgTerArtigo
    {
        public string Classe { get; set; }

        public string Terceiro { get; set; }

        public string Artigo { get; set; }

        public string Codigo { get; set; }

        public string Designacao { get; set; }

        public short? Dias { get; set; }

        public string obs { get; set; }

        public int? Prioridade { get; set; }

        public int? DiasPrzEnt { get; set; }

        public int? DiasMrgSeg { get; set; }

        public string UnMedTer { get; set; }

        public double? ConvTer { get; set; }

        public double? ConvStk { get; set; }

        public double? Preco { get; set; }

        public string Desconto { get; set; }

        
    }

}