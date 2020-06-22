using System;
using System.Collections.Generic;
using System.Text;

namespace Aether.Application.Core.Exceptions
{


    [Serializable]
    public class MediatorMissingRequestImplementationException : Exception
    {
        public MediatorMissingRequestImplementationException() { }
        public MediatorMissingRequestImplementationException(string message) : base(message) { }
        public MediatorMissingRequestImplementationException(string message, Exception inner) : base(message, inner) { }
        protected MediatorMissingRequestImplementationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
