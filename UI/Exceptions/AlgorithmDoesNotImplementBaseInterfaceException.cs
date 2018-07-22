using System;
using System.Runtime.Serialization;

namespace UI.Exceptions
{
    public class AlgorithmDoesNotImplementBaseInterfaceException : LaboratoryBaseException
    {
        public AlgorithmDoesNotImplementBaseInterfaceException()
        {
        }

        public AlgorithmDoesNotImplementBaseInterfaceException(string message) : base(message)
        {
        }

        public AlgorithmDoesNotImplementBaseInterfaceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlgorithmDoesNotImplementBaseInterfaceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
