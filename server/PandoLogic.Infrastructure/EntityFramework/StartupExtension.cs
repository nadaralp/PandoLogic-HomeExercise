﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using PandoLogic.Core.Entities;

namespace PandoLogic.Infrastructure.EntityFramework
{
    public static class StartupExtension
    {
        public static void AddEntityFrameworkContexts(this IServiceCollection services, IConfiguration configuration)
        {
            string testConnectionString =
                "Server=localhost,1433;Database=PandoLogic_Nadar;Trusted_Connection=True;user=sa;password=sysadmin123;Persist Security Info=False;Integrated Security=false;Max Pool Size=10000;";

            //configuration.GetConnectionString("JobsContext")
            services.AddDbContext<JobsContext>(options =>
                options.UseSqlServer(testConnectionString));
        }

        public static void EnsureJobsContextBeenSeeded<T>(this IApplicationBuilder app, ILogger<T> logger)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                if (serviceScope is null) return;

                var context = serviceScope.ServiceProvider.GetRequiredService<JobsContext>();
                context.Database.EnsureCreated(); // Creates PandoLogic_Nadar

                if (!(TableExistsAndContainsData<Job>(context) || TableExistsAndContainsData<JobTitle>(context)))
                {
                    logger.LogInformation("One or more tables don't exist {Job};{JobTitle}");

                    // Open both SQL files and execute.
                    string baseEntityFrameworkDirectory = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "EntityFramework");
                    string createTestJobTitlesSqlFileName = "CreateTestJobTitles.sql";
                    string createTestJobsSqlFileName = "CreateTestJobs.sql";

                    logger.LogInformation("Creating Tables and seeding...");
                    try
                    {
                        OpenFileAndWriteContentAsSqlQuery(
                            Path.Join(baseEntityFrameworkDirectory, createTestJobTitlesSqlFileName), context);

                        OpenFileAndWriteContentAsSqlQuery(Path.Join(baseEntityFrameworkDirectory, createTestJobsSqlFileName),
                            context);
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e.Message);
                    }

                    return;
                }

                logger.LogError("Both tables exist. skipping creation and seeding of tables and data.");
            }
        }

        private static bool TableExistsAndContainsData<TEntity>(DbContext context) where TEntity : class
        {
            try
            {
                var _ = context.Set<TEntity>().Any();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void OpenFileAndWriteContentAsSqlQuery(string filePath, DbContext context)
        {
            using (var sr = new StreamReader(filePath))
            {
                string sqlScript = sr.ReadToEnd();

                // Executing SQL queries based on GO split
                SplitSqlStatements(sqlScript)
                    .ToList()
                    .ForEach(script => context.Database.ExecuteSqlRaw(script));
            }
        }

        private static IEnumerable<string> SplitSqlStatements(string sqlScript)
        {
            // Split by "GO" statements
            var statements = sqlScript.Split("GO");

            // Remove empties, trim, and return
            return statements
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim(' ', '\r', '\n'));
        }
    }
}