namespace VgNetDapperModels.BaseModels
{
    public class PFOrigem
    {
        public int Ordem { get; set; }

        public string TipoDoc { get; set; }

        public int Ano { get; set; }

        public short Mes { get; set; }

        public int NumDoc { get; set; }

        public int LinhaID { get; set; }

        public string Local { get; set; }

        public string Lote { get; set; }

        public int Tam { get; set; }

        public int Cor { get; set; }

        public double? Quant { get; set; }

        public int? DocRecno { get; set; }

        public double? QtdFecha { get; set; }

    }
}