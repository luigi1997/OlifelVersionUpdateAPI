using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("AmbTabDestino")]
    public class AmbTabDestino
    {
        public string Versao { get; set; }

        public string Codigo { get; set; }

        public string Descritivo { get; set; }

        public string Activo { get; set; }

        public string Nivel { get; set; }

        public string Grupo_Versao { get; set; }

        public string Grupo_Codigo { get; set; }

        public string Designacao
        {
            get
            {
                return Codigo + " - " + Descritivo.Trim();
            }
        }

    }
}