using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository
    {

        Task<Users?> GetById(object id);
        Task Insert(Users obj);
        Task<Users?> GetByParam(Expression<Func<Users, bool>> obj);
    }
}
