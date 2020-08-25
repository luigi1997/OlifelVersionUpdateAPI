using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.VgTabModels
{
    [Table("Utilizadores")]
    public class Utilizador
    {
        public string UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int? PasswordFormat { get; set; }

        public string PasswordSalt { get; set; }

        public string PasswordQuestion { get; set; }

        public string PasswordAnswer { get; set; }

        public string UserEmail { get; set; }

        public string MobilePIN { get; set; }

        public string Telemovel { get; set; }

        public bool? isApproved { get; set; }

        public bool? isLockedOut { get; set; }

        public bool? isPOS { get; set; }

        public bool? isNotify { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? LastPwdChangeDate { get; set; }

        public DateTime? LastLockOutDate { get; set; }

        public int? ContaFalhasPassword { get; set; }

        public int? ContaFalhasResposta { get; set; }

        public string AutorizaPwd { get; set; }

        public int? AutorizaNivel { get; set; }

        public string LastEmpresa { get; set; }

        public string Empresa { get; set; }

        public bool? isAdmin { get; set; }

        public byte[] FotoPerfil { get; set; }

        public string usrAT { get; set; }

        public string pwdAT { get; set; }

        public string smtpServer { get; set; }

        public string smtpPort { get; set; }

        public string smtpUser { get; set; }

        public string smtpPass { get; set; }

        public string smtpMail { get; set; }

        public bool? smtpEnableSSL { get; set; }

        public bool? EscondePrecos { get; set; }

        public bool? MonoJanelaPesq { get; set; }

        public bool? MonoJanelaList { get; set; }

        public bool? isAcompTablet { get; set; }

        [Computed]
        public string AuthenticationToken { get; set; }
        [Computed]
        public List<string> FormsAccess { get; set; }
        [Computed]
        public List<VgEmpresaLight> Empresas { get; set; }
    }

    public class VgEmpresaLight
    {
        public string empresa { get; set; }
        public string abreviatura { get; set; }
        public string nome { get; set; }
        public string nomeComercial { get; set; }
        public List<string> formAcess { get; set; }

    }
}
