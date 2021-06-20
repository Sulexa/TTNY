namespace TwitchGames.TwitchChat.Models
{
    public interface ITwitchConfig
    {
        string AccessToken { get; set; }
        string Channel { get; set; }
        string Username { get; set; }
    }

    public class TwitchConfig : ITwitchConfig
    {
        public string Username { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
        public string Channel { get; set; } = null!;
    }
}
