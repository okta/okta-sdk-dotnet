using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okta.Core.Models
{
    /// <summary>
    /// All possible statuses during authentication.
    /// </summary>
    public static class AuthStatus
    {
        public const string Success = "SUCCESS";
        public const string MfaEnroll = "MFA_ENROLL";
        public const string MfaEnrollActivate = "MFA_ENROLL_ACTIVATE";
        public const string MfaRequired = "MFA_REQUIRED";
        public const string MfaChallenge = "MFA_CHALLENGE";
        public const string PasswordExpired = "PASSWORD_EXPIRED";
        public const string Recovery = "RECOVERY";
        public const string LockedOut = "LOCKED_OUT";
        public const string PasswordReset = "PASSWORD_RESET";
    }
}
