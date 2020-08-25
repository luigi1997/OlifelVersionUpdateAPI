using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{

    public interface ITDLiga
    {
        string TipoDoc { get; set; }

        string TipoDocBase { get; set; }

        string QtdReg1 { get; set; }

        string QtdReg2 { get; set; }

        string QtdReg3 { get; set; }

        string QtdReg4 { get; set; }

        string QtdReg5 { get; set; }

        bool? TemRepor { get; set; }

        bool? TemGeral { get; set; }

        bool? TemLigou { get; set; }

        bool? TemVerTodos { get; set; }

        bool? TemPoliCom { get; set; }

        bool? TemNegativo { get; set; }

         bool? PassaCab { get; set; }

         bool? TemAgrupa { get; set; }

         bool? TemQtdNula { get; set; }

         bool? TemQtdCtrl { get; set; }

         bool? TemApaga { get; set; }

         bool? TemVerNegas { get; set; }

         bool? TemStock { get; set; }

         string BtnFldText { get; set; }

         string BtnFldDate { get; set; }

         string BtnFldVal1 { get; set; }

         string BtnFldVal2 { get; set; }

         string BtnFldVal3 { get; set; }

         bool? BtnShowText { get; set; }

         bool? BtnShowDate { get; set; }

         bool? BtnShowVal { get; set; }

         bool? BtnShowObj { get; set; }

         bool? BtnCheckItem { get; set; }

         bool? RegQtdBase { get; set; }

         bool? ShowDateAfter { get; set; }

         int? Estado { get; set; }

         bool? TemEstornoBase { get; set; }

         int? EstadoRepor { get; set; }

         string FiltroEntidade { get; set; }

         string FiltroProcesso { get; set; }

         string FiltroData { get; set; }

         bool? TemPoliComDesc { get; set; }

         bool? TemAddTamCor { get; set; }

         int? NumDiasMostraDocs { get; set; }

         bool? FiltroTipoDocAtivo { get; set; }

         bool? artMostraImagem { get; set; }

         string QtdFecha { get; set; }

    }
}
