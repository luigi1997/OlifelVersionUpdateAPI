using Dapper;
using System.Data;

namespace VgNetDapperDataExtended
{
    public class VgTipoDoc : VgNetDapperModels.AbstractModels.VgTipoDoc<TDClasse,TDLiga, VgTDGera>
    {
        public string getTDActCC()
        {
            return getChar(MovCCCre) + getChar(MovCCDeb) + getChar(MovCCVD) +
                     getChar(ActAcumCmp) + getChar(ActAcumVnd) + getChar(ActAcumPOS) +
                     getChar(ActPontosQtd) + getChar(ActPontosVal);
        }

        public string getTDActStk()
        {
            return getChar(ActEntDev) + getChar(ActEntEnc) + getChar(ActEntRes) +
                     getChar(ActSaiDev) + getChar(ActSaiEnc) + getChar(ActSaiRes) +
                     getChar(ActPCM) + getChar(ActPCP) + getChar(ActPCU) + getChar(ActStock);
        }

        public string getTDActTar()
        {
            return getChar(MovTaras) + getChar(ValTaras);
        }

        public string getTDActBase()
        {
            return getChar(temConcluiDocBase);
        }
        private string getChar(string TDConfig)
        {
            string result = "_";
            if (TDConfig != null && TDConfig != string.Empty)
                result = TDConfig;
            return result;
        }

        private string getChar(bool? TDConfig)
        {
            string result = "0";
            if (TDConfig.HasValue)
                if (TDConfig.Value)
                    result = "1";
            return result;
        }

        public static VgTipoDoc findByKey(string tipoDoc, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.QueryFirstOrDefault<VgTipoDoc>("select * from TipoDoc where TipoDoc = @TipoDoc", new { TipoDoc = tipoDoc }, transaction);
        }

        
        }
    }