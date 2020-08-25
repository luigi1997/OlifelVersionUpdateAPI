using Dapper.Contrib.Extensions;
using System;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("DocPag")]
    public class VgDocPag : IVgDocPag
    {
      
        [ExplicitKey]
        public string TipoDoc { get; set; }
        [ExplicitKey]
        public int Ano { get; set; }
        [ExplicitKey]
        public short Mes { get; set; }
        [ExplicitKey]
        public int NumDoc { get; set; }
        [Key]
        public int DocPagID { get; set; }

        public int? FormPag { get; set; }
        [Computed]
        public string FormPagDescritivo { get; set; }

        public string NDocPag { get; set; }

        public double? Valor { get; set; }

        public DateTime? Data { get; set; }

        public string Banco { get; set; }

        public string Obs { get; set; }

        public bool? Devolvido { get; set; }

        public bool? Depositado { get; set; }

        public string ContaDep { get; set; }

        public string BancoDep { get; set; }

        public DateTime? DataDep { get; set; }

        public string Conta { get; set; }

        public int? MovBan { get; set; }

        public int? MovNum { get; set; }

        public string BancoDest { get; set; }

        public string NumDeposito { get; set; }

        public DateTime? DataDeposito { get; set; }

        public bool? Carteira { get; set; }

        public bool? ExportadoSEPA { get; set; }

    }

}