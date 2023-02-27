using GameHost.Domain.Common.Models;
using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Hosts.ValueObjects;
using GameHost.Domain.Sessions.ValueObjects;
using GameHost.Domain.SessionReview.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameHost.Domain.Session.ValueObjects;

namespace GameHost.Domain.SessionReview
{
    public sealed class SessionReview : AggregateRoot<SessionReviewId>
    {
        public Rating Rating { get; }
        public string Comment { get; }
        public HostId HostId { get; }
        public SessionId SessionId { get; }
        public PlayerId PlayerId { get; }

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private SessionReview(SessionReviewId sessionReviewId, Rating rating, string comment, HostId hostId, SessionId sessionId, PlayerId playerId, DateTime createdDateTime, DateTime updatedDateTime)
        : base(sessionReviewId)
        {
            Rating = rating;
            Comment = comment;
            HostId = hostId;
            SessionId = sessionId;
            PlayerId = playerId;

            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static SessionReview Create(Rating rating, string comment, HostId hostId, SessionId sessionId, PlayerId playerId)
        {
            return new(SessionReviewId.CreateUnique(), rating, comment, hostId, sessionId, playerId, DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}
