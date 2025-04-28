using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class MateriaProfesorRepository : IMateriaProfesorRepository
    {

        private readonly IRepository<MateriaProfesor> repository;

        private readonly PruebaContext _Context;
        public MateriaProfesorRepository(IRepository<MateriaProfesor> repository, PruebaContext Context)
        {
            this.repository = repository;
            _Context = Context;
        }

        public async Task CreateRange(MateriaProfesor[] objeto)
        {
            await repository.InsertRange(objeto);
        }

        public async Task Delete(MateriaProfesor objeto)
        {
            await repository.Delete(objeto);
        }

        public async Task<List<MateriaProfesor>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<List<MateriaProfesor>> GetAllById(int id)
        {
            return await repository.GetListByParam(x => x.IdProfesor == id);
        }

        public async Task<MateriaProfesor?> GetId(int objeto)
        {
            return await repository.GetById(objeto);

        }

        public  async Task<List<SPMateriasProfesor>>? GetMateriasprofesor()
        {
            var listMateriasProfesor = await _Context.SPMateriasProfesores.FromSqlRaw("EXEC SPMateriasProfesor").ToListAsync();
            return listMateriasProfesor;
        }

        public async Task Update(MateriaProfesor objeto)
        {
            await repository.Update(objeto);
        }





    }
}
