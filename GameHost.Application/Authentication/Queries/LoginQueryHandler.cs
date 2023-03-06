using GameHost.Application.Common.Authentication;
using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Application.Common.Interfaces.Services;
using GameHost.Application.Exceptions;
using GameHost.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Authentication.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher<User> passwordHasher;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }
        public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            if (userRepository.GetUserByEmail(request.Email) is not User user)
            {
                throw new BadRequestException("User does not exist");
            }

            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new NotFoundException("Invalid username or password");
            }

            var token = jwtTokenGenerator.GenerateToken(user);



            return new AuthenticationResult(
                  user,
                  token);
        }
    }
}
