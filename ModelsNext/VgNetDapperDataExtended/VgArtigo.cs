using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace VgNetDapperDataExtended
{
    [Table("Artigos")]
    public class VgArtigo : VgNetDapperModels.AbstractModels.VgArtigo<ArtImagem,VgArtTamCor, ArtPreco, VgArtEscTam, VgArtEscCor>
    {

        public List<ArtImagem> getArtImagens(IDbConnection connection)
        {
            return connection.Query<ArtImagem>("SELECT * FROM ArtImagens WHERE Artigo = @Artigo", new { Artigo = Artigo }).ToList();
        }

        public static VgArtigo findByKey(string Artigo, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.QueryFirstOrDefault<VgArtigo>(
                "SELECT * FROM Artigos WHERE Artigo = @Artigo", 
                new { Artigo = Artigo }, transaction);
        }

        public static VgArtigo findByGTIN(string gtin, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.QueryFirstOrDefault<VgArtigo>(
                @"select art.* from artigosGTIN agt
                inner join Artigos art on agt.Artigo = art.Artigo
                where GTIN = @GTIN",
                new { GTIN = gtin }, transaction);
        }

        public static VgArtigo findByRecno(int recno, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.QueryFirstOrDefault<VgArtigo>(
                "SELECT * FROM Artigos WHERE Recno = @Recno",
                new { Recno = recno }, transaction);
        }

        public List<VgArtTamCor> getArtTamCor(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<VgArtTamCor>("SELECT * FROM ArtTamCor WHERE Artigo = @Artigo", new { Artigo = Artigo }, transaction).ToList();
        }
        public List<ArtPreco> getArtPrecos(IDbConnection connection, IDbTransaction transaction = null, int? numPreco = null)
        {
            string precoFilter = "";
            if (numPreco != null)
                precoFilter = "AND NumPreco = @NumPreco";
            return connection.Query<ArtPreco>(
                $@"SELECT * 
                FROM ArtPrecos
                WHERE Artigo = @Artigo {precoFilter}", 
                new { Artigo = Artigo, NumPreco = numPreco },
                transaction).ToList();
        }
        public List<VgArtEscTam> getArtEscTam(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<VgArtEscTam>("SELECT * FROM ArtEscTam WHERE Artigo = @Artigo order by Sequencia", new { Artigo = Artigo }, transaction).ToList();
        }
        public List<VgArtEscCor> getArtEscCor(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<VgArtEscCor>("SELECT * FROM ArtEscCor WHERE Artigo = @Artigo order by Sequencia", new { Artigo = Artigo }, transaction).ToList();
        }
    }
}