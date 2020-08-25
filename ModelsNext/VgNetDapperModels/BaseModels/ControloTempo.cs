using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("ControloTempos")]
    public class ControloTempo
    {
        [ExplicitKey]
        public string Tipodoc { get; set; }
        [ExplicitKey]
        public int Ano { get; set; }
        [ExplicitKey]
        public short Mes { get; set; }
        [ExplicitKey]
        public int NumDoc { get; set; }
        [Key]
        public int Id { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public string Funcionario { get; set; }
        public string Categoria { get; set; }
    }

}
