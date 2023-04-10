using SmartDigitalPsico.Domains.Enuns;

namespace SmartDigitalPsico.Model.VO.Domains
{
    public class CacheConfigurationVO
    {
        //https://codewithmukesh.com/blog/repository-pattern-caching-hangfire-aspnet-core/

        //https://github.com/iammukeshm/RepositoryPatternWithCachingAndHangfire
        public int AbsoluteExpirationInHours { get; set; }
        public int SlidingExpirationInMinutes { get; set; }
        public int AbsoluteExpirationInMinutes { get; set; }

        public string PathCache { get; set; }

        public string ExtensionCache { get; set; }
        public bool IsEnable { get; set; }
        public ETypeLocationCache TypeCache { get; set; }
    }
}
