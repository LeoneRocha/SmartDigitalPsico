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


            RuleFor(entity => entity.PatientId)
               .NotNull().LessThanOrEqualTo(0)
               .WithMessage("O Patient deve ser informado.");


        }
    }
}
