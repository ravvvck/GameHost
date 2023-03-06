using GameHost.Application.Common.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Authentication.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<AuthenticationResult>
    {
        public string RefreshToken { get; set; }
    }
}
