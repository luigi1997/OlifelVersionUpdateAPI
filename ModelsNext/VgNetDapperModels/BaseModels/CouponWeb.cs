using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("CupoesWeb")]
    public class CouponWeb
    {
        [ExplicitKey]
        public string Coupon { get; set; }
        public float? Valor { get; set; }
        public float? Percentagem { get; set; }
        public string Classe { get; set; }
        public string Terceiro { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool Estado { get; set; }
        public bool Enviado { get; set; }
        public bool UsoUnico { get; set; }
        public bool RetiraPortes { get; set; }

        [Computed]
        public bool Notificar { get; set; } = false;
        [Computed]
        public string Email { get; set; }

    }
}