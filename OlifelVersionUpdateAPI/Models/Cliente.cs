using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlifelVersionUpdateAPI.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Grupo { get; set; }
        public string Versao_atual { get; set; }
        public bool Contrato_assistencia { get; set; }
        public DateTime? Data_criacao { get; set; }
        public string Classe { get; set; }
        public string Terceiro { get; set; }
        public string Morada { get; set; }
        public string Localidade { get; set; }
        public string CPostal { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Fax { get; set; }
        public string NIF { get; set; }
        public string Obs { get; set; }
    }
}
