using FluentValidation;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Validation.Contratcs
{
    public class PatientSelectListValidator : RecordsListValidator<Patient>
    {

        public PatientSelectListValidator(IUserRepository userRepository)
            : base(userRepository)
        {
            RuleFor(recordsList => recordsList.UserIdLogged)
                .MustAsync(HasPermissionAsync)
                .WithMessage("ErrorValidator_User_Not_Permission"); //"The user is not authorized to retrieve this list of records.");
        }

        protected override Task<bool> HasPermissionAsync(RecordsList<Patient> recordsList, long userIdLogged, CancellationToken cancellationToken)
        {
            return base.HasPermissionAsync(recordsList, userIdLogged, cancellationToken);
        }
    }
}
