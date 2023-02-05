using GameHost.Application.Common.Authentication;
using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Application.Common.Interfaces.Services;
using GameHost.Domain.User;
using MediatR;
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

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userRepository = userRepository;
        }
        public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            if (userRepository.GetUserByEmail(request.Email) is not User user)
            {
                throw new Exception("User does not exist");
            }

            if (user.Password != request.Password)
            {
                throw new Exception("Invalid password");

            }

            var token = jwtTokenGenerator.GenerateToken(user);



            return new AuthenticationResult(
                  user,
                  token);
        }
    }
}
