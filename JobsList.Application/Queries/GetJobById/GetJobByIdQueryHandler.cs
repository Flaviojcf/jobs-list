using JobsList.Application.Exceptions;
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
            var job = await _jobsRepository.GetByIdAsync(request.Id);

            if (job == null)
            {
                throw new NotFoundException($"O job com o id {request.Id} não foi encontrado");
            }

            return job;
        }
    }
}
