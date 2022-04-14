using System.Net;
using WorkerShiftApp.Models.DTOs;

namespace WorkerShiftApp.Helper
{
    public class StandardResponse
    {

        public static ResponseModel Ok(string message, dynamic data = null)
        {
            return new ResponseModel
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = message,
                Data = data
            };
        }

        public static ResponseModel BadRequest(string message, dynamic data = null)
        {
            return new ResponseModel
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                Message = message,
                Data = data
            };
        }

        public static ResponseModel InternalServerError(string message, dynamic data = null)
        {
            return new ResponseModel
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.InternalServerError,
                Message = message,
                Data = data
            };
        }

        public static ResponseModel NotFound(string message, dynamic data = null)
        {
            return new ResponseModel
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                Message = message,
                Data = data
            };
        }
    }
}
