namespace SmartDigitalPsico.Model.Entity.Domains.Configurations
{
    public class CacheConfiguration
    {
        //https://codewithmukesh.com/blog/repository-pattern-caching-hangfire-aspnet-core/

        //https://github.com/iammukeshm/RepositoryPatternWithCachingAndHangfire
        public int AbsoluteExpirationInHours { get; set; }
        public int SlidingExpirationInMinutes { get; set; }

        public String PathCache { get; set; }

        public String ExtensionCache { get; set; }
    }
}
