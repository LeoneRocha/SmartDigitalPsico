using FluentValidation;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Business.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        //https://docs.fluentvalidation.net/en/latest/start.html
        //criar um custom para realizar a consulta. -- Para buscar entidade ou validar contra o banco
        public UserValidator()
        {
            RuleFor(entity => entity.Name)
                .NotNull().NotEmpty()
                .WithMessage(" O nome não pode ser vazio.");

            RuleFor(entity => entity.Login)
                .NotNull().NotEmpty()
                .WithMessage("O Login não pode ser vazia.")
                .MaximumLength(25)
                .WithMessage("O Login não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.Email)
               .NotNull().NotEmpty()
               .WithMessage("O Email não pode ser vazia.")
               .EmailAddress()
               .WithMessage("O Email invalido.")
               .MaximumLength(100)
               .WithMessage("O Email não pode ultrapassar {MaxLength} carateres.");

        }
    }
}
