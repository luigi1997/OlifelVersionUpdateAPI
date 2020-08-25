using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.BaseModels
{
    [Table("Vendedores")]
    public class VgVendedor
    {
        public string Vendedor { get; set; }
        public string Nome { get; set; }
        public string CCusto { get; set; }
        public string Categoria { get; set; }
        public int? Escalao { get; set; }
        public string NIF { get; set; }
        public short? DocComissoes { get; set; }
        public string obs { get; set; }
        public string CCCom { get; set; }
        public string txtBotao { get; set; }
        public string ImgBotao { get; set; }
        public string CorBotao { get; set; }
        public string CorTexto { get; set; }
        public string FntName { get; set; }
        public short? FntSize { get; set; }
        public bool? FntBld { get; set; }
        public bool? FntItl { get; set; }
        public bool? FntUnd { get; set; }
        public bool? FntStr { get; set; }
        public int? POSpwd { get; set; }
        public bool? TemTerminal { get; set; }
        public int? CodTerminal { get; set; }
        public string TxtTerminal { get; set; }
        public string ReportaVen { get; set; }
        public string ReportaCom { get; set; }
        public short? SobreVenCom { get; set; }
        public string Classe { get; set; }
        public string Terceiro { get; set; }
        public string TipoDoc { get; set; }
        public string Artigo { get; set; }
        public int? Rubrica { get; set; }
        public string Email { get; set; }
    }
}
