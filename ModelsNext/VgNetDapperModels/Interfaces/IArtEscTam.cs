namespace VgNetDapperModels.Interfaces
{
    public interface IArtEscTam
    {
        string Artigo { get; set; }
        int Tam { get; set; }
        string Descritivo { get; set; }
        short? GrupoTam { get; set; }
        short? Sequencia { get; set; }
    }
}
