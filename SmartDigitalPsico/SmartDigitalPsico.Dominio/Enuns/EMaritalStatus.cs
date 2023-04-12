using System.ComponentModel;

namespace SmartDigitalPsico.Domains.Enuns
{
    public enum EMaritalStatus
    {
        [Description("Single")]
        Single = 0,

        [Description("Married")]
        Married = 1,

        [Description("Divorced")]
        Divorced = 2,

        [Description("Other")]
        Other = 10,
    }
}
