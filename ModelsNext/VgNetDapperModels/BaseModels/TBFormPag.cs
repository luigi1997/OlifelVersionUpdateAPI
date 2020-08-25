using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("TBFormPag")]
    public class TBFormPag : ITBFormPag
    {
        [Key]
        public int FormPag { get; set; }

        public string Descritivo { get; set; }

        public string CtbConta { get; set; }

        public bool? CtbLetras { get; set; }

        public bool? Recalculo { get; set; }

        public string obs { get; set; }

        public string txtBotao { get; set; }

        public string ImgBotao { get; set; }

        public string CorBotao { get; set; }

        public string CorTexto { get; set; }

        public string FntName { get; set; }

        public bool? TemDoc { get; set; }

        public int? MovBan { get; set; }

        public string Conta { get; set; }

        public string MecPagSAFT { get; set; }

        public bool? TemCaixa { get; set; }

        public bool? TemPOS { get; set; }

        public bool? IsCashPOS { get; set; }

        public string CtbContaDebito { get; set; }

        public string CtbContaCredito { get; set; }

        public bool? ExpSEPA { get; set; }
       
    }

}