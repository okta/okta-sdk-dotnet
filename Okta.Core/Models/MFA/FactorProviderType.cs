using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okta.Core.Models
{
    /// <summary>
    /// All supported MFA providers.
    /// </summary>
    public static class FactorProviderType
    {
        public const string Okta = "OKTA";
        public const string Rsa = "SMS";
        public const string Symantec = "SYMANTEC";
        public const string Google = "GOOGLE";
    }
}
