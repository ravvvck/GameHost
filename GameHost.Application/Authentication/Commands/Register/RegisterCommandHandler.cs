using GameHost.Application.Common.Authentication;
using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Application.Common.Interfaces.Services;
using GameHost.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher<User> passwordHasher;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }
        public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (userRepository.GetUserByEmail(command.Email) is not null)
            {
                throw new Exception("User already exist");
            }
            
            var user = User.Create(command.FirstName, command.LastName, command.Email, command.Password);
            var hashedPassword = passwordHasher.HashPassword(user,command.Password);
            user.PasswordHash= hashedPassword;
            userRepository.Register(user);
            Guid userId = Guid.NewGuid();
            var token = jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult(
                   user,
                   token);
        }
    }
    }

