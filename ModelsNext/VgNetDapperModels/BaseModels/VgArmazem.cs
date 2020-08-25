using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("Armazens")]
    public class VgArmazem
    {
        public string Armazem { get; set; }

        public string Designacao { get; set; }

        public string Morada { get; set; }

        public string Localidade { get; set; }

        public string CodPostal { get; set; }

        public string LocPostal { get; set; }

        public string Telefone { get; set; }

        public string Telex { get; set; }

        public string Fax { get; set; }

        public string Responsavel { get; set; }

        public string Obs { get; set; }

        public int recno { get; set; }

        public string Pais { get; set; }

        public bool? TemLocal { get; set; }

        public int? ProcLocal { get; set; }

    }

}