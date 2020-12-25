using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PandoLogic.Core.Repositories;
using PandoLogic.ServicesCore.Services;

namespace PandoLogic.Infrastructure.Services
{
    public static class StartupExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IJobsService, JobsService>();
            services.AddScoped<IJobsTitleService, JobTitlesService>();
        }
    }
}