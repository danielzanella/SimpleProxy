namespace SimpleProxy
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Attribute used to specify the url fragment that corresponds to the remote method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Method)]
    [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments")]
    public sealed class ResourceAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAttribute"/> class with the specified url fragment.
        /// </summary>
        /// <param name="relative">The url fragment (appended to the server root url) that corresponds to the remote method described by this attribute.</param>
        public ResourceAttribute(string relative)
        {
            this.Relative = relative;

            this.ParameterNames = new string[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAttribute"/> class with the specified url fragment and a list of properties used in the url fragment.
        /// </summary>
        /// <param name="relative">The url fragment (appended to the server root url) that corresponds to the remote method described by this attribute.</param>
        /// <param name="parameterNames">A list of parameter names that provide the values to be replaced in the url fragment.</param>
        /// <remarks>The url fragment should contain placeholders in the same format used by String.Format(), which will be replaced by values from the specified properties, in the same order as they appear in the parameterNames array.</remarks>
        public ResourceAttribute(string relative, params string[] parameterNames)
        {
            this.Relative = relative;

            this.ParameterNames = parameterNames;
        }

        /// <summary>
        /// Gets the url fragment.
        /// </summary>
        public string Relative { get; private set; }

        /// <summary>
        /// Gets the parameter name list.
        /// </summary>
        public IReadOnlyList<string> ParameterNames { get; private set; }
    }
}
