using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
    /// <summary>
    /// A response received after making a forgot password request.
    /// </summary>
    public class ForgotPasswordResponse : ApiObject
    {
        /// <summary>
        /// Url for user to reset their password
        /// </summary>
        [JsonProperty("resetPasswordUrl")]
        public Uri ResetPasswordUrl { get; set; }
    }
}