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
        }
    }
}
