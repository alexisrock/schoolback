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
    public class MateriaProfesorConfiguration : IEntityTypeConfiguration<MateriaProfesor>
    {
        public void Configure(EntityTypeBuilder<MateriaProfesor> builder)
        {
            builder.ToTable("MateriaProfesor");
            builder.HasKey(u => u.Id);
            builder.HasOne(u => u.Materia)
            .WithMany()
            .HasForeignKey(u => u.IdMateria)
            .HasConstraintName("Fk_IdMateria_MateriaProfesor")
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Profesor)
           .WithMany()
           .HasForeignKey(u => u.IdProfesor)
           .HasConstraintName("Fk_IdProfesor_MateriaProfesor")
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

