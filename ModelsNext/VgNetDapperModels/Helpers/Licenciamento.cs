using System;
using System.Collections.Generic;
using System.Text;
using VgNetDapperModels.VgTabModels;

namespace VgNetDapperModels.Helpers
{
    public class Licenciamento
    {
		public const string Chave = "olifel.net";
		private static string CharToNumber(string CharToConvert)
		{
			return ((int)(CharToConvert.ToCharArray()[0]) - 65).ToString();
		}

		public static FormLicenca GetAccessFromLicense(string licenseKey, string formName)
		{
			
			try
			{
				FormLicenca licenca = null;
				if (licenseKey.Length == 31)
				{
					// Data Ativacao
					string dataStr = CharToNumber(licenseKey.Substring(20, 1)) +
									licenseKey.Substring(12, 1) +
									"/" +
									CharToNumber(licenseKey.Substring(18, 1)) +
									CharToNumber(licenseKey.Substring(2, 1)) +
									"/" +
									CharToNumber(licenseKey.Substring(4, 1)) +
									licenseKey.Substring(10, 1) +
									CharToNumber(licenseKey.Substring(27, 1)) +
									CharToNumber(licenseKey.Substring(24, 1));

					DateTime oDate = Convert.ToDateTime(dataStr);


					string formResult = CryptographyAES.AESCypher.Encrypt(formName, Chave, CryptographyAES.AESCypher.AESCryptographyLevel.AES_128).ToUpper();

					string first = licenseKey.Substring(6, 1);
					string last = licenseKey.Substring(14, 1);
					string pos1 = licenseKey.Substring(22, 1);
					string pos2 = licenseKey.Substring(30, 1);

					string prazo = licenseKey.Substring(19, 1);
					string postos = licenseKey.Substring(26, 1) + licenseKey.Substring(16, 1);

					if (formResult.Substring(0, 1) == first && formResult.Substring(1, 1) == pos1 && formResult.Substring(2, 1) == pos2 && formResult.Substring(formResult.Length - 1) == last)
					{
						licenca = new FormLicenca();
						licenca.FormId = formName;
						licenca.DataAtivacao = oDate;
						licenca.Prazo = prazo;
						licenca.Postos = Convert.ToInt32(postos);
						licenca.DataExpiracao = GetExpirationDate(licenca.Prazo, licenca.DataAtivacao);
					}

					return licenca;
				}
				else
				{
					return null;
				}

			}

			catch (Exception)
			{
				return null;
			}			
		}

		/// <summary>
		/// Obtém a string representativa do prazo através do seu caracter
		/// </summary>
		/// <param name="prazoChar"></param>
		/// <returns></returns>
		public static string GetPrazoString(string prazoChar)
		{
			string result = string.Empty;

			switch (prazoChar.ToUpper())
			{
				case "I":
					result = "Indeterminado";
					break;
				case "W":
					result = "Semanal";
					break;
				case "M":
					result = "Mensal";
					break;
				case "T":
					result = "Trimestral";
					break;
				case "S":
					result = "Semestral";
					break;
				case "A":
					result = "Anual";
					break;
				case "O":
					result = "Definitivo";
					break;
			}

			return result;
		}

		/// <summary>
		/// Obtém a data de expiraçcao
		/// </summary>
		/// <param name="prazoChar"></param>
		/// <returns></returns>
		public static DateTime GetExpirationDate(string prazoChar, DateTime activationDate)
		{
			DateTime result = DateTime.Now;

			switch (prazoChar.ToUpper())
			{
				case "I":
					//result = "Indeterminado"; Versao Autorizada
					break;
				case "W":
					result = activationDate.AddDays(7);
					break;
				case "M":
					result = activationDate.AddMonths(1);
					break;
				case "T":
					result = activationDate.AddMonths(3);
					break;
				case "S":
					result = activationDate.AddMonths(6);
					break;
				case "A":
					result = activationDate.AddYears(1);
					break;
				case "O":
					result = activationDate.AddYears(200);
					break;
			}

			return result;
		}
	}
}
