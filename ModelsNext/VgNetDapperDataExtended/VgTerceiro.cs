using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace VgNetDapperDataExtended
{
    [Table("Terceiros")]
    public class VgTerceiro : VgNetDapperModels.AbstractModels.VgTerceiro<VgMorada,TBCondPag, TBFormPag>
    {

        #region class helpers
        public void Load(IDbConnection connection)
        {
            LoadMoradas(connection);

            if (FormPag != null)
                FormPagObj = TBFormPag.findByKey((int)FormPag, connection);
        }

        public void LoadMoradas(IDbConnection connection, IDbTransaction transaction = null)
        {
            if (MoradaPrincipal != null)
            {
                MoradaPrincipalObj = VgMorada.findByKey((int)MoradaPrincipal, connection, transaction);
                MoradaPrincipalObj.Load(connection, transaction);
            }

            if (MoradaDescarga != null)
            {
                MoradaDescargaObj = VgMorada.findByKey((int)MoradaDescarga, connection, transaction);
                MoradaDescargaObj.Load(connection, transaction);
            }

            if (MoradaCarga != null)
            {
                MoradaCargaObj = VgMorada.findByKey((int)MoradaCarga, connection, transaction);
                MoradaCargaObj.Load(connection, transaction);
            }

            if (FormPag != null)
                FormPagObj = TBFormPag.findByKey((int)FormPag, connection, transaction);
        }
        public VgMorada getMoradaPrincipal(IDbConnection connection)
        {
            if (MoradaPrincipal != null)
                return VgMorada.findByKey((int)MoradaPrincipal, connection);
            return null;
        }

        public static VgTerceiro findByKey(string classe, string terceiro, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.QueryFirstOrDefault<VgTerceiro>(
                "select * from Terceiros where Classe = @Classe and Terceiro = @Terceiro", 
                new { Classe = classe, Terceiro = terceiro }, transaction);
        }

        public static VgTerceiro findByCodEDI(string codEDI, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.QueryFirstOrDefault<VgTerceiro>(
                "select * from Terceiros where CodEDI = @CodEDI and ISNULL(TemEDI,0) = 1",
                new { CodEDI = codEDI }, transaction);
        }

        public static VgTerceiro findByNIF(string classe, string nif, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.QueryFirstOrDefault<VgTerceiro>(
                "select * from Terceiros where Classe = @Classe and Nifkey = @NifKey",
                new { Classe = classe, Nifkey = nif }, transaction);
        }
        #endregion

    }
}