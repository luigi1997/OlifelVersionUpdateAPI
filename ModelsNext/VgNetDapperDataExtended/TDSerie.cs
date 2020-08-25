using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace VgNetDapperDataExtended 
{
    [Table("TDSerie")]
    public class TDSerie : VgNetDapperModels.BaseModels.TDSerie
    {
        public static TDSerie GetTDSerieByKey(string _docTD, int _docAno, short _docMes, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.QueryFirstOrDefault<TDSerie>(
                "SELECT * FROM TDSerie WHERE TipoDoc = @TipoDoc AND Ano = @Ano AND Mes = @Mes",
                new { TipoDoc = _docTD, Ano = _docAno, Mes = _docMes }, transaction);
        }
    }

}