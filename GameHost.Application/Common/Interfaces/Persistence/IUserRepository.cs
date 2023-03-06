
using GameHost.Domain.Users;
using GameHost.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User> UpdateAsync(User user);
        User? GetUserByEmail(string email);
        User? GetUserByUserId(UserId userId);
        User? GetUserByRefreshToken(string refreshToken);
        void Register(User user);

    }
}
