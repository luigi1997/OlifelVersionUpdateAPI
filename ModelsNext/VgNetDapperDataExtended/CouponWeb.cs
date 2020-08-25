using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace VgNetDapperDataExtended
{
    [Table("CupoesWeb")]
    public class CouponWeb : VgNetDapperModels.BaseModels.CouponWeb
    {
        public static List<CouponWeb> getAll(IDbConnection connection)
        {
            return connection.Query<CouponWeb>(
                            @"select * 
                              from CupoesWeb 
                              where ((DataFim >= GETDATE() OR DataFim IS NULL) 
                                AND (DataInicio <= GETDATE() OR DataInicio IS NULL)) 
                              and Estado = 1").ToList();
        }

        public static CouponWeb findByKey(string coupon, IDbConnection connection)
        {
            return connection.QueryFirstOrDefault<CouponWeb>(
                "select * from CupoesWeb where Coupon = @Coupon and ((DataFim >= GETDATE() OR DataFim IS NULL) AND (DataInicio <= GETDATE() OR DataInicio IS NULL)) and Estado = 1",
                new { Coupon = coupon });
        }
    }
}