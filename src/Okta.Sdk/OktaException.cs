// <copyright file="OktaException.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace Okta.Sdk
{
    /// <summary>
    /// Base class for all Okta client and API exceptions.
    /// </summary>
    public class OktaException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OktaException"/> class.
        /// </summary>
        public OktaException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OktaException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public OktaException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OktaException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public OktaException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
