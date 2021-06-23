using System;
using System.ComponentModel.DataAnnotations;
using TwitchGames.Ttny.Dal.Entities.TownEntity;
using TwitchGames.Ttny.Dal.Entities.UserEntity;

namespace TwitchGames.Ttny.Dal.Entities.TownEventEntity
{
    public class TownEvent
    {
        [Key]
        public Guid TownEventId { get; set; }
        public Guid TownId { get; set; }
        public Guid? UserId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Message { get; set; }

        public Town? Town { get; set; }
        public User? User { get; set; }
    }
}
