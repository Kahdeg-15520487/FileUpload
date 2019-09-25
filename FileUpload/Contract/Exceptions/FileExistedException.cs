using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FileUpload.Contract.Exceptions
{
    public class FileExistedException : Exception
    {
        public FileExistedException()
        {
        }

        public FileExistedException(string message) : base(message)
        {
        }

        public FileExistedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileExistedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
