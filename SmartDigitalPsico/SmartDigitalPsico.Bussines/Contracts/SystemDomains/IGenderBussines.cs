using SmartDigitalPsico.Bussines.Contracts.Generic;
using SmartDigitalPsico.Bussines.Generic;
using SmartDigitalPsico.Data.Contract.Generic;
using SmartDigitalPsico.Data.Contract.SystemDomains;
using SmartDigitalPsico.Data.Repository.SystemDomains;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Bussines.Contracts.Principals
{
    public interface IGenderBussines : IGenericBussinesEntityBaseSimple<Gender, EntityDTOBaseSimple> 
    { 

    }
}