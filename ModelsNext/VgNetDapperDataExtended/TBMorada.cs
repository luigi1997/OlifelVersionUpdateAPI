using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace VgNetDapperDataExtended
{
    [Table("TBMoradas")]
    public class TBMorada : VgNetDapperModels.BaseModels.TBMorada
    {
        public static TBMorada findByKey(int? Morada, IDbConnection connection)
        {
            if (Morada == null || Morada <= 0) return null;
            return connection.QueryFirstOrDefault<TBMorada>(
                "SELECT * FROM TBMoradas WHERE Morada = @Morada",
                new { Morada = Morada });
        }
    }
}