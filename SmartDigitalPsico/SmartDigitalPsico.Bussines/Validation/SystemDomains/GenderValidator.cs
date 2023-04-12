using FluentValidation;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Business.Validation.SystemDomains
{
    public class GenderValidator : AbstractValidator<Gender>
    {
        //https://docs.fluentvalidation.net/en/latest/start.html
        public GenderValidator()
        {
            RuleFor(entity => entity.Description)
                .NotNull().NotEmpty()
                .WithMessage("ErrorValidator_Description_Null");

            RuleFor(entity => entity.Language)
                .NotNull().NotEmpty()
                .WithMessage("ErrorValidator_Language_Null") 
                .MaximumLength(10)
                .WithMessage("ErrorValidator_Language_MaximumLength")  
                .WithErrorCode("[{MaxLength}],"); //"O Language não pode ultrapassar {MaxLength} carateres.");
        }
    }
}
