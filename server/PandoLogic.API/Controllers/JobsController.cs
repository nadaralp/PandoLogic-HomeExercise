using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandoLogic.Core.Repositories;

namespace PandoLogic.API.Controllers
{
    public class JobsController : BaseController
    {
        private readonly IJobsRepository _jobsRepository;

        public JobsController(IJobsRepository jobsRepository)
        {
            _jobsRepository = jobsRepository;
        }

        [HttpGet]
        public async Task<dynamic> Test()
        {
            return await _jobsRepository.ToListAsync();
        }
    }
}