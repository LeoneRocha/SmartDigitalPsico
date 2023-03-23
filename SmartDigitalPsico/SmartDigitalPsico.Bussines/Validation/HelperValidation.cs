using Azure;
using FluentValidation.Results;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Business.Validation
{
    public class HelperValidation
    {
        internal static List<ErrorResponse> GetErrosMap(FluentValidation.Results.ValidationResult validationResult)
        {
            List<ErrorResponse> errorsResult = new List<ErrorResponse>();
            if (!validationResult.IsValid)
            {
                StringBuilder sb = new StringBuilder();
                //foreach (var failure in validationResult.Errors)
                //{
                //    //sb.Append("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                //}
                //response.Message = sb.ToString();
                validationResult.Errors.ForEach(erroItem =>
                {
                    errorsResult.Add(new ErrorResponse()
                    {
                        Message = erroItem.ErrorMessage,
                        Name = erroItem.PropertyName
                    });
                });
            }
            return errorsResult;
        }

        internal static string GetMessage(FluentValidation.Results.ValidationResult validationResult, bool isValid)
        {
            return isValid ? "Valido" : "Ocorram erros.";
        }
    }
}
