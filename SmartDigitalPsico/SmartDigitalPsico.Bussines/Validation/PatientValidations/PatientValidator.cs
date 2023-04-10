using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Principals;

namespace SmartDigitalPsico.Business.Validation.PatientValidations
{
    public class PatientValidator : AbstractValidator<Patient>
    {
        private IPatientRepository _entityRepository;
        private IMedicalRepository _medicalRepository;
        private IUserRepository _userRepository;

        public PatientValidator(IPatientRepository entityRepository, IMedicalRepository medicalRepository, IUserRepository userRepository)
        {
            _entityRepository = entityRepository;
            _medicalRepository = medicalRepository;
            _userRepository = userRepository;

            #region Columns

            RuleFor(entity => entity.Name)
             .NotNull().NotEmpty()
          .WithMessage("ErrorValidator_Description_Null");

            RuleFor(entity => entity.Profession)
                .MaximumLength(255)
                .WithMessage("O Profession não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.Email)
               .NotNull().NotEmpty() 
               .WithMessage("ErrorValidator_Email_Null")
               .EmailAddress() 
               .WithMessage("ErrorValidator_Email_Invalid")
               .MaximumLength(100)
               .WithMessage("O Email não pode ultrapassar {MaxLength} carateres.")
               .MustAsync(async (entity, value, c) => await UniqueEmail(entity, value)) 
              .WithMessage("ErrorValidator_Email_Unique");

            RuleFor(p => p.DateOfBirth).Must(BeAValidAge) 
                .WithMessage("ErrorValidator_DateOfBirth_Invalid");

            RuleFor(p => p.Rg)
                .NotNull().NotEmpty()
                .WithMessage("ErrorValidator_RG_Null") 
                .Length(10, 15)
               .WithMessage("Rg must be between 10 and {MaxLength} characters long");
            //.Matches("^[0-9]*$")//TODO: MUDAR REGEX PARA RG 
            // .WithMessage("Rg can only contain numbers");

            RuleFor(p => p.Cpf)
                .NotNull().NotEmpty() 
                .WithMessage("ErrorValidator_CPF_Null")
                .Length(10, 15)
               .WithMessage("Rg must be between 10 and {MaxLength} characters long");
            //.Matches("^[0-9]*$")//TODO: MUDAR REGEX PARA RG 
            // .WithMessage("Rg can only contain numbers");


            RuleFor(entity => entity.Profession)
                .MaximumLength(255)
                .WithMessage("O Profession não pode ultrapassar {MaxLength} carateres.");


            RuleFor(entity => entity.Education)
                .MaximumLength(255)
                .WithMessage("O Education não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.PhoneNumber)
                .MaximumLength(20)
                .WithMessage("O PhoneNumber não pode ultrapassar {MaxLength} carateres.")
                .Length(8, 20)
               .WithMessage("PhoneNumber must be between 8 and {MaxLength} characters long");
            // .Matches("^[0-9]*$")
            //.WithMessage("Phone Number can only contain numbers");

            RuleFor(entity => entity.AddressStreet)
                .MaximumLength(255)
                .WithMessage("O AddressStreet não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.AddressNeighborhood)
                .MaximumLength(255)
                .WithMessage("O AddressNeighborhood não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.AddressCity)
              .MaximumLength(255)
              .WithMessage("O AddressCity não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.AddressState)
                .MaximumLength(255)
                .WithMessage("O AddressState não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.AddressCep)
                .MaximumLength(20)
                .WithMessage("O AddressCep não pode ultrapassar {MaxLength} carateres.")
                .Length(8, 20)
               .WithMessage("AddressCep must be between 8 and {MaxLength} characters long");
            // .Matches("^[0-9]*$")
            //.WithMessage("AddressCep can only contain numbers");

            RuleFor(entity => entity.EmergencyContactName)
             .MaximumLength(255)
             .WithMessage("O EmergencyContactName não pode ultrapassar {MaxLength} carateres.");

            RuleFor(entity => entity.EmergencyContactPhoneNumber)
             .MaximumLength(255)
             .WithMessage("O EmergencyContactPhoneNumber não pode ultrapassar {MaxLength} carateres.");

            #endregion

            #region Relationship

            RuleFor(entity => entity.CreatedUser)
              .NotNull() 
              .WithMessage("ErrorValidator_CreatedUser_Null");

            RuleFor(entity => entity.MedicalId)
            .NotNull() 
            .WithMessage("ErrorValidator_MedicalId_Null")
            .MustAsync(async (entity, value, c) => await MedicalIdFound(entity, value)) 
            .WithMessage("ErrorValidator_MedicalId_NotFound")
            .MustAsync(async (entity, value, c) => await MedicalChanged(entity, value))
            .WithMessage("ErrorValidator_Medical_Changed")
            .MustAsync(async (entity, value, c) => await MedicalCreated(entity, value)) 
            .WithMessage("ErrorValidator_MedicalCreated_Invalid")
            .MustAsync(async (entity, value, c) => await MedicalModify(entity, value)) 
            .WithMessage("ErrorValidator_MedicalModify_Invalid");

            #endregion Relationship 
        }
        private async Task<bool> MedicalIdFound(Patient entity, long value)
        {
            var entityFind = await _medicalRepository.FindByID(entity.MedicalId);
            if (entityFind == null)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> UniqueEmail(Patient entity, string value)
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
        private async Task<bool> MedicalChanged(Patient entity, long value)
        {
            if (entity?.Id > 0)
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
            }
            return true;
        }

        private async Task<bool> MedicalCreated(Patient entity, long value)
        {
            if (entity?.Id == 0)
            {
                long idUser = entity.CreatedUserId.GetValueOrDefault();
                var medical = await _medicalRepository.FindByID(value);
                if (medical == null || (medical.UserId != null && medical.UserId != idUser))
                {
                    return false;
                }
            }
            return true;
        }

        private async Task<bool> MedicalModify(Patient entity, long value)
        {
            if (entity?.Id > 0)
            {
                long idUser = entity.ModifyUserId.GetValueOrDefault();

                var medical = await _medicalRepository.FindByID(value);
                if (medical == null || (medical.UserId != null && medical.UserId != idUser))
                {
                    return false;
                }
            }
            return true;
        }

        protected bool BeAValidAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;

            if (dobYear <= currentYear && dobYear > (currentYear - 130))
            {
                return true;
            }
            return false;
        }
    }
}
