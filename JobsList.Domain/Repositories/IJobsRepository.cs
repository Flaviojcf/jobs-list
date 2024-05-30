using JobsList.Domain.Entities;

namespace JobsList.Domain.Repositories
{
    public interface IJobsRepository
    {
        Task CreateAsync(Jobs job);
        Task<List<Jobs>> GetAllAsync();
        Task<Jobs> GetByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
