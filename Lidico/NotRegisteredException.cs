using System;
using System.Runtime.Serialization;

namespace Lidico
{
    [Serializable]
    internal class NotRegisteredException : ApplicationException
    {
        public NotRegisteredException()
        {
        }

        public NotRegisteredException(string message) : base(message)
        {
        }

        public NotRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}