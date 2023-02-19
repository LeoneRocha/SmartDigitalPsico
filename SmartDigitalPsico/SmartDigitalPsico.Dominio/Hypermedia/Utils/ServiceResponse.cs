using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;

namespace SmartDigitalPsico.Domains.Hypermedia.Utils
{
    public class ServiceResponse<T>// where T : ISupportsHyperMedia
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;

        // public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
