using GameHost.Domain.Hosts;
using GameHost.Domain.Sessions;
using GameHost.Domain.Sessions.Entities;
using GameHost.Domain.Users;
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
        public DbSet<Game> Games { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<User> Users { get; set; }
        public GameHostDbContext(DbContextOptions<GameHostDbContext> options) : base(options)
        {

        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameHostDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
