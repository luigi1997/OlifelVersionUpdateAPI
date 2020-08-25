using Dapper.Contrib.Extensions;
using System;

namespace VgNetDapperDataExtended
{
    [Table("TerMoradas")]
    public class TerMorada : VgNetDapperModels.BaseModels.TerMorada
    {
        public TerMorada(string Classe, string Terceiro, int Morada)
        {
            if(string.IsNullOrEmpty(Classe))
                throw new ArgumentException("'Classe' property cannot be empty or null");
            if (string.IsNullOrEmpty(Terceiro))
                throw new ArgumentException("'Terceiro' property cannot be empty or null");

            this.Classe = Classe;
            this.Terceiro = Terceiro;
            this.Morada = Morada;
        }
    }
}