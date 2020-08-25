using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("Documentos")]
    public class DocBDLiga
    {
        [ExplicitKey]
        public string TipoDoc { get; set; }
        [ExplicitKey]
        public int Ano { get; set; }
        [ExplicitKey]
        public int NumDoc { get; set; }
        [ExplicitKey]
        public int NumLinha { get; set; }

        public string Terceiros { get; set; }

        public string Nome { get; set; }

        public DateTime? Datadoc { get; set; }

        public string NIF { get; set; }

        public string Morada { get; set; }

        public string Localidade { get; set; }

        public string CodPostDoc { get; set; }

        public string LocPostDoc { get; set; }

        public string Pais { get; set; }

        public bool? Fanulado { get; set; }

        public string Artigo { get; set; }

        public string Descricao { get; set; }

        public double? Quantidade { get; set; }

        public string Unidade { get; set; }

        public DateTime? DataEntrega { get; set; }

        public string TamDesc { get; set; }

        public string CorDesc { get; set; }

        public int? Grupo { get; set; }

        public DateTime? DataExportacao { get; set; }

        public DateTime? DataImportacao { get; set; }

    }

}