using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Domain.Sessions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Sessions.Queries
{
    public class GetAllSessionsQueryHandler : IRequestHandler<GetAllSessionsQuery, List<Session>>
    {
        private readonly ISessionRepository sessionRepository;

        public GetAllSessionsQueryHandler(ISessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }
        public async Task<List<Session>> Handle(GetAllSessionsQuery request, CancellationToken cancellationToken)
        {
            var sessions = await sessionRepository.GetAll();
            return sessions;
        }
    }
}
