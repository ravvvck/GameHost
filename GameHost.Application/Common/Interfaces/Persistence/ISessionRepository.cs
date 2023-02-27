using GameHost.Domain.Sessions;
using GameHost.Domain.Sessions.ValueObjects;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Common.Interfaces.Persistence
{
    public interface ISessionRepository
    {
        void Delete(SessionId sessionId);
        Task<List<Session>> GetAll();
        Task<Session> GetById(SessionId sessionId);
        void Add(Session e);
        Task<Session> Update(Session session);
    }
}
