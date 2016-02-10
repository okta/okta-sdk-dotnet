using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Okta.Core.Models;

namespace Okta.Core.Clients
{
    /// <summary>
    /// A client to manage <see cref="User"/>s
    /// </summary>
    public class UsersClient : ApiClient<User>
    {
        public UsersClient(IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.UsersEndpoint) { }
        public UsersClient(OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.UsersEndpoint) { }
        public UsersClient(string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.UsersEndpoint) { }

        public User Add(User user, bool activate = true)
        {
            var urlParams = new Dictionary<string, object> { { "activate", activate } };
            return base.Add(user, urlParams);
        }

        public User Get(User user)
        {
            return base.Get(user);
        }

        /// <summary>
        /// Retrieves a user name by either its "login" property or it unique "id" property
        /// </summary>
        /// <param name="userId">the id or login property of the Okta user</param>
        /// <returns>An Okta User object</returns>
        /// <example>userClient.Get("user@domain.local") or userClient.Get("00u5t0pkimhkCPyGo0h7")</example>
        public User Get(string userId)
        {
            return base.Get(userId);
        }

        ///// <summary>
        ///// Retrieves an Okta user given its Username property (which is unique)
        ///// </summary>
        ///// <param name="userName">Username/login property of the Okta user</param>
        ///// <returns></returns>
        //public User GetByUsername(string userName)
        //{
        //    User user = null;
        //    var filter = new FilterBuilder();
        //    filter.Where("profile.login").EqualTo(userName);

        //    var users = base.GetFilteredEnumerator(filter, pageSize: 1);
        //    IEnumerator<User> usersEnum = users.GetEnumerator();
        //    if (users != null && usersEnum.MoveNext())
        //    {
        //        user = usersEnum.Current;
        //    }
        //    return user;
        //}

        public User Update(User user)
        {
            return base.Update(user);
        }

        public User SetCredentials(User user, LoginCredentials credentials)
        {
            var userWithCredentials = new User()
            {
                Credentials = credentials
            };
            var results = BaseClient.Put(GetResourceUri(user), userWithCredentials.ToJson());
            return Utils.Deserialize<User>(results);
        }

        public User SetCredentials(string id, LoginCredentials credentials)
        {
            var userWithCredentials = new User()
            {
                Credentials = credentials
            };
            var results = BaseClient.Put(id, userWithCredentials.ToJson());
            return Utils.Deserialize<User>(results);
        }

        public User SetPassword(User user, string newPassword)
        {
            var credentials = new LoginCredentials();
            credentials.Password.Value = newPassword;
            return SetCredentials(user, credentials);
        }

        public User SetPassword(string id, string newPassword)
        {
            var credentials = new LoginCredentials();
            credentials.Password.Value = newPassword;
            return SetCredentials(id, credentials);
        }

        public User SetRecoveryQuestion(User user, string question, string answer)
        {
            var credentials = new LoginCredentials();
            credentials.RecoveryQuestion.Question = question;
            credentials.RecoveryQuestion.Answer = answer;
            return SetCredentials(user, credentials);
        }

        public User SetRecoveryQuestion(string id, string question, string answer)
        {
            var credentials = new LoginCredentials();
            credentials.RecoveryQuestion.Question = question;
            credentials.RecoveryQuestion.Answer = answer;
            return SetCredentials(id, credentials);
        }

        public Uri Activate(User user, bool sendEmail = true)
        {
            // TODO: Should this return a Uri or an activation response?
            var response = PerformLifecycle(user, Constants.LifecycleActivate, urlParams: new Dictionary<string, object> { { "sendEmail", sendEmail } });
            if (sendEmail)
            {
                return null;
            }
            else
            {
                var activationResult = Utils.Deserialize<ActivationResponse>(response);
                return activationResult.ActivationUrl;
            }
        }

        public Uri Activate(string id, bool sendEmail = true)
        {
            var response = PerformLifecycle(id, Constants.LifecycleActivate, urlParams: new Dictionary<string, object> { { "sendEmail", sendEmail } });
            if (sendEmail)
            {
                return null;
            }
            else
            {
                var activationResult = Utils.Deserialize<ActivationResponse>(response);
                return activationResult.ActivationUrl;
            }
        }

