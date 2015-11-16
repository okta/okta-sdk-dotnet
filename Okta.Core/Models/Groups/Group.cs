using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
    /// <summary>
    /// A group of users
    /// </summary>
    public class Group : OktaObject
    {
        public Group()
        {
            Profile = new GroupProfile();
        }

        public Group(string name, string description)
        {
            Profile = new GroupProfile()
            {
                Name = name,
                Description = description
            };
        }

        /// <summary>
        /// Determines the group's profile
        /// </summary>
        [JsonProperty("objectClass")]
        public string[] ObjectClass { get; set; }

        /// <summary>
        /// The group's profile attributes
        /// </summary>
        [JsonProperty("profile")]
        public GroupProfile Profile { get; set; }

        /// <summary>
        /// The Okta Group Type
        /// </summary>
        [JsonProperty("type")]
        public string GroupType { get; set; }
    }
}