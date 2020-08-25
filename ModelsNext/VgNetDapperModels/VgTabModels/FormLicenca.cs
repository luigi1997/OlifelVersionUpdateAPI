using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.VgTabModels
{
    public class FormLicenca
    {
        public string FormId { get; set; }
        public DateTime DataAtivacao { get; set; }
        public int Postos { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public string Prazo { get; set; }

    }
}
