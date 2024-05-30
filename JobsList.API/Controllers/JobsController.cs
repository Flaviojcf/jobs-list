using JobsList.Application.Commands.CreateJob;
using JobsList.Application.Commands.DeleteJob;
using JobsList.Application.Commands.UpdateJob;
using JobsList.Application.Queries.GetAllJobs;
using JobsList.Application.Queries.GetJobById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobsList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll(string query)
        {
            var getAllJobsQuery = new GetAllJobsQuery(query);

            var jobs = await _mediator.Send(getAllJobsQuery);

            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getJobByIdQuery = new GetJobByIdQuery(id);

            var job = await _mediator.Send(getJobByIdQuery);

            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateJobCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteJobCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateJobCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
