using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Business.Validation.PatientValidations
{
    public class PatientHospitalizationInformationValidator : AbstractValidator<PatientHospitalizationInformation>
    { 
        public PatientHospitalizationInformationValidator()
        {
            RuleFor(entity => entity.CID)
                .NotNull().NotEmpty()
                .WithMessage("A CID não pode ser vazia.");

            RuleFor(entity => entity.PatientId)
                .NotNull().LessThanOrEqualTo(0)
                .WithMessage("O Patient deve ser informado.");

        }
    }
}
