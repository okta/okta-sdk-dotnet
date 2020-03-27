using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public class OAuthApiError : Resource, IOAuthApiError
    {
        /// <inheritdoc/>
        public string Error => GetStringProperty("error");

        /// <inheritdoc/>
        public string ErrorDescription => GetStringProperty("error_description");
    }
}
