using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.BaseModels
{
    [Table("TPCapacidade")]
    public class TPCapacidade
    {
        [Key]
        public int Calendario { get; set; }
        [ExplicitKey]
        public int Fase { get; set; }
        [ExplicitKey]
        public int Linha { get; set; }
        [ExplicitKey]
        public DateTime Data { get; set; }

        public DateTime? HoraIni { get; set; }
        public DateTime? HoraFim { get; set; }
        public double? Horas { get; set; }
        public double? Pares { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public double? ContaPares { get; set; }
        public double? GastaHoras { get; set; }
        public DateTime? PausaIni { get; set; }
        public DateTime? PausaFim { get; set; }
        public DateTime? Intervalo1Ini { get; set; }
        public DateTime? Intervalo1Fim { get; set; }
        public DateTime? Intervalo2Ini { get; set; }
        public DateTime? Intervalo2Fim { get; set; }

        /// <summary>
        /// Numero de funcionários do turno da manha
        /// </summary>
        public int? NFuncManha { get; set; }

        /// <summary>
        /// Numero de funcionários do turno da tarde
        /// </summary>
        public int? NFuncTarde { get; set; }
    }
}
