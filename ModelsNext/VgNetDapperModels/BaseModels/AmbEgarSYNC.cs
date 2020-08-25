using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperModels.BaseModels
{
    [Table("AmbEgarSYNC")]
    public class AmbEgarSYNC
    {
        [ExplicitKey]
        public string numeroGuia { get; set; }
        [ExplicitKey]
        public string codigoGuia { get; set; }

        public string remNIF { get; set; }

        public string remNome { get; set; }

        public string remMorada { get; set; }

        public string remLocalidade { get; set; }

        public string remCodigoPostal { get; set; }

        public string remEstAPA { get; set; }

        public string destNIF { get; set; }

        public string destNome { get; set; }

        public string destMorada { get; set; }

        public string destLocalidade { get; set; }

        public string destCodigoPostal { get; set; }

        public string destEstAPA { get; set; }

        public string destNumPgl { get; set; }

        public string destNumPglCorrigido { get; set; }

        public string transNIF { get; set; }

        public string transNome { get; set; }

        public string transMatricula { get; set; }

        public DateTime? transDataHoraIni { get; set; }

        public DateTime? transDataValidade { get; set; }

        public string resDesignacao { get; set; }

        public string resCodigoResiduoLer { get; set; }

        public string resCodigoOperacao { get; set; }

        public double? resQuantidade { get; set; }

        public string resCodigoGrupo { get; set; }

        public string resDescGrupo { get; set; }

        public string resDescResiduo { get; set; }

        public string resDescOperacao { get; set; }

        public string resCodigoResiduoLerC { get; set; }

        public string resCodigoOperacaoC { get; set; }

        public double? resQuantidadeC { get; set; }

        public string resCodigoGrupoC { get; set; }

        public string resDescGrupoC { get; set; }

        public string resDescResiduoC { get; set; }

        public string resDescOperacaoC { get; set; }

        public string tipoProdutor { get; set; }

        public string tipoProdutorDesc { get; set; }

        public string tipoInterveniente { get; set; }

        public string tipoIntervenienteDesc { get; set; }

        public string estado { get; set; }

        public string estadoDesc { get; set; }

        public DateTime? dataEstado { get; set; }

        public string comentarioRemetente { get; set; }

        public string comentarioDestinatario { get; set; }

        public bool? pendenteAutorizacao { get; set; }

        public string url { get; set; }

        public DateTime? dataSync { get; set; }

        public string tipoRemetente { get; set; }

        public string remNomeEstab { get; set; }

        public string locRecRetCodigoInterno { get; set; }

        public string locRecRetDescricao { get; set; }

        public string destNomeEstab { get; set; }

        public string resNumPgl { get; set; }

        public string resNumPglCorrigido { get; set; }

        public string numeroOnu { get; set; }

        public string observacoesUm { get; set; }

        public string grupoEmbalagem { get; set; }

        public string classe { get; set; }

        public string codigoEtiqueta { get; set; }

        public string codigorestricaoTuneis { get; set; }

        public string observacoesDois { get; set; }

        public string categoria { get; set; }

        public string volumes { get; set; }

        public DateTime? transDataHoraFim { get; set; }

        public string nifIntervenienteCriacao { get; set; }
        public bool? isChecked { get; set; }

    }

}
