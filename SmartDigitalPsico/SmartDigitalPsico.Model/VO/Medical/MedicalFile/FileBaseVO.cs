using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Model.VO.Medical.MedicalFile
{ 
    public abstract class FileBaseVO  
    { 
        [MaxLength(255)]
        public string? Description { get; set; }
         
        [MaxLength(2083)]
        public string? FilePath { get; set; }
         
        public byte[]? FileData { get; set; }
         
        [MaxLength(3)]
        public string? FileExtension { get; set; }
         
        [MaxLength(100)]
        public string? FileContentType { get; set; }
         
        public long FileSizeKB { get; set; }
    }
}
