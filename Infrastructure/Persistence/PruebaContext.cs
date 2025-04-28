using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.Configuration;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class PruebaContext : DbContext
    {

        public PruebaContext(DbContextOptions<PruebaContext> options) : base(options) { }
        public virtual DbSet<MateriaProfesor>? MateriaProfesor { get; set; }
        public virtual DbSet<Users>? Usuarios { get; set; }
        public virtual DbSet<Materia>? Materia { get; set; }
        public virtual DbSet<Rol>? Rol { get; set; }
        public virtual DbSet<Profesor>? Profesor { get; set; }
        public virtual DbSet<Estudiante>? Estudiante { get; set; }
        public virtual DbSet<Curso>? Curso { get; set; }
        public virtual DbSet<InscripcionMateria>? InscripcionMateria { get; set; }
        public virtual DbSet<Domain.ValueObjects.Configuration>? Configuration { get; set; }
        public virtual DbSet<SPMateriasProfesor>? SPMateriasProfesores { get; set; }
        public virtual DbSet<SPEstudiantesByProfesor>? SPEstudiantesByProfesor { get; set; }
        public virtual DbSet<SPEstudiantesMaterias>? SPEstudiantesMaterias { get; set; }
        public virtual DbSet<SPMateriasEstudiante>? SPMateriasEstudiante { get; set; }
        public virtual DbSet<SPMateriasByIdProfesor>? SPMateriasByIdProfesor { get; set; }


        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RolConfiguration());
            modelBuilder.ApplyConfiguration(new ProfesorConfiguration());
            modelBuilder.ApplyConfiguration(new MateriaProfesorConfiguration());
            modelBuilder.ApplyConfiguration(new MateriaConfiguration());
            modelBuilder.ApplyConfiguration(new InscripcionMateriaConfiguration());
            modelBuilder.ApplyConfiguration(new EstudianteConfiguration());
            modelBuilder.ApplyConfiguration(new CursoConfiguration());
            modelBuilder.ApplyConfiguration(new ConfigurationConfiguration());
            modelBuilder.SpConfiguration();

        }
    }
}
