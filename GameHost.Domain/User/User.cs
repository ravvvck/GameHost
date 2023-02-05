﻿using GameHost.Domain.Common.Models;
using GameHost.Domain.Entities;
using GameHost.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.User
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private User(UserId userId, string firstName, string lastName, string email, string password, DateTime createdDateTime, DateTime updatedDateTime)
        : base(userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static User Create(string firstName, string lastName, string email, string password)
        {
            return new(UserId.CreateUnique(), firstName, lastName, email, password, DateTime.UtcNow, DateTime.UtcNow);
        }
    }

}
