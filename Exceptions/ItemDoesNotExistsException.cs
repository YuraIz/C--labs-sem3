using System;
using System.Runtime.Serialization;


namespace _053505_Izmer_lab6.Exceptions
{
    public class ItemDoesNotExistsException : Exception
    {
        public ItemDoesNotExistsException() { }
        public ItemDoesNotExistsException(string message) : base(message) { }
        public ItemDoesNotExistsException(string message, System.Exception inner) : base(message, inner) { }
        protected ItemDoesNotExistsException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}