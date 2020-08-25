using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace VgNetDapperModels.BaseModels
{
    [Table("Licenca")]
    public class VgLicenca
    {
        public int LicID { get; set; }

        public string Produto { get; set; }

        public string Licenca { get; set; }

        public string Confirmacao { get; set; }

        public string Versao { get; set; }

        public string VersaoAutorizada { get; set; }

        public string NomLicenca { get; set; }

        public string EmpLicenca { get; set; }

        public int? Postos { get; set; }

        public int? PostosExternos { get; set; }

        public string PathStdReports { get; set; }

        public bool? NotificaExcecao { get; set; }

        public bool MultiEmpresa { get; set; }

        public List<VgFormulario> ListaFormularios { get; set; }
    }
}