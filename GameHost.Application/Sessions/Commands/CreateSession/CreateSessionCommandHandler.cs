using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Domain.Hosts;
using GameHost.Domain.Hosts.ValueObjects;
using GameHost.Domain.Sessions;
using GameHost.Domain.Sessions.Entities;
using GameHost.Domain.Sessions.ValueObjects;
using MediatR;
using Microsoft.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Sessions.Commands.CreateSession
{
    public class CreateSessionCommandHandler : IRequestHandler<CreateSessionCommand, Session>
    {
        private readonly ISessionRepository sessionRepository;
        private readonly IHostRepository hostRepository;
        private readonly IUserRepository userRepository;

        public CreateSessionCommandHandler(ISessionRepository sessionRepository, IHostRepository hostRepository, IUserRepository userRepository)
        {
            this.sessionRepository = sessionRepository;
            this.hostRepository = hostRepository;
            this.userRepository = userRepository;
        }
        public async Task<Session> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
        {
            Host host = hostRepository.FindByUserIdOrCreate(request.UserId);

            var session = Session.Create(
                host: host,
                name: request.Name,
                description: request.Description,
                address: request.Address,
                date: request.Date,
                games: request.Games.ConvertAll(game => Game.Create(
                    game.Name,
                    game.Description,
                    game.InfoURL
                )));
            sessionRepository.Add(session);
            return session;
        }
    }
}
