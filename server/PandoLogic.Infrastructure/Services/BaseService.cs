using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PandoLogic.Core.Repositories;
using PandoLogic.ServicesCore.Services;

namespace PandoLogic.Infrastructure.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;
        protected IMapper Mapper;

        public BaseService(IBaseRepository<T> repository, IMapper mapper)
        {
            Mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllEntitiesAsync()
            => await _repository.ToListAsync();
    }
}