# Okta.Sdk.Api.IdentityProviderUsersApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetIdentityProviderApplicationUser**](IdentityProviderUsersApi.md#getidentityproviderapplicationuser) | **GET** /api/v1/idps/{idpId}/users/{userId} | Retrieve a user for IdP
[**LinkUserToIdentityProvider**](IdentityProviderUsersApi.md#linkusertoidentityprovider) | **POST** /api/v1/idps/{idpId}/users/{userId} | Link a user to IdP
[**ListIdentityProviderApplicationUsers**](IdentityProviderUsersApi.md#listidentityproviderapplicationusers) | **GET** /api/v1/idps/{idpId}/users | List all users for IdP
[**ListSocialAuthTokens**](IdentityProviderUsersApi.md#listsocialauthtokens) | **GET** /api/v1/idps/{idpId}/users/{userId}/credentials/tokens | List all tokens from OIDC IdP
[**ListUserIdentityProviders**](IdentityProviderUsersApi.md#listuseridentityproviders) | **GET** /api/v1/users/{id}/idps | List all IdPs for user
[**UnlinkUserFromIdentityProvider**](IdentityProviderUsersApi.md#unlinkuserfromidentityprovider) | **DELETE** /api/v1/idps/{idpId}/users/{userId} | Unlink a user from IdP


<a name="getidentityproviderapplicationuser"></a>
# **GetIdentityProviderApplicationUser**
> IdentityProviderApplicationUser GetIdentityProviderApplicationUser (string idpId, string userId)

Retrieve a user for IdP

Retrieves a linked identity provider (IdP) user by ID

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

            var apiInstance = new IdentityProviderUsersApi(config);
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // Retrieve a user for IdP
                IdentityProviderApplicationUser result = apiInstance.GetIdentityProviderApplicationUser(idpId, userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderUsersApi.GetIdentityProviderApplicationUser: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 

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

<a name="linkusertoidentityprovider"></a>
# **LinkUserToIdentityProvider**
> IdentityProviderApplicationUser LinkUserToIdentityProvider (string idpId, string userId, UserIdentityProviderLinkRequest userIdentityProviderLinkRequest)

Link a user to IdP

Links an Okta user to an existing SAML or social identity provider (IdP).  The SAML IdP must have `honorPersistentNameId` set to `true` to use this API. The [Name Identifier Format](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/IdentityProvider/#tag/IdentityProvider/operation/replaceIdentityProvider!path=protocol/0/settings&t=request) of the incoming assertion must be `urn:oasis:names:tc:SAML:2.0:nameid-format:persistent`.

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

            var apiInstance = new IdentityProviderUsersApi(config);
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var userIdentityProviderLinkRequest = new UserIdentityProviderLinkRequest(); // UserIdentityProviderLinkRequest | 

            try
            {
                // Link a user to IdP
                IdentityProviderApplicationUser result = apiInstance.LinkUserToIdentityProvider(idpId, userId, userIdentityProviderLinkRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderUsersApi.LinkUserToIdentityProvider: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 
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

<a name="listidentityproviderapplicationusers"></a>
# **ListIdentityProviderApplicationUsers**
> List&lt;IdentityProviderApplicationUser&gt; ListIdentityProviderApplicationUsers (string idpId, string q = null, string after = null, int? limit = null, string expand = null)

List all users for IdP

Lists all the users linked to an identity provider (IdP)

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

            var apiInstance = new IdentityProviderUsersApi(config);
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP
            var q = "q_example";  // string | Searches the records for matching value (optional) 
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)
            var expand = user;  // string | Expand user data (optional) 

            try
            {
                // List all users for IdP
                List<IdentityProviderApplicationUser> result = apiInstance.ListIdentityProviderApplicationUsers(idpId, q, after, limit, expand).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderUsersApi.ListIdentityProviderApplicationUsers: " + e.Message );
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
 **q** | **string**| Searches the records for matching value | [optional] 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]
 **expand** | **string**| Expand user data | [optional] 

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

<a name="listsocialauthtokens"></a>
# **ListSocialAuthTokens**
> List&lt;SocialAuthToken&gt; ListSocialAuthTokens (string idpId, string userId)

List all tokens from OIDC IdP

Lists the tokens minted by the social authentication provider when the user authenticates with Okta via Social Auth.  Okta doesn't import all the user information from a social provider. If the app needs information that isn't imported, it can get the user token from this endpoint. Then the app can make an API call to the social provider with the token to request the additional information.

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

            var apiInstance = new IdentityProviderUsersApi(config);
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // List all tokens from OIDC IdP
                List<SocialAuthToken> result = apiInstance.ListSocialAuthTokens(idpId, userId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderUsersApi.ListSocialAuthTokens: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 

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

<a name="listuseridentityproviders"></a>
# **ListUserIdentityProviders**
> List&lt;IdentityProvider&gt; ListUserIdentityProviders (string id)

List all IdPs for user

Lists the identity providers (IdPs) associated with the user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListUserIdentityProvidersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderUsersApi(config);
            var id = "id_example";  // string | An ID, login, or login shortname (as long as the shortname is unambiguous) of an existing Okta user

            try
            {
                // List all IdPs for user
                List<IdentityProvider> result = apiInstance.ListUserIdentityProviders(id).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderUsersApi.ListUserIdentityProviders: " + e.Message );
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
 **id** | **string**| An ID, login, or login shortname (as long as the shortname is unambiguous) of an existing Okta user | 

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
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="unlinkuserfromidentityprovider"></a>
# **UnlinkUserFromIdentityProvider**
> void UnlinkUserFromIdentityProvider (string idpId, string userId)

Unlink a user from IdP

Unlinks the Okta user and the identity provider (IdP) user. The next time the user federates into Okta through this IdP, they have to re-link their account according to the account link policy.

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

            var apiInstance = new IdentityProviderUsersApi(config);
            var idpId = 0oa62bfdjnK55Z5x80h7;  // string | `id` of IdP
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // Unlink a user from IdP
                apiInstance.UnlinkUserFromIdentityProvider(idpId, userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderUsersApi.UnlinkUserFromIdentityProvider: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 

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

