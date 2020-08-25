namespace VgNetDapperModels.Interfaces
{
    public interface IDocFile
    {
        string TipoDoc { get; set; }

        int Ano { get; set; }

        short Mes { get; set; }

        int NumDoc { get; set; }

        int NumFile { get; set; }

        string Descritivo { get; set; }

        string OriginalFileName { get; set; }

        string SavedFileName { get; set; }
    }
}
