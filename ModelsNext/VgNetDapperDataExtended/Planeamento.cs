using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace VgNetDapperDataExtended
{
    [Table("Planeamento")]
    public class Planeamento : VgNetDapperModels.AbstractModels.Planeamento<VgTerceiro, VgMorada, TBCondPag, TBFormPag>
    {

        #region class helpers
        public void Load(IDbConnection connection)
        {
            if (!string.IsNullOrEmpty(Classe) && !string.IsNullOrEmpty(Terceiro))
            {
                VgTerceiro = VgTerceiro.findByKey(Classe,Terceiro, connection);
                VgTerceiro.Load(connection);
            }
        }
        
        public static Planeamento findByKey(int semanaID, int semanaAno, string tipodoc, int ano, int mes, int numdoc, int fase, int ordem, IDbConnection connection)
        {
            return connection.QueryFirstOrDefault<Planeamento>(
                "select * from Planeamento where SemanaId = @semanaID and SemanaAno = @semanaAno and TipoDoc=@tipodoc and Ano=@ano and Mes=@mes and numdoc=@numdoc and Fase=@fase and Ordem=@ordem",
                new { semanaID = semanaID, semanaAno = semanaAno, tipodoc =tipodoc, ano= ano, mes = mes, numdoc=numdoc, fase=fase, ordem=ordem});
        }
        #endregion

    }
}