        public void Deactivate(User user)
        {
            PerformLifecycle(user, Constants.LifecycleDeactivate);
        }

        public void Deactivate(string id)
        {
            PerformLifecycle(id, Constants.LifecycleDeactivate);
        }

        public void Unlock(User user)
        {
            PerformLifecycle(user, Constants.LifecycleUnlock);
        }

        public void Unlock(string id)
        {
            PerformLifecycle(id, Constants.LifecycleUnlock);
        }

        public void ResetPassword(User user)
        {
            PerformLifecycle(user, Constants.LifecycleResetPassword);
        }

        public void ResetPassword(string id)
        {
            PerformLifecycle(id, Constants.LifecycleResetPassword);
        }

        public string ExpirePassword(User user, bool tempPassword = false)
        {
            var response = PerformLifecycle(user, Constants.LifecycleExpirePassword, urlParams: new Dictionary<string, object> { { "tempPassword", tempPassword } });
            if (tempPassword)
            {
                var expirePasswordResult = Utils.Deserialize<ExpirePasswordResponse>(response);
                return expirePasswordResult.TempPassword;
            }
            else
            {
                return null;
            }
        }

        public string ExpirePassword(string id, bool tempPassword = false)
        {
            var response = PerformLifecycle(id, Constants.LifecycleExpirePassword, urlParams: new Dictionary<string, object> { { "tempPassword", tempPassword } });
            if (tempPassword)
            {
                var expirePasswordResult = Utils.Deserialize<ExpirePasswordResponse>(response);
                return expirePasswordResult.TempPassword;
            }
            else
            {
                return null;
            }
        }

        public void ResetFactors(User user)
        {
            PerformLifecycle(user, Constants.LifecycleResetFactors);
        }

        public void ResetFactors(string id)
        {
            PerformLifecycle(id, Constants.LifecycleResetFactors);
        }

        public Uri ForgotPassword(User user, bool sendEmail = true)
        {
            var response = PerformLifecycle(user, Constants.LifecycleForgotPassword, urlParams: new Dictionary<string, object> { { "sendEmail", sendEmail } });
            if (sendEmail)
            {
                return null;
            }
            else
            {
                var forgotPasswordResult = Utils.Deserialize<ForgotPasswordResponse>(response);
                return forgotPasswordResult.ResetPasswordUrl;
            }
        }

        public void ForgotPassword(string id)
        {
            PerformLifecycle(id, Constants.LifecycleForgotPassword);
        }

        public LoginCredentials ForgotPassword(User user, LoginCredentials creds)
        {
            var response = PerformLifecycle(user, Constants.LifecycleForgotPassword, creds.ToJson());
            return Utils.Deserialize<LoginCredentials>(response);
        }

        public LoginCredentials ChangePassword(User user, String oldPassword, String newPassword)
        {
            var passwordRequestObject = new
            {
                oldPassword = new { value = oldPassword },
                newPassword = new { value = newPassword }
            };
            var passwordRequest = Utils.SerializeObject(passwordRequestObject);
            var response = PerformLifecycle(user, Constants.LifecycleChangePassword, passwordRequest);
            return Utils.Deserialize<LoginCredentials>(response);
        }

        public LoginCredentials ChangeRecoveryQuestion(User user, String currentPassword, RecoveryQuestion newRecoveryQuestion)
        {
            var recoveryQuestionObject = new
            {
                password = new { value = currentPassword },
                recovery_question = newRecoveryQuestion
            };
            var recoveryQuestionRequest = Utils.SerializeObject(recoveryQuestionObject);
            var response = PerformLifecycle(user, Constants.LifecycleChangeRecoveryQuestion, recoveryQuestionRequest);
            return Utils.Deserialize<LoginCredentials>(response);
        }

        public UserAppLinksClient GetUserAppLinksClient(User user)
        {
            return new UserAppLinksClient(user, BaseClient);
        }

        public UserFactorsClient GetUserFactorsClient(User user)
        {
            return new UserFactorsClient(user, BaseClient);
        }

        public UserGroupsClient GetUserGroupsClient(User user)
        {
            return new UserGroupsClient(user, BaseClient);
        }
    }
}
