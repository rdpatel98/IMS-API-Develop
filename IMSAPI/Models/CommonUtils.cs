using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    public static class CommonUtils
    {
        public const int ApiCallSuccess = 200;
        public const int ApiCallFailed = 400;
        public const string SuccessMessage = "Success";

        public static ApiResponse CreateSuccessApiResponse(object objResult)
        {
            return new ApiResponse(ApiCallSuccess, SuccessMessage, objResult);
        }

        public static ApiResponse CreateFailureApiResponse(string exceptionMessage, object objResult = null)
        {
            return new ApiResponse(ApiCallFailed, exceptionMessage, objResult);
        }
    }
}