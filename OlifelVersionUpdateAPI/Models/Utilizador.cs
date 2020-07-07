using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlifelVersionUpdateAPI.Models
{
    public class Utilizador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public string UserPwd { get; set; }
        public bool IsAdmin { get; set; }
    }
}
