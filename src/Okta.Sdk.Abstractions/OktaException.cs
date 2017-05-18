// <copyright file="OktaException.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace Okta.Sdk.Abstractions
{
    public class OktaException : Exception
    {
        public OktaException()
        {
        }

        public OktaException(string message)
            : base(message)
        {
        }

        public OktaException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
