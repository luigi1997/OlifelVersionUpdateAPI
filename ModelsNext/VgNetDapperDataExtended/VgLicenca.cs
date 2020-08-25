using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Headers;
using System.Text;
using VgNetDapperDataExtended.Helpers;

namespace VgNetDapperDataExtended
{
    [Table("Licenca")]
    public class VgLicenca : VgNetDapperModels.BaseModels.VgLicenca
    {

        /// <summary>
        /// Insere a licenca na tabela licenca e forms respetivos
        /// </summary>
        /// <param name="FileBinContent"></param>
        /// <returns></returns>
        public static bool insertLicenses(byte[] fileBytes, IDbConnection connection, IDbTransaction transaction = null)
        {
            try
            {
                VgLicenca currentLicenca = new VgLicenca();
                string readStr = string.Empty;
                string decodeStr = string.Empty;
                int strSize = 0;
                int strPostion = 0;

                Encoding encoding = Encoding.Default;
                //byte[] fileBytes = System.Text.Encoding.Default.GetBytes(fileBinContent);

                // Código Postal
                //strSize = 100;
                //strPostion = Tools.GetRecRightStart(5, strSize);
                //readStr = encoding.GetString(fileBytes, strPostion, strSize);
                //decodeStr = Security.VgDecrypt(readStr);
                //if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                //    tbCodPostal.Text = decodeStr.SafeSubstr(2, strSize);

                //NIF
                //strSize = 100;
                //strPostion = Tools.GetRecRightStart(7, strSize);
                //readStr = encoding.GetString(fileBytes, strPostion, strSize);
                //decodeStr = Security.VgDecrypt(readStr);
                //if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                //    tbNIF.Text = decodeStr.SafeSubstr(2, strSize);

                // Postos
                strSize = 2;
                strPostion = Tools.GetRecRightStart(8, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                int nPostos = 0;
                if (Int32.TryParse(decodeStr, out nPostos))
                {
                    currentLicenca.Postos = nPostos;
                }
                else
                {
                    currentLicenca.Postos = 0;
                }

                // TODO Verificar se esta linha faz falta -> decodeStr = Security.VgDecrypt(readStr);

                //Localidade
                //strSize = 100;
                //strPostion = Tools.GetRecRightStart(11, strSize);
                //readStr = encoding.GetString(fileBytes, strPostion, strSize);
                //decodeStr = Security.VgDecrypt(readStr);
                //if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                //    tbLocalidade.Text = decodeStr.SafeSubstr(2, strSize);

                //Morada
                strSize = 100;
                strPostion = Tools.GetRecRightStart(17, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                //if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                //    tbMorada.Text = decodeStr.SafeSubstr(2, strSize);

                // Comprovativo
                strSize = 31;
                strPostion = Tools.GetRecRightStart(9, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                currentLicenca.Confirmacao = decodeStr;

                // Midx
                //strSize = 14;
                //strPostion = Tools.GetRecRightStart(10, strSize);
                //readStr = encoding.GetString(fileBytes, strPostion, strSize);
                //decodeStr = Security.VgDecrypt(readStr);
                //currentLicenca.SetMidx(decodeStr);

                // Licenca
                strSize = 35;
                strPostion = Tools.GetRecRightStart(12, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                currentLicenca.Licenca = decodeStr;

                //Telefone
                //strSize = 100;
                //strPostion = Tools.GetRecRightStart(21, strSize);
                //readStr = encoding.GetString(fileBytes, strPostion, strSize);
                //decodeStr = Security.VgDecrypt(readStr);
                //if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                //    tbTelefone.Text = decodeStr.SafeSubstr(2, strSize);

                // Nome
                strSize = 50;
                strPostion = Tools.GetRecRightStart(23, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                currentLicenca.NomLicenca = decodeStr;

                //Versoes
                strPostion = 2300;
                strSize = 100;
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                //Versao Licenciada
                int anoIni, anoFim, mesIni, mesFim = 0;
                anoIni = Int32.Parse(decodeStr.SafeSubstr(0, 4));
                mesIni = Int32.Parse(decodeStr.SafeSubstr(6, 2));
                anoFim = Int32.Parse(decodeStr.SafeSubstr(10, 4));
                mesFim = Int32.Parse(decodeStr.SafeSubstr(16, 2));
                currentLicenca.Versao = anoIni.ToString() + mesIni.ToString("00");
                currentLicenca.VersaoAutorizada = anoFim.ToString() + mesFim.ToString("00");

                // Empresa
                strSize = 50;
                strPostion = Tools.GetRecRightStart(25, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                currentLicenca.EmpLicenca = decodeStr;

                strSize = 100;
                // Nº de formularios
                strPostion = Tools.GetRecRightStart(26, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                int nForms = 0;
                if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                    nForms = Int32.Parse(decodeStr.SafeSubstr(2, strSize));


                int recPosition = 26;
                strSize = 100;
                int keyLength = 0;
                currentLicenca.ListaFormularios = new List<VgNetDapperModels.BaseModels.VgFormulario>();
                for (int i = 0; i < nForms; i++)
                {
                    VgFormulario formulario = new VgFormulario();
                    readStr = encoding.GetString(fileBytes, (recPosition * strSize), strSize);
                    decodeStr = Security.VgDecrypt(readStr);
                    if (Int32.TryParse(decodeStr.SafeSubstr(20, 2), out keyLength))
                    {
                        formulario.FormID = decodeStr.SafeSubstr(0, 20);
                        formulario.Licenca = decodeStr.SafeSubstr(22, keyLength);
                        currentLicenca.ListaFormularios.Add(formulario);
                    }

                    recPosition += 1;
                }

                //////ID Aplicação
                //strSize = 100;
                //recPosition += 1;
                //strPostion = Tools.GetRecRightStart(recPosition, strSize);
                //readStr = encoding.GetString(fileBytes, strPostion, strSize);
                //decodeStr = Security.VgDecrypt(readStr);
                //if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                //    cmbAplicacao.SelectedValue = Convert.ToInt32(decodeStr.SafeSubstr(2, strSize));

                //Nome Aplicação
                strSize = 100;
                recPosition += 2;
                strPostion = Tools.GetRecRightStart(recPosition, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                    currentLicenca.Produto = decodeStr.SafeSubstr(2, strSize);

                //Multiempresa
                strSize = 1;
                recPosition += 1;
                strPostion = Tools.GetRecRightStart(recPosition, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                int res = 0;
                if (Int32.TryParse(decodeStr, out res))
                {
                    currentLicenca.MultiEmpresa = Convert.ToBoolean(res);
                }
                else
                {
                    currentLicenca.MultiEmpresa = false;
                }

                if (currentLicenca != null && !string.IsNullOrEmpty(currentLicenca.Produto))
                {
                    connection.Execute(
                                $@"IF NOT EXISTS(SELECT * FROM Licenca WHERE Produto=@Produto)
                                    BEGIN
                                        INSERT INTO [dbo].[Licenca]
                                                   ([Produto]
                                                   ,[Licenca]
                                                   ,[Confirmacao]
                                                   ,[Versao]
                                                   ,[VersaoAutorizada]
                                                   ,[NomLicenca]
                                                   ,[EmpLicenca]
                                                   ,[Postos]
                                                   ,[PathStdReports]
                                                   ,[NotificaExcecao]
                                                   ,[PostosExternos]
                                                   ,[MultiEmpresa])
                                             VALUES
                                                   (@Produto
                                                   ,@Licenca
                                                   ,@Confirmacao
                                                   ,@Versao
                                                   ,@VersaoAutorizada
                                                   ,@NomLicenca
                                                   ,@EmpLicenca
                                                   ,@Postos
                                                   ,@PathStdReports
                                                   ,@NotificaExcecao
                                                   ,@PostosExternos
                                                   ,@MultiEmpresa)
                                    END
                                    ELSE
                                    BEGIN
                                    UPDATE Licenca SET 
                                               [Licenca] = @Licenca
                                              ,[Confirmacao] = @Confirmacao
                                              ,[Versao] = @Versao
                                              ,[VersaoAutorizada] = @VersaoAutorizada
                                              ,[NomLicenca] = @NomLicenca
                                              ,[EmpLicenca] = @EmpLicenca
                                              ,[Postos] = @Postos
                                              ,[MultiEmpresa] = @MultiEmpresa
                                    WHERE Produto = @Produto
                                END",
                                new
                                {
                                    Produto = currentLicenca.Produto,
                                    Licenca = currentLicenca.Licenca,
                                    Confirmacao = currentLicenca.Confirmacao,
                                    Versao = currentLicenca.Versao,
                                    VersaoAutorizada = currentLicenca.VersaoAutorizada,
                                    NomLicenca = currentLicenca.NomLicenca,
                                    EmpLicenca = currentLicenca.EmpLicenca,
                                    Postos = currentLicenca.Postos,
                                    PathStdReports = currentLicenca.PathStdReports,
                                    NotificaExcecao = currentLicenca.NotificaExcecao,
                                    PostosExternos = currentLicenca.PostosExternos,
                                    MultiEmpresa = currentLicenca.MultiEmpresa

                                }, transaction: transaction);

                    foreach (VgFormulario formulario in currentLicenca.ListaFormularios)
                    {
                        connection.Execute(
                                $@"IF NOT EXISTS(SELECT * FROM Formularios WHERE FormID=@FormID)
                                    BEGIN
                                        INSERT INTO [dbo].[Formularios]
                                                   ([FormID]
                                                   ,[FormName]
                                                   ,[Retira]
                                                   ,[Licenca])
                                             VALUES
                                                   (@FormID
                                                   ,'Por especificar - ' + @FormID
                                                   ,0
                                                   ,@Licenca)
                                    END
                                    ELSE
                                    BEGIN
                                        UPDATE Formularios SET 
                                               [Licenca] = @Licenca
                                        WHERE FormID = @FormID
                                    END",
                                new
                                {
                                    Licenca = formulario.Licenca,
                                    FormID = formulario.FormID.Trim()

                                }, transaction: transaction);
                    }

                }


                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }


        public static VgLicenca getDecryptedLicense(byte[] fileBytes)
        {
            try
            {
                VgLicenca currentLicenca = new VgLicenca();
                string readStr = string.Empty;
                string decodeStr = string.Empty;
                int strSize = 0;
                int strPostion = 0;

                Encoding encoding = Encoding.Default;
                //byte[] fileBytes = System.Text.Encoding.Default.GetBytes(fileBinContent);

                // Código Postal
                //strSize = 100;
                //strPostion = Tools.GetRecRightStart(5, strSize);
                //readStr = encoding.GetString(fileBytes, strPostion, strSize);
                //decodeStr = Security.VgDecrypt(readStr);
                //if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                //    tbCodPostal.Text = decodeStr.SafeSubstr(2, strSize);

                //NIF
                //strSize = 100;
                //strPostion = Tools.GetRecRightStart(7, strSize);
                //readStr = encoding.GetString(fileBytes, strPostion, strSize);
                //decodeStr = Security.VgDecrypt(readStr);
                //if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                //    tbNIF.Text = decodeStr.SafeSubstr(2, strSize);

                // Postos
                strSize = 2;
                strPostion = Tools.GetRecRightStart(8, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                int nPostos = 0;
                if (Int32.TryParse(decodeStr, out nPostos))
                {
                    currentLicenca.Postos = nPostos;
                }
                else
                {
                    currentLicenca.Postos = 0;
                }

                // TODO Verificar se esta linha faz falta -> decodeStr = Security.VgDecrypt(readStr);

                //Localidade
                //strSize = 100;
                //strPostion = Tools.GetRecRightStart(11, strSize);
                //readStr = encoding.GetString(fileBytes, strPostion, strSize);
                //decodeStr = Security.VgDecrypt(readStr);
                //if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                //    tbLocalidade.Text = decodeStr.SafeSubstr(2, strSize);

                //Morada
                //strSize = 100;
                //strPostion = Tools.GetRecRightStart(17, strSize);
                //readStr = encoding.GetString(fileBytes, strPostion, strSize);
                //decodeStr = Security.VgDecrypt(readStr);
                //if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                //    tbMorada.Text = decodeStr.SafeSubstr(2, strSize);

                // Comprovativo
                strSize = 31;
                strPostion = Tools.GetRecRightStart(9, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                currentLicenca.Confirmacao = decodeStr;

                // Midx
                //strSize = 14;
                //strPostion = Tools.GetRecRightStart(10, strSize);
                //readStr = encoding.GetString(fileBytes, strPostion, strSize);
                //decodeStr = Security.VgDecrypt(readStr);
                //currentLicenca.SetMidx(decodeStr);

                // Licenca
                strSize = 35;
                strPostion = Tools.GetRecRightStart(12, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                currentLicenca.Licenca = decodeStr;

                //Telefone
                //strSize = 100;
                //strPostion = Tools.GetRecRightStart(21, strSize);
                //readStr = encoding.GetString(fileBytes, strPostion, strSize);
                //decodeStr = Security.VgDecrypt(readStr);
                //if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                //    tbTelefone.Text = decodeStr.SafeSubstr(2, strSize);

                // Nome
                strSize = 50;
                strPostion = Tools.GetRecRightStart(23, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                currentLicenca.NomLicenca = decodeStr;

                //Versoes
                strPostion = 2300;
                strSize = 100;
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                //Versao Licenciada
                int anoIni, anoFim, mesIni, mesFim = 0;
                anoIni = Int32.Parse(decodeStr.SafeSubstr(0, 4));
                mesIni = Int32.Parse(decodeStr.SafeSubstr(6, 2));
                anoFim = Int32.Parse(decodeStr.SafeSubstr(10, 4));
                mesFim = Int32.Parse(decodeStr.SafeSubstr(16, 2));
                currentLicenca.Versao = anoIni.ToString() + mesIni.ToString("00");
                currentLicenca.VersaoAutorizada = anoFim.ToString() + mesFim.ToString("00");

                // Empresa
                strSize = 50;
                strPostion = Tools.GetRecRightStart(25, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                currentLicenca.EmpLicenca = decodeStr;

                strSize = 100;
                // Nº de formularios
                strPostion = Tools.GetRecRightStart(26, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                int nForms = 0;
                if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                    nForms = Int32.Parse(decodeStr.SafeSubstr(2, strSize));


                int recPosition = 26;
                strSize = 100;
                int keyLength = 0;
                currentLicenca.ListaFormularios = new List<VgNetDapperModels.BaseModels.VgFormulario>();
                for (int i = 0; i < nForms; i++)
                {
                    VgFormulario formulario = new VgFormulario();
                    readStr = encoding.GetString(fileBytes, (recPosition * strSize), strSize);
                    decodeStr = Security.VgDecrypt(readStr);
                    if (Int32.TryParse(decodeStr.SafeSubstr(20, 2), out keyLength))
                    {
                        formulario.FormID = decodeStr.SafeSubstr(0, 20);
                        formulario.Licenca = decodeStr.SafeSubstr(22, keyLength);
                        currentLicenca.ListaFormularios.Add(formulario);
                    }


                    recPosition += 1;
                }

                //////ID Aplicação
                //strSize = 100;
                //recPosition += 1;
                //strPostion = Tools.GetRecRightStart(recPosition, strSize);
                //readStr = encoding.GetString(fileBytes, strPostion, strSize);
                //decodeStr = Security.VgDecrypt(readStr);
                //if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                //    cmbAplicacao.SelectedValue = Convert.ToInt32(decodeStr.SafeSubstr(2, strSize));

                //Nome Aplicação
                strSize = 100;
                recPosition += 2;
                strPostion = Tools.GetRecRightStart(recPosition, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                if (Int32.TryParse(decodeStr.SafeSubstr(0, 2), out strSize))
                    currentLicenca.Produto = decodeStr.SafeSubstr(2, strSize);

                //Multiempresa
                strSize = 1;
                recPosition += 1;
                strPostion = Tools.GetRecRightStart(recPosition, strSize);
                readStr = encoding.GetString(fileBytes, strPostion, strSize);
                decodeStr = Security.VgDecrypt(readStr);
                int res = 0;
                if (Int32.TryParse(decodeStr, out res))
                {
                    currentLicenca.MultiEmpresa = Convert.ToBoolean(res);
                }
                else
                {
                    currentLicenca.MultiEmpresa = false;
                }

                return currentLicenca;
            }

            catch (Exception ex)
            {
                return null;
            }
        }
    }
}