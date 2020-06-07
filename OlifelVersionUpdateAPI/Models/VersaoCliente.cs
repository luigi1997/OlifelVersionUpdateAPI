using System;
using System.ComponentModel.DataAnnotations;

namespace OlifelVersionUpdateAPI.Models
{
    public class VersaoCliente
    {
        [Key]
        [Required]
        public string Cliente_ID { get; set; }
        [Key]
        [Required]
        public string Versao_ID { get; set; }
        [Required]
        public DateTime? Data_distribuicao { get; set; }
    }
}
