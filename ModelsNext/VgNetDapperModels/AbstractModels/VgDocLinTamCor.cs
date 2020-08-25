using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.AbstractModels
{
    [Table("DocLinTamCor")]
    public abstract class VgDocLinTamCor<DLTC> : IVgDocLinTamCor
                     where DLTC : IDocLigaTamCor
    {
     
        [Computed]
        public IList<DLTC> DocLigaTamCor { get; set; }
        [Computed]
        public IList<DLTC> DocLigaTamCorBase { get; set; }

        [Computed]
        public string TamDesc { get; set; }

        [ExplicitKey]
        public string TipoDoc { get; set; }
        [ExplicitKey]
        public int Ano { get; set; }
        [ExplicitKey]
        public short Mes { get; set; }
        [ExplicitKey]
        public int NumDoc { get; set; }
        [ExplicitKey]
        public int LinhaID { get; set; }
        [ExplicitKey]
        public string Local { get; set; }
        [ExplicitKey]
        public string Lote { get; set; }
        [ExplicitKey]
        public int Tam { get; set; }
        [ExplicitKey]
        public int Cor { get; set; }

        public string Artigo { get; set; }

        public string Armazem { get; set; }

        public double? Quantidade { get; set; }

        public double? Preco { get; set; }

        public double? ArtQtd { get; set; }

        public double? ArtRes { get; set; }

        public double? ArmQtd { get; set; }

        public double? ArmRes { get; set; }

        public double? PCU { get; set; }

        public double? PCM { get; set; }

        public double? CMP { get; set; }

        public double? PCP { get; set; }

        public double? QtdReg1 { get; set; }

        public double? QtdReg2 { get; set; }

        public double? QtdReg3 { get; set; }

        public double? QtdReg4 { get; set; }

        public double? QtdReg5 { get; set; }

        public double? QtdDescProd { get; set; }

        public DateTime? DtUpdate { get; set; }

        public DateTime? HrUpdate { get; set; }

        public double? QtdBase { get; set; }

        public string DesTam { get; set; }

        public string DesCor { get; set; }

        public double? Reservado { get; set; }

        public double? Requisitado { get; set; }

        public double? Entregue { get; set; }

        public double? Saida { get; set; }

        public double? QtdStk { get; set; }

        public string ChaveTamCor { get; set; }

        public double? QtdExc1 { get; set; }

        public double? QtdExc2 { get; set; }

        public double? QtdExc3 { get; set; }

        public double? QtdExc4 { get; set; }

        public double? QtdExc5 { get; set; }

        public double? AcertoRes { get; set; }

        public double? AcertoReq { get; set; }

        public double? AcertoEnt { get; set; }

        public double? AcertoSai { get; set; }

        public double? Peso { get; set; }

        public double? CustoUni { get; set; }

        public double? CustoVal { get; set; }

        public double? CustoUlt { get; set; }

        public double? CustoMed { get; set; }

        public double? QtdTara { get; set; }

        public bool? AprovaLinha { get; set; }

        public string AprovaUser { get; set; }

        public double? QtdStkOrig { get; set; }

        public double? QtdFecha { get; set; }

        public double? QtdPrev { get; set; }

        public double? Gito { get; set; }

        public string Molde { get; set; }

    }


}