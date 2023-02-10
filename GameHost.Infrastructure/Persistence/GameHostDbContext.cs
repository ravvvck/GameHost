using GameHost.Domain.Session;
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
        public GameHostDbContext(DbContextOptions<GameHostDbContext> options) : base(options)
        {

        }

        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameHostDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
