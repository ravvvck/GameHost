﻿using GameHost.Domain.User;
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