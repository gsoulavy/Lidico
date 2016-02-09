using System;
using System.Runtime.Serialization;

namespace Lidico
{
    public class UnassignableException : ApplicationException
    {
        public UnassignableException()
        {
        }

        public UnassignableException(string message) : base(message)
        {
        }

        public UnassignableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnassignableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}