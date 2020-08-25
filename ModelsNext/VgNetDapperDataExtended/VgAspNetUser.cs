using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace VgNetDapperDataExtended
{
    [Table("AspNetUsers")]
    public class VgAspNetUser : VgNetDapperModels.BaseModels.VgAspNetUser
    {
        public static VgAspNetUser findByEmail(string email, IDbConnection connection)
        {
            return connection.QueryFirstOrDefault<VgAspNetUser>("select * from AspNetUsers where Email = @Email", new { Email = email });
        }
        public static VgAspNetUser findByUsername(string username, IDbConnection connection)
        {
            return connection.QueryFirstOrDefault<VgAspNetUser>("select * from AspNetUsers where UserName = @UserName", new { UserName = username });
        }
    }
}