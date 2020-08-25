using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.AbstractModels
{
    [Table("PFControlos")]
    public abstract class PFControlo<T> : IPFControlo<T>
            where T : IPFControloDefeito
    {
        [Key]
        public int Controlo { get; set; }
        public int Ordem { get; set; }
        public int Fase { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public int UnidControladas { get; set; }
        public int UnidProduzidas { get; set; }
        public byte[] Imagem { get; set; }
        public DateTime DataControlo { get; set; }

        [Computed]
        public IList<T> Defeitos { get; set; }
    }
}