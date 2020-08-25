using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace VgNetDapperDataExtended
{
    [Table("ArtImagens")]
    public class ArtImagem : VgNetDapperModels.BaseModels.ArtImagem
    {

        public static ArtImagem findByKey(string Artigo, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.QueryFirstOrDefault<ArtImagem>(
                "SELECT * FROM ArtImagens WHERE Artigo = @Artigo",
                new { Artigo = Artigo }, transaction);
        }
    }
}