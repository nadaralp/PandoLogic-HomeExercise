using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandoLogic.Core;
using PandoLogic.Core.Entities;
using PandoLogic.Core.Repositories;
using PandoLogic.Infrastructure.EntityFramework;

namespace PandoLogic.Infrastructure.Repositories
{
    public class JobRepository : BaseRepository<Job>, IJobsRepository
    {
        public JobRepository(JobsContext context) : base(context)
        {
        }
    }
}