using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("MedicalFile", Schema = "dbo")]
    public class MedicalFile : FileBase, IEntityBaseLogUser
    {
        #region Relationship 
         [Required]
         public Medical Medical { get; set; }
        public User? CreatedUser { get; set; }
        public User? ModifyUser { get; set; }
        #endregion Relationship
          
    }
}