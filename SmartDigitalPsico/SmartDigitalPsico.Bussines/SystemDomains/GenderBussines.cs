using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Data.Context;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using System.Security.Claims;
using SmartDigitalPsico.Model.Entity.Principals;
using System.Text;
using System.Collections.Generic;
using SmartDigitalPsico.Data.Contract.Principals;
using SmartDigitalPsico.Bussines.Contracts.Principals;
using SmartDigitalPsico.Data.Contract.SystemDomains;
using SmartDigitalPsico.Data.Repository;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Bussines.Generic;
using SmartDigitalPsico.Data.Repository.SystemDomains;

namespace SmartDigitalPsico.Bussines.Principals
{
    public class GenderBussines : GenericBussinesEntityBaseSimple<Gender, IGenderRepository, EntityDTOBaseSimple>, IGenderBussines

    {
        public GenderBussines(IMapper _mapper, IGenderRepository _genderRepository)
            : base(_mapper, _genderRepository) { }
    }
}