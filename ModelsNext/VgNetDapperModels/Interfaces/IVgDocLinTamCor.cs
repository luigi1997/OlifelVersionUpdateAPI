using System;

namespace VgNetDapperModels.Interfaces
{
    public interface IVgDocLinTamCor
    {
        string TipoDoc { get; set; }

        int Ano { get; set; }

        short Mes { get; set; }

        int NumDoc { get; set; }

        int LinhaID { get; set; }

        string Local { get; set; }

        string Lote { get; set; }

        int Tam { get; set; }

        int Cor { get; set; }

        string Artigo { get; set; }

        string Armazem { get; set; }

        double? Quantidade { get; set; }

        double? Preco { get; set; }

        double? ArtQtd { get; set; }

        double? ArtRes { get; set; }

        double? ArmQtd { get; set; }

        double? ArmRes { get; set; }

        double? PCU { get; set; }

        double? PCM { get; set; }

        double? CMP { get; set; }

        double? PCP { get; set; }

        double? QtdReg1 { get; set; }

        double? QtdReg2 { get; set; }

        double? QtdReg3 { get; set; }

        double? QtdReg4 { get; set; }

        double? QtdReg5 { get; set; }

        double? QtdDescProd { get; set; }

        DateTime? DtUpdate { get; set; }

        DateTime? HrUpdate { get; set; }

        double? QtdBase { get; set; }

        string DesTam { get; set; }

        string DesCor { get; set; }

        double? Reservado { get; set; }

        double? Requisitado { get; set; }

        double? Entregue { get; set; }

        double? Saida { get; set; }

        double? QtdStk { get; set; }

        string ChaveTamCor { get; set; }

        double? QtdExc1 { get; set; }

        double? QtdExc2 { get; set; }

        double? QtdExc3 { get; set; }

        double? QtdExc4 { get; set; }

        double? QtdExc5 { get; set; }

        double? AcertoRes { get; set; }

        double? AcertoReq { get; set; }

        double? AcertoEnt { get; set; }

        double? AcertoSai { get; set; }

        double? Peso { get; set; }

        double? CustoUni { get; set; }

        double? CustoVal { get; set; }

        double? CustoUlt { get; set; }

        double? CustoMed { get; set; }

        double? QtdTara { get; set; }

        bool? AprovaLinha { get; set; }

        string AprovaUser { get; set; }

        double? QtdStkOrig { get; set; }

        double? QtdFecha { get; set; }

        double? QtdPrev { get; set; }
        double? Gito { get; set; }
    }
}
