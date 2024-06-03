using FluentValidation;
using FluentValidation.AspNetCore;
using JobsList.API.Filters;
using JobsList.API.Middlewares;
using JobsList.Application.Commands.CreateJob;
using JobsList.Application.Commands.UpdateJob;
using JobsList.Application.Validators;
using JobsList.Domain.Repositories;
using JobsList.Infrastructure.Persistance;
using JobsList.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter))).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateJobCommandValidator>());
builder.Services.AddScoped<IValidator<CreateJobCommand>, CreateJobCommandValidator>();
builder.Services.AddScoped<IValidator<UpdateJobCommand>, UpdateJobCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateJobCommandValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<JobsListDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IJobsRepository, JobsRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateJobCommand).Assembly));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
