using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Domain.ValueObjects;
using Domain.Interfaces;

namespace Infrastructure.Persistence
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly IRepository<Domain.ValueObjects.Configuration> repository;

        public ConfigurationRepository(IRepository<Domain.ValueObjects.Configuration> _repository)
        {
            repository = _repository;
        }
        public async Task<Domain.ValueObjects.Configuration?> GetByParam(Expression<Func<Domain.ValueObjects.Configuration, bool>> obj)
        {
            return await repository.GetByParam(obj);
        }
    
    }
}
