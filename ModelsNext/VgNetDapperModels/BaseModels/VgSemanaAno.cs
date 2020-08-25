using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.BaseModels
{
    public class VgSemanaAno
    {
        public int SemanaId { get; set; }
        public int SemanaAno { get; set; }
        public int Sequencia { get; set; }
        public DateTime DiaInicio { get; set; }
        public DateTime DiaFim { get; set; }
    }
}
