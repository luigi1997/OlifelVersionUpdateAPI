using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.BaseModels
{
    [Table("TBFuncionario")]
    public class TBFuncionario
    {
        [ExplicitKey]
        public string Funcionario { get; set; }
        public string Nome { get; set; }
        public string CCusto { get; set; }
        public string Categoria { get; set; }
        public double? CustoHora { get; set; }
        public string obs { get; set; }
        public string UserID { get; set; }
        public bool? NaoMostraObs { get; set; }
        public bool? SugereAmostra { get; set; }
        public string RelFPR { get; set; }
        public string RelAmt { get; set; }
        public string RelPro { get; set; }
        public bool Ativo { get; set; }
        public bool ControloTemposAtivo { get; set; }
    }

}
