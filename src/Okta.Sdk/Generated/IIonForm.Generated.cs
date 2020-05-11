// <copyright file="IIonForm.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a IonForm resource in the Okta API.</summary>
    public partial interface IIonForm : IResource
    {
        string Accepts { get; set; }

        string Href { get; set; }

        string Method { get; set; }

        string Name { get; set; }

        string Produces { get; set; }

        int? Refresh { get; set; }

        IList<string> Rel { get; set; }

        IList<string> RelatesTo { get; set; }

        IList<IIonField> Value { get; }

    }
}
