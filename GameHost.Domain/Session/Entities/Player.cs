using GameHost.Domain.Common.Models;
using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Session.ValueObjects;
using GameHost.Domain.SessionReview.ValueObjects;
using GameHost.Domain.Sessions;
using GameHost.Domain.Sessions.ValueObjects;
using GameHost.Domain.User.Entity;
using GameHost.Domain.Users.ValueObjects;


namespace GameHost.Domain.Session.Entities
{
    public sealed class Player : Entity<PlayerId>
    {


        private readonly List<SessionId> _sessionIds = new();
        public User User { get; }
        public Session Session { get; }





        private Player(PlayerId playerId, UserId userId, SessionId sessionId)
        : base(playerId)
        {

            UserId = userId;
            SessionIds.Add()
        }

        public static Player Create(UserId userId, SessionId sessionId)
        {
            return new(PlayerId.CreateUnique(), userId, sessionId);
        }
    }

}
