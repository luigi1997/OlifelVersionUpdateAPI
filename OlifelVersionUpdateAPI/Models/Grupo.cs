using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlifelVersionUpdateAPI.Models
{
    public class Grupo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Hora_distribuicao { get; set; }
        public DateTime? Data_criacao { get; set; }
        public DateTime? Data_ultima_alteracao { get; set; }
    }
}
