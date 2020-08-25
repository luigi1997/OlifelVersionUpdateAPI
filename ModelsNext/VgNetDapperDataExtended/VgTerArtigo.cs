using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace VisualGestAPI.Models.DapperModels
{
    [Table("TerArtigos")]
    public class VgTerArtigo : VgNetDapperModels.BaseModels.VgTerArtigo
    {
        public static VgTerArtigo findByKey(string classe, string terceiro, string artigo, IDbConnection connection)
        {
            return connection.QueryFirstOrDefault<VgTerArtigo>(
                "SELECT * FROM TerArtigos WHERE Classe = @Classe AND Terceiro = @Terceiro AND Artigo = @Artigo",
                new { Classe = classe, Terceiro = terceiro, Artigo = artigo });
        }
    }

}