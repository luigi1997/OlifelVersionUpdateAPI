using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VgNetDapperDataExtended.Helpers
{
    public static class Tools
    {

        /// <summary>
        /// Cria uma string com caracteres sorteados com o tamanho indicado
        /// </summary>
        /// <param name="size">Tamanho da string a criar</param>
        /// <param name="seed">Número base para o sorteio de caracteres. 
        /// Em cliclos, a indicação de numeros diferentes a cada evocação deste método permite evitar a geração de strings repetidas</param>
        /// <returns></returns>
        internal static string FillRandomString(int size = 100, int seed = 0)
        {
            string result = string.Empty;
            int charCode = 0;
            Random rnd = seed == 0 ? new Random() : new Random(DateTime.Now.Millisecond + seed);
            
            while (result.Length < size)
            {
                charCode = rnd.Next(32, 126);
                result += Convert.ToChar(charCode != 192 ? charCode : 64);    // 192 = backslash, 64 = @
            }
            
            return result;
        }

        /// <summary>
        /// Retorna uma substring de uma string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        internal static string SafeSubstr(this string str, int startIndex, int length)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            try
            {
                return length > str.Length - startIndex ? str.Substring(startIndex) : str.Substring(startIndex, length);
            }

            catch (IndexOutOfRangeException)
            {
                return str;
            }

            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Altera uma string substituindo os caracteres a partir de uma posição com outra string
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2">string a inserir</param>
        /// <param name="position">Posição a inserir a nova string (começa no 1)</param>
        /// <returns></returns>
        internal static string Mid(this string str1, string str2, int position)
        {
            if (position > str1.Length || position < 0)
                return string.Empty;

            Encoding enc = Encoding.Default;
            int str1Bytes = enc.GetByteCount(str1);
            int str2Bytes = enc.GetByteCount(str2);
            string leftStr = str1.Substring(0, position - 1);
            int rightPosition = position + str2Bytes - 1;
            string rightStr = rightPosition < str1Bytes ? str1.Substring(rightPosition) : string.Empty;
            return leftStr + str2.Truncate(str1Bytes - position + 1) + rightStr;
        }

        /// <summary>
        /// Devolve uma substring contando a posição de start a partir da direita (fim da string)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        internal static string Right(this string str, int start, int length)
        {
            return str.SafeSubstr(str.Length - length - 1, length);
        }


        internal static int GetRecRightStart(int record, int size, int recordSize = 100)
        {
            return record * recordSize - size - (record - 1);
        }

        /// <summary>
        /// Corta uma string para um determinado valor
        /// </summary>
        /// <param name="str"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        internal static string Truncate(this String str, int size)
        {
            return str.Length > size ? str.Substring(0, size) : str;
        }

        /// <summary>
        /// Corta uma string para um determinado valor em bytes
        /// </summary>
        /// <param name="str"></param>
        /// <param name="size"></param>
        /// <param name="cutSymbol"></param>
        /// <returns></returns>

        internal static string TruncateBytes(this string str, int size, string cutSymbol = "")
        {
            Encoding enc = Encoding.UTF8;
            int strByteSize = enc.GetByteCount(str);
            int cutSymbolByteSize = enc.GetByteCount(cutSymbol);
            if (strByteSize > size)
            {
                byte[] strBytesArray = enc.GetBytes(str);
                return cutSymbol != "" && size - cutSymbolByteSize > cutSymbolByteSize ? enc.GetString(strBytesArray, 0, size - cutSymbolByteSize) + cutSymbol :
                    enc.GetString(strBytesArray, 0, size);
            }
            else
                return str;
        }


        /// <summary>
        /// Convert caracteres especiais numa string para ASCII
        /// </summary>
        /// <param name="dirty"></param>
        /// <returns></returns>
        internal static string ToAscii(this string dirty)
        {
            ASCIIEncoding asciiEncoding = new ASCIIEncoding();
            byte[] bytes = asciiEncoding.GetBytes(dirty);
            return asciiEncoding.GetString(bytes);
        }

        /// <summary>
        /// Sorteio um número ou letra em maiúsculas
        /// </summary>
        /// <returns></returns>
        internal static char GetRandomNumberOrLetter()
        {
            Random rnd = new Random();
            int numberOrLetter = rnd.Next(4);           // A probabilidade de gerar um  número é de 1 sobre o valor de rnd.next
            int result = 0;
            if (numberOrLetter == 1)
                result = rnd.Next(48, 57);              // Sorteia um numero
            else
                result = rnd.Next(65, 90);              // sorteia um caracter maiúsculo

            return Convert.ToChar(result);
        }

        /// <summary>
        /// Escreve uma linha num ficheiro de log
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="title"></param>
        /// <param name="textLine"></param>
        /// <returns></returns>
        internal static bool WriteToLogFile(string fileName, string title, string textLine = "")
        {
            try
            {
                if (File.Exists(fileName))
                {
                    FileInfo fileInfo = new FileInfo(fileName);

                    if (fileInfo.Length > 4000000)
                    {
                        File.Copy(fileName, "~" + fileName, true);
                        File.Delete(fileName);
                    }
                }

                using (StreamWriter swLog = File.AppendText(fileName))
                {
                    swLog.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + " - " + title + (string.IsNullOrEmpty(textLine) ? string.Empty : ", " + textLine));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Lê uma string de uma Binary stream
        /// </summary>
        /// <param name="br"></param>
        /// <param name="recordSize"></param>
        /// <returns></returns>
        internal static string ReadBinaryString(BinaryReader br, int recordSize = 100)
        {
            string result = string.Empty;
            try
            {
                for (int i = 0; i < recordSize; i++)
                {
                    result += br.ReadChar();
                }

                return result;
            }

            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Inser uma array noutra
        /// </summary>
        /// <param name="thisArray"></param>
        /// <param name="start"></param>
        /// <param name="insArray"></param>
        internal static void InsertArray(this Array thisArray, int start, Array insArray)
        {
            if (start < 0 || start > thisArray.Length)
               throw new Exception("Ponto de inserção inválido");

            //if (insArray.Length > thisArray.Length || insArray.Length > thisArray.Length - start)
            //    throw new Exception("Tamanho da array a inserir inválido.\r\n" + "Array base = " + thisArray.Length.ToString()
            //        + ", Array a inserir = " + insArray.Length.ToString() + ", ponto inserção = " + start.ToString());

            for (int i = 0; i < insArray.Length; i++)
            {
                thisArray.SetValue(insArray.GetValue(i), start++);
            }
        }

        /// <summary>
        /// Inser um array numa lista
        /// </summary>
        /// <param name="thisArray"></param>
        /// <param name="start"></param>
        /// <param name="insArray"></param>
        internal static void Insert2List(this List<byte> thisArray, int start, Array insArray)
        {
            if (start < 0 || start < thisArray.Count)
                throw new Exception("Ponto de inserção inválido");

            if (start > thisArray.Count)
            {
                int comp = thisArray.Count;
                for (int i = comp ; i < start; i++)
                {
                    thisArray.Add(0);
                }
            }

            //if (insArray.Length > thisArray.Length || insArray.Length > thisArray.Length - start)
            //    throw new Exception("Tamanho da array a inserir inválido.\r\n" + "Array base = " + thisArray.Length.ToString()
            //        + ", Array a inserir = " + insArray.Length.ToString() + ", ponto inserção = " + start.ToString());

            for (int i = 0; i < insArray.Length; i++)
            {
                thisArray.Add((byte)insArray.GetValue(i));
                //thisArray.Insert(start++,(byte)insArray.GetValue(i));
                //thisArray.SetValue(insArray.GetValue(i), );
            }
        }
    }
}
