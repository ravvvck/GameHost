using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Domain.User;
using GameHost.Domain.Users;
using GameHost.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository

    {
        public UserRepository(GameHostDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        private readonly GameHostDbContext dbContext;

        public void Register(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

        }

        public User? GetUserByEmail(string email)
        {
            return dbContext.Users.SingleOrDefault(u => u.Email == email);
        }

        public User? GetUserByUserId(UserId userId)
        {
            return dbContext.Users.SingleOrDefault(u => u.Id == userId);
        }
    }
}
