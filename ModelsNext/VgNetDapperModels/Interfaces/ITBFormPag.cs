using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface ITBFormPag
    {
        int FormPag { get; set; }

        string Descritivo { get; set; }

        string CtbConta { get; set; }

        bool? CtbLetras { get; set; }

        bool? Recalculo { get; set; }

        string obs { get; set; }

        string txtBotao { get; set; }

        string ImgBotao { get; set; }

        string CorBotao { get; set; }

        string CorTexto { get; set; }

        string FntName { get; set; }

        bool? TemDoc { get; set; }

        int? MovBan { get; set; }

        string Conta { get; set; }

        string MecPagSAFT { get; set; }

        bool? TemCaixa { get; set; }

        bool? TemPOS { get; set; }

        bool? IsCashPOS { get; set; }

        string CtbContaDebito { get; set; }

        string CtbContaCredito { get; set; }

        bool? ExpSEPA { get; set; }
    }
}
