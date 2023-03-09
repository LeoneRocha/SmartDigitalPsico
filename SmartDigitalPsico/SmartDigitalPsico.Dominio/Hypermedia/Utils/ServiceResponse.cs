using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;

namespace SmartDigitalPsico.Domains.Hypermedia.Utils
{
    public class ServiceResponse<T> : IServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
    }

    public interface IServiceResponse<T>
    {
        T Data { get; set; }
        bool Success { get; set; }
        string Message { get; set; }
    }

}
