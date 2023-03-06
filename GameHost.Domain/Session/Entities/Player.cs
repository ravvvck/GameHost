using GameHost.Domain.Common.Models;
using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Session.ValueObjects;
using GameHost.Domain.SessionReview.ValueObjects;
using GameHost.Domain.Sessions;
using GameHost.Domain.Sessions.ValueObjects;

using GameHost.Domain.Users.ValueObjects;


namespace GameHost.Domain.Session.Entities
{
    public sealed class Player : Entity<PlayerId>
    {
        public GameHost.Domain.Users.User User { get; private set; }
        public GameHost.Domain.Sessions.Session Session { get; private set; }




        public Player()
        {

        }
        private Player(PlayerId playerId, GameHost.Domain.Users.User user, GameHost.Domain.Sessions.Session session)
        : base(playerId)
        {

            User = user;
            Session = session;
        }

        public static Player Create(GameHost.Domain.Users.User user, GameHost.Domain.Sessions.Session session)
        {
            return new(PlayerId.CreateUnique(), user, session);
        }
    }

}
