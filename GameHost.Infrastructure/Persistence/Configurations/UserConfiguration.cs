using GameHost.Domain.Sessions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameHost.Domain.Users;
using GameHost.Domain.Users.ValueObjects;
using GameHost.Domain.Sessions.ValueObjects;

namespace GameHost.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUserTable(builder);
        }

       

        private void ConfigureUserTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                value => UserId.Create(value));

            builder.Property(t => t.FirstName)
                .HasMaxLength(100);
            builder.Property(t => t.LastName)
                .HasMaxLength(100);

            
        }
    
    }
}
