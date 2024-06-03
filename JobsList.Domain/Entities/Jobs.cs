using JobsList.Domain.Validation;

namespace JobsList.Domain.Entities
{
    public sealed class Jobs : BaseEntity
    {
        public Jobs(string title, string description, string location, decimal salary)
        {
            ValidateDomain(title, description, location, salary);
            Title = title;
            Description = description;
            Location = location;
            Salary = salary;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Location { get; private set; }
        public decimal Salary { get; private set; }
        public bool IsActive { get; private set; } = true;

        public void Active()
        {
            IsActive = true;
        }

        public void DeActive()
        {
            IsActive = false;
            UpdatedAt = DateTime.Now;
        }

        public void Update(string title, string description, string location, decimal salary)
        {
            ValidateDomain(title, description, location, salary);
            Title = title;
            Description = description;
            Location = location;
            Salary = salary;
            UpdatedAt = DateTime.Now;
        }

        private static void ValidateDomain(string title, string description, string location, decimal salary)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(title), "Title is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(location), "Location is required");
            DomainExceptionValidation.When(salary < 0, "Salary must be greater than 0");
        }
    }
}
