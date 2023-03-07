using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Principals
{

    public abstract class FileBase : EntityBaseSimple
    {
        #region Columns  
        /// <summary>
        /// Name File
        /// </summary>
        [Column("Description", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string? Description { get; set; }

        [Column("FilePath", TypeName = "varchar(2083)")]
        [MaxLength(2083)]
        public string? FilePath { get; set; }

        [Column("FileData")]
        public byte[]? FileData { get; set; }

        [Column("FileExtension", TypeName = "varchar(3)")]
        [MaxLength(3)]
        public string? FileExtension { get; set; }

        [Column("FileContentType", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string? FileContentType { get; set; }

        [Column("FileSizeKB")]
        public long FileSizeKB { get; set; }

        [Column("TypeLocationSaveFile")]
        public ETypeLocationSaveFiles TypeLocationSaveFile { get; set; }


        #endregion Columns 
    }
}