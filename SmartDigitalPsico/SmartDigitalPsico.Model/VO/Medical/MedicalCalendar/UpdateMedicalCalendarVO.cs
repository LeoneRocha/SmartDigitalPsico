using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Medical
{
    public class UpdateMedicalCalendarVO : EntityVOBase 
    {
        #region Relationship 

        #endregion Relationship

        #region Columns 

        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool AllDay { get; set; }
        public string? ColorCategory { get; set; }
        public string? Url { get; set; }
        public bool PushedCalendar { get; set; }
        public string? TimeZone { get; set; }
        #endregion Columns 
    }
}