using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FileUpload.Contract.Exceptions
{
    public class ApiExceptionMessage
    {
        private static readonly string Pattern = @"^(\[).*(\])";

        [JsonIgnore]
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public string Code { get; set; }

        public object Target { get; set; }

        public List<ApiExceptionMessage> Details { get; set; } = new List<ApiExceptionMessage>();

        public static ApiExceptionMessage FromTemplatedMessage(string templatedMessage, int statusCode)
        {
            ApiExceptionMessage exceptionMessage = new ApiExceptionMessage { StatusCode = statusCode };
            exceptionMessage.ParseFromTemplatedMessage(templatedMessage);
            return exceptionMessage;
        }

        public void ParseFromTemplatedMessage(string templatedMessage)
        {
            if (Regex.IsMatch(templatedMessage, Pattern))
            {
                this.Code = templatedMessage.Substring(1, templatedMessage.IndexOf(']'));
                this.Message = templatedMessage.Substring(templatedMessage.IndexOf(']') + 1);
            }
            else
            {
                this.Message = templatedMessage;
            }
        }
    }
}
