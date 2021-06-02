using System.Collections.Generic;

namespace FlightManagement.Application.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set;  }
        public string Message { get; set; }
        public IList<string> ValidationErrors { get; set; } = new List<string>();

        public BaseResponse()
        {
            Success = true;
        }

        public BaseResponse(string message = null)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }
    }
}