namespace Okta.Core.Models
{
    /// <summary>
    /// All supported MFA factors
    /// </summary>
    public static class FactorType
    {
        public const string Question = "question";
        public const string Sms = "sms";
        public const string OtpToken = "token";
        public const string TotpToken = "token:software:totp";
        public const string HardwareToken = "token:hardware";
        public const string Push = "push";
        public const string Web = "web";

    }
}
