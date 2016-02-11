namespace Okta.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The foundation of all the Okta models.
    /// </summary>
    /// <remarks>
    /// This enables serialization and deserialization.
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiObject
    {
        /// <summary>
        /// Gets or sets the changed properties.
        /// </summary>
        /// <remarks>
        /// This allows us to track properties we should send for partial updates.
        /// </remarks>
        /// <value>
        /// The changed properties.
        /// </value>
        internal HashSet<string> ChangedProperties { get; set; }

        /// <summary>
        /// Gets or sets the unmapped properties.
        /// </summary>
        /// <remarks>
        /// These properties aren't hardcoded into our models. Ex: Any universal directory property</remarks>
        /// <value>
        /// The unmapped properties.
        /// </value>
        internal Dictionary<string, JProperty> UnmappedProperties { get; set; }

        internal ApiObject()
        {
            this.UnmappedProperties = new Dictionary<string, JProperty>();
            this.ChangedProperties = new HashSet<string>();
        }

        /// <summary>
        /// Gets an unmapped property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Value of the requested property.</returns>
        /// <exception cref="OktaException">Property not available: propertyName</exception>
        public string GetProperty(string propertyName)
        {
            JProperty property;
            if (UnmappedProperties.TryGetValue(propertyName, out property))
            {
                return property.Value.ToString();
            }

            throw new OktaException("Property not available: " + propertyName);
        }

        /// <summary>
        /// Sets an unmapped property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value.</param>
        public void SetProperty(string propertyName, object value)
        {
            if (UnmappedProperties.ContainsKey(propertyName))
            {
                UnmappedProperties[propertyName] = new JProperty(propertyName, value);
            }
            else
            {
                UnmappedProperties.Add(propertyName, new JProperty(propertyName, value));
            }
        }

        /// <summary>
        /// Checks for the availability of an unmapped property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public bool ContainsProperty(string propertyName)
        {
            if (UnmappedProperties.ContainsKey(propertyName))
            {
                return true;
            }

            return false;
        }
        

        /// <summary>
        /// Get a List of all the Unmapped property names
        /// </summary>
        /// <returns></returns>
        public List<string> GetUnmappedPropertyNames()
        {
            return UnmappedProperties.Keys.ToList();
        }

        /// <summary>
        /// Converts an object to json.
        /// </summary>
        /// <returns>A JSON string.</returns>
        public virtual string ToJson() { return ToJson(false); }

        /// <summary>
        /// Converts an object to json.
        /// </summary>
        /// <param name="updatedPropertiesOnly">if set to <c>true</c> [updated properties only].</param>
        /// <returns>A JSON string.</returns>
        /// <exception cref="System.NotImplementedException">We don't support only updated properties yet</exception>
        public virtual string ToJson(bool updatedPropertiesOnly)
        {
            if (updatedPropertiesOnly)
            {
                // TODO: Needs a custom serializer
                // http://geekswithblogs.net/DavidHoerster/archive/2011/07/26/json.net-custom-convertersndasha-quick-tour.aspx
                throw new OktaException("Feature not implemented", new NotImplementedException("We don't support only updated properties yet"));
            }

            return Utils.SerializeObject(this);
        }
    }
}
