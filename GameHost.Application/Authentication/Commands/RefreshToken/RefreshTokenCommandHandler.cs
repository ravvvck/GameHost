﻿using GameHost.Application.Common.Authentication;
using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Application.Common.Interfaces.Services;
using GameHost.Application.Exceptions;
using GameHost.Domain.Users.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Authentication.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthenticationResult>
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenGenerator jwtTokenGenerator;

        public RefreshTokenCommandHandler(IUserRepository userRepository, ITokenGenerator jwtTokenGenerator)
        {
            this.userRepository = userRepository;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<AuthenticationResult> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var user = userRepository.GetUserByRefreshToken(request.RefreshToken);
            if (user == null)
            {
                throw new BadRequestException("User not found");
            }
            if (user.RefreshTokenExpires < DateTime.UtcNow)
            {
                throw new BadRequestException("Refresh token is expired.");
            }
            var token = jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);

        }
    }
}
