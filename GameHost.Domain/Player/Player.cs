using GameHost.Domain.Common.Models;
using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Player.ValueObjects;
using GameHost.Domain.SessionReview.ValueObjects;
using GameHost.Domain.User.Entity;
using GameHost.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Player
{
    public sealed class Player : AggregateRoot<PlayerId>
    {
        
        
        private readonly List<SessionReviewId> _sessionReviewId = new();
        private readonly List<UserRating> _ratings = new();
        public string FirstName { get; }
        public string LastName { get; }
        public AverageRating AverageRating { get; }
        public UserId UserId { get; }

        
        public IReadOnlyList<SessionReviewId> SessionReviewId => _sessionReviewId;
        public IReadOnlyList<UserRating> Ratings => _ratings;
        

        private Player(PlayerId playerId, string firstName, string lastName, AverageRating averageRating, UserId userId)
        : base(playerId)
        {
            FirstName = firstName;
            LastName = lastName;
            AverageRating = averageRating;
            UserId = userId;
            
        }

        public static Player Create(string firstName, string lastName,  AverageRating averageRating, UserId userId)
        {
            return new(PlayerId.CreateUnique(), firstName, lastName,  averageRating, userId);
        }
    }

}
