using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class ConfigurationConfiguration : IEntityTypeConfiguration<Domain.ValueObjects.Configuration>
    {
        public void Configure(EntityTypeBuilder<Domain.ValueObjects.Configuration> builder)
        {
            builder.ToTable("Configuration");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Value).IsRequired();
        }
    }
}
