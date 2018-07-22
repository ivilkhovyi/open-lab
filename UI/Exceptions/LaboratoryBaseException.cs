using System;
using System.Runtime.Serialization;

namespace UI.Exceptions
{
    public class LaboratoryBaseException : Exception
    {
        public LaboratoryBaseException()
        {
        }

        public LaboratoryBaseException(string message) : base(message)
        {
        }

        public LaboratoryBaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LaboratoryBaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
