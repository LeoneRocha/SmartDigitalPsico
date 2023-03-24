using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Business.Validation.SystemDomains
{
    public class MedicalFileValidator : AbstractValidator<MedicalFile>
    {
        //https://docs.fluentvalidation.net/en/latest/start.html
        public MedicalFileValidator()
        {
            RuleFor(entity => entity.TypeLocationSaveFile)
                .NotNull().NotEmpty()
                .WithMessage("A Description não pode ser vazia."); 
        }
    }
}
