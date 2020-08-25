using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.BaseModels
{
    [Table("TSImpressos")]
    public class TSImpresso
    {
        public int Impresso { get; set; }

        public short? Tipo { get; set; }

        public string Descritivo { get; set; }

        public string ReportName { get; set; }

        public string PrinterName { get; set; }

        public bool? Configura { get; set; }

        public short? PaperSize { get; set; }

        public bool? LandScape { get; set; }

        public bool? UsaPorDefeito { get; set; }

    }

}