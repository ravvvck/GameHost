using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Application.Exceptions;
using GameHost.Domain.Sessions;
using GameHost.Domain.Sessions.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Infrastructure.Persistence.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        public SessionRepository(GameHostDbContext dbContext, IAuthorizationService authorizationService)
        {
            this.dbContext = dbContext;
            this.authorizationService = authorizationService;
        }

        private readonly GameHostDbContext dbContext;
        private readonly IAuthorizationService authorizationService;

        public void Add(Session session)
        {
            dbContext.Sessions.Add(session);    
            dbContext.SaveChangesAsync();
        }

        public async Task<List<Session>> GetAll()
        {
            var sessions = await dbContext.Sessions.Include(s => s.Host).ToListAsync();
            return sessions;
        }

        public async void Delete(SessionId sessionId)
        {
            
            var session = await dbContext.Sessions.FirstOrDefaultAsync(session => session.Id == sessionId);
            if (session == null)
            {
                throw new NotFoundException("Session do not exist.");
            }

            dbContext.Sessions.Remove(session);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Session> GetById(SessionId sessionId)
        {
            var session = await dbContext.Sessions.Include(s=>s.Host).ThenInclude(x => x.User)
                .FirstOrDefaultAsync(session => session.Id == sessionId);
            if (session == null)
            {
                throw new NotFoundException("Session do not exist.");
            }
            return session;
        }

        public async Task<Session> Update(Session session)
        {
            var oldSession = await dbContext.Sessions.FirstOrDefaultAsync(os => os.Id == session.Id);
            if (oldSession == null)
            {
                throw new NotFoundException("Session do not exist.");
            }
            dbContext.Entry(oldSession).CurrentValues.SetValues(session);
            dbContext.SaveChanges();
            return session;

        }
    }
}
