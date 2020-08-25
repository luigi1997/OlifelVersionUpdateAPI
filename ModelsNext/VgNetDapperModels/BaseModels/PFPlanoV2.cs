using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.BaseModels
{
    [Table("PFPlanos")]
    public class PFPlanoV2
    {
        [Key]
        public int Ordem { get; set; }
        [Key]
        public int Etapa { get; set; }
        [Key]
        public int Plano { get; set; }
        [Key]
        public int SubPlano { get; set; }


        public double? Quant { get; set; }
        public double? QtdEnt { get; set; }
        public double? QtdSai { get; set; }
        public DateTime? DatEnt { get; set; }
        public DateTime? DatSai { get; set; }
        public int? SubIni { get; set; }
        public int? SubFin { get; set; }
        public bool? Entrou { get; set; }
        public bool? Saiu { get; set; }
        public DateTime? TempoDecorrido { get; set; }
        public DateTime? TempoPausas { get; set; }
        public DateTime? TempoUtil { get; set; }
    }
}
