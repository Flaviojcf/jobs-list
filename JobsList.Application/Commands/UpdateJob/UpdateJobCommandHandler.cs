using JobsList.Domain.Repositories;
using MediatR;

namespace JobsList.Application.Commands.UpdateJob
{
    public class UpdateJobCommandHandler(IJobsRepository jobsRepository) : IRequestHandler<UpdateJobCommand, Unit>
    {
        private readonly IJobsRepository _jobsRepository = jobsRepository;
        public async Task<Unit> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var job = await _jobsRepository.GetByIdAsync(request.Id);

            job.Update(request.Title, request.Description, request.Location, request.Salary);

            return Unit.Value;
        }
    }
}
