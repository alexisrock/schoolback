using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistence
{
    public class InscripcionMateriaRepository : IInscripcionMateriaRepository
    {

        private readonly IRepository<InscripcionMateria> repository;

        public InscripcionMateriaRepository(IRepository<InscripcionMateria> repository)
        {
            this.repository = repository;
        }

        public async Task Create(InscripcionMateria objeto)
        {
            await repository.Insert(objeto);
        }

        public async Task Create(InscripcionMateria[] objeto)
        {
            await repository.InsertRange(objeto);
        }

        public async Task Delete(InscripcionMateria objeto)
        {
            await repository.Delete(objeto);
        }

        public async Task<List<InscripcionMateria>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<InscripcionMateria?> GetId(int objeto)
        {
            return await repository.GetById(objeto);

        }

        public async Task<List<InscripcionMateria>> GetListByParam(Expression<Func<InscripcionMateria, bool>> obj)
        {

            return await repository.GetListByParam(obj);
        }

        public async Task Update(InscripcionMateria objeto)
        {
            await repository.Update(objeto);
        }



    }
}
