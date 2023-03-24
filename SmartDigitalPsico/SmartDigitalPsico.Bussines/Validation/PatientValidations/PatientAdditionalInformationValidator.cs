using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Business.Validation.PatientValidations
{
    public class PatientAdditionalInformationValidator : AbstractValidator<PatientAdditionalInformation>
    { 
        public PatientAdditionalInformationValidator()
        {
            RuleFor(entity => entity.FollowUp_Neurological)
                .NotNull().NotEmpty()
                .WithMessage("A FollowUp não pode ser vazia."); 
        }
    }
}
