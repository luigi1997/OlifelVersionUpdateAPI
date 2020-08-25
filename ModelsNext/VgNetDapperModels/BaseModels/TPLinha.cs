using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("TPLinhas")]
    public class TPLinha
    {
        public int Linha { get; set; }
        public string Descritivo { get; set; }
        public int Fase { get; set; }
        public double? Horas { get; set; }
        public double? Pares { get; set; }
        public DateTime? HoraIni { get; set; }
        public DateTime? HoraFim { get; set; }
        public DateTime? PausaIni { get; set; }
        public DateTime? PausaFim { get; set; }
        public string GridColor { get; set; }
        public string ForeColor { get; set; }
        public DateTime? Intervalo1Ini { get; set; }
        public DateTime? Intervalo1Fim { get; set; }
        public DateTime? Intervalo2Ini { get; set; }
        public DateTime? Intervalo2Fim { get; set; }
        public int? NumFunc { get; set; }
    }

}