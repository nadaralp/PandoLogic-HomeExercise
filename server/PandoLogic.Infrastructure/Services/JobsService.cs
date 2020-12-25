using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PandoLogic.Core;
using PandoLogic.Core.Entities;
using PandoLogic.Core.Repositories;
using PandoLogic.ServicesCore.Models.Jobs;
using PandoLogic.ServicesCore.Services;

namespace PandoLogic.Infrastructure.Services
{
    public class JobsService : BaseService<Job>, IJobsService
    {
        private readonly IJobsRepository _repository;

        public JobsService(IJobsRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<JobResponseModel>> GetAllJobsByJobTitleId(int jobTitleId)
        {
            var jobsFromDb = await _repository.FilterAsync(job => job.JobTitleId == jobTitleId);
            return Mapper.Map<IEnumerable<JobResponseModel>>(jobsFromDb);
        }
    }
}