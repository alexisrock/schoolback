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
    public class EstudianteConfiguration : IEntityTypeConfiguration<Estudiante>
    {
        public void Configure(EntityTypeBuilder<Estudiante> builder)
        {
            builder.ToTable("Estudiante");
            builder.HasKey(u => u.Id);      
            builder.HasOne(u => u.Usuario)
              .WithMany()
              .HasForeignKey(u => u.IdUsuario)              
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Curso)
             .WithMany()
             .HasForeignKey(u => u.IdCurso)           
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
