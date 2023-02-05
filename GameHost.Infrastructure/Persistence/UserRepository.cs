using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
        
    {
        private readonly static List<User> Users = new ();
        public void Add(User user)
        {
            Users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
           return  Users.SingleOrDefault(u => u.Email == email);
        }
    }
}
