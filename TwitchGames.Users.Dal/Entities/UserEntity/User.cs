using System;
using System.ComponentModel.DataAnnotations;

namespace TwitchGames.Users.Dal.Entities.UserEntity
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string TwitchId { get; set; }
        public string DisplayName { get; set; }

        //Attention ça peut etre vide TODO set default value
        public string ColorHex { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
