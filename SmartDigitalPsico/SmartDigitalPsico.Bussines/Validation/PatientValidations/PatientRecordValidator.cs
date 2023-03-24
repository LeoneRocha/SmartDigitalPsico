using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Business.Validation.PatientValidations
{
    public class PatientRecordValidator : AbstractValidator<PatientRecord>
    {
        public PatientRecordValidator()
        {
            RuleFor(entity => entity.Annotation)
                .NotNull().NotEmpty()
                .WithMessage("A Annotation não pode ser vazia.");


            RuleFor(entity => entity.PatientId)
                .NotNull().LessThanOrEqualTo(0)
                .WithMessage("O Patient deve ser informado.");
        }
    }
}
