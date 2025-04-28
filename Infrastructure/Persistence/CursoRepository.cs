using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Infrastructure.Persistence
{
    public class CursoRepository : ICursoRepository
    {
        private readonly IRepository<Curso> repository;


        public CursoRepository(IRepository<Curso> repository)
        {
            this.repository = repository;
        }

        public async Task<List<Curso>> GetAll()
        {
            return await repository.GetAll();
        }
    }
}
