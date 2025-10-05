# Okta.Sdk.Api.IdentityProviderApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateIdentityProvider**](IdentityProviderApi.md#activateidentityprovider) | **POST** /api/v1/idps/{idpId}/lifecycle/activate | Activate an IdP
[**CreateIdentityProvider**](IdentityProviderApi.md#createidentityprovider) | **POST** /api/v1/idps | Create an IdP
[**DeactivateIdentityProvider**](IdentityProviderApi.md#deactivateidentityprovider) | **POST** /api/v1/idps/{idpId}/lifecycle/deactivate | Deactivate an IdP
[**DeleteIdentityProvider**](IdentityProviderApi.md#deleteidentityprovider) | **DELETE** /api/v1/idps/{idpId} | Delete an IdP
[**GetIdentityProvider**](IdentityProviderApi.md#getidentityprovider) | **GET** /api/v1/idps/{idpId} | Retrieve an IdP
[**ListIdentityProviders**](IdentityProviderApi.md#listidentityproviders) | **GET** /api/v1/idps | List all IdPs
[**ReplaceIdentityProvider**](IdentityProviderApi.md#replaceidentityprovider) | **PUT** /api/v1/idps/{idpId} | Replace an IdP


<a name="activateidentityprovider"></a>
# **ActivateIdentityProvider**
> IdentityProvider ActivateIdentityProvider (string idpId)

Activate an IdP

Activates an inactive identity provider (IdP)

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
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP

            try
            {
                // Activate an IdP
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

<a name="createidentityprovider"></a>
# **CreateIdentityProvider**
> IdentityProvider CreateIdentityProvider (IdentityProvider identityProvider)

Create an IdP

Creates a new identity provider (IdP) integration.  #### SAML 2.0 IdP  You must first add the IdP's signature certificate to the IdP key store before you can add a SAML 2.0 IdP with a `kid` credential reference.   Don't use `fromURI` to automatically redirect a user to a particular app after successfully authenticating with a third-party IdP. Instead, use SAML deep links. Using `fromURI` isn't tested or supported. For more information about using deep links when signing users in using an SP-initiated flow, see [Understanding SP-Initiated Login flow](https://developer.okta.com/docs/concepts/saml/#understanding-sp-initiated-login-flow).  Use SAML deep links to automatically redirect the user to an app after successfully authenticating with a third-party IdP. To use deep links, assemble these three parts into a URL:  * SP ACS URL<br> For example: `https://${yourOktaDomain}/sso/saml2/:idpId` * The app to which the user is automatically redirected after successfully authenticating with the IdP <br> For example: `/app/:app-location/:appId/sso/saml` * Optionally, if the app is an outbound SAML app, you can specify the `relayState` passed to it.<br> For example: `?RelayState=:anyUrlEncodedValue`  The deep link for the above three parts is:<br> `https://${yourOktaDomain}/sso/saml2/:idpId/app/:app-location/:appId/sso/saml?RelayState=:anyUrlEncodedValue`  #### Smart Card X509 IdP  You must first add the IdP's server certificate to the IdP key store before you can add a Smart Card `X509` IdP with a `kid` credential reference. You need to upload the whole trust chain as a single key using the [Key Store API](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/IdentityProviderKeys/#tag/IdentityProviderKeys/operation/createIdentityProviderKey). Depending on the information stored in the smart card, select the proper [template](https://developer.okta.com/docs/reference/okta-expression-language/#idp-user-profile) `idpuser.subjectAltNameEmail` or `idpuser.subjectAltNameUpn`.  #### Identity verification vendors as identity providers  Identity verification vendors (IDVs) work like IdPs, with a few key differences. IDVs verify your user's identities by requiring them to submit a proof of identity. There are many ways to verify user identities. For example, a proof of identity can be a selfie to determine liveliness or it can be requiring users to submit a photo of their driver's license and matching that information with a database.  There are three IDVs that you can configure as IdPs in your org by creating an account with the vendor, and then creating an IdP integration. Control how the IDVs verify your users by using [Okta account management policy rules](https://developer.okta.com/docs/guides/okta-account-management-policy/main/).  * [Persona](https://withpersona.com/)  * [CLEAR Verified](https://www.clearme.com/)  * [Incode](https://incode.com/)

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
            var identityProvider = new IdentityProvider(); // IdentityProvider | IdP settings

            try
            {
                // Create an IdP
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
 **identityProvider** | [**IdentityProvider**](IdentityProvider.md)| IdP settings | 

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

<a name="deactivateidentityprovider"></a>
# **DeactivateIdentityProvider**
> IdentityProvider DeactivateIdentityProvider (string idpId)

Deactivate an IdP

Deactivates an active identity provider (IdP)

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
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP

            try
            {
                // Deactivate an IdP
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

Delete an IdP

Deletes an identity provider (IdP) integration by `idpId` * All existing IdP users are unlinked with the highest order profile source taking precedence for each IdP user. * Unlinked users keep their existing authentication provider such as `FEDERATION` or `SOCIAL`.

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
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP

            try
            {
                // Delete an IdP
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

<a name="getidentityprovider"></a>
# **GetIdentityProvider**
> IdentityProvider GetIdentityProvider (string idpId)

Retrieve an IdP

Retrieves an identity provider (IdP) integration by `idpId`

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
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP

            try
            {
                // Retrieve an IdP
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

<a name="listidentityproviders"></a>
# **ListIdentityProviders**
> List&lt;IdentityProvider&gt; ListIdentityProviders (string q = null, string after = null, int? limit = null, IdentityProviderType? type = null)

List all IdPs

Lists all identity provider (IdP) integrations with pagination. A subset of IdPs can be returned that match a supported filter expression or query.

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
            var q = Example SAML;  // string | Searches the `name` property of IdPs for matching value (optional) 
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)
            var type = (IdentityProviderType) "AMAZON";  // IdentityProviderType? | Filters IdPs by `type` (optional) 

            try
            {
                // List all IdPs
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
 **q** | **string**| Searches the &#x60;name&#x60; property of IdPs for matching value | [optional] 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]
 **type** | **IdentityProviderType?**| Filters IdPs by &#x60;type&#x60; | [optional] 

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

<a name="replaceidentityprovider"></a>
# **ReplaceIdentityProvider**
> IdentityProvider ReplaceIdentityProvider (string idpId, IdentityProvider identityProvider)

Replace an IdP

Replaces an identity provider (IdP) integration by `idpId`

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
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP
            var identityProvider = new IdentityProvider(); // IdentityProvider | Updated configuration for the IdP

            try
            {
                // Replace an IdP
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
 **identityProvider** | [**IdentityProvider**](IdentityProvider.md)| Updated configuration for the IdP | 

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

