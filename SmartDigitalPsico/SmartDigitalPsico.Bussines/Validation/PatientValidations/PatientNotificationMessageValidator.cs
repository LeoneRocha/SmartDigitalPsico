using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Business.Validation.PatientValidations
{
    public class PatientNotificationMessageValidator : AbstractValidator<PatientNotificationMessage>
    { 
        public PatientNotificationMessageValidator()
        {
            RuleFor(entity => entity.MessagePatient)
                .NotNull().NotEmpty()
                .WithMessage("A Message não pode ser vazia."); 
        }
    }
}
