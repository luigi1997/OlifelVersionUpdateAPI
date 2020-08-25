using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace VgNetDapperModels.Helpers
{
    public class Utils
    {
        public static string getChar(bool? TDConfig)
        {
            string result = "0";
            if (TDConfig.HasValue)
                if (TDConfig.Value)
                    result = "1";
            return result;
        }

        public static string getChar(string TDConfig)
        {
            string result = "_";
            if (TDConfig != null && TDConfig != string.Empty)
                result = TDConfig;
            return result;
        }
        public static short getShort(object Value)
        {
            if (Value == null) return 0;
            if (Value.GetType() == typeof(String))
            {
                Value = Value.ToString().Replace("%", "");
                Value = Value.ToString().Replace("€", "");
            }
            try
            {
                short res = Convert.ToInt16(Value);
                return res;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static int getInt(object Value)
        {
            if (Value == null) return 0;
            if (Value.GetType() == typeof(String))
            {
                Value = Value.ToString().Replace("%", "");
                Value = Value.ToString().Replace("€", "");
            }
            try
            {
                int res = Convert.ToInt32(Value);
                return res;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static double getDouble(object Value, bool isDenominator=false)
        {
            if (Value == null)
            {
                if(!isDenominator)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
                

            Value = Value.ToString().Replace("%", "");
            Value = Value.ToString().Replace("€", "");
            Value = ReplaceDecimalSeparator(Value.ToString());
            try
            {
                double res = Convert.ToDouble(Value);
                return res;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static double VGRound(double? valor, int casas, MidpointRounding myRounding = MidpointRounding.AwayFromZero)
        {
            double result = getDouble(valor);
            //converter para decimais por causa dos problemas de arredondamentos dos doubles 
            decimal x = Convert.ToDecimal(result);
            decimal y = Math.Round(x, casas, myRounding);
            result = Utils.getDouble(y);

            return result;
        }

        public static double VGRound(double? valor, short? casas, MidpointRounding myRounding = MidpointRounding.AwayFromZero)
        {
            double result = getDouble(valor);
            int iCasas = getInt(casas);
            //converter para decimais por causa dos problemas de arredondamentos dos doubles 
            decimal x = Convert.ToDecimal(result);
            decimal y = Math.Round(x, iCasas, myRounding);
            result = Utils.getDouble(y);

            return result;
        }

        public static string ReplaceDecimalSeparator(string Value)
        {
            string Result = Value;
            switch (NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
            {
                case ".":
                    Result = Result.Replace(",", ".");
                    break;
                case ",":
                    Result = Result.Replace(".", ",");
                    break;
                default:
                    break;
            }
            return Value;
        }

        /// <summary>
        /// Retorna uma substring, a partir do 1º caracter à esquerda, com o tamanho indicado.
        /// Se o tamanho da string  for inferior ao indicado retorna a mesma string
        /// </summary>
        /// <param name="str">A string a processar</param>
        /// <param name="size">Tamanho desejado</param>
        /// <returns>String igual ou inferior ao tamanho indicado</returns>
        public static string LeftStr(string str, int size)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            else
            {
                return str.Length <= size ? str : str.Substring(0, size);
            }
        }

        /// <summary>
        /// Retira Caracteres Especiais e Portugueses numa string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ObterStringSemAcentosECaracteresEspeciais(string str)
        {
            // Troca os caracteres acentuados por não acentuados //
            string[] acentos = new string[] { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
            string[] semAcento = new string[] { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };

            for (int i = 0; i < acentos.Length; i++)
            {
                str = str.Replace(acentos[i], semAcento[i]);
            }

            // Troca os caracteres especiais da string por "" //
            //string[] caracteresEspeciais = { "\\.", ",", "-", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°" };

            //for (int i = 0; i < caracteresEspeciais.Length; i++)
            //{
            //	str = str.Replace(caracteresEspeciais[i], "");
            //}
            string[] caracteresEspeciais = { "‘", "!", "@", "#", "$", "%", "&", "*", "(", ")", "_", "-", "+", "=", "{", "[", "}", "]", "|", "\\", "<", ",", ">", ".", ":", ";", "?", "/" };
            foreach (var chr in caracteresEspeciais)
            {
                str = str.Replace(chr, "");
            }

            // Troca os espaços no início por "" //
            str = str.Replace("^\\s+", "");
            // Troca os espaços no início por "" //
            str = str.Replace("\\s+$", "");
            // Troca os espaços duplicados, tabulações e etc por " " //
            str = str.Replace("\\s+", " ");
            // Troca um espaço  por "-" //
            str = str.Replace(" ", "-");
            return str.ToLower();
        }
        /// <summary>
        /// Converte para Datetime um valor de data e outro com a hora
        /// </summary>
        /// <param name="dtDoc">Data</param>
        /// <param name="hrDoc">Hora</param>
        /// <returns>Data hora</returns>
        public static DateTime GetDocDatetime(DateTime dtDoc, DateTime hrDoc)
        {
            return new DateTime(dtDoc.Year, dtDoc.Month, dtDoc.Day, hrDoc.Hour, hrDoc.Minute, hrDoc.Second);
        }
    }
}
