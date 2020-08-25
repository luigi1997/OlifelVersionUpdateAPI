using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.Interfaces
{
    public interface IVgMorada
    {
        int MoradaID { get; set; }
        string Descritivo { get; set; }

        string Nome { get; set; }
        string Morada { get; set; }

        string Pais { get; set; }
        int? Localidade { get; set; }

        string LocalidadeDesc { get; set; }

        string CodPostal { get; set; }

        string LocPostal { get; set; }
        int? Zona { get; set; }

        string GLN { get; set; }
        int? Distrito { get; set; }

        string DistritoDesc { get; set; }
        int? Concelho { get; set; }
        int? Freguesia { get; set; }

        string Latitude { get; set; }

        string Longitude { get; set; }

        string Telefone { get; set; }

        string Fax { get; set; }

        string Email { get; set; }

        string Homepage { get; set; }

        string Classe { get; set; }

        string Terceiro { get; set; }
        decimal? Distancia { get; set; }
    }
}
