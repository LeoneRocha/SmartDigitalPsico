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
        }
    }
}
