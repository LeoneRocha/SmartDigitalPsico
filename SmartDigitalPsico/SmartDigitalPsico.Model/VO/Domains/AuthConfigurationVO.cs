using SmartDigitalPsico.Domains.Enuns;

namespace SmartDigitalPsico.Model.VO.Domains
{
    public class AuthConfigurationVO
    { 
        public bool IsEnable { get; set; }
        public ETypeApiCredential TypeApiCredential { get; set; }
    }
}
