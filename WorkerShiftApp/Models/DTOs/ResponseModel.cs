using System.Net;

namespace WorkerShiftApp.Models.DTOs
{
    public class ResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public object Data { get; set; }
        public string Message { get; set; } = "";
    }
}
