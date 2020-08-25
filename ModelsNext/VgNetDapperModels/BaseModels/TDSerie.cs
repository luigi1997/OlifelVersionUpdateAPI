using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("TDSerie")]
    public class TDSerie
    {
        [ExplicitKey]
        public string TipoDoc { get; set; }
        [ExplicitKey]
        public int Ano { get; set; }
        [ExplicitKey]
        public short Mes { get; set; }

        public bool? Sequencial { get; set; }

        public int? Radical { get; set; }

        public int? PriNumero { get; set; }

        public DateTime? PriData { get; set; }

        public int? UltNumero { get; set; }

        public DateTime? UltData { get; set; }

        public string Prefixo { get; set; }

        public string Sufixo { get; set; }

        public int? ContaDocs { get; set; }

        public int? PriProvisorio { get; set; }

        public int? UltProvisorio { get; set; }

        public int? ContaProv { get; set; }
    }

}