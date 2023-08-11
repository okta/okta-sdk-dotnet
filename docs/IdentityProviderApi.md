# Okta.Sdk.Api.IdentityProviderApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateIdentityProvider**](IdentityProviderApi.md#activateidentityprovider) | **POST** /api/v1/idps/{idpId}/lifecycle/activate | Activate an Identity Provider
[**CloneIdentityProviderKey**](IdentityProviderApi.md#cloneidentityproviderkey) | **POST** /api/v1/idps/{idpId}/credentials/keys/{idpKeyId}/clone | Clone a Signing Credential Key
[**CreateIdentityProvider**](IdentityProviderApi.md#createidentityprovider) | **POST** /api/v1/idps | Create an Identity Provider
[**CreateIdentityProviderKey**](IdentityProviderApi.md#createidentityproviderkey) | **POST** /api/v1/idps/credentials/keys | Create an X.509 Certificate Public Key
[**DeactivateIdentityProvider**](IdentityProviderApi.md#deactivateidentityprovider) | **POST** /api/v1/idps/{idpId}/lifecycle/deactivate | Deactivate an Identity Provider
[**DeleteIdentityProvider**](IdentityProviderApi.md#deleteidentityprovider) | **DELETE** /api/v1/idps/{idpId} | Delete an Identity Provider
[**DeleteIdentityProviderKey**](IdentityProviderApi.md#deleteidentityproviderkey) | **DELETE** /api/v1/idps/credentials/keys/{idpKeyId} | Delete a Signing Credential Key
[**GenerateCsrForIdentityProvider**](IdentityProviderApi.md#generatecsrforidentityprovider) | **POST** /api/v1/idps/{idpId}/credentials/csrs | Generate a Certificate Signing Request
[**GenerateIdentityProviderSigningKey**](IdentityProviderApi.md#generateidentityprovidersigningkey) | **POST** /api/v1/idps/{idpId}/credentials/keys/generate | Generate a new Signing Credential Key
[**GetCsrForIdentityProvider**](IdentityProviderApi.md#getcsrforidentityprovider) | **GET** /api/v1/idps/{idpId}/credentials/csrs/{idpCsrId} | Retrieve a Certificate Signing Request
[**GetIdentityProvider**](IdentityProviderApi.md#getidentityprovider) | **GET** /api/v1/idps/{idpId} | Retrieve an Identity Provider
[**GetIdentityProviderApplicationUser**](IdentityProviderApi.md#getidentityproviderapplicationuser) | **GET** /api/v1/idps/{idpId}/users/{userId} | Retrieve a User
[**GetIdentityProviderKey**](IdentityProviderApi.md#getidentityproviderkey) | **GET** /api/v1/idps/credentials/keys/{idpKeyId} | Retrieve an Credential Key
[**GetIdentityProviderSigningKey**](IdentityProviderApi.md#getidentityprovidersigningkey) | **GET** /api/v1/idps/{idpId}/credentials/keys/{idpKeyId} | Retrieve a Signing Credential Key
[**LinkUserToIdentityProvider**](IdentityProviderApi.md#linkusertoidentityprovider) | **POST** /api/v1/idps/{idpId}/users/{userId} | Link a User to a Social IdP
[**ListCsrsForIdentityProvider**](IdentityProviderApi.md#listcsrsforidentityprovider) | **GET** /api/v1/idps/{idpId}/credentials/csrs | List all Certificate Signing Requests
[**ListIdentityProviderApplicationUsers**](IdentityProviderApi.md#listidentityproviderapplicationusers) | **GET** /api/v1/idps/{idpId}/users | List all Users
[**ListIdentityProviderKeys**](IdentityProviderApi.md#listidentityproviderkeys) | **GET** /api/v1/idps/credentials/keys | List all Credential Keys
[**ListIdentityProviderSigningKeys**](IdentityProviderApi.md#listidentityprovidersigningkeys) | **GET** /api/v1/idps/{idpId}/credentials/keys | List all Signing Credential Keys
[**ListIdentityProviders**](IdentityProviderApi.md#listidentityproviders) | **GET** /api/v1/idps | List all Identity Providers
[**ListSocialAuthTokens**](IdentityProviderApi.md#listsocialauthtokens) | **GET** /api/v1/idps/{idpId}/users/{userId}/credentials/tokens | List all Tokens from a OIDC Identity Provider
[**PublishCsrForIdentityProvider**](IdentityProviderApi.md#publishcsrforidentityprovider) | **POST** /api/v1/idps/{idpId}/credentials/csrs/{idpCsrId}/lifecycle/publish | Publish a Certificate Signing Request
[**ReplaceIdentityProvider**](IdentityProviderApi.md#replaceidentityprovider) | **PUT** /api/v1/idps/{idpId} | Replace an Identity Provider
[**RevokeCsrForIdentityProvider**](IdentityProviderApi.md#revokecsrforidentityprovider) | **DELETE** /api/v1/idps/{idpId}/credentials/csrs/{idpCsrId} | Revoke a Certificate Signing Request
[**UnlinkUserFromIdentityProvider**](IdentityProviderApi.md#unlinkuserfromidentityprovider) | **DELETE** /api/v1/idps/{idpId}/users/{userId} | Unlink a User from IdP


<a name="activateidentityprovider"></a>
# **ActivateIdentityProvider**
> IdentityProvider ActivateIdentityProvider (string idpId)

Activate an Identity Provider

Activates an inactive IdP

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateIdentityProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP

            try
            {
                // Activate an Identity Provider
                IdentityProvider result = apiInstance.ActivateIdentityProvider(idpId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.ActivateIdentityProvider: " + e.Message );
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

[**IdentityProvider**](IdentityProvider.md)

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

<a name="cloneidentityproviderkey"></a>
# **CloneIdentityProviderKey**
> JsonWebKey CloneIdentityProviderKey (string idpId, string idpKeyId, string targetIdpId)

Clone a Signing Credential Key

Clones a X.509 certificate for an IdP signing key credential from a source IdP to target IdP

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

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP
            var idpKeyId = KmMo85SSsU7TZzOShcGb;  // string | `id` of IdP Key
            var targetIdpId = "targetIdpId_example";  // string | 

            try
            {
                // Clone a Signing Credential Key
                JsonWebKey result = apiInstance.CloneIdentityProviderKey(idpId, idpKeyId, targetIdpId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.CloneIdentityProviderKey: " + e.Message );
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
 **idpKeyId** | **string**| &#x60;id&#x60; of IdP Key | 
 **targetIdpId** | **string**|  | 

### Return type

[**JsonWebKey**](JsonWebKey.md)

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

<a name="createidentityprovider"></a>
# **CreateIdentityProvider**
> IdentityProvider CreateIdentityProvider (IdentityProvider identityProvider)

Create an Identity Provider

Creates a new identity provider integration

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateIdentityProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var identityProvider = new IdentityProvider(); // IdentityProvider | 

            try
            {
                // Create an Identity Provider
                IdentityProvider result = apiInstance.CreateIdentityProvider(identityProvider);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.CreateIdentityProvider: " + e.Message );
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
 **identityProvider** | [**IdentityProvider**](IdentityProvider.md)|  | 

### Return type

[**IdentityProvider**](IdentityProvider.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createidentityproviderkey"></a>
# **CreateIdentityProviderKey**
> JsonWebKey CreateIdentityProviderKey (JsonWebKey jsonWebKey)

Create an X.509 Certificate Public Key

Creates a new X.509 certificate credential to the IdP key store.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateIdentityProviderKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var jsonWebKey = new JsonWebKey(); // JsonWebKey | 

            try
            {
                // Create an X.509 Certificate Public Key
                JsonWebKey result = apiInstance.CreateIdentityProviderKey(jsonWebKey);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.CreateIdentityProviderKey: " + e.Message );
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
 **jsonWebKey** | [**JsonWebKey**](JsonWebKey.md)|  | 

### Return type

[**JsonWebKey**](JsonWebKey.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivateidentityprovider"></a>
# **DeactivateIdentityProvider**
> IdentityProvider DeactivateIdentityProvider (string idpId)

Deactivate an Identity Provider

Deactivates an active IdP

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateIdentityProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP

            try
            {
                // Deactivate an Identity Provider
                IdentityProvider result = apiInstance.DeactivateIdentityProvider(idpId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.DeactivateIdentityProvider: " + e.Message );
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

[**IdentityProvider**](IdentityProvider.md)

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

<a name="deleteidentityprovider"></a>
# **DeleteIdentityProvider**
> void DeleteIdentityProvider (string idpId)

Delete an Identity Provider

Deletes an identity provider integration by `idpId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteIdentityProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP

            try
            {
                // Delete an Identity Provider
                apiInstance.DeleteIdentityProvider(idpId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.DeleteIdentityProvider: " + e.Message );
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

<a name="deleteidentityproviderkey"></a>
# **DeleteIdentityProviderKey**
> void DeleteIdentityProviderKey (string idpKeyId)

Delete a Signing Credential Key

Deletes a specific IdP Key Credential by `kid` if it is not currently being used by an Active or Inactive IdP

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteIdentityProviderKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var idpKeyId = KmMo85SSsU7TZzOShcGb;  // string | `id` of IdP Key

            try
            {
                // Delete a Signing Credential Key
                apiInstance.DeleteIdentityProviderKey(idpKeyId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.DeleteIdentityProviderKey: " + e.Message );
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
 **idpKeyId** | **string**| &#x60;id&#x60; of IdP Key | 

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

<a name="generatecsrforidentityprovider"></a>
# **GenerateCsrForIdentityProvider**
> Csr GenerateCsrForIdentityProvider (string idpId, CsrMetadata metadata)

Generate a Certificate Signing Request

Generates a new key pair and returns a Certificate Signing Request for it

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

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP
            var metadata = new CsrMetadata(); // CsrMetadata | 

            try
            {
                // Generate a Certificate Signing Request
                Csr result = apiInstance.GenerateCsrForIdentityProvider(idpId, metadata);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.GenerateCsrForIdentityProvider: " + e.Message );
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

[**Csr**](Csr.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
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

<a name="generateidentityprovidersigningkey"></a>
# **GenerateIdentityProviderSigningKey**
> JsonWebKey GenerateIdentityProviderSigningKey (string idpId, int validityYears)

Generate a new Signing Credential Key

Generates a new X.509 certificate for an IdP signing key credential to be used for signing assertions sent to the IdP

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

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP
            var validityYears = 56;  // int | expiry of the IdP Key Credential

            try
            {
                // Generate a new Signing Credential Key
                JsonWebKey result = apiInstance.GenerateIdentityProviderSigningKey(idpId, validityYears);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.GenerateIdentityProviderSigningKey: " + e.Message );
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
 **validityYears** | **int**| expiry of the IdP Key Credential | 

### Return type

[**JsonWebKey**](JsonWebKey.md)

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
> Csr GetCsrForIdentityProvider (string idpId, string idpCsrId)

Retrieve a Certificate Signing Request

Retrieves a specific Certificate Signing Request model by id

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

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP
            var idpCsrId = 1uEhyE65oV3H6KM9gYcN;  // string | `id` of the IdP CSR

            try
            {
                // Retrieve a Certificate Signing Request
                Csr result = apiInstance.GetCsrForIdentityProvider(idpId, idpCsrId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.GetCsrForIdentityProvider: " + e.Message );
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

[**Csr**](Csr.md)

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

<a name="getidentityprovider"></a>
# **GetIdentityProvider**
> IdentityProvider GetIdentityProvider (string idpId)

Retrieve an Identity Provider

Retrieves an identity provider integration by `idpId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetIdentityProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP

            try
            {
                // Retrieve an Identity Provider
                IdentityProvider result = apiInstance.GetIdentityProvider(idpId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.GetIdentityProvider: " + e.Message );
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

[**IdentityProvider**](IdentityProvider.md)

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

<a name="getidentityproviderapplicationuser"></a>
# **GetIdentityProviderApplicationUser**
> IdentityProviderApplicationUser GetIdentityProviderApplicationUser (string idpId, string userId)

Retrieve a User

Retrieves a linked IdP user by ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetIdentityProviderApplicationUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP
            var userId = "userId_example";  // string | 

            try
            {
                // Retrieve a User
                IdentityProviderApplicationUser result = apiInstance.GetIdentityProviderApplicationUser(idpId, userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.GetIdentityProviderApplicationUser: " + e.Message );
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
 **userId** | **string**|  | 

### Return type

[**IdentityProviderApplicationUser**](IdentityProviderApplicationUser.md)

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

<a name="getidentityproviderkey"></a>
# **GetIdentityProviderKey**
> JsonWebKey GetIdentityProviderKey (string idpKeyId)

Retrieve an Credential Key

Retrieves a specific IdP Key Credential by `kid`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetIdentityProviderKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var idpKeyId = KmMo85SSsU7TZzOShcGb;  // string | `id` of IdP Key

            try
            {
                // Retrieve an Credential Key
                JsonWebKey result = apiInstance.GetIdentityProviderKey(idpKeyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.GetIdentityProviderKey: " + e.Message );
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
 **idpKeyId** | **string**| &#x60;id&#x60; of IdP Key | 

### Return type

[**JsonWebKey**](JsonWebKey.md)

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

<a name="getidentityprovidersigningkey"></a>
# **GetIdentityProviderSigningKey**
> JsonWebKey GetIdentityProviderSigningKey (string idpId, string idpKeyId)

Retrieve a Signing Credential Key

Retrieves a specific IdP Key Credential by `kid`

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

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP
            var idpKeyId = KmMo85SSsU7TZzOShcGb;  // string | `id` of IdP Key

            try
            {
                // Retrieve a Signing Credential Key
                JsonWebKey result = apiInstance.GetIdentityProviderSigningKey(idpId, idpKeyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.GetIdentityProviderSigningKey: " + e.Message );
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
 **idpKeyId** | **string**| &#x60;id&#x60; of IdP Key | 

### Return type

[**JsonWebKey**](JsonWebKey.md)

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

<a name="linkusertoidentityprovider"></a>
# **LinkUserToIdentityProvider**
> IdentityProviderApplicationUser LinkUserToIdentityProvider (string idpId, string userId, UserIdentityProviderLinkRequest userIdentityProviderLinkRequest)

Link a User to a Social IdP

Links an Okta user to an existing Social Identity Provider. This does not support the SAML2 Identity Provider Type

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class LinkUserToIdentityProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP
            var userId = "userId_example";  // string | 
            var userIdentityProviderLinkRequest = new UserIdentityProviderLinkRequest(); // UserIdentityProviderLinkRequest | 

            try
            {
                // Link a User to a Social IdP
                IdentityProviderApplicationUser result = apiInstance.LinkUserToIdentityProvider(idpId, userId, userIdentityProviderLinkRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.LinkUserToIdentityProvider: " + e.Message );
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
 **userId** | **string**|  | 
 **userIdentityProviderLinkRequest** | [**UserIdentityProviderLinkRequest**](UserIdentityProviderLinkRequest.md)|  | 

### Return type

[**IdentityProviderApplicationUser**](IdentityProviderApplicationUser.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listcsrsforidentityprovider"></a>
# **ListCsrsForIdentityProvider**
> List&lt;Csr&gt; ListCsrsForIdentityProvider (string idpId)

List all Certificate Signing Requests

Lists all Certificate Signing Requests for an IdP

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

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP

            try
            {
                // List all Certificate Signing Requests
                List<Csr> result = apiInstance.ListCsrsForIdentityProvider(idpId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.ListCsrsForIdentityProvider: " + e.Message );
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

[**List&lt;Csr&gt;**](Csr.md)

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

<a name="listidentityproviderapplicationusers"></a>
# **ListIdentityProviderApplicationUsers**
> List&lt;IdentityProviderApplicationUser&gt; ListIdentityProviderApplicationUsers (string idpId)

List all Users

Lists all users linked to the identity provider

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListIdentityProviderApplicationUsersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP

            try
            {
                // List all Users
                List<IdentityProviderApplicationUser> result = apiInstance.ListIdentityProviderApplicationUsers(idpId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.ListIdentityProviderApplicationUsers: " + e.Message );
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

[**List&lt;IdentityProviderApplicationUser&gt;**](IdentityProviderApplicationUser.md)

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

<a name="listidentityproviderkeys"></a>
# **ListIdentityProviderKeys**
> List&lt;JsonWebKey&gt; ListIdentityProviderKeys (string after = null, int? limit = null)

List all Credential Keys

Lists all IdP key credentials

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListIdentityProviderKeysExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of keys (optional) 
            var limit = 20;  // int? | Specifies the number of key results in a page (optional)  (default to 20)

            try
            {
                // List all Credential Keys
                List<JsonWebKey> result = apiInstance.ListIdentityProviderKeys(after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.ListIdentityProviderKeys: " + e.Message );
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
 **after** | **string**| Specifies the pagination cursor for the next page of keys | [optional] 
 **limit** | **int?**| Specifies the number of key results in a page | [optional] [default to 20]

### Return type

[**List&lt;JsonWebKey&gt;**](JsonWebKey.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listidentityprovidersigningkeys"></a>
# **ListIdentityProviderSigningKeys**
> List&lt;JsonWebKey&gt; ListIdentityProviderSigningKeys (string idpId)

List all Signing Credential Keys

Lists all signing key credentials for an IdP

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

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP

            try
            {
                // List all Signing Credential Keys
                List<JsonWebKey> result = apiInstance.ListIdentityProviderSigningKeys(idpId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.ListIdentityProviderSigningKeys: " + e.Message );
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

[**List&lt;JsonWebKey&gt;**](JsonWebKey.md)

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

<a name="listidentityproviders"></a>
# **ListIdentityProviders**
> List&lt;IdentityProvider&gt; ListIdentityProviders (string q = null, string after = null, int? limit = null, string type = null)

List all Identity Providers

Lists all identity provider integrations with pagination. A subset of IdPs can be returned that match a supported filter expression or query.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListIdentityProvidersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var q = "q_example";  // string | Searches the name property of IdPs for matching value (optional) 
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of IdPs (optional) 
            var limit = 20;  // int? | Specifies the number of IdP results in a page (optional)  (default to 20)
            var type = "type_example";  // string | Filters IdPs by type (optional) 

            try
            {
                // List all Identity Providers
                List<IdentityProvider> result = apiInstance.ListIdentityProviders(q, after, limit, type).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.ListIdentityProviders: " + e.Message );
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
 **q** | **string**| Searches the name property of IdPs for matching value | [optional] 
 **after** | **string**| Specifies the pagination cursor for the next page of IdPs | [optional] 
 **limit** | **int?**| Specifies the number of IdP results in a page | [optional] [default to 20]
 **type** | **string**| Filters IdPs by type | [optional] 

### Return type

[**List&lt;IdentityProvider&gt;**](IdentityProvider.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listsocialauthtokens"></a>
# **ListSocialAuthTokens**
> List&lt;SocialAuthToken&gt; ListSocialAuthTokens (string idpId, string userId)

List all Tokens from a OIDC Identity Provider

Lists the tokens minted by the Social Authentication Provider when the user authenticates with Okta via Social Auth

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListSocialAuthTokensExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP
            var userId = "userId_example";  // string | 

            try
            {
                // List all Tokens from a OIDC Identity Provider
                List<SocialAuthToken> result = apiInstance.ListSocialAuthTokens(idpId, userId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.ListSocialAuthTokens: " + e.Message );
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
 **userId** | **string**|  | 

### Return type

[**List&lt;SocialAuthToken&gt;**](SocialAuthToken.md)

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
> JsonWebKey PublishCsrForIdentityProvider (string idpId, string idpCsrId, System.IO.Stream body)

Publish a Certificate Signing Request

Publishes a certificate signing request with a signed X.509 certificate and adds it into the signing key credentials for the IdP

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

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP
            var idpCsrId = 1uEhyE65oV3H6KM9gYcN;  // string | `id` of the IdP CSR
            var body = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream | 

            try
            {
                // Publish a Certificate Signing Request
                JsonWebKey result = apiInstance.PublishCsrForIdentityProvider(idpId, idpCsrId, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.PublishCsrForIdentityProvider: " + e.Message );
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

[**JsonWebKey**](JsonWebKey.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/x-x509-ca-cert, application/pkix-cert, application/x-pem-file
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

<a name="replaceidentityprovider"></a>
# **ReplaceIdentityProvider**
> IdentityProvider ReplaceIdentityProvider (string idpId, IdentityProvider identityProvider)

Replace an Identity Provider

Replaces an identity provider integration by `idpId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceIdentityProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP
            var identityProvider = new IdentityProvider(); // IdentityProvider | 

            try
            {
                // Replace an Identity Provider
                IdentityProvider result = apiInstance.ReplaceIdentityProvider(idpId, identityProvider);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.ReplaceIdentityProvider: " + e.Message );
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
 **identityProvider** | [**IdentityProvider**](IdentityProvider.md)|  | 

### Return type

[**IdentityProvider**](IdentityProvider.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="revokecsrforidentityprovider"></a>
# **RevokeCsrForIdentityProvider**
> void RevokeCsrForIdentityProvider (string idpId, string idpCsrId)

Revoke a Certificate Signing Request

Revokes a certificate signing request and deletes the key pair from the IdP

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

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP
            var idpCsrId = 1uEhyE65oV3H6KM9gYcN;  // string | `id` of the IdP CSR

            try
            {
                // Revoke a Certificate Signing Request
                apiInstance.RevokeCsrForIdentityProvider(idpId, idpCsrId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.RevokeCsrForIdentityProvider: " + e.Message );
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

<a name="unlinkuserfromidentityprovider"></a>
# **UnlinkUserFromIdentityProvider**
> void UnlinkUserFromIdentityProvider (string idpId, string userId)

Unlink a User from IdP

Unlinks the link between the Okta user and the IdP user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnlinkUserFromIdentityProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderApi(config);
            var idpId = SVHoAOh0l8cPQkVX1LRl;  // string | `id` of IdP
            var userId = "userId_example";  // string | 

            try
            {
                // Unlink a User from IdP
                apiInstance.UnlinkUserFromIdentityProvider(idpId, userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderApi.UnlinkUserFromIdentityProvider: " + e.Message );
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
 **userId** | **string**|  | 

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

