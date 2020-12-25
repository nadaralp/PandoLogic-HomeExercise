using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandoLogic.Core.Repositories;
using PandoLogic.ServicesCore.Models.JobTitles;
using PandoLogic.ServicesCore.Services;

namespace PandoLogic.API.Controllers
{
    public class JobsController : BaseController
    {
        private readonly IJobsService _jobsService;

        public JobsController(IJobsService jobsService)
        {
            _jobsService = jobsService;
        }

        [HttpGet("{jobTitleId}")]
        public async Task<ActionResult<IEnumerable<JobTitleResponseModel>>> GetAllJobsByJobTitleId(int jobTitleId)
        {
            try
            {
                var jobsResponseModel = await _jobsService.GetAllJobsByJobTitleId(jobTitleId);
                return Ok(jobsResponseModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}