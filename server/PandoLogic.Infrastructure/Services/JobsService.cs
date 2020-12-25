using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PandoLogic.Core;
using PandoLogic.Core.Entities;
using PandoLogic.Core.Repositories;
using PandoLogic.ServicesCore.Services;

namespace PandoLogic.Infrastructure.Services
{
    public class JobsService : BaseService<Job>, IJobsService
    {
        public JobsService(IJobsRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}