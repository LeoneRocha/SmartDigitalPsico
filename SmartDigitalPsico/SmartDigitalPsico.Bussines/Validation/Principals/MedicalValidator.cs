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
                .MustAsync(async (entity, value, c) => await IsUniqueAccreditation(entity, value))
              .WithMessage("Email must be unique."); ;

            RuleFor(entity => entity.Email)
               .NotNull().NotEmpty()
               .WithMessage("O Email não pode ser vazia.")
               .EmailAddress()
               .WithMessage("O Email invalido.")
               .MaximumLength(100)
               .WithMessage("O Email não pode ultrapassar {MaxLength} carateres.")
               .MustAsync(async (entity, value, c) => await IsUniqueEmail(entity, value))
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

        private async Task<bool> IsUniqueAccreditation(Medical entity, string value)
        {
            var entityActual = await _entityRepository.FindByID(entity.Id);
            bool isNewEnity = entityActual == null;

            var existingEnity = await _entityRepository.FindByAccreditation(value);

            if (isNewEnity && existingEnity != null)
            {
                return false;
            }
            bool changingProp = entityActual != null && entityActual.Accreditation != value;
            if (changingProp)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> IsUniqueEmail(Medical entity, string value)
        {
            var entityActual = await _entityRepository.FindByID(entity.Id);
            bool isNewEnity = entityActual == null;
            var existingEnity = await _entityRepository.FindByEmail(value);
            if (isNewEnity && existingEnity != null)
            {
                return false;
            }
            bool changingProp = entityActual != null && entityActual.Email != value;
            if (changingProp)
            {
                return false;
            }
            return true;
        }
    }
}
