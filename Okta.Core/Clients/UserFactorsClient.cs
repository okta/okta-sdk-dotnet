using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Okta.Core.Models;

namespace Okta.Core.Clients
{
    /// <summary>
    /// A client to manage <see cref="Factor"/>s for a <see cref="User"/>
    /// </summary>
    public class UserFactorsClient : ApiClient<Factor>
    {
        public UserFactorsClient(User user, IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.UsersEndpoint + "/" + user.Id + Constants.FactorsEndpoint) { }
        public UserFactorsClient(User user, OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.UsersEndpoint + "/" + user.Id + Constants.FactorsEndpoint) { }
        public UserFactorsClient(User user, string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.UsersEndpoint + "/" + user.Id + Constants.FactorsEndpoint) { }

        public List<Factor> GetFactorCatalog()
        {
            var response = BaseClient.Get(resourcePath + Constants.CatalogEndpoint);
            return Utils.Deserialize<List<Factor>>(response);
        }

        public List<Question> GetQuestions()
        {
            var response = BaseClient.Get(resourcePath + Constants.QuestionsEndpoint);
            return Utils.Deserialize<List<Question>>(response);
        }

        public Factor Enroll(Factor factor)
        {
            return base.Add(factor);
        }

        public Factor EnrollQuestion(string questionType, string answer)
        {
            var question = Factor.BuildQuestion(questionType, answer);
            return Enroll(question);
        }

        public Factor Activate(Factor factor, string passCode)
        {
            //string body = "{ passCode: " + passCode +"}";
            string body = string.Format("{{ \"passCode\": \"{0}\" }}", passCode);
            var response = PerformLifecycle(factor, "activate", body );
            return Utils.Deserialize<Factor>(response);

            //return base.PerformLifecycle()
        }


        public void Reset(Factor factor)
        {
            base.Remove(factor);
        }

        public void Reset(string factorId)
        {
            base.Remove(factorId);
        }

        public ChallengeResponse BeginChallenge(Factor factor)
        {
            var response = BaseClient.Post(GetResourceUri(factor).ToString() + Constants.VerifyEndpoint);
            return Utils.Deserialize<ChallengeResponse>(response);
        }

        public ChallengeResponse CompleteChallenge(Factor factor, MfaAnswer mfaAnswer)
        {
            var response = BaseClient.Post(GetResourceUri(factor).ToString() + Constants.VerifyEndpoint, mfaAnswer.ToJson());
            return Utils.Deserialize<ChallengeResponse>(response);
        }
    }
}
