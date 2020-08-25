using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IArtImagem
    {
        string Artigo { get; set; }

        int ImgID { get; set; }

        int ImgNum { get; set; }

        byte[] ImgOld { get; set; }

        string Descritivo { get; set; }

        byte[] Imagem { get; set; }
        byte[] Web { get; set; }

        int Cor { get; set; }
    }
}
