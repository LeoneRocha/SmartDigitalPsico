using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Business.Validation.SystemDomains
{
    public class MedicalValidator : AbstractValidator<Medical>
    {
        //https://docs.fluentvalidation.net/en/latest/start.html
        public MedicalValidator()
        {
            RuleFor(entity => entity.Name)
                .NotNull().NotEmpty()
                .WithMessage("A Name não pode ser vazia.");

            RuleFor(entity => entity.Accreditation)
                .NotNull().NotEmpty()
                .WithMessage("O Accreditation não pode ser vazia.")
                .MaximumLength(10)
                .WithMessage("O Accreditation não pode ultrapassar {MaxLength} carateres.");


        }
    }
}
