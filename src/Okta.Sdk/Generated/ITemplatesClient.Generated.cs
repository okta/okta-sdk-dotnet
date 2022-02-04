// <copyright file="ITemplatesClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface ITemplatesClient
    {
        /// <summary>
        /// Add SMS Template Adds a new custom SMS template to your organization.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        ///  <returns>Task of ISmsTemplate</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ISmsTemplate> CreateSmsTemplateAsync(ISmsTemplate body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Remove SMS Template Removes an SMS template.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="templateId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteSmsTemplateAsync(string templateId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get SMS Template Fetches a specific template by &#x60;id&#x60;
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="templateId"></param>
        ///  <returns>Task of ISmsTemplate</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ISmsTemplate> GetSmsTemplateAsync(string templateId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// List SMS Templates Enumerates custom SMS templates in your organization. A subset of templates can be returned that match a template type.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="templateType"> (optional)</param>
        /// A collection of <see cref="ITemplatesClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<ISmsTemplate> ListSmsTemplates(string templateType = null);
        /// <summary>
        /// Partial SMS Template Update Updates only some of the SMS template properties:
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="templateId"></param>
        ///  <returns>Task of ISmsTemplate</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ISmsTemplate> PartialUpdateSmsTemplateAsync(ISmsTemplate body, string templateId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update SMS Template Updates the SMS template.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="templateId"></param>
        ///  <returns>Task of ISmsTemplate</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ISmsTemplate> UpdateSmsTemplateAsync(ISmsTemplate body, string templateId, CancellationToken cancellationToken = default(CancellationToken));
    }
}

