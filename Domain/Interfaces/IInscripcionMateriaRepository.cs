using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IInscripcionMateriaRepository
    {
        Task<InscripcionMateria?> GetId(int objeto);
        Task Create(InscripcionMateria objeto);
        Task Create(InscripcionMateria[] objeto);
        Task Delete(InscripcionMateria objeto);
        Task Update(InscripcionMateria objeto);
        Task<List<InscripcionMateria>> GetAll();
        Task<List<InscripcionMateria>> GetListByParam(Expression<Func<InscripcionMateria, bool>> obj);
    }
}

