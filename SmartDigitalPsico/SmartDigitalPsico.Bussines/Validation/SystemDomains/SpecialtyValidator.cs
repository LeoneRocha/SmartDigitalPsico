using FluentValidation;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Business.Validation.SystemDomains
{
    public class SpecialtyValidator : AbstractValidator<Specialty>
    {
        public SpecialtyValidator()
        {
            RuleFor(entity => entity.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("A descrição não pode ser vazia.")
                .MaximumLength(255)
                .WithMessage("O descrição não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.Language)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Language não pode ser vazia.")
                .MaximumLength(10)
                .WithMessage("O Language não pode ultrapassar {MaxLength} carateres.");
        }
    }
}
