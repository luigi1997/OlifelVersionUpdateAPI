using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{ 
    [Table("TgPaises")]
    public class TgPais
    {
        [ExplicitKey]
        public string Pais { get; set; }

        public string Designacao { get; set; }

        public string Moeda { get; set; }

        public string obs { get; set; }

        public int recno { get; set; }
        public bool TemOnline { get; set; }

        [Computed]
        public string CodeDescription
        {
            get
            {
                return $"{Pais} {Designacao}";
            }
        }
    }
}