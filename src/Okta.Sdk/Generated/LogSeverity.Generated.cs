// <copyright file="LogSeverity.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of LogSeverity values in the Okta API.
    /// </summary>
    public sealed class LogSeverity : StringEnum
    {
        /// <summary>The DEBUG LogSeverity.</summary>
        public static LogSeverity Debug = new LogSeverity("DEBUG");

        /// <summary>The INFO LogSeverity.</summary>
        public static LogSeverity Info = new LogSeverity("INFO");

        /// <summary>The WARN LogSeverity.</summary>
        public static LogSeverity Warn = new LogSeverity("WARN");

        /// <summary>The ERROR LogSeverity.</summary>
        public static LogSeverity Error = new LogSeverity("ERROR");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="LogSeverity"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator LogSeverity(string value) => new LogSeverity(value);

        /// <summary>
        /// Creates a new <see cref="LogSeverity"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public LogSeverity(string value)
            : base(value)
        {
        }

    }
}
