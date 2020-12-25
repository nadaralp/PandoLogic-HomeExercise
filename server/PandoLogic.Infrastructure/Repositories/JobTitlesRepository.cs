using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandoLogic.Core;
using PandoLogic.Core.Repositories;
using PandoLogic.Infrastructure.EntityFramework;

namespace PandoLogic.Infrastructure.Repositories
{
    public class JobTitlesRepository : BaseRepository<JobTitle>, IJobTitlesRepository
    {
        public JobTitlesRepository(JobsContext context) : base(context)
        {
        }
    }
}