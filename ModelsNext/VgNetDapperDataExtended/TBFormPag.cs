using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace VgNetDapperDataExtended
{
    [Table("TBFormPag")]
    public class TBFormPag : VgNetDapperModels.BaseModels.TBFormPag
    {

        #region class helpers
        public static TBFormPag findByKey(int formPag, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.QueryFirstOrDefault<TBFormPag>(
                "select * from TBFormPag where FormPag = @FormPag",
                new { FormPag  = formPag}, transaction);
        }

        #endregion
    }

}