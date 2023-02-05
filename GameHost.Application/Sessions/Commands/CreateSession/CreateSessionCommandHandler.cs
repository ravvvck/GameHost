using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Domain.Session;
using GameHost.Domain.Session.Entities;
using GameHost.Domain.Session.ValueObjects;
using MediatR;
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

        public CreateSessionCommandHandler(ISessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }
        public async Task<Session> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
        {
            var session = Session.Create(
                hostId: HostId.Create(request.HostId),
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
