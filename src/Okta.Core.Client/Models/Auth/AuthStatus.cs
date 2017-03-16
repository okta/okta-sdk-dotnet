namespace Okta.Core.Models
{
    /// <summary>
    /// The status of an authentication or recovery transaction.
    /// </summary>
    /// <remarks>
    /// Full documentation available at: http://developer.okta.com/docs/api/rest/authn.html#authentication-status
    /// </remarks>
    public static class AuthStatus
    {

        /// <summary>The user’s password was successfully validated but is about to expire. Only returned if WarnBeforePasswordExpiration is set to true when calling AuthClient.Authenticate()</summary>
        public const string PasswordWarn = "PASSWORD_WARN";

        // (Sorted according to the "Authentication Status" table in the URL above.)
        /// <summary>The user’s password was successfully validated but is expired.</summary>
        public const string PasswordExpired = "PASSWORD_EXPIRED";

        /// <summary>The user has requested a recovery token to reset their password or unlock their account.</summary>
        public const string Recovery = "RECOVERY";

        /// <summary>The user successfully answered their recovery question and must to set a new password.</summary>
        public const string PasswordReset = "PASSWORD_RESET";

        /// <summary>The user account is locked; self-service unlock or admin unlock is required.</summary>
        public const string LockedOut = "LOCKED_OUT";

        /// <summary>The user must select and enroll an available factor for additional verification.</summary>
        public const string MfaEnroll = "MFA_ENROLL";

        /// <summary>The user must activate the factor to complete enrollment.</summary>
        public const string MfaEnrollActivate = "MFA_ENROLL_ACTIVATE";

        /// <summary>The user must provide additional verification with a previously enrolled factor.</summary>
        public const string MfaRequired = "MFA_REQUIRED";

        /// <summary>The user must verify the factor-specific challenge.</summary>
        public const string MfaChallenge = "MFA_CHALLENGE";

        /// <summary>The transaction has completed successfully.</summary>
        public const string Success = "SUCCESS";
    }
}
