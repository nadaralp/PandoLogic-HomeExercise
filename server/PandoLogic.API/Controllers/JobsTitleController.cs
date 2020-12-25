using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandoLogic.ServicesCore.Models.Jobs;
using PandoLogic.ServicesCore.Services;

namespace PandoLogic.API.Controllers
{
    public class JobsTitleController : BaseController
    {
        private readonly IJobsTitleService _jobsTitleService;

        public JobsTitleController(IJobsTitleService jobsTitleService)
        {
            _jobsTitleService = jobsTitleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobResponseModel>>> GetAllJobTitles()
        {
            try
            {
                var jobTitlesResponseModel = await _jobsTitleService.GetAllJobTitlesAsync();
                return Ok(jobTitlesResponseModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}