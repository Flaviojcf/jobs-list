using JobsList.Domain.Entities;
using MediatR;

namespace JobsList.Application.Queries.GetJobById
{
    public class GetJobByIdQuery(int id) : IRequest<Jobs>
    {
        public int Id { get; private set; } = id;
    }
}
