using JobsList.Domain.Entities;
using JobsList.Domain.Repositories;
using MediatR;

namespace JobsList.Application.Queries.GetJobById
{
    public class GetJobByIdQueryHandler(IJobsRepository jobsRepository) : IRequestHandler<GetJobByIdQuery, Jobs>
    {
        private readonly IJobsRepository _jobsRepository = jobsRepository;
        public async Task<Jobs> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            return await _jobsRepository.GetByIdAsync(request.Id);
        }
    }
}
