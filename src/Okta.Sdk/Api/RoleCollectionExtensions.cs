// <copyright file="RoleCollectionExtensions.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Model;

namespace Okta.Sdk.Api
{
    /// <summary>
    /// Auto-paging helpers for Role* "List" operations whose responses are wrapped collection
    /// objects (<c>{ "&lt;items&gt;": [...], "_links": { "next": { "href": ... } } }</c>) rather than
    /// top-level arrays. The code generator only emits <see cref="Okta.Sdk.Client.IOktaCollectionClient{T}"/>
    /// for array responses, so these operations otherwise require callers to follow the
    /// <c>_links.next</c> cursor by hand. These extensions do that for you and yield every item
    /// across all pages as an <see cref="IAsyncEnumerable{T}"/>. See https://github.com/okta/okta-sdk-dotnet/issues/862.
    /// </summary>
    public static class RoleCollectionExtensions
    {
        /// <summary>Enumerates every resource set across all pages.</summary>
        public static async IAsyncEnumerable<ResourceSet> ListAllResourceSetsAsync(
            this RoleCResourceSetApi api,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string after = null;
            do
            {
                var page = await api.ListResourceSetsAsync(after, cancellationToken).ConfigureAwait(false);
                if (page?._ResourceSets != null)
                {
                    foreach (var item in page._ResourceSets) yield return item;
                }
                after = ExtractAfter(page?.Links?.Next?.Href);
            }
            while (after != null);
        }

        /// <summary>Enumerates every custom (IAM) role across all pages.</summary>
        public static async IAsyncEnumerable<IamRole> ListAllRolesAsync(
            this RoleECustomApi api,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string after = null;
            do
            {
                var page = await api.ListRolesAsync(after, cancellationToken).ConfigureAwait(false);
                if (page?.Roles != null)
                {
                    foreach (var item in page.Roles) yield return item;
                }
                after = ExtractAfter(page?.Links?.Next?.Href);
            }
            while (after != null);
        }

        /// <summary>Enumerates every resource of a resource set across all pages.</summary>
        public static async IAsyncEnumerable<ResourceSetResource> ListAllResourceSetResourcesAsync(
            this RoleCResourceSetResourceApi api,
            string resourceSetIdOrLabel,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string after = null;
            do
            {
                var page = await api.ListResourceSetResourcesAsync(resourceSetIdOrLabel, after, cancellationToken).ConfigureAwait(false);
                if (page?.Resources != null)
                {
                    foreach (var item in page.Resources) yield return item;
                }
                after = ExtractAfter(page?.Links?.Next?.Href);
            }
            while (after != null);
        }

        /// <summary>Enumerates every user with a role assignment across all pages.</summary>
        public static async IAsyncEnumerable<RoleAssignedUser> ListAllUsersWithRoleAssignmentsAsync(
            this RoleAssignmentAUserApi api,
            int? limit = null,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string after = null;
            do
            {
                var page = await api.ListUsersWithRoleAssignmentsAsync(after, limit, cancellationToken).ConfigureAwait(false);
                if (page?.Value != null)
                {
                    foreach (var item in page.Value) yield return item;
                }
                after = ExtractAfter(page?.Links?.Next?.Href);
            }
            while (after != null);
        }

        /// <summary>Enumerates every binding of a resource set across all pages.</summary>
        public static async IAsyncEnumerable<ResourceSetBindingRole> ListAllBindingsAsync(
            this RoleDResourceSetBindingApi api,
            string resourceSetIdOrLabel,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string after = null;
            do
            {
                var page = await api.ListBindingsAsync(resourceSetIdOrLabel, after, cancellationToken).ConfigureAwait(false);
                if (page?.Roles != null)
                {
                    foreach (var item in page.Roles) yield return item;
                }
                after = ExtractAfter(page?.Links?.Next?.Href);
            }
            while (after != null);
        }

        /// <summary>Enumerates every member of a resource set binding across all pages.</summary>
        public static async IAsyncEnumerable<ResourceSetBindingMember> ListAllMembersOfBindingAsync(
            this RoleDResourceSetBindingMemberApi api,
            string resourceSetIdOrLabel,
            string roleIdOrLabel,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string after = null;
            do
            {
                var page = await api.ListMembersOfBindingAsync(resourceSetIdOrLabel, roleIdOrLabel, after, cancellationToken).ConfigureAwait(false);
                if (page?.Members != null)
                {
                    foreach (var item in page.Members) yield return item;
                }
                after = ExtractAfter(page?.Links?.Next?.Href);
            }
            while (after != null);
        }

        /// <summary>Enumerates every entitlement of a governance bundle across all pages.</summary>
        public static async IAsyncEnumerable<BundleEntitlement> ListAllBundleEntitlementsAsync(
            this GovernanceBundleApi api,
            string bundleId,
            int? limit = null,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string after = null;
            do
            {
                var page = await api.ListBundleEntitlementsAsync(bundleId, after, limit, cancellationToken).ConfigureAwait(false);
                if (page?.Entitlements != null)
                {
                    foreach (var item in page.Entitlements) yield return item;
                }
                after = ExtractAfter(page?.Links?.Next?.Href);
            }
            while (after != null);
        }

        /// <summary>Enumerates every governance-source resource of a user's role-assignment grant across all pages.</summary>
        public static async IAsyncEnumerable<RoleGovernanceResource> ListAllRoleAssignmentGovernanceGrantResourcesAsync(
            this RoleAssignmentAUserApi api,
            string userId,
            string roleAssignmentId,
            string grantId,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string after = null;
            do
            {
                var page = await api.GetRoleAssignmentGovernanceGrantResourcesAsync(userId, roleAssignmentId, grantId, after, cancellationToken).ConfigureAwait(false);
                if (page?.Resources != null)
                {
                    foreach (var item in page.Resources) yield return item;
                }
                after = ExtractAfter(page?.Links?.Next?.Href);
            }
            while (after != null);
        }

        /// <summary>
        /// Extracts the <c>after</c> pagination cursor from a wrapped collection's <c>_links.next.href</c>.
        /// Returns <see langword="null"/> when there is no next page.
        /// </summary>
        internal static string ExtractAfter(string nextHref)
        {
            if (string.IsNullOrEmpty(nextHref))
            {
                return null;
            }

            var queryIndex = nextHref.IndexOf('?');
            if (queryIndex < 0)
            {
                return null;
            }

            foreach (var pair in nextHref.Substring(queryIndex + 1).Split('&'))
            {
                var kv = pair.Split(new[] { '=' }, 2);
                if (kv.Length == 2 && kv[0] == "after")
                {
                    return Uri.UnescapeDataString(kv[1]);
                }
            }

            return null;
        }
    }
}
