using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Okta.Core
{
    internal class Constants
    {
        // TODO: Convert these to static readonly if this class is going to be public - http://stackoverflow.com/a/756010/1978203

        public const string BaseUriFormat = "https://{0}.okta.com";
        public const int DefaultPageSize = 200;
        public const int MaxPageSize = 1000;
        public const int MaxThrottlingRetryMillis = 300 * 1000;
        public static TimeSpan DefaultTimeout = new TimeSpan(0, 0, 0, 30, 0);

        private static string _userAgent = "OktaSDK.NETv" + Utils.GetAssemblyVersion();
        public static string UserAgent { get { return _userAgent; } }

        // Relative endpoints
        public const string EndpointV1 = "/api/v1";
        
        // Main endpoints
        public const string UsersEndpoint = "/users";
        public const string GroupsEndpoint = "/groups";
        public const string SessionsEndpoint = "/sessions";
        public const string AppsEndpoint = "/apps";
        public const string EventsEndpoint = "/events";
        public const string FactorsEndpoint = "/factors";
        public const string AuthnEndpoint = "/authn";
        public const string OrgEndpoint = "/org";
        public const string UserSchemasEndpoint = "/meta/schemas/user/default";

        // Sub endpoints
        public const string CatalogEndpoint = "/catalog";
        public const string QuestionsEndpoint = "/questions";
        public const string VerifyEndpoint = "/verify";
        public const string AppLinksEndpoint = "/appLinks";
        public const string RecoveryEndpoint = "/recovery";
        public const string SkipEndpoint = "/skip";
        public const string TokenEndpoint = "/token";
        public const string UnlockEndpoint = "/unlock";
        public const string SmsEndpoint = "/sms";
        public const string AnswerEndpoint = "/answer";
        public const string PasswordEndpoint = "/password";
        public const string PreviousEndpoint = "/previous";
        public const string CancelEndpoint = "/cancel";

        // Mfa types
        public static class MfaTypes
        {
            public const string SecurityQuestion = "okta_question";
            public const string SMS = "okta_sms";
            public const string OktaVerify = "okta_otp";
            public const string OktaVerifyPush = "okta_push";
            public const string GoogleAuth = "google_otp";
            public const string SymantecVIP = "symantec_vip";
            public const string RSA = "rsa_token";
            public const string Duo = "duo";
            public const string Yubikey = "yubikey_token";
            public const string VoiceCall = "voicecall";
        }

        // Lifecycle aliases
        public const string LifecycleActivate = "activate";
        public const string LifecycleDeactivate = "deactivate";
        public const string LifecycleResetPassword = "resetPassword";
        public const string LifecycleExpirePassword = "expirePassword";
        public const string LifecycleResetFactors = "resetFactors";
        public const string LifecycleUnlock = "unlock";
        public const string LifecycleSuspend = "suspend";
        public const string LifecycleUnsuspend = "unsuspend";
        public const string LifecycleForgotPassword = "forgotPassword";
        public const string LifecycleChangePassword = "changePassword";
        public const string LifecycleChangeRecoveryQuestion = "changeRecoveryQuestion";

        // Lifecycle endpoints
        public const string LifecycleEndpoint = "/lifecycle";
        public const string LifecycleActivateEndpoint = LifecycleEndpoint + "/activate";
        public const string LifecycleDeactivateEndpoint = LifecycleEndpoint + "/deactivate";
        public const string LifecycleResetPasswordEndpoint = LifecycleEndpoint + "/reset_password";
        public const string LifecycleExpirePasswordEndpoint = LifecycleEndpoint + "/expire_password";
        public const string LifecycleResetFactorsEndpoint = LifecycleEndpoint + "/reset_factors";
        public const string LifecycleUnlockEndpoint = LifecycleEndpoint + "/unlock";
        public const string LifecycleSuspendEndpoint = LifecycleEndpoint + "/suspend";
        public const string LifecycleUnsuspendEndpoint = LifecycleEndpoint + "/unsuspend";

        public const string CredentialsEndpoint = "/credentials";
        public const string CredentialsForgotPasswordEndpoint = CredentialsEndpoint + "/forgot_password";
        public const string CredentialsChangePasswordEndpoint = CredentialsEndpoint + "/change_password";
        public const string CredentialsChangeRecoveryQuestionEndpoint = CredentialsEndpoint + "/change_recovery_question";
        public const string CredentialsResetPasswordEndpoint = CredentialsEndpoint + "/reset_password";

        // Lifecycle aliases mapped to endpoints
        public static Dictionary<string, string> LifecycleMap = new Dictionary<string, string>{
            {LifecycleActivate, LifecycleActivateEndpoint},
            {LifecycleDeactivate, LifecycleDeactivateEndpoint},
            {LifecycleResetPassword, LifecycleResetPasswordEndpoint},
            {LifecycleExpirePassword, LifecycleExpirePasswordEndpoint},
            {LifecycleResetFactors, LifecycleResetFactorsEndpoint},
            {LifecycleUnlock, LifecycleUnlockEndpoint},
            {LifecycleSuspend, LifecycleSuspendEndpoint},
             {LifecycleUnsuspend, LifecycleUnsuspendEndpoint},
            {LifecycleForgotPassword, CredentialsForgotPasswordEndpoint},
            {LifecycleChangePassword, CredentialsChangePasswordEndpoint},
            {LifecycleChangeRecoveryQuestion, CredentialsChangeRecoveryQuestionEndpoint},
        };

        public static HashSet<HttpStatusCode> AcceptableHttpStatusCodes = new HashSet<HttpStatusCode>
        {
            HttpStatusCode.OK,
            HttpStatusCode.Created,
            HttpStatusCode.Accepted,
            HttpStatusCode.NoContent,
            HttpStatusCode.ResetContent,
            HttpStatusCode.PartialContent
        };

        // Utility strings
        public const string EmptyObject = "{}";
        public const string DateFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
    }
}
