using MediatR;

namespace JobsList.Application.Commands.UpdateJob
{
    public class UpdateJobCommand(int id, string title, string description, string location, decimal salary) : IRequest<Unit>
    {
        public int Id { get; private set; } = id;
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public string Location { get; private set; } = location;
        public decimal Salary { get; private set; } = salary;
    }
}
