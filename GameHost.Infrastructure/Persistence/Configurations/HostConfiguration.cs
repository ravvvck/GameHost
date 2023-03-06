using GameHost.Domain.Hosts;
using GameHost.Domain.Hosts.ValueObjects;
using GameHost.Domain.Sessions;
using GameHost.Domain.Sessions.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Infrastructure.Persistence.Configurations
{
    public class HostConfiguration : IEntityTypeConfiguration<Host>
    {
        public void Configure(EntityTypeBuilder<Host> builder)
        {
            ConfigureHostTable(builder);
        }



        private void ConfigureHostTable(EntityTypeBuilder<Host> builder)
        {
            builder.ToTable("Hosts");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                value => HostId.Create(value));
            builder.HasMany(x => x.Sessions);

        }
    }
}
