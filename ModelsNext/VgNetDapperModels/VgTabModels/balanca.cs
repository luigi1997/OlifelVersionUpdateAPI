using Dapper.Contrib.Extensions;

namespace VgNetDapperModels.VgTabModels
{
    [Table("Balancas")]
    public class Balanca
    {
        [ExplicitKey]
        public string PostoSN { get; set; }
        [ExplicitKey]
        public byte BalancaID { get; set; }
        public string Designacao { get; set; }

        public string BPorta { get; set; }

        public byte? BMode { get; set; }

        public string BBaud { get; set; }

        public string BSettings { get; set; }

        public byte? BProtocol { get; set; }

        public bool BActiva { get; set; }

        public short? InBufferSize { get; set; }

        public short? OutBufferSize { get; set; }

        public short? RThreshold { get; set; }

        public short? SThreshold { get; set; }

        public bool DTR { get; set; }

        public bool EOF { get; set; }

        public bool RTS { get; set; }

        public string IPServer { get; set; }

        public short? TCPPort { get; set; }
        public string Operador { get; set; }
        public double? Fator { get; set; }
        public string CharINI { get; set; }
        public string CharFIM { get; set; }
        public int? TotalChars { get; set; }
    }

}
