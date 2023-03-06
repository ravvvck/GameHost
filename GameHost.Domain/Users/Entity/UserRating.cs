using GameHost.Domain.Common.Models;
using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Hosts.ValueObjects;
using GameHost.Domain.Sessions.ValueObjects;
using GameHost.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Users.Entity
{
    public sealed class UserRating : Entity<UserRatingId>
    {
        public HostId HostId { get; }
        public SessionId SessionId { get; }
        public Rating Rating { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private UserRating(UserRatingId userRatingId, HostId hostid, SessionId sessionId, Rating rating, DateTime createdDateTime, DateTime updatedDateTime)
            : base(userRatingId)
        {
            HostId = hostid;
            SessionId = sessionId;
            Rating = rating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static UserRating Create(HostId hostId, SessionId sessionId, Rating rating)
        {
            return new(UserRatingId.CreateUnique(), hostId, sessionId, rating, DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}
