using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ZigitHub.Api.Models;

namespace ZigitHub.Api.Handlers
{
    public static class ApiResponseHandler
    {
        public static ApiResponse<T> Success<T>(T data)
        {
            return new ApiResponse<T>
            {
                Data = data,
                ErrorMessage = null,
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public static ApiResponse<string> Failure(HttpStatusCode status, string errorMessage = null)
        {
            return new ApiResponse<string>
            {
                StatusCode = (int)status,
                ErrorMessage = errorMessage
            };
        }
    }
}
