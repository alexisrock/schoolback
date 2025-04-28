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
    public class InscripcionMateriaConfiguration : IEntityTypeConfiguration<InscripcionMateria>
    {
        public void Configure(EntityTypeBuilder<InscripcionMateria> builder)
        {
            builder.ToTable("InscripcionMateria");
            builder.HasKey(u => u.Id);
            builder.HasOne(u => u.MateriaProfesor)
            .WithMany() 
            .HasForeignKey(x => x.IdMateriaProfesor)
            .HasConstraintName("Fk_IdMateria_InscripcionMateria")
            .OnDelete(DeleteBehavior.Restrict);
        

            builder.HasOne(u => u.Estudiante)
           .WithMany()
           .HasForeignKey(u => u.IdEstudiante)
           .HasConstraintName("Fk_IdEstudiante_InscripcionMateria")
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
