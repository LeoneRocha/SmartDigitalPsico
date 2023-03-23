using FluentValidation;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Business.Validation
{
    public class PatientValidator : AbstractValidator<Patient>
    {
        //https://docs.fluentvalidation.net/en/latest/start.html
        //criar um custom para realizar a consulta. -- Para buscar entidade ou validar contra o banco
        public PatientValidator()
        {
            RuleFor(entity => entity.Name)
                .NotNull().NotEmpty()
                .WithMessage("A descrição não pode ser vazia.");

            RuleFor(entity => entity.MedicalId)
                .NotNull().LessThanOrEqualTo(0) 
                .WithMessage("O medical deve ser informado.");

            //RuleFor(entity => entity.Language)
            //    .NotNull().NotEmpty()
            //    .WithMessage("O Language não pode ser vazia.")
            //    .MaximumLength(10)
            //    .WithMessage("O Language não pode ultrapassar {MaxLength} carateres.");
        }
    }
}
