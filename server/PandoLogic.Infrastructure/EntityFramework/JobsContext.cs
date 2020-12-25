using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandoLogic.Core;
using PandoLogic.Core.Entities;

namespace PandoLogic.Infrastructure.EntityFramework
{
    public class JobsContext : DbContext
    {
        public JobsContext(DbContextOptions<JobsContext> options) : base(options)
        {
        }

        private const string JobsTableName = "Test_Jobs";
        public DbSet<Job> Jobs { get; set; }

        private const string JobTitlesTableName = "Test_JobTitles";
        public DbSet<JobTitle> JobTitles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Job>()
                .ToTable(JobsTableName)
                .HasKey(job => job.JobId);

            modelBuilder.Entity<JobTitle>()
                .ToTable(JobTitlesTableName)
                .HasKey(jobTitle => jobTitle.JobTitleId);

            // Populate the database for docker (because docker is stateless)
        }
    }
}