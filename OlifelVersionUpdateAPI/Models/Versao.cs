using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlifelVersionUpdateAPI.Models
{
    public class Versao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string Tag_name { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public DateTime Published_at { get; set; }
        [Required]
        public bool Distribuida { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + "\nTag_name: " + Tag_name + "\nNome: " + Name + "\nBody: " + Body + "\nPublished_at: " + Published_at + "\nDistribuida: " + Distribuida;
        }
    }
}
