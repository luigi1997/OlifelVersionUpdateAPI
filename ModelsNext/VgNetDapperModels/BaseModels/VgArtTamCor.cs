using System;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    public class VgArtTamCor : IVgArtTamCor
    {
        public string Artigo { get; set; }

        public int Tam { get; set; }

        public int Cor { get; set; }

        public double? Peso { get; set; }

        public double? PCR { get; set; }

        public double? PCU { get; set; }

        public double? PCM { get; set; }

        public double? CMP { get; set; }

        public double? PCP { get; set; }

        public double? StkQtd { get; set; }

        public DateTime? DataCria { get; set; }

        public DateTime? DtUpdate { get; set; }

        public DateTime? HrUpdate { get; set; }

        public DateTime? UltDatPCU { get; set; }

        public DateTime? UltDatPCP { get; set; }

        public string CodBarras { get; set; }

        public double? StkMin { get; set; }

        public double? StkMax { get; set; }

        public double? StkEnc { get; set; }

        public double? LotEnc { get; set; }

        public short? SeqTam { get; set; }

        public short? SeqCor { get; set; }

        public double? AcumPCMQtd { get; set; }

        public double? AcumPCMVal { get; set; }

        public double? AcumEntQtd { get; set; }

        public double? AcumEntVal { get; set; }

        public double? AcumSaiQtd { get; set; }

        public double? AcumSaiVal { get; set; }

        public double? SaiEnc { get; set; }

        public double? SaiRes { get; set; }

        public double? SaiDev { get; set; }

        public double? EntEnc { get; set; }

        public double? EntRes { get; set; }

        public double? EntDev { get; set; }

        public double? PCRSai { get; set; }

        public double? PCUSai { get; set; }

        public double? PCMSai { get; set; }

        public double? CMPSai { get; set; }

        public double? PCPSai { get; set; }

        public double? AcumPCMQtdEnt { get; set; }

        public int? TipoCodBarras { get; set; }

        public double? AcumPCMCusto { get; set; }

        public double? AcumEntCusto { get; set; }

        public double? AcumSaiCusto { get; set; }

        public double? CustoUlt { get; set; }

        public double? CustoMed { get; set; }

    }

}