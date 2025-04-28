using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly IRepository<Estudiante> repository;
        private readonly PruebaContext _Context;


        public EstudianteRepository(IRepository<Estudiante> repository, PruebaContext Context)
        {
            this.repository = repository;
            _Context = Context;
        }           

        public async Task<Estudiante?> GetById(object id)
        {
            return await repository.GetById(id);
        }

        public async Task<Estudiante?> GetByParam(Expression<Func<Estudiante, bool>> obj)
        {
            return await repository.GetByParam(obj);
        }

        public async Task<List<SPEstudiantesMaterias>>? GetMateriasEstudiante(int idMateria)
        {
            var listestudianteMateria = await _Context.SPEstudiantesMaterias.FromSqlRaw("EXEC SPEstudiantesMaterias  @IdMateria", new SqlParameter("@IdMateria", idMateria)).ToListAsync();
            return listestudianteMateria;
        }

        public async Task Insert(Estudiante obj)
        {
           await repository.Insert(obj);      
        }

        public async Task<List<SPMateriasEstudiante>>? GetMateriasByIdEstudiante(int idUsuario)
        {
            var listestudianteMateria = await _Context.SPMateriasEstudiante.FromSqlRaw("EXEC SPMateriasEstudiante  @Idusuario", new SqlParameter("@Idusuario", idUsuario)).ToListAsync();
            return listestudianteMateria;
        }




    }
}
