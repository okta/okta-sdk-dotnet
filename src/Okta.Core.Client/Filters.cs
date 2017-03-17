namespace Okta.Core
{
    /// <summary>
    /// Aliases for properties on each <see cref="Okta.Core.Models.OktaObject"/> type that supports filtering
    /// </summary>
    public static class Filters
    {
        /// <summary>
        /// Attributes for a <see cref="Okta.Core.Models.User"/> that support filtering
        /// </summary>
        public static class User
        {
            public static string Status = "status";
            public static string Email = "profile.email";
            public static string Login = "profile.login";
            public static string FirstName = "profile.firstName";
            public static string LastName = "profile.lastName";
            public static string LastUpdated = "lastUpdated";
        }

        /// <summary>
        /// Attributes for a <see cref="Okta.Core.Models.App"/> that support filtering
        /// </summary>
        public static class App
        {
            public static string Status = "status";
            public static string UserId = "user.id";
            public static string GroupId = "group.id";
        }

        /// <summary>
        /// Attributes for a <see cref="Okta.Core.Models.Event"/> that support filtering
        /// </summary>
        public static class Event
        {
            public static string ActionType = "action.objectType";
            public static string TargetType = "target.objectType";
            public static string TargetId = "target.id";
            public static string Published = "published";
        }
    }
}
