using System;

namespace VgNetDapperModels.Interfaces
{
    public interface IVgArtTamCor
    {
        string Artigo { get; set; }

        int Tam { get; set; }

        int Cor { get; set; }

        double? Peso { get; set; }

        double? PCR { get; set; }

        double? PCU { get; set; }

        double? PCM { get; set; }

        double? CMP { get; set; }

        double? PCP { get; set; }

        double? StkQtd { get; set; }

        DateTime? DataCria { get; set; }

        DateTime? DtUpdate { get; set; }

        DateTime? HrUpdate { get; set; }

        DateTime? UltDatPCU { get; set; }

        DateTime? UltDatPCP { get; set; }

        string CodBarras { get; set; }

        double? StkMin { get; set; }

        double? StkMax { get; set; }

        double? StkEnc { get; set; }

        double? LotEnc { get; set; }

        short? SeqTam { get; set; }

        short? SeqCor { get; set; }

        double? AcumPCMQtd { get; set; }

        double? AcumPCMVal { get; set; }

        double? AcumEntQtd { get; set; }

        double? AcumEntVal { get; set; }

        double? AcumSaiQtd { get; set; }

        double? AcumSaiVal { get; set; }

        double? SaiEnc { get; set; }

        double? SaiRes { get; set; }

        double? SaiDev { get; set; }

        double? EntEnc { get; set; }

        double? EntRes { get; set; }

        double? EntDev { get; set; }

        double? PCRSai { get; set; }

        double? PCUSai { get; set; }

        double? PCMSai { get; set; }

        double? CMPSai { get; set; }

        double? PCPSai { get; set; }

        double? AcumPCMQtdEnt { get; set; }

        int? TipoCodBarras { get; set; }

        double? AcumPCMCusto { get; set; }

        double? AcumEntCusto { get; set; }

        double? AcumSaiCusto { get; set; }

        double? CustoUlt { get; set; }

        double? CustoMed { get; set; }

    }
}
