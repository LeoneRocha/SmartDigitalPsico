using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Business.Validation.PatientValidations
{
    public class PatientMedicationInformationValidator : AbstractValidator<PatientMedicationInformation>
    { 
        public PatientMedicationInformationValidator()
        {
            RuleFor(entity => entity.Description)
                .NotNull().NotEmpty()
                .WithMessage("A Description não pode ser vazia.");


            RuleFor(entity => entity.PatientId)
                .NotNull().LessThanOrEqualTo(0)
                .WithMessage("O Patient deve ser informado.");
        }
    }
}
