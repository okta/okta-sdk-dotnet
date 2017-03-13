namespace Okta.Core.Clients
{
    using System;
    using System.Collections.Generic;

    using Okta.Core.Models;

    /// <summary>
    /// A client to manage <see cref="User"/>s
    /// </summary>
    public class UsersClient : ApiClient<User>
    {
        public UsersClient(IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.UsersEndpoint) { }
        public UsersClient(OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.UsersEndpoint) { }
        public UsersClient(string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.UsersEndpoint) { }
        public UsersClient(string apiToken, Uri baseUri) : base(apiToken, baseUri, Constants.EndpointV1 + Constants.UsersEndpoint) { }

        public virtual User Add(User user, bool activate = true)
        {
            var urlParams = new Dictionary<string, object> { { "activate", activate } };
            return base.Add(user, urlParams);
        }

        public virtual User Get(User user)
        {
            return base.Get(user);
        }

        /// <summary>
        /// Retrieves a user name by either its "login" property or its unique "id" property
        /// </summary>
        /// <param name="userId">the id or login property of the Okta user</param>
        /// <returns>An Okta User object if it exists</returns>
        /// <exception cref="OktaException">Returns an E0000007 exception if the user is not found</exception>
        /// <example>userClient.Get("user@domain.local") or userClient.Get("00u5t0pkimhkCPyGo0h7")</example>
        public virtual User Get(string userId)
        {
            if (userId.StartsWith("?"))
            {
                return GetByUsername(userId);
            }

            return base.Get(userId);
        }

        /// <summary>
        /// Retrieves an Okta user given its Username property (which is unique) by using a filter=profile.login eq '[username]' filter
        /// </summary>
        /// <param name="userName">Username/login property of the Okta user</param>
        /// <returns>An Okta User object if it exists or a null object if it doesn't exist</returns>
        /// <example>userClient.GetByUsername("user@domain.local") or userClient.GetByUsername("user")</example>
        public virtual User GetByUsername(string userName)
        {
            User user = null;
            var filter = new FilterBuilder();
            filter.Where("profile.login").EqualTo(userName);

            var users = base.GetFilteredEnumerator(filter, pageSize: 1);
            IEnumerator<User> usersEnum = users.GetEnumerator();
            if (users != null && usersEnum.MoveNext())
            {
                user = usersEnum.Current;
            }
            
            return user;
        }

        public virtual User Update(User user)
        {
            return base.Update(user);
        }

        public virtual User SetCredentials(User user, LoginCredentials credentials)
        {
            var userWithCredentials = new User {
                Credentials = credentials
            };
            var results = BaseClient.Put(GetResourceUri(user), userWithCredentials.ToJson());
            return Utils.Deserialize<User>(results);
        }

        public virtual User SetCredentials(string id, LoginCredentials credentials)
        {
            var userWithCredentials = new User {
                Credentials = credentials
            };
            var results = BaseClient.Put(GetResourceUri(id), userWithCredentials.ToJson());
            return Utils.Deserialize<User>(results);
        }

        public virtual User SetPassword(User user, string newPassword)
        {
            var credentials = new LoginCredentials();
            credentials.Password.Value = newPassword;
            return SetCredentials(user, credentials);
        }

        public virtual User SetPassword(string id, string newPassword)
        {
            var credentials = new LoginCredentials();
            credentials.Password.Value = newPassword;
            return SetCredentials(id, credentials);
        }

        public virtual User SetRecoveryQuestion(User user, string question, string answer)
        {
            var credentials = new LoginCredentials();
            credentials.RecoveryQuestion.Question = question;
            credentials.RecoveryQuestion.Answer = answer;
            return SetCredentials(user, credentials);
        }

        public virtual User SetRecoveryQuestion(string id, string question, string answer)
        {
            var credentials = new LoginCredentials();
            credentials.RecoveryQuestion.Question = question;
            credentials.RecoveryQuestion.Answer = answer;
            return SetCredentials(id, credentials);
        }

        public virtual Uri Activate(User user, bool sendEmail = true)
        {
            // TODO: Should this return a Uri or an activation response?
            var response = PerformLifecycle(user, Constants.LifecycleActivate, urlParams: new Dictionary<string, object> { { "sendEmail", sendEmail } });
            if (sendEmail)
            {
                return null;

            }

            var activationResult = Utils.Deserialize<ActivationResponse>(response);
            return activationResult.ActivationUrl;
        }

        public virtual Uri Activate(string id, bool sendEmail = true)
        {
            var response = PerformLifecycle(id, Constants.LifecycleActivate, urlParams: new Dictionary<string, object> { { "sendEmail", sendEmail } });
            if (sendEmail)
            {
                return null;
            }

            var activationResult = Utils.Deserialize<ActivationResponse>(response);
            return activationResult.ActivationUrl;
        }

        public virtual void Deactivate(User user)
        {
            PerformLifecycle(user, Constants.LifecycleDeactivate);
        }

        public virtual void Deactivate(string id)
        {
            PerformLifecycle(id, Constants.LifecycleDeactivate);
        }

        public virtual void Suspend(string id)
        {
            PerformLifecycle(id, Constants.LifecycleSuspend);
        }

        public virtual void Unsuspend(string id)
        {
            PerformLifecycle(id, Constants.LifecycleUnsuspend);
        }

        public virtual void Unlock(User user)
        {
            PerformLifecycle(user, Constants.LifecycleUnlock);
        }

        public virtual void Unlock(string id)
        {
            PerformLifecycle(id, Constants.LifecycleUnlock);
        }

        public virtual void ResetPassword(User user)
        {
            PerformLifecycle(user, Constants.LifecycleResetPassword);
        }

        public virtual void ResetPassword(string id)
        {
            PerformLifecycle(id, Constants.LifecycleResetPassword);
        }

        public virtual string ExpirePassword(User user, bool tempPassword = false)
        {
            var response = PerformLifecycle(user, Constants.LifecycleExpirePassword, urlParams: new Dictionary<string, object> { { "tempPassword", tempPassword } });
            if (tempPassword)
            {
                var expirePasswordResult = Utils.Deserialize<ExpirePasswordResponse>(response);
                return expirePasswordResult.TempPassword;
            }

            return null;
        }

        public virtual string ExpirePassword(string id, bool tempPassword = false)
        {
            var response = PerformLifecycle(id, Constants.LifecycleExpirePassword, urlParams: new Dictionary<string, object> { { "tempPassword", tempPassword } });
            if (tempPassword)
            {
                var expirePasswordResult = Utils.Deserialize<ExpirePasswordResponse>(response);
                return expirePasswordResult.TempPassword;
            }

            return null;
        }

        public virtual void ResetFactors(User user)
        {
            PerformLifecycle(user, Constants.LifecycleResetFactors);
        }

        public virtual void ResetFactors(string id)
        {
            PerformLifecycle(id, Constants.LifecycleResetFactors);
        }

        public virtual Uri ForgotPassword(User user, bool sendEmail = true)
        {
            var response = PerformLifecycle(user, Constants.LifecycleForgotPassword, urlParams: new Dictionary<string, object> { { "sendEmail", sendEmail } });
            if (sendEmail)
            {
                return null;
            }

            var forgotPasswordResult = Utils.Deserialize<ForgotPasswordResponse>(response);
            return forgotPasswordResult.ResetPasswordUrl;
        }

        public virtual Uri ForgotPassword(string id, bool sendEmail = true)
        {
            var response = PerformLifecycle(id, Constants.LifecycleForgotPassword, urlParams: new Dictionary<string, object> { { "sendEmail", sendEmail } });
            if (sendEmail)
            {
                return null;
            }

            var forgotPasswordResult = Utils.Deserialize<ForgotPasswordResponse>(response);
            return forgotPasswordResult.ResetPasswordUrl;
        }

        public virtual LoginCredentials ForgotPassword(User user, LoginCredentials creds)
        {
            var response = PerformLifecycle(user, Constants.LifecycleForgotPassword, creds.ToJson());
            return Utils.Deserialize<LoginCredentials>(response);
        }

        public virtual LoginCredentials ChangePassword(User user, string oldPassword, string newPassword)
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

        public virtual LoginCredentials ChangeRecoveryQuestion(User user, string currentPassword, RecoveryQuestion newRecoveryQuestion)
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

        public virtual UserAppLinksClient GetUserAppLinksClient(User user)
        {
            return new UserAppLinksClient(user, BaseClient);
        }

        public virtual UserFactorsClient GetUserFactorsClient(User user)
        {
            return new UserFactorsClient(user, BaseClient);
        }

        public virtual UserGroupsClient GetUserGroupsClient(User user)
        {
            return new UserGroupsClient(user, BaseClient);
        }

        /// <summary>
        /// Deletes a user using the Delete User API method
        /// </summary>
        /// <see cref="http://developer.okta.com/docs/api/resources/users.html#delete-user"/>
        /// <param name="userId">Id of the user to delete</param>
        public virtual void Delete(string userId)
        {
            BaseClient.Delete(resourcePath + "/" + userId);
        }


        /// <summary>
        /// Deletes a user using the Delete User API method
        /// </summary>
        /// <see cref="http://developer.okta.com/docs/api/resources/users.html#delete-user"/>
        /// <param name="user">The user to delete</param>
        public virtual void Delete(User user)
        {
            Delete(user.Id);
        }
    }
}
