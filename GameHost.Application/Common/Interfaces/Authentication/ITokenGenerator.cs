
using GameHost.Domain.Users;
using GameHost.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Common.Authentication
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
        RefreshToken GenerateRefreshToken();
    }
}
