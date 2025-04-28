using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Infrastructure.Persistence
{
    public class RolRepository : IRolRepository
    {

        private readonly IRepository<Rol> repository;


        public RolRepository(IRepository<Rol> repository)
        {
            this.repository = repository;
        }

        public async Task<List<Rol>> GetAll()
        {
            return await repository.GetAll();
        }
    }
}