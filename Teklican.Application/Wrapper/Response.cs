using Microsoft.AspNetCore.Http;

namespace Teklican.Application.Wrapper
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string message)
        {
            Succeeded = true;
            Message = message;
            Data = data;
            StatusCode = StatusCodes.Status200OK;
        }
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; } = null!;
        public List<string> Errors { get; set; } = null!;
        public T Data { get; set; } = default!;
        public int StatusCode { get; set; }
    }
}
