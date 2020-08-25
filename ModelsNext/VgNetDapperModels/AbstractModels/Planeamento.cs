using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.AbstractModels
{
    public abstract class Planeamento<T, M, TBCP, TBFP> 
                where T : IVgTerceiro
                where M : IVgMorada
                where TBCP : ITBCondPag
                where TBFP : ITBFormPag
    {
        [ExplicitKey]
        public int SemanaId { get; set; }
        [ExplicitKey]
        public int SemanaAno { get; set; }
        [ExplicitKey]
        public string TipoDoc { get; set; }
        [ExplicitKey]
        public int Ano { get; set; }
        [ExplicitKey]
        public short Mes { get; set; }
        [ExplicitKey]
        public int NumDoc { get; set; }
        [ExplicitKey]
        public int Fase { get; set; }
        [ExplicitKey]
        public int LinhaID { get; set; }
        [ExplicitKey]
        public int Ordem { get; set; }
        [ExplicitKey]
        public int LinhaFase { get; set; }

        public DateTime? DtEntrega { get; set; }

        public double? Quantidade { get; set; }

        public string Modelo { get; set; }

        public int? Sequencia { get; set; }

        public int? Plano { get; set; }

        public double? Tempo { get; set; }

        public string Classe { get; set; }

        public string Terceiro { get; set; }

        public string Utilizador { get; set; }

        public DateTime? DtUpdate { get; set; }

        public int? SemanaIdInicial { get; set; }
        
        public int? SemanaAnoInicial { get; set; }

        public int? Grupo { get; set; }

        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime? DataFimProducao { get; set; }

        public bool? Confirmada { get; set; }

        [Computed]
        public T VgTerceiro { get; set; }
       
    }
}
