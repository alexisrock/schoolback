using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Interfaces
{
    public interface IMateriaRepository
    {
        Task<List<Materia>> GetAll();
        Task Insert(Materia obj);
        Task Update(Materia obj);
        Task Delete(object id);
        Task<Materia?> GetId(int objeto);

    }
}
