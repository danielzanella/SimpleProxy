namespace SimpleProxy
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Context containing request and response information for a proxy.
    /// </summary>
    public sealed class ProxyContext
    {
        private List<RequestContext> m_requests = new List<RequestContext>();

        /// <summary>
        /// Gets the list of remote requests.
        /// </summary>
        public IReadOnlyList<RequestContext> Requests 
        { 
            get 
            { 
                return m_requests.AsReadOnly(); 
            } 
        }

        /// <summary>
        /// Creates a remote request context.
        /// </summary>
        /// <returns>The remote request context.</returns>
        internal RequestContext CreateRequestContext()
        {
            // avoid holding large response contents for longer than a minute.
            DateTime minuteAgo = DateTime.UtcNow.AddMinutes(-1);

            m_requests.Where(r => null != r.ResponseContent && r.RequestTimestamp < minuteAgo).Select(r => r.ResponseContent = null);

            var newRequestContext = new RequestContext();

            m_requests.Add(newRequestContext);

            return newRequestContext;
        }
    }
}
