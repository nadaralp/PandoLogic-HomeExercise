using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PandoLogic.Infrastructure.AutoMapper;
using PandoLogic.Infrastructure.EntityFramework;
using PandoLogic.Infrastructure.Repositories;
using PandoLogic.Infrastructure.Services;

namespace PandoLogic.API
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;
        private readonly string CorsPolicy = "CorsPolicy";

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PandoLogic.API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                    builder =>
                    {
                        var allowedCors = Configuration.GetSection("CorsOrigins").Get<IEnumerable<string>>();
                        builder.WithOrigins(allowedCors.ToArray());
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });

            services.AddEntityFrameworkContexts(Configuration, _logger);
            services.AddRepositories();

            services.AddAutoMapperProfiles();
            services.AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PandoLogic.API v1"));
            }

            app.UseCors(CorsPolicy);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.EnsureJobsContextBeenSeeded(_logger);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}