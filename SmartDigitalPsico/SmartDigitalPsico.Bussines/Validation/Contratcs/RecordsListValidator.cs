using FluentValidation;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Validation.Contratcs
{
    public abstract class RecordsListValidator<T> : AbstractValidator<RecordsList<T>> where T : IEntityBaseLogUser
    {
        protected readonly IUserRepository _userRepository;

        public RecordsListValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(recordsList => recordsList.UserIdLogged)
                .MustAsync(HasPermissionAsync)
                .WithMessage("ErrorValidator_User_Not_Permission"); //"The user is not authorized to retrieve this list of records.");
        }

        protected virtual async Task<bool> HasPermissionAsync(RecordsList<T> recordsList, long userIdLogged, CancellationToken cancellationToken)
        {
            bool userHasPermission = false;
            User userLogged = await _userRepository.FindByID(userIdLogged);

            userHasPermission = recordsList.Records.All(rg => rg.CreatedUser?.Id == userIdLogged);
            //var userLo = await _authorizationService.AuthorizeAsync(loggedInUser, recordsList, "RetrieveRecordsList");

            return userHasPermission;
        }
    }
}
