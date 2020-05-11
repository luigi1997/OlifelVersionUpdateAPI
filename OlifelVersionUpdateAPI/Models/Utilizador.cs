using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlifelVersionUpdateAPI.Models
{
    public class Utilizador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool Admin { get; set; }
        public DateTime? Data_criacao { get; set; }
        public DateTime? Data_ultima_alteracao { get; set; }
    }
}
