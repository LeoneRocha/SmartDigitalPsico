using System.ComponentModel;

namespace SmartDigitalPsico.Domains.Enuns
{
    public enum EStatusCalendar
    { 
        [Description("Ativo")]
        Active = 0,

        [Description("Cancelado")]
        Canceled = 1, 
    }
}
