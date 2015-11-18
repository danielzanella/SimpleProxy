namespace SimpleProxy
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;

    /// <summary>
    /// Represents an error raised during a remote request attempt.
    /// </summary>
    [Serializable]
    [SuppressMessage("Microsoft.Usage", "CA2240:ImplementISerializableCorrectly")]
    public class ProxyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyException"/> class.
        /// </summary>
        public ProxyException() 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyException"/> class with response information.
        /// </summary>
        /// <param name="response">Remote server response.</param>
        public ProxyException(HttpWebResponse response) : this() 
        { 
            this.Response = response;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ProxyException(string message)
            : base(message) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyException"/> class with a specified error message and response information.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="response">Remote server response.</param>
        public ProxyException(string message, HttpWebResponse response)
            : base(message) 
        {
            this.Response = response;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception..
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ProxyException(string message, Exception inner) : base(message, inner) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected ProxyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Gets the response information, if any.
        /// </summary>
        public HttpWebResponse Response { get; private set; }
    }
}
