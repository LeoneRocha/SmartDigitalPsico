using FluentValidation;
using FluentValidation.Results;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
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
            User userLogged = await this._userRepository.FindByID(userIdLogged);
            if (recordsList.Records.Count == 0 || userLogged == null) { return false; }

            userHasPermission = recordsList.Records.All(rg =>
            rg.CreatedUser?.Id == userIdLogged
            //&& rg.Patient.Medical.UserId == userIdLogged
            );
            //var userLo = await _authorizationService.AuthorizeAsync(loggedInUser, recordsList, "RetrieveRecordsList");

            return userHasPermission;
        }
        public List<ErrorResponse> GetMapErros(List<ValidationFailure> errors)
        {
            return errors.DistinctBy(d=> d.PropertyName).Select(er => new ErrorResponse() { ErrorCode = er.ErrorCode, Message = er.ErrorMessage, Name = er.PropertyName }).ToList();
        }
    }
}
