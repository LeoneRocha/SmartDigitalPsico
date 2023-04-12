using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Validation.PatientValidations
{
    public class PatientMedicationInformationValidator : AbstractValidator<PatientMedicationInformation>
    {
        private IPatientMedicationInformationRepository _entityRepository;
        private IPatientRepository _patientRepository;
        private IMedicalRepository _medicalRepository;
        private IUserRepository _userRepository;
        public PatientMedicationInformationValidator(IPatientMedicationInformationRepository entityRepository,
            IPatientRepository patientRepository, IMedicalRepository medicalRepository, IUserRepository userRepository)
        {
            _entityRepository = entityRepository;
            _patientRepository = patientRepository;
            _medicalRepository = medicalRepository;
            _userRepository = userRepository;

            #region Columns

            RuleFor(entity => entity.Description)
              .NotNull().NotEmpty()
              .WithMessage("A Description não pode ser vazia.")
              .MaximumLength(255)
              .WithMessage("O Description não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.StartDate)
                .NotNull()
               .WithMessage("A StartDate não pode ser vazia.");

            RuleFor(entity => entity.Dosage)
                .MaximumLength(255)
                .WithMessage("O Dosage não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.Posology)
              .MaximumLength(255)
              .WithMessage("O Dosage não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.MainDrug)
            .MaximumLength(255)
            .WithMessage("O Dosage não pode ultrapassar {MaxLength} carateres.");

            #endregion Columns 

            #region Relationship

            RuleFor(entity => entity.CreatedUser)
                 .NotNull() 
                 .WithMessage("ErrorValidator_CreatedUser_Null");

            RuleFor(entity => entity.PatientId)
              .NotNull() 
              .WithMessage("ErrorValidator_Patient_Null")
              .MustAsync(async (entity, value, c) => await PatientIdFound(entity, value)) 
              .WithMessage("ErrorValidator_Patient_NotFound")
              .MustAsync(async (entity, value, c) => await PatientIdChanged(entity, value)) 
              .WithMessage("ErrorValidator_Patient_Changed")
              .MustAsync(async (entity, value, c) => await MedicalCreated(entity, value)) 
              .WithMessage("ErrorValidator_Patient_Medical_Created")
              .MustAsync(async (entity, value, c) => await MedicalModify(entity, value)) 
              .WithMessage("ErrorValidator_Patient_Medical_Modify");

            #endregion Relationship  
        }

        private async Task<bool> PatientIdFound(PatientMedicationInformation entity, long value)
        {
            var entityFind = await _patientRepository.FindByID(entity.PatientId);
            if (entityFind == null)
            {
                return false;
            }
            return true;
        }
        private async Task<bool> PatientIdChanged(PatientMedicationInformation entity, long value)
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
        private async Task<bool> MedicalCreated(PatientMedicationInformation entity, long value)
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
        private async Task<bool> MedicalModify(PatientMedicationInformation entity, long value)
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
