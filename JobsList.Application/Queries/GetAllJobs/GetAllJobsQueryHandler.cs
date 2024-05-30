using JobsList.Domain.Entities;
using JobsList.Domain.Repositories;
using MediatR;

namespace JobsList.Application.Queries.GetAllJobs
{
    public class GetAllJobsQueryHandler(IJobsRepository jobsRepository) : IRequestHandler<GetAllJobsQuery, List<Jobs>>
    {
        private readonly IJobsRepository _jobsRepository = jobsRepository;
        public async Task<List<Jobs>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
        {
            return await _jobsRepository.GetAllAsync();
        }
    }
}
