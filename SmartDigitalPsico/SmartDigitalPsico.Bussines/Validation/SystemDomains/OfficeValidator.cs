using FluentValidation;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Business.Validation.SystemDomains
{
    public class OfficeValidator : AbstractValidator<Office>
    {
        public OfficeValidator()
        {
            RuleFor(entity => entity.Description)
                .NotNull().NotEmpty()
                .WithMessage("A descrição não pode ser vazia.");

            RuleFor(entity => entity.Language)
                .NotNull().NotEmpty()
                .WithMessage("O Language não pode ser vazia.")
                .MaximumLength(10)
                .WithMessage("O Language não pode ultrapassar {MaxLength} carateres.");
        }
    }
}
