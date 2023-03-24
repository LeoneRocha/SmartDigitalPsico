using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Business.Validation.PatientValidations
{
    public class PatientFileValidator : AbstractValidator<PatientFile>
    {
        public PatientFileValidator()
        {
            RuleFor(entity => entity.Description)
                .NotNull().NotEmpty()
                .WithMessage("A descrição não pode ser vazia.");

            RuleFor(entity => entity.PatientId)
                .NotNull().LessThanOrEqualTo(0)
                .WithMessage("O Patient deve ser informado.");
        }
    }
}
