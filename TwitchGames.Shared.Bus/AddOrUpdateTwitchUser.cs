namespace TwitchGames.Shared.Bus
{
    public class AddOrUpdateTwitchUser
    {
        public string TwitchId { get; set; }
        public string DisplayName { get; set; }
        public string ColorHex { get; set; }

        public AddOrUpdateTwitchUser(string twitchId, string displayName, string colorHex)
        {
            TwitchId = twitchId;
            DisplayName = displayName;
            ColorHex = colorHex;
        }
    }
}
