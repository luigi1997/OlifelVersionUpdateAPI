using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace VgNetDapperDataExtended
{
    public class TbCategoria : VgNetDapperModels.BaseModels.TbCategoria
    {
        public static TbCategoria findByKey(string categoria, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.QueryFirstOrDefault<TbCategoria>(
                "select * from tbcategoria where categoria = @Categoria",
                new { Categoria = categoria },
                transaction);
        }
    }
}
