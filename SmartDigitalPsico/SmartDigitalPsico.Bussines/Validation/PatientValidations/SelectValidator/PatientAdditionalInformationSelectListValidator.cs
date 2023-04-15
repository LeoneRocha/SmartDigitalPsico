using FluentValidation;
using FluentValidation.Results;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Validation.Contratcs
{
    public class PatientAdditionalInformationSelectListValidator : RecordsListValidator<PatientAdditionalInformation>
    {

        public PatientAdditionalInformationSelectListValidator(IUserRepository userRepository)
            : base(userRepository)
        {
            RuleFor(recordsList => recordsList.UserIdLogged)
                .MustAsync(this.HasPermissionAsync)
                .WithMessage("ErrorValidator_User_Not_Permission"); //"The user is not authorized to retrieve this list of records.");
        }
        protected override async Task<bool> HasPermissionAsync(RecordsList<PatientAdditionalInformation> recordsList, long userIdLogged, CancellationToken cancellationToken)
        {
            bool userHasPermission = false;
            User userLogged = await base._userRepository.FindByID(userIdLogged);
            if (recordsList.Records.Count == 0 || userLogged == null) { return false; }

            userHasPermission = recordsList.Records.All(rg =>
            rg.CreatedUser?.Id == userIdLogged
            //&& rg.Patient.Medical.UserId == userIdLogged
            );
            //var userLo = await _authorizationService.AuthorizeAsync(loggedInUser, recordsList, "RetrieveRecordsList");

            return userHasPermission;
        }


    }
}
