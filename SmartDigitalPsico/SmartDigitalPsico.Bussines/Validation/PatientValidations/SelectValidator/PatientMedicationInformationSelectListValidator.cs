using FluentValidation;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Validation.Contratcs
{
    public class PatientMedicationInformationSelectListValidator : RecordsListValidator<PatientMedicationInformation>
    {

        public PatientMedicationInformationSelectListValidator(IUserRepository userRepository)
            : base(userRepository)
        {
            RuleFor(recordsList => recordsList.UserIdLogged)
                .MustAsync(base.HasPermissionAsync)
                .WithMessage("ErrorValidator_User_Not_Permission"); //"The user is not authorized to retrieve this list of records.");
        }
    }
}
