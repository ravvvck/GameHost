using GameHost.Domain.Common.Models;
using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Event.ValueObjects;
using GameHost.Domain.Session.ValueObjects;
using GameHost.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Host
{
    public sealed class Host : AggregateRoot<HostId>
    {
        private readonly List<SessionId> _sessionIds = new();
        public Address Address { get; }
        public AverageRating AverageRating { get; }
        public UserId UserId { get; }

        private Host(HostId hostId, AverageRating averageRating, UserId userId)
        : base(hostId)
        {
            
            AverageRating = averageRating;
            UserId = userId;
            
        }

        public static Host Create( AverageRating averageRating, UserId userId)
        {
            return new(HostId.CreateUnique(), averageRating, userId);
        }
    }
}
