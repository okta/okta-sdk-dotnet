using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Okta.Sdk.Internal
{
    public interface IOAuthTokenProvider
    {
        Task<string> GetAccessTokenAsync(bool forceRenew = false);
    }
}
