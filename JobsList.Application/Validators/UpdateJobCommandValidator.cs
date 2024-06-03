using FluentValidation;
using JobsList.Application.Commands.UpdateJob;

namespace JobsList.Application.Validators
{
    public class UpdateJobCommandValidator : AbstractValidator<UpdateJobCommand>
    {
        public UpdateJobCommandValidator()
        {
            RuleFor(j => j.Title).NotEmpty().WithMessage("O campo título é obrigatório");

            RuleFor(j => j.Description).NotEmpty().WithMessage("O campo descrição é obrigatório");

            RuleFor(j => j.Location).NotEmpty().WithMessage("O campo localidade é obrigatório");

            RuleFor(j => j.Salary).NotEmpty().WithMessage("O campo salário é obrigatório").GreaterThan(0).WithMessage("O campo salário precisa ser maior que 0");
        }
    }
}
