using Dapper.Contrib.Extensions;
using System;
using System.Data;
using VgNetDapperModels.Interfaces;

namespace VgNetDapperModels.BaseModels
{
    [Table("Moradas")]
    public class VgMorada : IVgMorada
    {
        [Key]
        public int MoradaID { get; set; }
        public string Descritivo { get; set; }

        public string Nome { get; set; }
        public string Morada { get; set; }

        public string Pais { get; set; }
        [Computed]
        public string PaisDesc { get; set; }

        public int? Localidade { get; set; }
        [Computed]
        public string LocalidadeDesc { get; set; }

        public string CodPostal { get; set; }

        public string LocPostal { get; set; }
        public int? Zona { get; set; }

        public string GLN { get; set; }
        public int? Distrito { get; set; }
        [Computed]
        public string DistritoDesc { get; set; }
        public int? Concelho { get; set; }
        public int? Freguesia { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Telefone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Homepage { get; set; }

        public string Classe { get; set; }

        public string Terceiro { get; set; }
        public decimal? Distancia { get; set; }

        public override string ToString()
        {
            return $@"{Morada}{Environment.NewLine}{LocalidadeDesc}{Environment.NewLine}{CodPostal} {LocPostal}{Environment.NewLine}{Pais} {PaisDesc}";
        }
    }
}