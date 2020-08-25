using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperDataExtended
{
    [Table("DocLin")]
    public class DocLin : VgNetDapperModels.AbstractModels.DocLin<DocLiga,VgDocLinSortido,VgDocLinTamCor,DocLinSortItem,DocLigaTamCor, DocLinDescResiduos, ArtPreco, DocLigaEmb, DocLigaPlanos, DocLigaPlanosTamCor> 
    {
        public DocLin()
        {
            Sortidos = new List<VgDocLinSortido>();
            TamsCor = new List<VgDocLinTamCor>();
            DocLiga = new List<DocLiga>();
            DocLigaBase = new List<DocLiga>();
            DocLinDescResiduos = new List<DocLinDescResiduos>();
        }

        public List<VgDocLinTamCor> getTamsCor(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<VgDocLinTamCor>(
                @"SELECT dltc.*, aet.Descritivo as TamDesc 
                FROM DocLinTamCor dltc inner join ArtEscTam aet on dltc.Artigo = aet.Artigo and dltc.Tam = aet.Tam
                WHERE TipoDoc = @TipoDoc AND Ano = @Ano AND Mes = @Mes AND NumDoc = @NumDoc AND LinhaID = @LinhaID",
                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes, NumDoc = NumDoc, LinhaID = LinhaID }, transaction).ToList();
        }

        public List<DocLiga> getDocLiga(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<DocLiga>(
                @"SELECT *
                FROM DocLiga
                WHERE TipoDoc = @TipoDoc AND Ano = @Ano AND Mes = @Mes AND NumDoc = @NumDoc AND LinhaID = @LinhaID",
                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes, NumDoc = NumDoc, LinhaID = LinhaID }, transaction).ToList();
        }

        public List<DocLigaTamCor> getDocLigaTams(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<DocLigaTamCor>(
                @"SELECT *
                FROM DocLigaTamCor
                WHERE TipoDoc = @TipoDoc AND Ano = @Ano AND Mes = @Mes AND NumDoc = @NumDoc AND LinhaID = @LinhaID",
                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes, NumDoc = NumDoc, LinhaID = LinhaID }, transaction).ToList();
        }

        public List<DocLigaPlanos> getDocLigaPlanos(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<DocLigaPlanos>(
                @"SELECT *
                FROM DocLigaPlanos
                WHERE TipoDoc = @TipoDoc AND Ano = @Ano AND Mes = @Mes AND NumDoc = @NumDoc AND LinhaID = @LinhaID",
                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes, NumDoc = NumDoc, LinhaID = LinhaID }, transaction).ToList();
        }

        public List<DocLigaPlanosTamCor> getDocLigaPlanosTamCor(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<DocLigaPlanosTamCor>(
                @"SELECT *
                FROM DocLigaPlanosTamCor
                WHERE TipoDoc = @TipoDoc AND Ano = @Ano AND Mes = @Mes AND NumDoc = @NumDoc AND LinhaID = @LinhaID",
                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes, NumDoc = NumDoc, LinhaID = LinhaID }, transaction).ToList();
        }

        public List<DocLinDescResiduos> getDescResiduos(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<DocLinDescResiduos>(
                @"SELECT * FROM DocLinDescResiduos
                WHERE TipoDoc = @TipoDoc AND Ano = @Ano AND Mes = @Mes AND NumDoc = @NumDoc AND LinhaID = @LinhaID",
                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes, NumDoc = NumDoc, LinhaID = LinhaID }, transaction).ToList();
        }

        public List<DocLigaEmb> getDocLigaEmbs(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<DocLigaEmb>(
                "SELECT * FROM DocLigaEmb WHERE TipoDoc = @TipoDoc and Ano = @Ano and Mes = @Mes and NumDoc = @NumDoc AND LinhaID = @LinhaID",
                new { TipoDoc = TipoDoc, Ano = Ano, Mes = Mes, NumDoc = NumDoc, LinhaID = LinhaID }, transaction).ToList();
        }
    }
}