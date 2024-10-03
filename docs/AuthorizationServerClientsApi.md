# Okta.Sdk.Api.AuthorizationServerClientsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetRefreshTokenForAuthorizationServerAndClient**](AuthorizationServerClientsApi.md#getrefreshtokenforauthorizationserverandclient) | **GET** /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId} | Retrieve a refresh token for a Client
[**ListOAuth2ClientsForAuthorizationServer**](AuthorizationServerClientsApi.md#listoauth2clientsforauthorizationserver) | **GET** /api/v1/authorizationServers/{authServerId}/clients | List all Client resources for an authorization server
[**ListRefreshTokensForAuthorizationServerAndClient**](AuthorizationServerClientsApi.md#listrefreshtokensforauthorizationserverandclient) | **GET** /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens | List all refresh tokens for a Client
[**RevokeRefreshTokenForAuthorizationServerAndClient**](AuthorizationServerClientsApi.md#revokerefreshtokenforauthorizationserverandclient) | **DELETE** /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId} | Revoke a refresh token for a Client
[**RevokeRefreshTokensForAuthorizationServerAndClient**](AuthorizationServerClientsApi.md#revokerefreshtokensforauthorizationserverandclient) | **DELETE** /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens | Revoke all refresh tokens for a Client


<a name="getrefreshtokenforauthorizationserverandclient"></a>
# **GetRefreshTokenForAuthorizationServerAndClient**
> OAuth2RefreshToken GetRefreshTokenForAuthorizationServerAndClient (string authServerId, string clientId, string tokenId, string expand = null)

Retrieve a refresh token for a Client

Retrieves a refresh token for a Client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRefreshTokenForAuthorizationServerAndClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerClientsApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | `client_id` of the app
            var tokenId = sHHSth53yJAyNSTQKDJZ;  // string | `id` of Token
            var expand = "expand_example";  // string | Valid value: `scope`. If specified, scope details are included in the `_embedded` attribute. (optional) 

            try
            {
                // Retrieve a refresh token for a Client
                OAuth2RefreshToken result = apiInstance.GetRefreshTokenForAuthorizationServerAndClient(authServerId, clientId, tokenId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerClientsApi.GetRefreshTokenForAuthorizationServerAndClient: " + e.Message );
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
 **authServerId** | **string**| &#x60;id&#x60; of the Authorization Server | 
 **clientId** | **string**| &#x60;client_id&#x60; of the app | 
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

<a name="listoauth2clientsforauthorizationserver"></a>
# **ListOAuth2ClientsForAuthorizationServer**
> List&lt;OAuth2Client&gt; ListOAuth2ClientsForAuthorizationServer (string authServerId)

List all Client resources for an authorization server

Lists all Client resources for which the specified authorization server has tokens

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListOAuth2ClientsForAuthorizationServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerClientsApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server

            try
            {
                // List all Client resources for an authorization server
                List<OAuth2Client> result = apiInstance.ListOAuth2ClientsForAuthorizationServer(authServerId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerClientsApi.ListOAuth2ClientsForAuthorizationServer: " + e.Message );
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
 **authServerId** | **string**| &#x60;id&#x60; of the Authorization Server | 

### Return type

[**List&lt;OAuth2Client&gt;**](OAuth2Client.md)

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

<a name="listrefreshtokensforauthorizationserverandclient"></a>
# **ListRefreshTokensForAuthorizationServerAndClient**
> List&lt;OAuth2RefreshToken&gt; ListRefreshTokensForAuthorizationServerAndClient (string authServerId, string clientId, string expand = null, string after = null, int? limit = null)

List all refresh tokens for a Client

Lists all refresh tokens issued by an authorization server for a specific Client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListRefreshTokensForAuthorizationServerAndClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerClientsApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | `client_id` of the app
            var expand = "expand_example";  // string | Valid value: `scope`. If specified, scope details are included in the `_embedded` attribute. (optional) 
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of tokens (optional) 
            var limit = -1;  // int? | The maximum number of tokens to return (maximum 200) (optional)  (default to -1)

            try
            {
                // List all refresh tokens for a Client
                List<OAuth2RefreshToken> result = apiInstance.ListRefreshTokensForAuthorizationServerAndClient(authServerId, clientId, expand, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerClientsApi.ListRefreshTokensForAuthorizationServerAndClient: " + e.Message );
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
 **authServerId** | **string**| &#x60;id&#x60; of the Authorization Server | 
 **clientId** | **string**| &#x60;client_id&#x60; of the app | 
 **expand** | **string**| Valid value: &#x60;scope&#x60;. If specified, scope details are included in the &#x60;_embedded&#x60; attribute. | [optional] 
 **after** | **string**| Specifies the pagination cursor for the next page of tokens | [optional] 
 **limit** | **int?**| The maximum number of tokens to return (maximum 200) | [optional] [default to -1]

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

<a name="revokerefreshtokenforauthorizationserverandclient"></a>
# **RevokeRefreshTokenForAuthorizationServerAndClient**
> void RevokeRefreshTokenForAuthorizationServerAndClient (string authServerId, string clientId, string tokenId)

Revoke a refresh token for a Client

Revokes a refresh token for a Client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeRefreshTokenForAuthorizationServerAndClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerClientsApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | `client_id` of the app
            var tokenId = sHHSth53yJAyNSTQKDJZ;  // string | `id` of Token

            try
            {
                // Revoke a refresh token for a Client
                apiInstance.RevokeRefreshTokenForAuthorizationServerAndClient(authServerId, clientId, tokenId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerClientsApi.RevokeRefreshTokenForAuthorizationServerAndClient: " + e.Message );
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
 **authServerId** | **string**| &#x60;id&#x60; of the Authorization Server | 
 **clientId** | **string**| &#x60;client_id&#x60; of the app | 
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

<a name="revokerefreshtokensforauthorizationserverandclient"></a>
# **RevokeRefreshTokensForAuthorizationServerAndClient**
> void RevokeRefreshTokensForAuthorizationServerAndClient (string authServerId, string clientId)

Revoke all refresh tokens for a Client

Revokes all refresh tokens for a Client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeRefreshTokensForAuthorizationServerAndClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerClientsApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | `client_id` of the app

            try
            {
                // Revoke all refresh tokens for a Client
                apiInstance.RevokeRefreshTokensForAuthorizationServerAndClient(authServerId, clientId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerClientsApi.RevokeRefreshTokensForAuthorizationServerAndClient: " + e.Message );
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
 **authServerId** | **string**| &#x60;id&#x60; of the Authorization Server | 
 **clientId** | **string**| &#x60;client_id&#x60; of the app | 

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

