using PandoLogic.Core.Entities;
using PandoLogic.ServicesCore.Models.JobTitles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandoLogic.ServicesCore.Services
{
    public interface IJobsTitleService : IBaseService<JobTitle>
    {
        Task<IEnumerable<JobTitleResponseModel>> GetAllJobTitlesAsync();
    }
}