
using GameHost.Domain.Users;
using GameHost.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Common.Interfaces.Services
{
    public class AuthenticationResult
    {
        public User User { get; set; }
        public string Token { get; set; }
        public RefreshToken RefreshToken { get; set; }

        public AuthenticationResult(User user, string token, RefreshToken refreshToken)
        {
            User = user;
            Token = token;
            RefreshToken = refreshToken;
        }

        public AuthenticationResult(User user, string token)
        {
            User = user;
            Token = token;
        }
    }
    //}
    //public record AuthenticationResult(
    //      User User,
    //        string Token);


}
