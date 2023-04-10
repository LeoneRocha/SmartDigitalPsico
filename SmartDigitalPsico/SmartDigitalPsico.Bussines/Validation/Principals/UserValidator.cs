using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Validation.Principals
{
    public class UserValidator : AbstractValidator<User>
    {
        private IUserRepository _entityRepository;
        //https://docs.fluentvalidation.net/en/latest/start.html
        //criar um custom para realizar a consulta. -- Para buscar entidade ou validar contra o banco
        public UserValidator(IUserRepository entityRepository)
        {
            _entityRepository = entityRepository;

            RuleFor(entity => entity.Name)
                .NotNull().NotEmpty()
                //.WithMessage(" O nome não pode ser vazio.")
                .WithMessage("ErrorValidator_Name_Null");

            RuleFor(entity => entity.Login)
                .NotNull().NotEmpty()
                //.WithMessage("O Login não pode ser vazia.")
                .WithMessage("ErrorValidator_Login_Null")
                .MaximumLength(25)
                .WithMessage("O Login não pode ultrapassar {MaxLength} carateres.")
                .MustAsync(async (entity, value, c) => await UniqueLogin(entity, value))
               //.WithMessage("Login must be unique.")
               .WithMessage("ErrorValidator_Login_Unique");

            RuleFor(entity => entity.Email)
               .NotNull().NotEmpty()
               //.WithMessage("O Email não pode ser vazia.")
               .WithMessage("ErrorValidator_Email_Null")
               .EmailAddress()
               //.WithMessage("O Email invalido.")
               .WithMessage("ErrorValidator_Email_Invalid")
               .MaximumLength(100)
               .WithMessage("O Email não pode ultrapassar {MaxLength} carateres.")
               .MustAsync(async (entity, value, c) => await UniqueEmail(entity, value))
            //  .WithMessage("Email must be unique.");
               .WithMessage("ErrorValidator_Email_Unique");

        }
        private async Task<bool> UniqueEmail(User entity, string value)
        {
            var userActual = await _entityRepository.FindByID(entity.Id);
            bool newUser = userActual == null; 
            var user = await _entityRepository.FindByEmail(value);
            if (newUser && user == null || user?.Id == 0)
            {
                return true;
            } 
            bool changingEmail = userActual != null && userActual.Email != value;
            if (!changingEmail)
            {
                return true;
            } 
            return false;
        }
        private async Task<bool> UniqueLogin(User entity, string value)
        {
            var userActual = await _entityRepository.FindByID(entity.Id);
            bool newUser = userActual == null; 
            var user = await _entityRepository.FindByLogin(value);
            if (newUser && user == null || user?.Id == 0)
            {
                return true;
            } 
            bool changingEmail = userActual != null && userActual.Login != value;
            if (!changingEmail)
            {
                return true;
            } 
            return false;
        }
    }
}
