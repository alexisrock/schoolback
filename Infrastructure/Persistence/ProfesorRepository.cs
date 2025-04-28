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
    public class ProfesorRepository: IProfesorRepository
    {
        private readonly IRepository<Profesor> repository;

        private readonly PruebaContext _Context;

        public ProfesorRepository(IRepository<Profesor> repository, PruebaContext Context)
        {
            this.repository = repository;
            _Context = Context;
        }

    
        public async Task<Profesor?> GetById(object id)
        {
            return await repository.GetById(id);
        }

        public async Task<Profesor?> GetByParam(Expression<Func<Profesor, bool>> obj)
        {

            return await repository.GetByParam(obj);
        }

        public async Task Insert(Profesor obj)
        {
            await repository.Insert(obj);
        }

        public async Task<List<SPEstudiantesByProfesor>>? GetMateriasprofesor(int idProfesor, int idMateria)
        {
            var listestudiantesProfesor = await _Context.SPEstudiantesByProfesor.FromSqlRaw("EXEC SPEstudiantesByProfesor @IdProfesor, @IdMateria", new SqlParameter("@IdProfesor", idProfesor), new SqlParameter("@IdMateria", idMateria)).ToListAsync();
            return listestudiantesProfesor;
        }

        public async Task<List<SPMateriasByIdProfesor>>? GetMateriasByIdprofesor(int idUsiario)
        {
            var listestudiantesProfesor = await _Context.SPMateriasByIdProfesor.FromSqlRaw("EXEC SPMateriasByIdProfesor  @Idusuario", new SqlParameter("@Idusuario", idUsiario)).ToListAsync();
            return listestudiantesProfesor;
        }




    }
}
