using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Domain.Session;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Infrastructure.Persistence
{
    public class SessionRepository : ISessionRepository
    {

        private readonly List<Session> _sessions = new();
        public void Add(Session session)
        {
            _sessions.Add(session);
        }

        
    }
}
