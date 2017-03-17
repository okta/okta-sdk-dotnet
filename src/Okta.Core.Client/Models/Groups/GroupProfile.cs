namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// A profile that describes a <see cref="Group"/>
    /// </summary>
    public class GroupProfile : ApiObject
    {
        /// <summary>
        /// Name of the group
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the group
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Pre-windows 2000 name of the windows group
        /// </summary>
        [JsonProperty("samAccountName")]
        public string SamAccountName { get; set; }

        /// <summary>
        /// The distinguished name of the windows group
        /// </summary>
        [JsonProperty("dn")]
        public string Dn { get; set; }

        /// <summary>
        /// Fully-qualified name of the windows group
        /// </summary>
        [JsonProperty("windowsDomainQualifiedName")]
        public string WindowsDomainQualifiedName { get; set; }

        /// <summary>
        /// Base-64 encoded GUID (objectGUID) of the windows group
        /// </summary>
        [JsonProperty("externalId")]
        public string ExternalId { get; set; }
    }
}