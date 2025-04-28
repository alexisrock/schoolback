using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configuration
{
    internal static  class StoreProcedureConfiguration
    {



        internal static ModelBuilder SpConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SPMateriasProfesor>().HasNoKey().ToView("SPMateriasProfesor");
            modelBuilder.Entity<SPEstudiantesByProfesor>().HasNoKey().ToView("SPEstudiantesByProfesor");
            modelBuilder.Entity<SPEstudiantesMaterias>().HasNoKey().ToView("SPEstudiantesMaterias");
            modelBuilder.Entity<SPMateriasEstudiante>().HasNoKey().ToView("SPMateriasEstudiante");
            modelBuilder.Entity<SPMateriasByIdProfesor>().HasNoKey().ToView("SPMateriasByIdProfesor");


            
            return modelBuilder;
        }


    }
}
