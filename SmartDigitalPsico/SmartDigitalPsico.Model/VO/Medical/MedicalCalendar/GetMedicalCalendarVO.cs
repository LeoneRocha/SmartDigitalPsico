using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Patient;
using SmartDigitalPsico.Model.VO.User;

namespace SmartDigitalPsico.Model.VO.Medical
{
    public class GetMedicalCalendarVO : EntityVOBase, ISupportsHyperMedia
    {
        #region Relationship 
        public GetMedicalVO Medical { get; set; }
        public GetPatientVO? Patient { get; set; }
        public GetUserVO? CreatedUser { get; set; }
        public GetUserVO? ModifyUser { get; set; }
        #endregion Relationship

        #region Columns 

        public string Title { get; set; }


        public DateTime StartDate { get; set; }


        public DateTime? EndDate { get; set; }

        public bool AllDay { get; set; }

        public int Status { get; set; }

        public string? ColorCategory { get; set; }

        public string? Url { get; set; }

        public bool PushedCalendar { get; set; }

        public string? TimeZone { get; set; }
        #endregion Columns 

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}