namespace SimpleProxy
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Context containing request information.
    /// </summary>
    public sealed class RequestContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext"/> class.
        /// </summary>
        public RequestContext()
        {
            this.ResponseHeaders = new Dictionary<string, string>();
            this.RequestTimestamp = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets the response headers.
        /// </summary>
        public Dictionary<string, string> ResponseHeaders { get; private set; }
        
        /// <summary>
        /// Gets the request url.
        /// </summary>
        public Uri RequestUrl { get; internal set; }

        /// <summary>
        /// Gets the HTTP response status code.
        /// </summary>
        public int ResponseStatus { get; internal set; }

        /// <summary>
        /// Gets the HTTP response size, in bytes.
        /// </summary>
        public long ResponseSize { get; internal set; }

        /// <summary>
        /// Gets the amount of time it took to send the request and receive a response from the server.
        /// </summary>
        public TimeSpan RequestElapsedTime { get; internal set; }

        /// <summary>
        /// Gets the amount of time it took to send the request and receive a response from the server, in milliseconds.
        /// </summary>
        public long RequestElapsedMilliseconds { get; internal set; }

        /// <summary>
        /// Gets or sets the response contents.
        /// </summary>
        public string ResponseContent { get; set; }

        /// <summary>
        /// Gets the time when the request was created.
        /// </summary>
        /// <remarks>Date and time in UTC.</remarks>
        public DateTime RequestTimestamp { get; private set; }
    }
}
