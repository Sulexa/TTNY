using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TwitchGames.Ttny.Dal.Entities.TownEventEntity;
using TwitchGames.Ttny.Dal.Entities.TownUserEntity;

namespace TwitchGames.Ttny.Dal.Entities.UserEntity
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string DisplayName { get; set; }

        //Attention ça peut etre vide TODO set default value
        public string ColorHex { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        public IEnumerable<TownEvent> TownEvents { get; set; } = null!;

        public IEnumerable<TownUser> TownUsers { get; set; } = null!;
    }
}
