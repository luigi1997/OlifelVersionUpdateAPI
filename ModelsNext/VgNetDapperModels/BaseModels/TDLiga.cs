using Dapper.Contrib.Extensions;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("TDLiga")]
    public class TDLiga : ITDLiga
    {
        public string TipoDoc { get; set; }

        public string TipoDocBase { get; set; }

        public string TipoDocBaseDesc { get; set; }

        public string QtdReg1 { get; set; }

        public string QtdReg2 { get; set; }

        public string QtdReg3 { get; set; }

        public string QtdReg4 { get; set; }

        public string QtdReg5 { get; set; }

        public bool? TemRepor { get; set; }

        public bool? TemGeral { get; set; }

        public bool? TemLigou { get; set; }

        public bool? TemVerTodos { get; set; }

        public bool? TemPoliCom { get; set; }

        public bool? TemNegativo { get; set; }

        public bool? PassaCab { get; set; }

        public bool? TemAgrupa { get; set; }

        public bool? TemQtdNula { get; set; }

        public bool? TemQtdCtrl { get; set; }

        public bool? TemApaga { get; set; }

        public bool? TemVerNegas { get; set; }

        public bool? TemStock { get; set; }

        public string BtnFldText { get; set; }

        public string BtnFldDate { get; set; }

        public string BtnFldVal1 { get; set; }

        public string BtnFldVal2 { get; set; }

        public string BtnFldVal3 { get; set; }

        public bool? BtnShowText { get; set; }

        public bool? BtnShowDate { get; set; }

        public bool? BtnShowVal { get; set; }

        public bool? BtnShowObj { get; set; }

        public bool? BtnCheckItem { get; set; }

        public bool? RegQtdBase { get; set; }

        public bool? ShowDateAfter { get; set; }

        public int? Estado { get; set; }

        public bool? TemEstornoBase { get; set; }

        public int? EstadoRepor { get; set; }

        public string FiltroEntidade { get; set; }

        public string FiltroProcesso { get; set; }

        public string FiltroData { get; set; }

        public bool? TemPoliComDesc { get; set; }

        public bool? TemAddTamCor { get; set; }

        public int? NumDiasMostraDocs { get; set; }

        public bool? FiltroTipoDocAtivo { get; set; }

        public bool? artMostraImagem { get; set; }

        public string QtdFecha { get; set; }
        

        public int GetQtdRegNum()
        {
            if (!string.IsNullOrEmpty(QtdReg1))
                return 1;
            if (!string.IsNullOrEmpty(QtdReg2))
                return 2;
            if (!string.IsNullOrEmpty(QtdReg3))
                return 3;
            if (!string.IsNullOrEmpty(QtdReg4))
                return 4;
            if (!string.IsNullOrEmpty(QtdReg5))
                return 5;
            return - 1;
        }
    }

}