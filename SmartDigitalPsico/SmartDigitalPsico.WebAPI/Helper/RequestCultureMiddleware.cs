using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SmartDigitalPsico.Business.CacheManager;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Principals;
using SmartDigitalPsico.Business.SystemDomains;
using SmartDigitalPsico.Business.Validation.PatientValidations;
using SmartDigitalPsico.Business.Validation.Principals;
using SmartDigitalPsico.Business.Validation.SystemDomains;
using SmartDigitalPsico.Domains.Security;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.CacheManager;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.FileManager;
using SmartDigitalPsico.Repository.Principals;
using SmartDigitalPsico.Repository.SystemDomains;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Contracts.SystemDomains;
using SmartDigitalPsico.Services.Principals;
using SmartDigitalPsico.Services.SystemDomains;
using System.Globalization;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Helper
{
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestedCulture = context.Request.Headers["X-Culture"].ToString();
            if (!string.IsNullOrWhiteSpace(requestedCulture))
            {
                var cultureInfo = new CultureInfo(requestedCulture);
                CultureInfo.CurrentCulture = cultureInfo;
                CultureInfo.CurrentUICulture = cultureInfo;
            } 
            await _next.Invoke(context);
        }
    } 
}
