namespace SmartDigitalPsico.Domains.Security
{
    public interface ITokenConfiguration
    {
        string Audience { get; set; }
        string Issuer { get; set; }
        string Secret { get; set; }
        int Minutes { get; set; }
        int DaysToExpiry { get; set; }
    }
    public class TokenConfiguration : ITokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int Minutes { get; set; }
        public int DaysToExpiry { get; set; }
    }
}
