using System.ComponentModel;

namespace SmartDigitalPsico.Domains.Enuns
{
    public enum ETypeLocationSaveFiles
    {
        [Description("Local Salvamento em Banco de dados")]
        DataBase = 0,
        
        [Description("Local Salvamento em Disco HD/SSD")]
        Disk = 1,

        [Description("Local Salvamento em Cloud Storage Azure")]
        CloudStorageAzure = 2,

        [Description("Local Salvamento em Cloud Storage AWS")]
        CloudStorageAWS = 3, 
    }
}
