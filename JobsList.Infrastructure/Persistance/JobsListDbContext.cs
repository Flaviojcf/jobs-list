using JobsList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JobsList.Infrastructure.Persistance
{
    public class JobsListDbContext(DbContextOptions<JobsListDbContext> options) : DbContext(options)
    {
        public DbSet<Jobs> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
