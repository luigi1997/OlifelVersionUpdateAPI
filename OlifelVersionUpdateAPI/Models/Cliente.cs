using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlifelVersionUpdateAPI.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Grupo { get; set; }
        [Required]
        public string Versao_atual { get; set; }
        [Required]
        public DateTime Data_limite_atualizacoes { get; set; }
        [Required]
        public DateTime Data_limite_funcionamento { get; set; }
        [Required]
        public bool Contrato_assistencia { get; set; }
        public DateTime? Data_criacao { get; set; }
        public DateTime? Data_ultima_alteracao { get; set; }
        [Required]
        public string Classe { get; set; }
        [Required]
        public string Terceiro { get; set; }
        [Required]
        public int Numero_postos { get; set; }
    }
}
