using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork  
    {
        Task ExecuteAsync(Func<Task> operation);
        Task<T> ExecuteAsync<T>(Func<Task<T>> operation);
    }
}
