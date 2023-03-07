using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Principals
{
   
    public class FileData : FileBase 
    {

        public string FolderDestination { get; set; }
        public string FileName { get; set; }
    }
}