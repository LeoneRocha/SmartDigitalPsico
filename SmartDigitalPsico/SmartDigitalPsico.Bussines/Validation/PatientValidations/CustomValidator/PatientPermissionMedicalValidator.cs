using FluentValidation;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Principals;

namespace SmartDigitalPsico.Business.Validation.PatientValidations.CustomValidator
{
    public class PatientPermissionMedicalValidator
    {
        public static ErrorResponse ValidatePermissionMedical(long medicalId, User userAction)
        {
            if (userAction == null)
            {
                var error = new ErrorResponse()
                {
                    Message = "Permissão negada! Deve se informa usuario.",
                    Name = "validatePermissionMedical"
                };
                return error;
            }
            else if (userAction.MedicalId != medicalId && !userAction.Admin)
            {
                var error = new ErrorResponse()
                {
                    Message = "Permissão negada! Medico Informado deve ser o mesmo logado.",
                    Name = "validatePermissionMedical"
                };

                return error;
            }
            return null;
        }

        internal static ErrorResponse ValidatePermissionAdmin(User userAction)
        {
            if (userAction == null)
            {
                var error = new ErrorResponse()
                {
                    Message = "Permissão negada! Deve se informa usuario.",
                    Name = "validatePermissionMedical"
                };
                return error;
            }
            else if (!userAction.Admin)
            {
                var error = new ErrorResponse()
                {
                    Message = "Permissão negada! Apenas administradores podem acessar.",
                    Name = "validatePermissionMedical"
                };

                return error;
            }
            return null;
        }
    }
}
