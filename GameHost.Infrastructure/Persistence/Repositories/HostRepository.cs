using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Domain.Hosts;
using GameHost.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Infrastructure.Persistence.Repositories
{
    public class HostRepository : IHostRepository
    {
        private readonly GameHostDbContext dbContext;

        public HostRepository(GameHostDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Host Add(Host host)
        {
            dbContext.Add(host);
            dbContext.SaveChanges();
            return host;
        }

        public Host FindByUserId(UserId userId)
        {
            var host = dbContext.Hosts.FirstOrDefault(h => h.User.Id == userId);
                
            return host;

        }

        public Host FindByUserIdOrCreate(UserId userId)
        {
            var host = dbContext.Hosts.FirstOrDefault(h => h.User.Id == userId);
            if (host == null)
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Id == userId);
                var newHost = Host.Create(user);
                dbContext.Add(newHost);
                dbContext.SaveChanges();
                return newHost;
            }
            return host;
        }
    }
}
