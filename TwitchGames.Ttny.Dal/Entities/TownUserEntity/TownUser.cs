using System;
using TwitchGames.Ttny.Dal.Entities.TownEntity;
using TwitchGames.Ttny.Dal.Entities.UserEntity;

namespace TwitchGames.Ttny.Dal.Entities.TownUserEntity
{
    public class TownUser
    {
        public Guid TownId { get; set; }
        public Guid UserId { get; set; }
        public bool Alive { get; set; }
        public bool HaveAction { get; set; }

        public Town? Town { get; set; }
        public User? User { get; set; }
    }
}
