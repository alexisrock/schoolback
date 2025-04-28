using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects;

namespace Domain.Interfaces
{
    public interface ICursoRepository
    {

        Task<List<Curso>> GetAll();
    }
}
