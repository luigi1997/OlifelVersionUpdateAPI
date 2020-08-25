using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IPFControlo<T> 
              where T : IPFControloDefeito
    {
         int Controlo { get; set; }
         int Ordem { get; set; }
         int Fase { get; set; }
         string UserID { get; set; }
         string UserName { get; set; }
         int UnidControladas { get; set; }
         int UnidProduzidas { get; set; }
         byte[] Imagem { get; set; }
         DateTime DataControlo { get; set; }
    }
}
