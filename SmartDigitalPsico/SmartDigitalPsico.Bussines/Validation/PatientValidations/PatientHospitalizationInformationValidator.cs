using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Validation.PatientValidations
{
    public class PatientHospitalizationInformationValidator : AbstractValidator<PatientHospitalizationInformation>
    { 
        private IPatientHospitalizationInformationRepository _entityRepository;
        private IPatientRepository _patientRepository;
        private IMedicalRepository _medicalRepository;
        private IUserRepository _userRepository;

        public PatientHospitalizationInformationValidator(IPatientHospitalizationInformationRepository entityRepository,
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
             
              RuleFor(entity => entity.CID)
              .NotNull().NotEmpty()
              .WithMessage("A CID não pode ser vazia.")
              .MaximumLength(20)
              .WithMessage("O CID não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.Observation)
                .NotNull().NotEmpty()
                .WithMessage("A Observation não pode ser vazia.")
                .MaximumLength(2000)
                .WithMessage("O Observation não pode ultrapassar {MaxLength} carateres.");

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
        private async Task<bool> PatientIdFound(PatientHospitalizationInformation entity, long value)
        {
            var entityFind = await _patientRepository.FindByID(entity.PatientId);
            if (entityFind == null)
            {
                return false;
            }
            return true;
        }
        private async Task<bool> PatientIdChanged(PatientHospitalizationInformation entity, long value)
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
        private async Task<bool> MedicalCreated(PatientHospitalizationInformation entity, long value)
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
        private async Task<bool> MedicalModify(PatientHospitalizationInformation entity, long value)
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
