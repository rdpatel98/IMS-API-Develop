using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        public ApiResponse(int statusCode, string message = null, object objResult = null)
        {
            StatusCode = statusCode;
            Message = message;
            Result = objResult;
        }
    }
}