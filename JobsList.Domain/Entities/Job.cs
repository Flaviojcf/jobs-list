namespace JobsList.Domain.Entities
{
    public sealed class Job(string title, string description, string location, decimal salary) : BaseEntity
    {
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public string Location { get; private set; } = location;
        public decimal Salary { get; private set; } = salary;
        public bool IsActive { get; private set; } = false;

        public void Active()
        {
            IsActive = true;
        }

        public void DeActive()
        {
            IsActive = false;
        }
    }
}
