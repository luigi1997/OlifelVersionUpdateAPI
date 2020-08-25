using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    public class TBCondPag : ITBCondPag
    {
        public int CondPag { get; set; }

        public string Descritivo { get; set; }

        public short? dias { get; set; }

        public float? desconto { get; set; }

        public short? Prestacoes { get; set; }

        public float? JurosAnual { get; set; }

        public short? AntRepPost { get; set; }

        public short? DiaIni { get; set; }

        public short? MesIni { get; set; }

        public short? DiaFim { get; set; }

        public string obs { get; set; }

    }

}