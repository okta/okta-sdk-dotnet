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
    /// <summary>A client that works with Okta Template resources.</summary>
    public partial interface ITemplatesClient
    {
        /// <summary>
        /// Enumerates custom SMS templates in your organization. A subset of templates can be returned that match a template type.
        /// </summary>
        /// <param name="templateType"></param>
        /// <returns>A collection of <see cref="ISmsTemplate"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<ISmsTemplate> ListSmsTemplates(SmsTemplateType templateType = null);

        /// <summary>
        /// Adds a new custom SMS template to your organization.
        /// </summary>
        /// <param name="smsTemplate">The <see cref="ISmsTemplate"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ISmsTemplate"/> response.</returns>
        Task<ISmsTemplate> CreateSmsTemplateAsync(ISmsTemplate smsTemplate, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches a specific template by `id`
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ISmsTemplate"/> response.</returns>
        Task<ISmsTemplate> GetSmsTemplateAsync(string templateId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the SMS template.
        /// </summary>
        /// <param name="smsTemplate">The <see cref="ISmsTemplate"/> resource.</param>
        /// <param name="templateId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ISmsTemplate"/> response.</returns>
        Task<ISmsTemplate> UpdateSmsTemplateAsync(ISmsTemplate smsTemplate, string templateId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates only some of the SMS template properties:
        /// </summary>
        /// <param name="smsTemplate">The <see cref="ISmsTemplate"/> resource.</param>
        /// <param name="templateId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ISmsTemplate"/> response.</returns>
        Task<ISmsTemplate> PartialUpdateSmsTemplateAsync(ISmsTemplate smsTemplate, string templateId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes an SMS template.
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteSmsTemplateAsync(string templateId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
