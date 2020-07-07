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
        public string Tag_name { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public DateTime Published_at { get; set; }
    }
}
