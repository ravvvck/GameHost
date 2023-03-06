using GameHost.Domain.Common.Models;
using GameHost.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Users
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenCreated { get; set; }
        public DateTime RefreshTokenExpires { get; set; }
        private User()
        {

        }

        private User(UserId userId, string firstName, string lastName, string email, string password, DateTime createdDateTime, DateTime updatedDateTime)
        : base(userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = password;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static User Create(string firstName, string lastName, string email, string password)
        {
            return new(UserId.CreateUnique(), firstName, lastName, email, password, DateTime.UtcNow, DateTime.UtcNow);
        }

        public void UpdateRefreshToken(RefreshToken refreshToken)
        {
            this.RefreshToken = refreshToken.Token;
            this.RefreshTokenCreated = refreshToken.Created;
            this.RefreshTokenExpires = refreshToken.Expires;
        }
    }

}
