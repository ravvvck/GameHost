using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Domain.Sessions;
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
        public SessionRepository(GameHostDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private readonly GameHostDbContext dbContext;

        public void Add(Session session)
        {
            dbContext.Sessions.Add(session);    
            dbContext.SaveChanges();
        }


    }
}
