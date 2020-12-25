using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PandoLogic.Infrastructure.EntityFramework
{
    public static class StartupExtension
    {
        public static void AddEntityFrameworkContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JobsContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("JobsContext")));
        }
    }
}