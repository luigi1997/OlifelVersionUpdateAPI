using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IPFControloDefeito
    {
         int Defeito { get; set; }
         int Controlo { get; set; }
         byte[] Imagem { get; set; }
         string Descricao { get; set; }
         int Quantidade { get; set; }
    }
}
