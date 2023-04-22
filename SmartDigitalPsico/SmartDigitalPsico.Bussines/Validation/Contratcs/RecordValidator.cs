using FluentValidation;
using FluentValidation.Results;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Validation.Contratcs
{
    public abstract class RecordValidator<T> : AbstractValidator<Record<T>> where T : IEntityBaseLogUser
    {
        protected readonly IUserRepository _userRepository;

        public RecordValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(enitty => enitty.UserIdLogged)
                .MustAsync(HasPermissionAsync)
                .WithMessage("ErrorValidator_User_Not_Permission"); //"The user is not authorized to retrieve this list of records.");
        }

        protected virtual async Task<bool> HasPermissionAsync(Record<T> enittyRecord, long userIdLogged, CancellationToken cancellationToken)
        {
            bool userHasPermission = false;
            User userLogged = await _userRepository.FindByID(userIdLogged);

            userHasPermission = enittyRecord.RecordEntity.CreatedUser?.Id == userIdLogged || userLogged.Admin;
            //var userLo = await _authorizationService.AuthorizeAsync(loggedInUser, recordsList, "RetrieveRecordsList");

            return userHasPermission;
        }
        public List<ErrorResponse> GetMapErros(List<ValidationFailure> errors)
        {
            return errors.Select(er => new ErrorResponse() { ErrorCode = er.ErrorCode, Message = er.ErrorMessage, Name = er.PropertyName }).ToList();
        }
    }
}
