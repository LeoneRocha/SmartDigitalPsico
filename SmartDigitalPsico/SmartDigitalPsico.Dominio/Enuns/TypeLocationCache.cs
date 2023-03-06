using System.ComponentModel;

namespace SmartDigitalPsico.Domains.Enuns
{
    public enum ETypeLocationCache
    { 
        [Description("Local Salvamento em Disco HD/SSD")]
        Disk = 0,

        [Description("Local Salvamento em Memory")]
        Memory = 1,

        [Description("Local Salvamento em MongoDB")]
        MongoDB = 2,

        [Description("Local Salvamento em Azure Storage")]
        AzureStorage = 3,

        [Description("Local Salvamento em Azure Cosmo DB")]
        AzureCosmoDB = 4,

        [Description("Local Salvamento em Azure Redis")]
        AzureRedis = 5,
    }
}
