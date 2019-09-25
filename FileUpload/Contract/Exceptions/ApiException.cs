using System;
using System.Net;

namespace FileUpload.Contract.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(ApiExceptionMessage exceptionMessage)
        {
            this.ExceptionMessage = exceptionMessage;
        }

        public ApiException(string message)
        {
            this.ExceptionMessage = new ApiExceptionMessage { Message = message };
        }

        public ApiException(HttpStatusCode statusCode)
        {
            this.ExceptionMessage = new ApiExceptionMessage { Message = statusCode.ToString(), StatusCode = (int)statusCode };
        }

        public ApiException(string message, int statusCode)
        {
            this.ExceptionMessage = new ApiExceptionMessage { Message = message, StatusCode = statusCode };
        }

        public ApiException(string message, HttpStatusCode statusCode)
        {
            this.ExceptionMessage = new ApiExceptionMessage { Message = message, StatusCode = (int)statusCode };
        }

        public ApiExceptionMessage ExceptionMessage { get; set; }
    }
}
