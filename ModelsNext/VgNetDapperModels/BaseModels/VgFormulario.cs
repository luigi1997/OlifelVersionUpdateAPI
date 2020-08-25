using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("Formularios")]
    public class VgFormulario
    {
        public string FormID { get; set; }

        public string FormName { get; set; }

        public bool Retira { get; set; }

        public string Licenca { get; set; }
    }
}