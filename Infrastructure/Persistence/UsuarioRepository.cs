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
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly IRepository<Users> repository;

        public UsuarioRepository(IRepository<Users> _repository)
        {
            repository = _repository;
        }

        public async Task<Users?> GetById(object id)
        {
            return await repository.GetById(id);
        }

        public async Task<Users?> GetByParam(Expression<Func<Users, bool>> obj)
        {
            return await repository.GetByParam(obj);
        }

        public async Task Insert(Users obj)
        {
            await repository.Insert(obj);
        }



    }
}
