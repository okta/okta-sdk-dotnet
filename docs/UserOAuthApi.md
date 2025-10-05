# Okta.Sdk.Api.UserOAuthApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetRefreshTokenForUserAndClient**](UserOAuthApi.md#getrefreshtokenforuserandclient) | **GET** /api/v1/users/{userId}/clients/{clientId}/tokens/{tokenId} | Retrieve a refresh token for a client
[**ListRefreshTokensForUserAndClient**](UserOAuthApi.md#listrefreshtokensforuserandclient) | **GET** /api/v1/users/{userId}/clients/{clientId}/tokens | List all refresh tokens for a client
[**RevokeTokenForUserAndClient**](UserOAuthApi.md#revoketokenforuserandclient) | **DELETE** /api/v1/users/{userId}/clients/{clientId}/tokens/{tokenId} | Revoke a token for a client
[**RevokeTokensForUserAndClient**](UserOAuthApi.md#revoketokensforuserandclient) | **DELETE** /api/v1/users/{userId}/clients/{clientId}/tokens | Revoke all refresh tokens for a client


<a name="getrefreshtokenforuserandclient"></a>
# **GetRefreshTokenForUserAndClient**
> OAuth2RefreshToken GetRefreshTokenForUserAndClient (string userId, string clientId, string tokenId, string expand = null)

Retrieve a refresh token for a client

Retrieves a refresh token issued for the specified user and client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRefreshTokenForUserAndClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserOAuthApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID
            var tokenId = sHHSth53yJAyNSTQKDJZ;  // string | `id` of Token
            var expand = scope;  // string | Valid value: `scope`. If specified, scope details are included in the `_embedded` attribute. (optional) 

            try
            {
                // Retrieve a refresh token for a client
                OAuth2RefreshToken result = apiInstance.GetRefreshTokenForUserAndClient(userId, clientId, tokenId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserOAuthApi.GetRefreshTokenForUserAndClient: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 
 **clientId** | **string**| Client app ID | 
 **tokenId** | **string**| &#x60;id&#x60; of Token | 
 **expand** | **string**| Valid value: &#x60;scope&#x60;. If specified, scope details are included in the &#x60;_embedded&#x60; attribute. | [optional] 

### Return type

[**OAuth2RefreshToken**](OAuth2RefreshToken.md)

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

<a name="listrefreshtokensforuserandclient"></a>
# **ListRefreshTokensForUserAndClient**
> List&lt;OAuth2RefreshToken&gt; ListRefreshTokensForUserAndClient (string userId, string clientId, string expand = null, string after = null, int? limit = null)

List all refresh tokens for a client

Lists all refresh tokens issued for the specified user and client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListRefreshTokensForUserAndClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserOAuthApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID
            var expand = scope;  // string | Valid value: `scope`. If specified, scope details are included in the `_embedded` attribute. (optional) 
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | Specifies the number of tokens to return (optional)  (default to 20)

            try
            {
                // List all refresh tokens for a client
                List<OAuth2RefreshToken> result = apiInstance.ListRefreshTokensForUserAndClient(userId, clientId, expand, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserOAuthApi.ListRefreshTokensForUserAndClient: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 
 **clientId** | **string**| Client app ID | 
 **expand** | **string**| Valid value: &#x60;scope&#x60;. If specified, scope details are included in the &#x60;_embedded&#x60; attribute. | [optional] 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| Specifies the number of tokens to return | [optional] [default to 20]

### Return type

[**List&lt;OAuth2RefreshToken&gt;**](OAuth2RefreshToken.md)

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

<a name="revoketokenforuserandclient"></a>
# **RevokeTokenForUserAndClient**
> void RevokeTokenForUserAndClient (string userId, string clientId, string tokenId)

Revoke a token for a client

Revokes the specified refresh and access tokens

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeTokenForUserAndClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserOAuthApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID
            var tokenId = sHHSth53yJAyNSTQKDJZ;  // string | `id` of Token

            try
            {
                // Revoke a token for a client
                apiInstance.RevokeTokenForUserAndClient(userId, clientId, tokenId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserOAuthApi.RevokeTokenForUserAndClient: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 
 **clientId** | **string**| Client app ID | 
 **tokenId** | **string**| &#x60;id&#x60; of Token | 

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

<a name="revoketokensforuserandclient"></a>
# **RevokeTokensForUserAndClient**
> void RevokeTokensForUserAndClient (string userId, string clientId)

Revoke all refresh tokens for a client

Revokes all refresh tokens issued for the specified user and client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeTokensForUserAndClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserOAuthApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID

            try
            {
                // Revoke all refresh tokens for a client
                apiInstance.RevokeTokensForUserAndClient(userId, clientId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserOAuthApi.RevokeTokensForUserAndClient: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 
 **clientId** | **string**| Client app ID | 

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

