using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk.Configuration
{
    public enum AuthorizationMode
    {
        // Indicates that the SDK will send a SSWS token in the authorozation header when making calls.
        SSWS,

        // Indicates that the SDK will request and send an access token in the authorization header when making calls.
        PrivateKey
    }
}
