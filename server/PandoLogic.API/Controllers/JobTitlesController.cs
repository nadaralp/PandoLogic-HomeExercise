using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandoLogic.ServicesCore.Models.Jobs;
using PandoLogic.ServicesCore.Models.JobTitles;
using PandoLogic.ServicesCore.Services;

namespace PandoLogic.API.Controllers
{
    public class JobTitlesController : BaseController
    {
        private readonly IJobsTitleService _jobsTitleService;

        public JobTitlesController(IJobsTitleService jobsTitleService)
        {
            _jobsTitleService = jobsTitleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobTitleResponseModel>>> GetAllJobTitles()
        {
            try
            {
                // I didn't understand if you need to return distinct. But it would be the same implementation just .Distinct() on the City,State combo
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