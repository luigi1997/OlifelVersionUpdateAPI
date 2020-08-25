namespace VgNetDapperModels.BaseModels
{
    public class InterligaConfig
    {

        public string ConnString { get; set; }

        public int? DefaultFamiliaArt { get; set; }

        public string DefaultClasseTer { get; set; }

        public string DefaultMoeda { get; set; }

        public int? DefaultTabIVA { get; set; }

        public int? DefaultTabCodIVA { get; set; }

        public double? DefaultTaxIVA { get; set; }

        public bool? ExportEmbBdLiga { get; set; }

    }

}