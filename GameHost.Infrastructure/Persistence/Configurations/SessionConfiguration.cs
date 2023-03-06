using GameHost.Domain.Hosts;
using GameHost.Domain.Hosts.ValueObjects;
using GameHost.Domain.Session.ValueObjects;
using GameHost.Domain.Sessions;
using GameHost.Domain.Sessions.Entities;
using GameHost.Domain.Sessions.ValueObjects;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Infrastructure.Persistence.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            ConfigureSessionTable(builder);
            ConfigureGameTable(builder);
            ConfigurePlayerTable(builder);
        }

        private void ConfigurePlayerTable(EntityTypeBuilder<Session> builder)
        {
            builder.OwnsMany(m => m.Players, sb =>
            {
                sb.ToTable("Players");
                sb.WithOwner().HasForeignKey("SessionId");
                sb.HasKey("Id", "SessionId");

                sb.Property(t => t.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                value => PlayerId.Create(value));
                
            });
        }

        private void ConfigureGameTable(EntityTypeBuilder<Session> builder)
        {
            builder.OwnsMany(m => m.Games, sb =>
            {
                sb.ToTable("Games");
                sb.WithOwner().HasForeignKey("SessionId");
                sb.HasKey("Id", "SessionId");

                sb.Property(t => t.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                value => GameId.Create(value));
                sb.Property(t => t.Name)
               .HasMaxLength(100);
                sb.Property(t => t.Description)
                    .HasMaxLength(100);
                sb.Property(t => t.InfoURL)
                    .HasMaxLength(50);
            });
        }

        private void ConfigureSessionTable(EntityTypeBuilder<Session>  builder)
        {
            builder.ToTable("Sessions");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                value => SessionId.Create(value));
            builder.OwnsOne(x => x.Address);

            builder.Property(t => t.Name)
                .HasMaxLength(100);
            builder.Property(t => t.Description)
                .HasMaxLength(100);

            
        }

       
    }
}
