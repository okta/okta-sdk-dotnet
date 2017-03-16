namespace Okta.Core.Models
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// An entity that has an id and generally has CRUD operations available.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class OktaObject : LinkedObject
    {
        internal OktaObject()
        {
            Links = new Dictionary<string, List<Link>>();
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [JsonProperty("id")]
        public virtual string Id { get; set; }

        /// <summary>
        /// Validates the specified is create.
        /// </summary>
        /// <param name="isCreate">if set to <c>true</c> [is create].</param>
        /// <exception cref="OktaException">
        /// Id should be null for create.
        /// or
        /// Id should not be null.
        /// </exception>
        public virtual void Validate(bool isCreate)
        {
            if (isCreate)
            {
                if (!string.IsNullOrEmpty(this.Id))
                {
                    throw new OktaException("Id should be null for create.");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.Id))
                {
                    throw new OktaException("Id should not be null.");
                }
            }
        }
    }
}
