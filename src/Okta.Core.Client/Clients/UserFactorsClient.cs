namespace Okta.Core.Clients
{
    using System.Collections.Generic;

    using Okta.Core.Models;

    /// <summary>
    /// A client to manage <see cref="Factor"/>s for a <see cref="User"/>
    /// </summary>
    public class UserFactorsClient : ApiClient<Factor>
    {
        public UserFactorsClient(User user, IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.UsersEndpoint + "/" + user.Id + Constants.FactorsEndpoint) { }
        public UserFactorsClient(User user, OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.UsersEndpoint + "/" + user.Id + Constants.FactorsEndpoint) { }
        public UserFactorsClient(User user, string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.UsersEndpoint + "/" + user.Id + Constants.FactorsEndpoint) { }

        public virtual List<Factor> GetFactorCatalog()
        {
            var response = BaseClient.Get(resourcePath + Constants.CatalogEndpoint);
            return Utils.Deserialize<List<Factor>>(response);
        }

        public virtual Factor GetFactor(string factorId)
        {
            var response = BaseClient.Get(resourcePath + "/" + factorId);
            return Utils.Deserialize<Factor>(response);

        }

        public virtual List<Question> GetQuestions()
        {
            var response = BaseClient.Get(resourcePath + Constants.QuestionsEndpoint);
            return Utils.Deserialize<List<Question>>(response);
        }

        public virtual Factor Enroll(Factor factor)
        {
            return base.Add(factor);
        }

        public virtual Factor EnrollQuestion(string questionType, string answer)
        {
            var question = Factor.BuildQuestion(questionType, answer);
            return Enroll(question);
        }

        public virtual Factor Activate(Factor factor, string passCode)
        {
            //string body = "{ passCode: " + passCode +"}";
            string body = string.Format("{{ \"passCode\": \"{0}\" }}", passCode);
            var response = PerformLifecycle(factor, "activate", body );
            return Utils.Deserialize<Factor>(response);

            //return base.PerformLifecycle()
        }
        public virtual void Reset(Factor factor)
        {
            base.Remove(factor);
        }

        public virtual void Reset(string factorId)
        {
            base.Remove(factorId);
        }

        public virtual ChallengeResponse BeginChallenge(Factor factor)
        {
            var response = BaseClient.Post(this.GetResourceUri(factor) + Constants.VerifyEndpoint);
            return Utils.Deserialize<ChallengeResponse>(response);
        }

        /// <summary>
        /// Completes an MFA Security Question challenge
        /// </summary>
        /// <param name="factor">the Factor security question object used to validate the answer</param>
        /// <param name="mfaAnswer">an object of type MfaAnswer used to validate the answer</param>
        /// <returns></returns>
        public virtual ChallengeResponse CompleteChallenge(Factor factor, MfaAnswer mfaAnswer)
        {
            var response = BaseClient.Post(this.GetResourceUri(factor) + Constants.VerifyEndpoint, mfaAnswer.ToJson());
            return Utils.Deserialize<ChallengeResponse>(response);
        }

        public virtual ChallengeResponse PollTransaction(string strPollUrl)
        {
            //replace double forward slashes which would otherwise create an invalid request - API BUG?
            strPollUrl = strPollUrl.Replace("//verify", "/verify");
            var response = BaseClient.Get(strPollUrl);
            return Utils.Deserialize<ChallengeResponse>(response);
        }
    }
}
