namespace SimpleProxy
{
    using System;

    /// <summary>
    /// Specifies which HTTP method will be used in the request for a specific method call.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class HttpMethodAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpMethodAttribute"/> class.
        /// </summary>
        /// <param name="httpMethod">The HTTP method.</param>
        public HttpMethodAttribute(HttpMethod httpMethod)
        {
            this.HttpMethod = httpMethod;
        }

        /// <summary>
        /// Gets the HTTP method.
        /// </summary>
        public HttpMethod HttpMethod { get; private set; }
    }
}
