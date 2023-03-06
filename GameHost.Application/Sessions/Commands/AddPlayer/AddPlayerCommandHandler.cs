using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Sessions.Commands.AddPlayer
{
    public class AddPlayerCommandHandler : IRequestHandler<AddPlayerCommand, Unit>
    {
        private readonly ISessionRepository sessionRepository;
        private readonly IUserRepository userRepository;

        public AddPlayerCommandHandler(ISessionRepository sessionRepository, IUserRepository userRepository)
        {
            this.sessionRepository = sessionRepository;
            this.userRepository = userRepository;
        }
        public async Task<Unit> Handle(AddPlayerCommand request, CancellationToken cancellationToken)
        {
            var session = sessionRepository.GetById(request.SessionId).Result;
            var user = userRepository.GetUserByUserId(request.UserId);
            if (session == null || user == null)
            {
                throw new NotFoundException("Session or user not found");
            }
            session.AddPlayer(user);
            sessionRepository.Update(session);
            return Unit.Value;

        }
    }
}
