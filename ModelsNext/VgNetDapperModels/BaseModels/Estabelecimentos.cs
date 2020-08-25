using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("Estabelecimentos")]
    public class Estabelecimento
    {
        [ExplicitKey]
        public string nif { get; set; }
        [ExplicitKey]
        public string codigoapa { get; set; }
        public string nome { get; set; }
        public string moradasede { get; set; }
        public string codpostalsede { get; set; }
        public string localidadesede { get; set; }
        public bool? autoriza_emissao { get; set; }
    }
}
