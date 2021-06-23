namespace TwitchGames.TwitchChat.Models
{
    public class BotCommandDto
    {
        public string TwitchId { get; set; }
        public string DisplayName { get; set; }
        public string ColorHex { get; set; }

        public BotCommandDto(string twitchId, string displayName, string colorHex)
        {
            TwitchId = twitchId;
            DisplayName = displayName;
            ColorHex = colorHex;
        }
    }
}
