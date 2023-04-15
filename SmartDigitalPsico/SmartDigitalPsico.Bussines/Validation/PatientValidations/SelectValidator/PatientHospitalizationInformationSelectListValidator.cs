using FluentValidation;
using FluentValidation.Results;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Validation.Contratcs
{
    public class PatientHospitalizationInformationSelectListValidator : RecordsListValidator<PatientHospitalizationInformation>
    {

        public PatientHospitalizationInformationSelectListValidator(IUserRepository userRepository)
            : base(userRepository)
        {
            RuleFor(recordsList => recordsList.UserIdLogged)
                .MustAsync(base.HasPermissionAsync)
                .WithMessage("ErrorValidator_User_Not_Permission"); //"The user is not authorized to retrieve this list of records.");
        }
    }
}
