using System.Threading.Tasks;

namespace Okta.Sdk.Internal
{
    public class NullOAuthTokenProvider : IOAuthTokenProvider
    {
        private static NullOAuthTokenProvider _instance = null;

        private NullOAuthTokenProvider()
        {}

        public static NullOAuthTokenProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NullOAuthTokenProvider();
                }

                return _instance;
            }
        }

        public Task<string> GetAccessTokenAsync(bool forceRenew = false)
        {
            return new Task<string>(null);
        }
    }
}
