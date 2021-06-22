namespace TwitchGames.Shared.Bus
{
    public class AddTwitchUser
    {
        public string TwitchId { get; set; }
        public string DisplayName { get; set; }
        public string ColorHex { get; set; }

        public AddTwitchUser(string twitchId, string displayName, string colorHex)
        {
            TwitchId = twitchId;
            DisplayName = displayName;
            ColorHex = colorHex;
        }
    }
}
