using JobsList.Domain.Entities;
using JobsList.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobsList.Infrastructure.Persistance.Repositories
{
    public class JobsRepository(JobsListDbContext dbContext) : IJobsRepository
    {
        private readonly JobsListDbContext _dbContext = dbContext;

        public async Task CreateAsync(Jobs job)
        {
            await _dbContext.Jobs.AddAsync(job);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Jobs>> GetAllAsync()
        {
            return await _dbContext.Jobs.Where(j => j.IsActive).ToListAsync();
        }

        public async Task<Jobs> GetByIdAsync(int id)
        {
            return await _dbContext.Jobs.SingleOrDefaultAsync(j => j.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
