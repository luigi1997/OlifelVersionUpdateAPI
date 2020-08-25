using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("ArtIdiomas")]
    public class ArtIdioma
    {
        public string Artigo { get; set; }

        public int Idioma { get; set; }

        public string Designacao { get; set; }

        public string Abreviatura { get; set; }

        public string TxtBotao { get; set; }

        public string TxtTalao { get; set; }

        public string TxtPagina { get; set; }

        public string TxtLista { get; set; }

        public string obs { get; set; }

    }

}