using System;
using System.ComponentModel.DataAnnotations;

namespace OlifelVersionUpdateAPI.Models
{
    public class VersaoCliente
    {
        [Key]
        public Guid Cliente_ID { get; set; }
        [Key]
        public string Versao_ID { get; set; }
        public DateTime Data_distribuicao { get; set; }
    }
}
