using PandoLogic.Core.Entities;
using PandoLogic.ServicesCore.Models.Jobs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandoLogic.ServicesCore.Services
{
    public interface IJobsService : IBaseService<Job>
    {
        Task<IEnumerable<JobResponseModel>> GetAllJobsByJobTitleId(int jobTitleId);
    }
}