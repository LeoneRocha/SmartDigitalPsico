using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Hypermedia.Filters;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Services.Contracts.SystemDomains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Helper
{
    public class SecurityHelperApi
    {
        public static long GetUserIdApi(ClaimsPrincipal user, Domains.Enuns.ETypeApiCredential typeApiCredential)
        {
            long idUser = 0;

            if (typeApiCredential == Domains.Enuns.ETypeApiCredential.Jwt)
            {
                var userApi = user;
                long.TryParse(user.FindFirstValue(ClaimTypes.NameIdentifier), out idUser);
            }
            return idUser;
        }
    }
}
