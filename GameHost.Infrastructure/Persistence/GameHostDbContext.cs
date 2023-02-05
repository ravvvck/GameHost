using GameHost.Domain.Event;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Infrastructure.Persistence
{
    public class GameHostDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
    }
}
