using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("PatientRecords", Schema = "dbo")]
    public class PatientRecord : EntityBaseSimple
    {
        #region Relationship 
        public Patient Patient { get; set; }

        #endregion Relationship
         
        #region Columns 

        [Column("Description", TypeName = "varchar(255)")]
        public string Description { get; set; }

        [Column("Annotation", TypeName = "varchar(max)")]
        public string Annotation { get; set; }
         
        [Column("AnnotationDate")]
        public DateTime AnnotationDate { get; set; }
           
        #endregion Columns 
    }
}