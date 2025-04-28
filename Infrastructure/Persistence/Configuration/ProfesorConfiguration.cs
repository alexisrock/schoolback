using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
    {
        public void Configure(EntityTypeBuilder<Profesor> builder)
        {
            builder.ToTable("Profesor");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Profesion).IsRequired();
      
            builder.HasOne(u => u.Usuario)
              .WithMany()
              .HasForeignKey(u => u.IdUsuario)
              .HasConstraintName("Fk_IdUsuario_Profesor")
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
