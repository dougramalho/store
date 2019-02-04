
using System;

namespace Store.Domain
{
    public class StoreException : Exception
    {
        public string ErrorCode { get; }

        public StoreException() { }

        public StoreException(string errorCode) : this(errorCode, null, null, null) { }

        public StoreException(string message, params object[] args)
            : this(null, null, message, args) { }

        public StoreException(string errorCode, string message, params object[] args)
            : this(errorCode, null, message, args) { }

        public StoreException(Exception innerException, string message, params object[] args)
            : this(string.Empty, innerException, message, args) { }

        public StoreException(string errorCode, Exception innerException, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            ErrorCode = errorCode;
        }


    }
}