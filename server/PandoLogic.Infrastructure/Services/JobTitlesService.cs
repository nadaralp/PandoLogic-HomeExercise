using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PandoLogic.Core;
using PandoLogic.Core.Entities;
using PandoLogic.Core.Repositories;
using PandoLogic.ServicesCore.Models.JobTitles;
using PandoLogic.ServicesCore.Services;

namespace PandoLogic.Infrastructure.Services
{
    public class JobTitlesService : BaseService<JobTitle>, IJobsTitleService
    {
        public JobTitlesService(IJobTitlesRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<IEnumerable<JobTitleResponseModel>> GetAllJobTitlesAsync()
        {
            var jobTitlesEntities = await GetAllEntitiesAsync();
            return Mapper.Map<IEnumerable<JobTitleResponseModel>>(jobTitlesEntities);
        }
    }
}