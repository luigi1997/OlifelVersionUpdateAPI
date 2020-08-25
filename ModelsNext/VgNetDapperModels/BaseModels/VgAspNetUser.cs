using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("AspNetUsers")]
    public class VgAspNetUser
    {
        [Key]
        public string Id { get; set; }

        public string Classe { get; set; }

        public string Terceiro { get; set; }

        public string Nome { get; set; }

        public string UltimoNome { get; set; }

        public string Nif { get; set; }

        public string Telefone { get; set; }

        public bool Desativado { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public string UserName { get; set; }

    }
}