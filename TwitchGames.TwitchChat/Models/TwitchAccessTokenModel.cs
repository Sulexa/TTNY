using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TwitchGames.TwitchChat.Models
{
    public class TwitchAccessTokenModel
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        //public string RefreshToken { get; set; }
        [JsonPropertyName("expires_in")]
        public long ExpiresIn { get; set; }

        //public List<object> Scope { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
    }
}
