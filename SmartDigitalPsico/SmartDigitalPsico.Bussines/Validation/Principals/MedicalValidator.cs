using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Validation.SystemDomains
{
    public class MedicalValidator : AbstractValidator<Medical>
    {
        private IMedicalRepository _entityRepository;
        public MedicalValidator(IMedicalRepository entityRepository)
        {
            _entityRepository = entityRepository;
             
            #region Columns
             
            RuleFor(entity => entity.Name)
                .NotNull().NotEmpty()
                .WithMessage("A Name não pode ser vazia.");

            RuleFor(entity => entity.Accreditation)
                .NotNull().NotEmpty()
                .WithMessage("O Accreditation não pode ser vazia.")
                .MaximumLength(10)
                .WithMessage("O Accreditation não pode ultrapassar {MaxLength} carateres.")
                .MustAsync(async (entity, value, c) => await UniqueAccreditation(entity, value))
              .WithMessage("Email must be unique."); ;

            RuleFor(entity => entity.Email)
               .NotNull().NotEmpty()
               .WithMessage("O Email não pode ser vazia.")
               .EmailAddress()
               .WithMessage("O Email invalido.")
               .MaximumLength(100)
               .WithMessage("O Email não pode ultrapassar {MaxLength} carateres.")
               .MustAsync(async (entity, value, c) => await UniqueEmail(entity, value))
              .WithMessage("Email must be unique.");
             
            RuleFor(p => p.SecurityKey)
                .MaximumLength(255)
               .WithMessage("O SecurityKey não pode ultrapassar {MaxLength} carateres.");

            #endregion
             
            #region Relationship

            RuleFor(entity => entity.CreatedUser)
              .NotNull()
              .WithMessage("O Usuário que está criando deve ser informado.");

            #endregion Relationship 
        }

        private async Task<bool> UniqueAccreditation(Medical entity, string value)
        {
            var user = await _entityRepository.FindByAccreditation(value);
            if (user == null || user?.Id == 0)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> UniqueEmail(Medical entity, string value)
        {
            var user = await _entityRepository.FindByEmail(value);
            if (user == null || user?.Id == 0)
            {
                return true;
            }
            return false;
        }
    }
}
