namespace SimpleProxy
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Runtime.Remoting.Messaging;
    using System.Runtime.Remoting.Proxies;
    using System.Text;
    using System.Web;

    /// <summary>
    /// Simple RealProxy implementation that dispatches method calls as HTTP requests to remote servers.
    /// </summary>
    public sealed class Proxy : RealProxy
    {
        private JsonSerializer m_jsonSerializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Proxy"/> class.
        /// </summary>
        /// <param name="proxyType">The <see cref="Type"/> of the remote object for which to create a proxy.</param>
        /// <param name="configuration">Proxy configuration information.</param>
        internal Proxy(Type proxyType, ProxyConfiguration configuration)
            : base(proxyType)
        {
            this.Configuration = configuration;

            this.Context = new ProxyContext();

            this.m_jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                ContractResolver = new ProxyContractResolver()
            });

            ResourceAttribute resourceUrlAttribute = proxyType.GetCustomAttribute<ResourceAttribute>();

            if (null == this.Configuration.Relative)
            {
                if (null != resourceUrlAttribute)
                {
                    this.Configuration.Relative = resourceUrlAttribute.Relative;

                    if (this.Configuration.Relative.Length != 0 && !this.Configuration.Relative.EndsWith("/", StringComparison.OrdinalIgnoreCase))
                    {
                        this.Configuration.Relative += "/";
                    }
                }
                else
                {
                    var invariantCulture = System.Globalization.CultureInfo.InvariantCulture;

                    this.Configuration.Relative = string.Format(invariantCulture, "api/{0}/", proxyType.Name.ToLower(invariantCulture));
                }
            }

            if (!this.Configuration.Root.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                this.Configuration.Root += "/";
            }
        }

        /// <summary>
        /// Gets the proxy configuration instance.
        /// </summary>
        public ProxyConfiguration Configuration { get; private set; }

        /// <summary>
        /// Gets the remote request and response context.
        /// </summary>
        public ProxyContext Context { get; private set; }

        /// <summary>
        /// Initializes a proxy using the specified configuration.
        /// </summary>
        /// <typeparam name="TRemote">The remote object for which to create a proxy.</typeparam>
        /// <param name="configuration">Proxy configuration information.</param>
        /// <returns>Proxy instance.</returns>
        public static TRemote For<TRemote>(ProxyConfiguration configuration)
        {
            ProxyContext discard;

            return Proxy.For<TRemote>(configuration, out discard);
        }

        /// <summary>
        /// Initializes a proxy using the specified configuration.
        /// </summary>
        /// <typeparam name="TRemote">The remote object for which to create a proxy.</typeparam>
        /// <param name="configuration">Proxy configuration information.</param>
        /// <param name="context">Once it returns, the context parameter will contain a reference to the context used to manipulate the HTTP request headers and inspect the responses.</param>
        /// <returns>Proxy instance.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
        public static TRemote For<TRemote>(ProxyConfiguration configuration, out ProxyContext context)
        {
            // The out parameter ir required due to the returned instance being of type TProxy,
            // and we won't be able to cast it back to Proxy to access the context property.
            Proxy proxyImpl = new Proxy(typeof(TRemote), configuration);

            var result = (TRemote)proxyImpl.GetTransparentProxy();

            context = proxyImpl.Context;

            return result;
        }

        /// <summary>
        /// Invokes the method that is specified in the provided IMessage on the remote object that is represented by the current instance.
        /// </summary>
        /// <param name="msg">A IMessage that contains a IDictionary of information about the method call.</param>
        /// <returns>The message returned by the invoked method, containing the return value and any out or ref parameters.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage methodCall = msg as IMethodCallMessage;
            var invariantCulture = System.Globalization.CultureInfo.InvariantCulture;

            if (null != methodCall)
            {
                try
                {
                    HttpMethod httpMethod = HttpMethod.Get;
                    HttpMethodAttribute httpMethodAttribute = methodCall.MethodBase.GetCustomAttribute<HttpMethodAttribute>(true);

                    if (null != httpMethodAttribute)
                    {
                        httpMethod = httpMethodAttribute.HttpMethod;
                    }

                    ResourceAttribute resourceUrlAttribute = methodCall.MethodBase.GetCustomAttribute<ResourceAttribute>(true);

                    string actionUrl = string.Empty;

                    if (null != resourceUrlAttribute)
                    {
                        actionUrl = resourceUrlAttribute.Relative;
                    }

                    Type expectedReturn = ((MethodInfo)methodCall.MethodBase).ReturnType;

                    object retVal = null;
                    object[] outArgs = null;

                    Dictionary<string, object> toSerialize = new Dictionary<string, object>();
                    Dictionary<string, string> toQueryString = new Dictionary<string, string>();

                    ParameterInfo[] parameters = methodCall.MethodBase.GetParameters();
                    bool hasStreamArg = false;
                    Stream postStream = null;

                    // Determines which arguments should be used in the querystring parameters, and which arguments will be serialized and posted.
                    for (int argIndex = 0, argCount = methodCall.InArgCount; argIndex < argCount; argIndex++)
                    {
                        object value = methodCall.GetInArg(argIndex);

                        ParameterInfo parameterInfo = parameters[argIndex];
                        if (value is Stream)
                        {
                            postStream = (Stream)value;
                            hasStreamArg = true;
                        }

                        bool isFromUri = parameterInfo.GetCustomAttributes(true).Any(a => a.GetType().Name == "FromUriAttribute");
                        Type valueType = null != value ? value.GetType() : null;
                        bool isPrimitive = null != valueType ? valueType.IsPrimitiveOrBasicStruct() : true;

                        if (null == value || isPrimitive || isFromUri)
                        {
                            if (null != value && value is DateTime)
                            {
                                value = SerializeDateTime(invariantCulture, value);

                                toQueryString.Add(methodCall.GetInArgName(argIndex), (value != null) ? value.ToString() : string.Empty);
                            }
                            else
                            {
                                if (null != value && !isPrimitive)
                                {
                                    string prefix = methodCall.GetInArgName(argIndex);

                                    foreach (PropertyInfo property in valueType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty))
                                    {
                                        string propName = string.Format(invariantCulture, "{0}.{1}", prefix, property.Name);
                                        if (!property.PropertyType.IsPrimitiveOrBasicStruct()) 
                                        {
                                            throw new NotSupportedException(string.Format(invariantCulture, "Unable to serializa value for GET query string argument named '{0}'", propName));
                                        }

                                        object propValue = property.GetValue(value);

                                        if (null != propValue && propValue is DateTime)
                                        {
                                            propValue = SerializeDateTime(invariantCulture, propValue);

                                            toQueryString.Add(propName, (propValue != null) ? propValue.ToString() : string.Empty);
                                        }
                                        else
                                        {
                                            toQueryString.Add(propName, (propValue != null) ? HttpUtility.UrlEncode(propValue.ToString()) : string.Empty);
                                        }
                                    }
                                }
                                else
                                {
                                    toQueryString.Add(methodCall.GetInArgName(argIndex), (value != null) ? HttpUtility.UrlEncode(value.ToString()) : string.Empty);
                                }
                            }
                        }
                        else
                        {
                            toSerialize.Add(methodCall.GetInArgName(argIndex), value);
                        }
                    }

                    bool postStreamDirectly = (httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Put) && hasStreamArg && toSerialize.Count == 1;

                    {
                        // Prepare the post content.
                        byte[] postData = null;

                        string responseData = null;

                        if (toSerialize.Count > 0 && !postStreamDirectly)
                        {
                            StringBuilder sb = new StringBuilder();
                            using (TextWriter writer = new StringWriter(sb, invariantCulture))
                            {
                                if (toSerialize.Count == 1)
                                {
                                    this.m_jsonSerializer.Serialize(writer, toSerialize.Values.First());
                                }
                                else
                                {
                                    this.m_jsonSerializer.Serialize(writer, toSerialize);
                                }
                            }

                            postData = Encoding.UTF8.GetBytes(sb.ToString());
                        }

                        if ((postData == null || postData.Length == 0) && httpMethod != HttpMethod.Get && !postStreamDirectly)
                        {
                            postData = Encoding.UTF8.GetBytes("{}");
                        }

                        // Assemble the querystring.
                        object[] urlParameters = null;

                        if (null != resourceUrlAttribute && resourceUrlAttribute.ParameterNames.Count() > 0)
                        {
                            urlParameters = new object[resourceUrlAttribute.ParameterNames.Count()];

                            for (int i = 0, total = resourceUrlAttribute.ParameterNames.Count(); i < total; i++)
                            {
                                string parameterName = resourceUrlAttribute.ParameterNames[i];

                                if (toQueryString.ContainsKey(parameterName))
                                {
                                    urlParameters[i] = toQueryString[parameterName];
                                    toQueryString.Remove(parameterName);
                                }
                                else if (toSerialize.ContainsKey(parameterName))
                                {
                                    urlParameters[i] = toSerialize[parameterName];
                                    toSerialize.Remove(parameterName);
                                }
                            }
                        }

                        var queryString = string.Empty;

                        if (toQueryString.Count > 0)
                        {
                            queryString = "?" + string.Join("&", (from kvp in toQueryString select kvp.Key + "=" + kvp.Value).ToArray());
                        }

                        // Determine the final url
                        if (null != urlParameters)
                        {
                            actionUrl = string.Format(invariantCulture, actionUrl, urlParameters);
                        }

                        string serviceUrl = this.Configuration.Root + this.Configuration.Relative + actionUrl + queryString;

                        // Create the request context
                        RequestContext context = this.Context.CreateRequestContext();

                        context.RequestUrl = new Uri(serviceUrl);

                        // Create and configure the HTTP request
                        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(context.RequestUrl);
                        {
                            webRequest.Method = httpMethod.ToString().ToUpper();
                            webRequest.Timeout = this.Configuration.RequestTimeout ?? (5 * 60 * 1000);

                            string contentTypeHeader = null;

                            if (null != this.Configuration.RequestHeaders) 
                            {
                                foreach (var kvp in this.Configuration.RequestHeaders)
                                {
                                    if (kvp.Key.ToLowerInvariant() == "content-type")
                                    {
                                        contentTypeHeader = kvp.Value;
                                        continue;
                                    }
                                    webRequest.Headers[kvp.Key] = kvp.Value;
                                }
                            }

                            if (postStreamDirectly)
                            {
                                webRequest.ContentType = contentTypeHeader ?? "application/octet-stream";
                                webRequest.ContentLength = postStream.Length;

                                Stream requestStream = webRequest.GetRequestStream();
                                postStream.CopyTo(requestStream);
                            }
                            else if (null != postData && postData.Length > 0)
                            {
                                webRequest.ContentLength = postData.Length;
                                webRequest.ContentType = contentTypeHeader ?? "application/json; charset=UTF-8";

                                Stream postStream2 = webRequest.GetRequestStream();
                                postStream2.Write(postData, 0, postData.Length);
                                postStream2.Close();
                            }
                        }

                        HttpWebResponse response = null;
                        Stream responseStream = null;

                        try
                        {
                            {
                                Stopwatch timer = Stopwatch.StartNew();

                                try
                                {
                                    // Add a HTTP header with a random number to help tracking the request here and on the remote server
                                    int randomNumber = new Random().Next(int.MaxValue);

                                    webRequest.Headers["X-SP-Unique-Identifier"] = randomNumber.ToString(invariantCulture);

                                    // Send the request
                                    response = (HttpWebResponse)webRequest.GetResponse();
                                }
                                catch (WebException ex)
                                {
                                    string errorContent = null;

                                    if (ex.Response != null)
                                    {
                                        context.ResponseStatus = (int)((HttpWebResponse)ex.Response).StatusCode;

                                        if (ex.Response.ContentLength != 0)
                                        {
                                            using (var stream = ex.Response.GetResponseStream())
                                            {
                                                if (null != stream)
                                                {
                                                    using (var reader = new StreamReader(stream))
                                                    {
                                                        errorContent = reader.ReadToEnd();

                                                        context.ResponseSize = errorContent.Length;
                                                    }
                                                }
                                            }

                                            string errorResult = null;

                                            if (null != errorContent)
                                            {
                                                using (StringReader r = new StringReader(errorContent))
                                                {
                                                    errorResult = r.ReadToEnd();
                                                }
                                            }

                                            if (!string.IsNullOrWhiteSpace(errorResult))
                                            {
                                                context.ResponseContent = errorResult;

                                                throw new ProxyException(errorResult, (HttpWebResponse)ex.Response);
                                            }
                                        }
                                    }

                                    throw new ProxyException(string.Format(invariantCulture, "Exception caught while performing a {0} request to url '{1}'. {2}: {3}", httpMethod.ToString(), serviceUrl, ex.GetType().Name, ex.Message), ex);
                                }
                                finally
                                {
                                    var elapsedMilliseconds = timer.ElapsedMilliseconds;

                                    timer.Stop();

                                    context.RequestElapsedMilliseconds = elapsedMilliseconds;
                                    context.RequestElapsedTime = new TimeSpan(0, 0, 0, 0, (int)elapsedMilliseconds);
                                }

                                context.ResponseHeaders.Clear();

                                // Add the response information to the context
                                for (int index = 0, total = response.Headers.Count; index < total; index++)
                                {
                                    context.ResponseHeaders[response.Headers.GetKey(index)] = response.Headers.Get(index);
                                }

                                context.ResponseStatus = (int)response.StatusCode;

                                if ((int)response.StatusCode >= 400)
                                {
                                    throw new ProxyException("Invalid HTTP status code.", response);
                                }

                                // Read the response contents
                                responseStream = response.GetResponseStream();

                                if (expectedReturn == typeof(Stream))
                                {
                                    MemoryStream memoryStream = new MemoryStream();

                                    responseStream.CopyTo(memoryStream);

                                    memoryStream.Seek(0, SeekOrigin.Begin);

                                    retVal = memoryStream;
                                }
                                else
                                {
                                    using (StreamReader responseReader = new StreamReader(responseStream))
                                    {
                                        responseData = responseReader.ReadToEnd();

                                        // note: context.ResponseSize should be in bytes, not string length
                                        // ContentLength should be length reported in the Content-Length header (number of octets)
                                        context.ResponseSize = response.ContentLength;

                                        context.ResponseContent = responseData;

                                        responseReader.Close();
                                    }
                                }
                            }

                            // Attempt to deserialize the response contents
                            if (null == retVal && context.ResponseHeaders.ContainsKey("Content-Type"))
                            {
                                string contentType = (context.ResponseHeaders["Content-Type"] ?? string.Empty).Split(';').FirstOrDefault(h => !h.Trim().StartsWith("charset", StringComparison.OrdinalIgnoreCase));

                                string temp = contentType.Split('/').Last();

                                if (temp.EndsWith("json", StringComparison.OrdinalIgnoreCase) || temp.EndsWith("javascript", StringComparison.OrdinalIgnoreCase))
                                {
                                    using (StringReader r = new StringReader(responseData))
                                    {
                                        using (JsonReader r2 = new JsonTextReader(r))
                                        {
                                            r2.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

                                            if (expectedReturn != typeof(void))
                                            {
                                                retVal = this.m_jsonSerializer.Deserialize(r2, expectedReturn);
                                            }
                                        }
                                    }
                                }
                                else if (expectedReturn != typeof(Stream))
                                {
                                    throw new ProxyException("Unknown response content type: " + contentType, response);
                                }
                            }
                        }
                        finally
                        {
                            if (null != responseStream) responseStream.Close();
                            if (null != response) response.Close();
                        }
                    }

                    int outArgsCount = null != outArgs ? outArgs.Length : 0;

                    IMethodReturnMessage callResult = new ReturnMessage(retVal, outArgs, outArgsCount, methodCall.LogicalCallContext, methodCall);

                    return callResult;
                }
                catch (Exception e)
                {
                    return new ReturnMessage(e, methodCall);
                }
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        private object SerializeDateTime(System.Globalization.CultureInfo invariantCulture, object value)
        {
            value = ((DateTime)value).ToLocalTime();

            StringBuilder sb = new StringBuilder();
            using (TextWriter writer = new StringWriter(sb, invariantCulture))
            {
                this.m_jsonSerializer.Serialize(writer, value);
            }

            value = sb.ToString();
            value = ((string)value).Substring(1, ((string)value).Length - 2);
            return value;
        }
    }
}
