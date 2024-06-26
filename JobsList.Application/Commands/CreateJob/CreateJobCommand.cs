﻿using MediatR;

namespace JobsList.Application.Commands.CreateJob
{
    public class CreateJobCommand(string title, string description, string location, decimal salary) : IRequest<int>
    {
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public string Location { get; private set; } = location;
        public decimal Salary { get; private set; } = salary;
    }
}
