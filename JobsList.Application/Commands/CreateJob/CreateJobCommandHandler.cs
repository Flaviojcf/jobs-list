using JobsList.Domain.Entities;
using JobsList.Domain.Repositories;
using MediatR;

namespace JobsList.Application.Commands.CreateJob
{
    public class CreateJobCommandHandler(IJobsRepository jobsRepository) : IRequestHandler<CreateJobCommand, int>
    {
        private readonly IJobsRepository _jobsRepository = jobsRepository;
        public async Task<int> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var job = new Jobs(request.Title, request.Description, request.Location, request.Salary);

            job.Active();

            await _jobsRepository.CreateAsync(job);

            return job.Id;
        }
    }
}
