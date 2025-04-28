using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMateriaProfesorRepository
    {
        Task<MateriaProfesor?> GetId(int objeto);
        Task CreateRange(MateriaProfesor[] objeto);
        Task Delete(MateriaProfesor objeto);
        Task Update(MateriaProfesor objeto);
        Task<List<MateriaProfesor>> GetAll();
        Task<List<MateriaProfesor>> GetAllById(int id);
        Task<List<SPMateriasProfesor>>? GetMateriasprofesor();
    }
}
