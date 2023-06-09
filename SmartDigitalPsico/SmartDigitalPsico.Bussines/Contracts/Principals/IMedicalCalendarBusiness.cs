using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical; 

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IMedicalCalendarBusiness : IGenericBusinessEntityBaseSimple<MedicalCalendar, AddMedicalCalendarVO, UpdateMedicalCalendarVO, GetMedicalCalendarVO>
    { 
    }
}