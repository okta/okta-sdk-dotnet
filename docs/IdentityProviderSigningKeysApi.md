# Okta.Sdk.Api.IdentityProviderSigningKeysApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CloneIdentityProviderKey**](IdentityProviderSigningKeysApi.md#cloneidentityproviderkey) | **POST** /api/v1/idps/{idpId}/credentials/keys/{kid}/clone | Clone a signing key credential for IdP
[**GenerateCsrForIdentityProvider**](IdentityProviderSigningKeysApi.md#generatecsrforidentityprovider) | **POST** /api/v1/idps/{idpId}/credentials/csrs | Generate a certificate signing request
[**GenerateIdentityProviderSigningKey**](IdentityProviderSigningKeysApi.md#generateidentityprovidersigningkey) | **POST** /api/v1/idps/{idpId}/credentials/keys/generate | Generate a new signing key credential for IdP
[**GetCsrForIdentityProvider**](IdentityProviderSigningKeysApi.md#getcsrforidentityprovider) | **GET** /api/v1/idps/{idpId}/credentials/csrs/{idpCsrId} | Retrieve a certificate signing request
[**GetIdentityProviderSigningKey**](IdentityProviderSigningKeysApi.md#getidentityprovidersigningkey) | **GET** /api/v1/idps/{idpId}/credentials/keys/{kid} | Retrieve a signing key credential for IdP
[**ListActiveIdentityProviderSigningKey**](IdentityProviderSigningKeysApi.md#listactiveidentityprovidersigningkey) | **GET** /api/v1/idps/{idpId}/credentials/keys/active | List the active signing key credential for IdP
[**ListCsrsForIdentityProvider**](IdentityProviderSigningKeysApi.md#listcsrsforidentityprovider) | **GET** /api/v1/idps/{idpId}/credentials/csrs | List all certificate signing requests
[**ListIdentityProviderSigningKeys**](IdentityProviderSigningKeysApi.md#listidentityprovidersigningkeys) | **GET** /api/v1/idps/{idpId}/credentials/keys | List all signing key credentials for IdP
[**PublishCsrForIdentityProvider**](IdentityProviderSigningKeysApi.md#publishcsrforidentityprovider) | **POST** /api/v1/idps/{idpId}/credentials/csrs/{idpCsrId}/lifecycle/publish | Publish a certificate signing request
[**RevokeCsrForIdentityProvider**](IdentityProviderSigningKeysApi.md#revokecsrforidentityprovider) | **DELETE** /api/v1/idps/{idpId}/credentials/csrs/{idpCsrId} | Revoke a certificate signing request


<a name="cloneidentityproviderkey"></a>
# **CloneIdentityProviderKey**
> IdPKeyCredential CloneIdentityProviderKey (string idpId, string kid, string targetIdpId)

Clone a signing key credential for IdP

Clones an X.509 certificate for an identity provider (IdP) signing key credential from a source IdP to target IdP > **Caution:** Sharing certificates isn't a recommended security practice.  > **Note:** If the key is already present in the list of key credentials for the target IdP, you receive a 400 error response.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CloneIdentityProviderKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderSigningKeysApi(config);
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP
            var kid = KmMo85SSsU7TZzOShcGb;  // string | Unique `id` of the IdP key credential
            var targetIdpId = "targetIdpId_example";  // string | `id` of the target IdP

            try
            {
                // Clone a signing key credential for IdP
                IdPKeyCredential result = apiInstance.CloneIdentityProviderKey(idpId, kid, targetIdpId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderSigningKeysApi.CloneIdentityProviderKey: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **idpId** | **string**| &#x60;id&#x60; of IdP | 
 **kid** | **string**| Unique &#x60;id&#x60; of the IdP key credential | 
 **targetIdpId** | **string**| &#x60;id&#x60; of the target IdP | 

### Return type

[**IdPKeyCredential**](IdPKeyCredential.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="generatecsrforidentityprovider"></a>
# **GenerateCsrForIdentityProvider**
> IdPCsr GenerateCsrForIdentityProvider (string idpId, CsrMetadata metadata)

Generate a certificate signing request

Generates a new key pair and returns a certificate signing request (CSR) for it > **Note:** The private key isn't listed in the [signing key credentials for the identity provider (IdP)](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/IdentityProviderSigningKeys/#tag/IdentityProviderSigningKeys/operation/listIdentityProviderSigningKeys) until it's published.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GenerateCsrForIdentityProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderSigningKeysApi(config);
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP
            var metadata = new CsrMetadata(); // CsrMetadata | 

            try
            {
                // Generate a certificate signing request
                IdPCsr result = apiInstance.GenerateCsrForIdentityProvider(idpId, metadata);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderSigningKeysApi.GenerateCsrForIdentityProvider: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **idpId** | **string**| &#x60;id&#x60; of IdP | 
 **metadata** | [**CsrMetadata**](CsrMetadata.md)|  | 

### Return type

[**IdPCsr**](IdPCsr.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/pkcs10


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="generateidentityprovidersigningkey"></a>
# **GenerateIdentityProviderSigningKey**
> IdPKeyCredential GenerateIdentityProviderSigningKey (string idpId, int validityYears)

Generate a new signing key credential for IdP

Generates a new X.509 certificate for an identity provider (IdP) signing key credential to be used for signing assertions sent to the IdP. IdP signing keys are read-only. > **Note:** To update an IdP with the newly generated key credential, [update your IdP](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/IdentityProvider/#tag/IdentityProvider/operation/replaceIdentityProvider) using the returned key's `kid` in the [signing credential](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/IdentityProvider/#tag/IdentityProvider/operation/replaceIdentityProvider!path=protocol/0/credentials/signing/kid&t=request).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GenerateIdentityProviderSigningKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderSigningKeysApi(config);
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP
            var validityYears = 56;  // int | expiry of the IdP key credential

            try
            {
                // Generate a new signing key credential for IdP
                IdPKeyCredential result = apiInstance.GenerateIdentityProviderSigningKey(idpId, validityYears);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderSigningKeysApi.GenerateIdentityProviderSigningKey: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **idpId** | **string**| &#x60;id&#x60; of IdP | 
 **validityYears** | **int**| expiry of the IdP key credential | 

### Return type

[**IdPKeyCredential**](IdPKeyCredential.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcsrforidentityprovider"></a>
# **GetCsrForIdentityProvider**
> IdPCsr GetCsrForIdentityProvider (string idpId, string idpCsrId)

Retrieve a certificate signing request

Retrieves a specific certificate signing request (CSR) by `id`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetCsrForIdentityProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderSigningKeysApi(config);
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP
            var idpCsrId = 1uEhyE65oV3H6KM9gYcN;  // string | `id` of the IdP CSR

            try
            {
                // Retrieve a certificate signing request
                IdPCsr result = apiInstance.GetCsrForIdentityProvider(idpId, idpCsrId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderSigningKeysApi.GetCsrForIdentityProvider: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **idpId** | **string**| &#x60;id&#x60; of IdP | 
 **idpCsrId** | **string**| &#x60;id&#x60; of the IdP CSR | 

### Return type

[**IdPCsr**](IdPCsr.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/pkcs10


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getidentityprovidersigningkey"></a>
# **GetIdentityProviderSigningKey**
> IdPKeyCredential GetIdentityProviderSigningKey (string idpId, string kid)

Retrieve a signing key credential for IdP

Retrieves a specific identity provider (IdP) key credential by `kid`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetIdentityProviderSigningKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderSigningKeysApi(config);
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP
            var kid = KmMo85SSsU7TZzOShcGb;  // string | Unique `id` of the IdP key credential

            try
            {
                // Retrieve a signing key credential for IdP
                IdPKeyCredential result = apiInstance.GetIdentityProviderSigningKey(idpId, kid);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderSigningKeysApi.GetIdentityProviderSigningKey: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **idpId** | **string**| &#x60;id&#x60; of IdP | 
 **kid** | **string**| Unique &#x60;id&#x60; of the IdP key credential | 

### Return type

[**IdPKeyCredential**](IdPKeyCredential.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listactiveidentityprovidersigningkey"></a>
# **ListActiveIdentityProviderSigningKey**
> List&lt;IdPKeyCredential&gt; ListActiveIdentityProviderSigningKey (string idpId)

List the active signing key credential for IdP

Lists the active signing key credential for an identity provider (IdP)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListActiveIdentityProviderSigningKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderSigningKeysApi(config);
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP

            try
            {
                // List the active signing key credential for IdP
                List<IdPKeyCredential> result = apiInstance.ListActiveIdentityProviderSigningKey(idpId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderSigningKeysApi.ListActiveIdentityProviderSigningKey: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **idpId** | **string**| &#x60;id&#x60; of IdP | 

### Return type

[**List&lt;IdPKeyCredential&gt;**](IdPKeyCredential.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **204** | No Content |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listcsrsforidentityprovider"></a>
# **ListCsrsForIdentityProvider**
> List&lt;IdPCsr&gt; ListCsrsForIdentityProvider (string idpId)

List all certificate signing requests

Lists all certificate signing requests (CSRs) for an identity provider (IdP)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListCsrsForIdentityProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderSigningKeysApi(config);
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP

            try
            {
                // List all certificate signing requests
                List<IdPCsr> result = apiInstance.ListCsrsForIdentityProvider(idpId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderSigningKeysApi.ListCsrsForIdentityProvider: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **idpId** | **string**| &#x60;id&#x60; of IdP | 

### Return type

[**List&lt;IdPCsr&gt;**](IdPCsr.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listidentityprovidersigningkeys"></a>
# **ListIdentityProviderSigningKeys**
> List&lt;IdPKeyCredential&gt; ListIdentityProviderSigningKeys (string idpId)

List all signing key credentials for IdP

Lists all signing key credentials for an identity provider (IdP)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListIdentityProviderSigningKeysExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderSigningKeysApi(config);
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP

            try
            {
                // List all signing key credentials for IdP
                List<IdPKeyCredential> result = apiInstance.ListIdentityProviderSigningKeys(idpId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderSigningKeysApi.ListIdentityProviderSigningKeys: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **idpId** | **string**| &#x60;id&#x60; of IdP | 

### Return type

[**List&lt;IdPKeyCredential&gt;**](IdPKeyCredential.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="publishcsrforidentityprovider"></a>
# **PublishCsrForIdentityProvider**
> IdPKeyCredential PublishCsrForIdentityProvider (string idpId, string idpCsrId, System.IO.Stream body)

Publish a certificate signing request

Publishes the certificate signing request (CSR) with a signed X.509 certificate and adds it into the signing key credentials for the identity provider (IdP) > **Notes:** > * Publishing a certificate completes the lifecycle of the CSR, and it's no longer accessible. > * If the validity period of the certificate is less than 90 days, a 400 error response is returned.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class PublishCsrForIdentityProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderSigningKeysApi(config);
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP
            var idpCsrId = 1uEhyE65oV3H6KM9gYcN;  // string | `id` of the IdP CSR
            var body = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream | 

            try
            {
                // Publish a certificate signing request
                IdPKeyCredential result = apiInstance.PublishCsrForIdentityProvider(idpId, idpCsrId, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderSigningKeysApi.PublishCsrForIdentityProvider: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **idpId** | **string**| &#x60;id&#x60; of IdP | 
 **idpCsrId** | **string**| &#x60;id&#x60; of the IdP CSR | 
 **body** | **System.IO.Stream****System.IO.Stream**|  | 

### Return type

[**IdPKeyCredential**](IdPKeyCredential.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/pkix-cert, application/x-x509-ca-cert, application/x-pem-file
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="revokecsrforidentityprovider"></a>
# **RevokeCsrForIdentityProvider**
> void RevokeCsrForIdentityProvider (string idpId, string idpCsrId)

Revoke a certificate signing request

Revokes a certificate signing request (CSR) and deletes the key pair from the identity provider (IdP)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeCsrForIdentityProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderSigningKeysApi(config);
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP
            var idpCsrId = 1uEhyE65oV3H6KM9gYcN;  // string | `id` of the IdP CSR

            try
            {
                // Revoke a certificate signing request
                apiInstance.RevokeCsrForIdentityProvider(idpId, idpCsrId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderSigningKeysApi.RevokeCsrForIdentityProvider: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **idpId** | **string**| &#x60;id&#x60; of IdP | 
 **idpCsrId** | **string**| &#x60;id&#x60; of the IdP CSR | 

### Return type

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

