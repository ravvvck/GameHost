using GameHost.Domain.Session;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameHost.Domain.User;
using GameHost.Domain.User.ValueObjects;

namespace GameHost.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureSessionTable(builder);
            ConfigureGameTable(builder);
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

        private void ConfigureSessionTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                value => UserId.Create(value));
            builder.OwnsOne(x => x.Address);

            builder.Property(t => t.Name)
                .HasMaxLength(100);
            builder.Property(t => t.Description)
                .HasMaxLength(100);

            builder.Property(t => t.HostId)
                 .HasConversion(id => id.Value,
                value => HostId.Create(value));
        }
    {
    }
}
