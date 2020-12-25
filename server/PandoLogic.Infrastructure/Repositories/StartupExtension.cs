using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PandoLogic.Core.Repositories;

namespace PandoLogic.Infrastructure.Repositories
{
    public static class StartupExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IJobsRepository, JobRepository>();
            services.AddScoped<IJobTitlesRepository, JobTitlesRepository>();
        }
    }
}