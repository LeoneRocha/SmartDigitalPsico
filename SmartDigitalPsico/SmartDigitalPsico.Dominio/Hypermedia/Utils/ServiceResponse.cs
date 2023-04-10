namespace SmartDigitalPsico.Domains.Hypermedia.Utils
{
    public class ServiceResponse<T> : IServiceResponse<T>
    {
        public ServiceResponse()
        {
            Errors = new List<ErrorResponse>();
        }
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public List<ErrorResponse> Errors { get; set; } 
    }

    public class ErrorResponse
    {
        public string Name { get; set; }

        public string Message { get; set; }
        public string ErrorCode { get; set; }
    }

    public interface IServiceResponse<T>
    {
        T Data { get; set; }
        bool Success { get; set; }
        string Message { get; set; }
    }

}
