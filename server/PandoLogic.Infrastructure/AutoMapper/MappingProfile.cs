using AutoMapper;
using PandoLogic.Core;
using PandoLogic.Core.Entities;
using PandoLogic.ServicesCore.Models.Jobs;
using PandoLogic.ServicesCore.Models.JobTitles;

namespace PandoLogic.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Jobs
            CreateBiDirectionalMap<Job, JobRequestModel>();
            CreateBiDirectionalMap<Job, JobResponseModel>();

            // Job Titles
            CreateBiDirectionalMap<JobTitle, JobTitleRequestModel>();
            CreateBiDirectionalMap<JobTitle, JobTitleResponseModel>();
        }

        private void CreateBiDirectionalMap<TEntity, TDto>()
        {
            CreateMap<TEntity, TDto>();
            CreateMap<TDto, TEntity>();
        }
    }
}