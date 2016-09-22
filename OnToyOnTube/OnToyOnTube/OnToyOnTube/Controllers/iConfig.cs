using SQLite.Net.Interop;


namespace OnToyOnTube.Controllers
{
    public interface iConfig
    {
        string DirectorioDB { get; }
        ISQLitePlatform Plataforma { get; }
    }
}