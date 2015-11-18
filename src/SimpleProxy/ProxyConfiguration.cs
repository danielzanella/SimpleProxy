namespace SimpleProxy
{
    using System.Collections.Generic;

    /// <summary>
    /// Remote server and request configuration for a proxy.
    /// </summary>
    public class ProxyConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyConfiguration"/> class.
        /// </summary>
        public ProxyConfiguration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyConfiguration"/> class.
        /// </summary>
        /// <param name="root">Url fragment representing the server root.</param>
        public ProxyConfiguration(string root) : this(root, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyConfiguration"/> class.
        /// </summary>
        /// <param name="requestHeaders">Dictionary containing the HTTP request headers to be sent with each request.</param>
        public ProxyConfiguration(Dictionary<string, string> requestHeaders) : this(null, requestHeaders)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyConfiguration"/> class.
        /// </summary>
        /// <param name="root">Partial url representing the server root.</param>
        /// <param name="requestHeaders">Dictionary containing the HTTP request headers to be sent in all requests.</param>
        public ProxyConfiguration(string root, Dictionary<string, string> requestHeaders)
        {
            this.Root = root;
            this.RequestHeaders = requestHeaders;
        }

        /// <summary>
        /// Gets or sets a dictionary containing the HTTP request headers to be sent with each request.
        /// </summary>
        public Dictionary<string, string> RequestHeaders { get; set; }

        /// <summary>
        /// Gets or sets the url fragment used as the remote server root url.
        /// </summary>
        public string Root { get; set; }

        /// <summary>
        /// Gets or sets an url fragment appended to the remote server root url.
        /// </summary>
        public string Relative { get; set; }

        /// <summary>
        /// Gets or sets the request timeout.
        /// </summary>
        public int? RequestTimeout { get; set; }
    }
}
