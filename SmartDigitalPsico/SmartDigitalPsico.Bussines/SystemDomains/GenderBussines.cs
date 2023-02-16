using AutoMapper;
using SmartDigitalPsico.Bussines.Contracts.Principals;
using SmartDigitalPsico.Bussines.Generic;
using SmartDigitalPsico.Data.Contract.SystemDomains;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Bussines.Principals
{
    public class GenderBussines : GenericBussinesEntityBaseSimple<Gender, IGenderRepository, EntityDTOBaseSimple>, IGenderBussines

    {
        public GenderBussines(IMapper _mapper, IGenderRepository _genderRepository)
            : base(_mapper, _genderRepository) { }
    }
}