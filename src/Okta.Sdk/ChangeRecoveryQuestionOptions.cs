// <copyright file="ChangeRecoveryQuestionOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Contains the parameters needed to change a user's recovery question.
    /// </summary>
    public sealed class ChangeRecoveryQuestionOptions
    {
        /// <summary>
        /// Gets or sets the user's current password.
        /// </summary>
        /// <value>
        /// The user's current password.
        /// </value>
        public string CurrentPassword { get; set; }

        /// <summary>
        /// Gets or sets the user's new recovery question.
        /// </summary>
        /// <value>
        /// The user's new recovery question.
        /// </value>
        public string RecoveryQuestion { get; set; }

        /// <summary>
        /// Gets or sets the user's new recovery answer.
        /// </summary>
        /// <value>
        /// The user's new recovery answer.
        /// </value>
        public string RecoveryAnswer { get; set; }
    }
}
