using JobsList.Application.Exceptions;
using JobsList.Domain.Repositories;
using MediatR;

namespace JobsList.Application.Commands.DeleteJob
{
    public class DeleteJobCommandHandler(IJobsRepository jobsRepository) : IRequestHandler<DeleteJobCommand, Unit>
    {
        private readonly IJobsRepository _jobsRepository = jobsRepository;
        public async Task<Unit> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var job = await _jobsRepository.GetByIdAsync(request.Id);

            if (job == null || job.IsActive == false)
            {
                throw new NotFoundException($"O job com o id {request.Id} não foi encontrado");
            }

            job.DeActive();

            await _jobsRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
