using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;

namespace VgNetDapperDataExtended
{
    [Table("Moradas")]
    public class VgMorada : VgNetDapperModels.BaseModels.VgMorada
    {
        
        public static VgMorada findByKey(int moradaID, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.QueryFirstOrDefault<VgMorada>(
                "select * from Moradas where MoradaID = @MoradaID",
                new { MoradaID = moradaID }, transaction);
        }

        public static VgMorada findByGLN(string gln, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.QueryFirstOrDefault<VgMorada>(
                "select * from Moradas where GLN = @GLN",
                new { GLN = gln }, transaction);
        }

        public  void Load(IDbConnection connection, IDbTransaction transaction = null)
        {
            LocalidadeDesc = connection.QueryFirstOrDefault<string>(
                "select Designacao from TGLocalidades where Localidade = @Localidade",
                new { Localidade = Localidade }, transaction);
            if (Distrito != null)
            {
                DistritoDesc = connection.QueryFirstOrDefault<string>(
                    "select Nome from TBDistritos where DistritoID = @DistritoID",
                    new { DistritoID = Distrito }, transaction);
            }
            if (Pais != null)
            {
                PaisDesc = connection.QueryFirstOrDefault<string>(
                    "select Designacao from TGPaises where Pais = @PaisID",
                    new { PaisID = Pais }, transaction);
            }
        }
    }
}