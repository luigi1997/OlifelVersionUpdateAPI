using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("Alertas")]
    public class Alerta
    {
        public int MsgId { get; set; }

        public string Empresa { get; set; }

        public string Utilizador { get; set; }

        public string Mensagem { get; set; }

        public bool Lida { get; set; }

        public string Origem { get; set; }

        public DateTime DataHora { get; set; }
        public string TipoDoc { get; set; }
        public int? Ano { get; set; }
        public short? Mes { get; set; }
        public int? NumDoc { get; set; }

    }
}
