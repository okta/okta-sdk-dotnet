﻿/*
 * Okta API
 *
 * Allows customers to easily access the Okta API
 *
 * The version of the OpenAPI document: 3.0.0
 * Contact: devex-public@okta.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk.Client
{
    public class OktaCollectionAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IOktaPagedCollectionEnumerator<T> _pagedEnumerator;
        private bool _initialized = false;
        private int _localPageIndex;
        private bool _disposedValue = false; // To detect redundant calls

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    //Noop
                }

                _disposedValue = true;
            }
        }

        public OktaCollectionAsyncEnumerator(RequestOptions initialRequest, string path, IAsynchronousClient client, CancellationToken cancellationToken = default, IReadableConfiguration configuration =null, IOAuthTokenProvider oAuthTokenProvider = null)
        {
            _pagedEnumerator =
                new OktaPagedCollectionEnumerator<T>(initialRequest, path, client, cancellationToken, configuration, oAuthTokenProvider);
        }


        public T Current => _pagedEnumerator.CurrentPage.Items.ElementAt(_localPageIndex);

        public ValueTask DisposeAsync()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);

            return default(ValueTask);
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            var hasMoreLocalItems = _initialized
                                    && _pagedEnumerator.CurrentPage.Items.Any()
                                    && (_localPageIndex + 1) < _pagedEnumerator.CurrentPage.Items.Count();

            if (hasMoreLocalItems)
            {
                _localPageIndex++;
                return true;
            }

            var movedNext = await _pagedEnumerator.MoveNextAsync().ConfigureAwait(false);
            if (!movedNext)
            {
                return false;
            }

            _initialized = true;
            _localPageIndex = 0;

            return _pagedEnumerator.CurrentPage.Items.Any();
        }
    }
}
