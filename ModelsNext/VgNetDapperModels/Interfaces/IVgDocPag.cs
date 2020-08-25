using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IVgDocPag
    {

        string TipoDoc { get; set; }

        int Ano { get; set; }

        short Mes { get; set; }

        int NumDoc { get; set; }

        int DocPagID { get; set; }

        int? FormPag { get; set; }

        string NDocPag { get; set; }

        double? Valor { get; set; }

        DateTime? Data { get; set; }

        string Banco { get; set; }

        string Obs { get; set; }

        bool? Devolvido { get; set; }

        bool? Depositado { get; set; }

        string ContaDep { get; set; }

        string BancoDep { get; set; }

        DateTime? DataDep { get; set; }

        string Conta { get; set; }

        int? MovBan { get; set; }

        int? MovNum { get; set; }

        string BancoDest { get; set; }

        string NumDeposito { get; set; }

        DateTime? DataDeposito { get; set; }

        bool? Carteira { get; set; }

        bool? ExportadoSEPA { get; set; }
    }
}
