using JobsList.Domain.Entities;
using MediatR;

namespace JobsList.Application.Queries.GetAllJobs
{
    public class GetAllJobsQuery(string query) : IRequest<List<Jobs>>
    {
        public string Query { get; private set; } = query;
    }
}
