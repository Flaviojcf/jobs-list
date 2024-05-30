using MediatR;

namespace JobsList.Application.Commands.DeleteJob
{
    public class DeleteJobCommand(int id) : IRequest<Unit>
    {
        public int Id { get; private set; } = id;
    }
}
