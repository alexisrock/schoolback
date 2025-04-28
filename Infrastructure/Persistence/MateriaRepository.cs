using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistence
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly IRepository<Materia> repository;

        public MateriaRepository(IRepository<Materia> repository)
        {
            this.repository = repository;
        }

        public async Task Delete(object id)
        {
            await repository.Delete(id);
        }

        public async Task<List<Materia>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<Materia?> GetId(int objeto)
        {
            return await repository.GetById(objeto);
        }

        public async Task Insert(Materia obj)
        {
            await repository.Insert(obj);
        }

        public async Task Update(Materia obj)
        {
            await repository.Update(obj);
        }



    }
}
