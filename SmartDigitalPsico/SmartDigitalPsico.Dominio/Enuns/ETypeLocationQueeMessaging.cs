using System.ComponentModel;

namespace SmartDigitalPsico.Domains.Enuns
{
    public enum ETypeLocationQueeMessaging
    {  
        [Description("Local Salvamento em MongoDB")]
        MongoDB = 0,

        [Description("Local Salvamento em Azure Storage Quee")]
        AzureStorageQuee = 1,

        [Description("Local Salvamento em Azure Service Bus")]
        AzureServiceBus =2,  
        
        [Description("Local Salvamento em Azure Event Grid")]
        AzureEventGrid = 3, 
        
        [Description("Local Salvamento em Azure Event Hubs")]
        AzureEventHubs = 4, 
        
        [Description("Local Salvamento em Azure Event Hubs")]
        AzureRelay = 5, 
    }
}
