using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Business.Validation.PatientValidations
{
    public class PatientValidator : AbstractValidator<Patient>
    { 
        public PatientValidator()
        {
            RuleFor(entity => entity.Name)
                .NotNull().NotEmpty()
                .WithMessage("A descrição não pode ser vazia.");

            RuleFor(entity => entity.MedicalId)
                .NotNull().LessThanOrEqualTo(0)
                .WithMessage("O medical deve ser informado."); 
        }
    }
}
