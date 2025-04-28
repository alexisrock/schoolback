using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<Estudiante?> GetById(object id);
        Task Insert(Estudiante obj);
        Task<Estudiante?> GetByParam(Expression<Func<Estudiante, bool>> obj);
        Task<List<SPEstudiantesMaterias>>? GetMateriasEstudiante(int idMateria);
        Task<List<SPMateriasEstudiante>>? GetMateriasByIdEstudiante(int idUsuario);


    }
}
