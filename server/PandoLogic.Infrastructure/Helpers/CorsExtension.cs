using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PandoLogic.Infrastructure.Helpers
{
    public static class CorsExtension
    {
        public static void AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(CorsPolicy,
            //        builder =>
            //        {
            //            var allowedCors = Configuration.GetSection("CorsOrigins").Get<IEnumerable<string>>();
            //            builder.WithOrigins(allowedCors.ToArray());
            //            builder.AllowAnyMethod();
            //            builder.AllowAnyHeader();
            //        });
            //});
        }
    }
}