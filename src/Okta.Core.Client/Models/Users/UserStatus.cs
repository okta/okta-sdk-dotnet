namespace Okta.Core.Models
{
    /// <summary>
    /// The possible statuses of a user.
    /// </summary>
    public static class UserStatus
    {
        public const string Active = "ACTIVE";
        public const string Staged = "STAGED";
        public const string Provisioned = "PROVISIONED";
        public const string PasswordExpired = "PASSWORD_EXPIRED";
        public const string LockedOut = "LOCKED_OUT";
        public const string Recovery = "RECOVERY";
        public const string Deprovisioned = "DEPROVISIONED";
        public const string Suspended = "SUSPENDED";
    }
}
