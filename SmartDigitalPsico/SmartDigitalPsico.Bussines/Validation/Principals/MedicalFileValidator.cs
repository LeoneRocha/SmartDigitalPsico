using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Principals;

namespace SmartDigitalPsico.Business.Validation.SystemDomains
{
    public class MedicalFileValidator : AbstractValidator<MedicalFile>
    {

        private IMedicalFileRepository _entityRepository;
        private IMedicalRepository _medicalRepository;
        private IUserRepository _userRepository; 
        public MedicalFileValidator(IMedicalFileRepository entityRepository, IMedicalRepository medicalRepository, IUserRepository userRepository)
        {
            _entityRepository = entityRepository;
            _medicalRepository = medicalRepository;
            _userRepository = userRepository;

            #region Columns
            RuleFor(entity => entity.Description)
                .MaximumLength(255)
                .WithMessage("O Description não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.FilePath)
                .MaximumLength(2083)
                .WithMessage("O FilePath não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.FileExtension)
             .MaximumLength(3)
             .WithMessage("O FileExtension não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.FileContentType)
             .MaximumLength(100)
             .WithMessage("O FileContentType não pode ultrapassar {MaxLength} carateres.");

            #endregion Columns

            #region Relationship
            RuleFor(entity => entity.MedicalId)
            .NotNull() 
            .WithMessage("O medical deve ser informado.")
            .MustAsync(async (entity, value, c) => await MedicalIdFound(entity, value))
            .WithMessage("O medical informado não existe.")
            .MustAsync(async (entity, value, c) => await MedicalChanged(entity, value))
            .MustAsync(async (entity, value, c) => await MedicalCreated(entity, value))
            .WithMessage("O medico infomado deve ser o mesmo logado. Medicos nao podem criar arquivos de outro medico.")
            .MustAsync(async (entity, value, c) => await MedicalModify(entity, value))
            .WithMessage("O medico infomado deve ser o mesmo logado. Medicos nao podem modificar arquivos de outro medico.");

            #endregion Relationship
        } 
        private async Task<bool> MedicalIdFound(MedicalFile entity, long value)
        {
            var entityFind = await _medicalRepository.FindByID(entity.MedicalId);
            if (entityFind == null)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> MedicalChanged(MedicalFile entity, long value)
        {
            long idUser = entity.CreatedUserId.GetValueOrDefault();
            var entityBefore = await _entityRepository.FindByID(value);
            if (entityBefore != null)
            {
                if (entityBefore.MedicalId != entity.MedicalId)
                {
                    return false;
                }
            }
            return true;
        }

        private async Task<bool> MedicalCreated(MedicalFile entity, long value)
        {
            long idUser = entity.CreatedUserId.GetValueOrDefault();
            var medical = await _medicalRepository.FindByID(value);
            if (medical == null || medical.UserId != idUser)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> MedicalModify(MedicalFile entity, long value)
        {
            long idUser = entity.ModifyUserId.GetValueOrDefault();

            var medical = await _medicalRepository.FindByID(value);
            if (medical == null || medical.UserId != idUser)
            {
                return false;
            }
            return true;
        }

    }
}
