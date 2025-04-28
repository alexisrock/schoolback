using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProfesorRepository
    {
        Task<Profesor?> GetById(object id);
        Task Insert(Profesor obj);
        Task<Profesor?> GetByParam(Expression<Func<Profesor, bool>> obj);
        Task<List<SPEstudiantesByProfesor>>? GetMateriasprofesor(int idProfesor, int idMateria);
        Task<List<SPMateriasByIdProfesor>>? GetMateriasByIdprofesor(int idUsiario);

    }
}
