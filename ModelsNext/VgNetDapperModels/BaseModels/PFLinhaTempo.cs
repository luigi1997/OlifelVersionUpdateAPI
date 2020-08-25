using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.BaseModels
{
    [Table("PFLinhaTempo")]
    public class PFLinhaTempo
    {
		[Key]
        public int Id { get; set; }

		public int Plano { get; set; }
		public int Etapa { get; set; }
		public int Ordem { get; set; }
		public int SubPlano { get; set; }

		public int Linha { get; set; }

		public int Fase { get; set; }

		public DateTime DataInicio { get; set; }
		public DateTime? DataFim { get; set; }
		public int? TempoUtilMin { get; set; }
	}
}
