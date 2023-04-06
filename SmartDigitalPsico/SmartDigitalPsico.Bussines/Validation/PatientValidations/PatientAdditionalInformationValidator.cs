using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Principals;

namespace SmartDigitalPsico.Business.Validation.PatientValidations
{
    public class PatientAdditionalInformationValidator : AbstractValidator<PatientAdditionalInformation>
    {
        private IPatientAdditionalInformationRepository _entityRepository;
        private IPatientRepository _patientRepository;
        private IMedicalRepository _medicalRepository;
        private IUserRepository _userRepository;

        public PatientAdditionalInformationValidator(IPatientAdditionalInformationRepository entityRepository,
            IPatientRepository patientRepository, IMedicalRepository medicalRepository, IUserRepository userRepository)
        {
            _entityRepository = entityRepository;
            _patientRepository = patientRepository;
            _medicalRepository = medicalRepository;
            _userRepository = userRepository;

            #region Columns
            RuleFor(entity => entity.FollowUp_Psychiatric)
                .MaximumLength(2000)
                .WithMessage("O FollowUp_Psychiatric não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.FollowUp_Neurological)
               .MaximumLength(2000)
               .WithMessage("O FollowUp_Neurological não pode ultrapassar {MaxLength} carateres.");
            #endregion Columns

            #region Relationship

            RuleFor(entity => entity.CreatedUser)
              .NotNull()
              .WithMessage("O Usuário que está criando deve ser informado.");

            RuleFor(entity => entity.PatientId)
              .NotNull() 
              .WithMessage("O PatientId deve ser informado.")
              .MustAsync(async (entity, value, c) => await PatientIdFound(entity, value))
              .WithMessage("O PatientId informado não existe.")
              .MustAsync(async (entity, value, c) => await PatientIdChanged(entity, value))
              .WithMessage("O PatientId não pode ser alterado.")
              .MustAsync(async (entity, value, c) => await MedicalCreated(entity, value))
              .WithMessage("Informações do paciente não podem ser adicionadas por outro medico e/ou usuario.")
              .MustAsync(async (entity, value, c) => await MedicalModify(entity, value))
              .WithMessage("Informações do paciente não podem ser modificadas por outro medico e/ou usuario.");

            #endregion Relationship  
        }
        private async Task<bool> PatientIdFound(PatientAdditionalInformation entity, long value)
        {
            var entityFind = await _patientRepository.FindByID(entity.PatientId);
            if (entityFind == null)
            {
                return false;
            }
            return true;
        }
        private async Task<bool> PatientIdChanged(PatientAdditionalInformation entity, long value)
        {
            var entityBefore = await _entityRepository.FindByID(entity.Id);
            if (entityBefore != null)
            {
                if (entityBefore.PatientId != entity.PatientId)
                {
                    return false;
                }
            }
            return true;
        }
        private async Task<bool> MedicalCreated(PatientAdditionalInformation entity, long value)
        {
            long idUser = entity.CreatedUserId.GetValueOrDefault();

            var patient = await _patientRepository.FindByID(entity.PatientId);
            if (patient != null)
            {
                if (patient.Medical.UserId != idUser)
                {
                    return false;
                }
            }
            return true;
        }
        private async Task<bool> MedicalModify(PatientAdditionalInformation entity, long value)
        {
            long idUser = entity.ModifyUserId.GetValueOrDefault();

            var patient = await _patientRepository.FindByID(entity.PatientId);
            if (patient != null)
            {
                if (patient.Medical.UserId != idUser)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
