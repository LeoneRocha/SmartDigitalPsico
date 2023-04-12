//using SmartDigitalPsico.Model.Contracts;
//using SmartDigitalPsico.Model.Contracts.Interface;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace SmartDigitalPsico.Model.Entity.Principals
//{
//    [Table("PatientRecordInfoTag", Schema = "dbo")]
//    public class PatientRecordInfoTag
//    {
//        #region Relationship 
//        public InfoTag InfoTag { get; set; }

//        [ForeignKey("InfoTagId")]
//        public long InfoTagId { get; set; }

//        public PatientRecord PatientRecord { get; set; }

//        [ForeignKey("PatientRecordId")]
//        public long PatientRecordId { get; set; }

//        #endregion Relationship 
//    }
//}