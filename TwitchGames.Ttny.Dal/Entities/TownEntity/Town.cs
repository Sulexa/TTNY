using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TwitchGames.Ttny.Dal.Entities.TownEventEntity;
using TwitchGames.Ttny.Dal.Entities.TownUserEntity;

namespace TwitchGames.Ttny.Dal.Entities.TownEntity
{
    public class Town
    {
        [Key]
        public Guid TownId { get; set; }
        public uint Wood { get; set; }
        public uint Food { get; set; }
        public uint Defense { get; set; }
        public uint NextAttackSize { get; set; }
        public bool Alive { get; set; }

        public IEnumerable<TownEvent> TownEvents { get; set; } = null!;
        public IEnumerable<TownUser> TownUsers { get; set; } = null!;
    }
}
