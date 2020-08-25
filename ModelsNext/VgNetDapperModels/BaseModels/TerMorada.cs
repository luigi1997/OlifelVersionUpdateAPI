using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("TerMoradas")]
    public class TerMorada
    {
        [ExplicitKey]
        public string Classe { get; set; }
        [ExplicitKey]
        public string Terceiro { get; set; }
        [ExplicitKey]
        public int Morada { get; set; }
    }
}