using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    /// <summary>
    /// Represents an error returned by the Okta OAuth API.
    /// </summary>
    public interface IOAuthApiError : IResource
    {
        /// <summary>
        /// Gets the <c>error</c> property.
        /// </summary>
        /// <value>The error.</value>
        string Error { get; }

        /// <summary>
        /// Gets the <c>error_description</c> property.
        /// </summary>
        /// <value>The error description.</value>
        string ErrorDescription { get; }
    }
}
