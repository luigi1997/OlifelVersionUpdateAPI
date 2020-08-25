namespace VgNetDapperModels.BaseModels
{
    public class TDPrint
    {
        public string TipoDoc { get; set; }

        public int Impresso { get; set; }

        public string PrinterName { get; set; }

        public short? NumVias { get; set; }

        public bool? Marca { get; set; }

        public bool? Confirma { get; set; }

        public bool? Numera { get; set; }

        public int? Contador { get; set; }

        public short? PaperSize { get; set; }

        public bool? LandScape { get; set; }

        public int? Layout { get; set; }

        public bool? TemTamCor { get; set; }

        public bool? TemPreview { get; set; }

        public bool? ChkPreview { get; set; }

    }
}