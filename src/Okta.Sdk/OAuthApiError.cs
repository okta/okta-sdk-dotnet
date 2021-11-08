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
