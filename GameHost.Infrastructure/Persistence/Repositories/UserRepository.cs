using Azure;
using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Application.Exceptions;
using GameHost.Domain.Sessions;
using GameHost.Domain.Users;
using GameHost.Domain.Users.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
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

        public async Task<User> UpdateAsync(User user)
        {
            var exist = await dbContext.Users.FirstOrDefaultAsync(os => os.Id == user.Id);
            if (exist == null)
            {
                throw new NotFoundException("User do not exist.");
            }
            dbContext.Entry(exist).CurrentValues.SetValues(user);
            dbContext.SaveChanges();
            return user;
        }
        

        public User? GetUserByUserId(UserId userId)
        {
            return dbContext.Users.SingleOrDefault(u => u.Id == userId);
        }

        public User? GetUserByRefreshToken(string refreshToken)
        {
            return dbContext.Users.SingleOrDefault(u => u.RefreshToken == refreshToken);
        }
    }
}
