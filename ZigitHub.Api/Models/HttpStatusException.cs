using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ZigitHub.Api.Models
{
    public class HttpStatusException : Exception
    {
        public HttpStatusException() : base()
        {
        }

        public HttpStatusException(string message) : base(message)
        {
        }

        public HttpStatusException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public HttpStatusException(HttpStatusCode statusCode)
            : base(string.Empty)
        {
            ErrorMessage = string.Empty;
            StatusCode = statusCode;
        }

        public HttpStatusException(string errorMessage, HttpStatusCode statusCode)
            : base(errorMessage)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }

        public HttpStatusException(string errorMessage, HttpStatusCode statusCode, Exception innerException)
            : base(errorMessage, innerException)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }

        public HttpStatusException(Exception innerException, HttpStatusCode statusCode)
            : base(string.Empty, innerException)
        {
            StatusCode = statusCode;
        }

        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
