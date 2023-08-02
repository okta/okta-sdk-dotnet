# Okta.Sdk.Api.ApplicationTokensApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetOAuth2TokenForApplication**](ApplicationTokensApi.md#getoauth2tokenforapplication) | **GET** /api/v1/apps/{appId}/tokens/{tokenId} | Retrieve an OAuth 2.0 Token
[**ListOAuth2TokensForApplication**](ApplicationTokensApi.md#listoauth2tokensforapplication) | **GET** /api/v1/apps/{appId}/tokens | List all OAuth 2.0 Tokens
[**RevokeOAuth2TokenForApplication**](ApplicationTokensApi.md#revokeoauth2tokenforapplication) | **DELETE** /api/v1/apps/{appId}/tokens/{tokenId} | Revoke an OAuth 2.0 Token
[**RevokeOAuth2TokensForApplication**](ApplicationTokensApi.md#revokeoauth2tokensforapplication) | **DELETE** /api/v1/apps/{appId}/tokens | Revoke all OAuth 2.0 Tokens


<a name="getoauth2tokenforapplication"></a>
# **GetOAuth2TokenForApplication**
> OAuth2Token GetOAuth2TokenForApplication (string appId, string tokenId, string expand = null)

Retrieve an OAuth 2.0 Token

Retrieves a token for the specified application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetOAuth2TokenForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationTokensApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var tokenId = sHHSth53yJAyNSTQKDJZ;  // string | `id` of Token
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // Retrieve an OAuth 2.0 Token
                OAuth2Token result = apiInstance.GetOAuth2TokenForApplication(appId, tokenId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationTokensApi.GetOAuth2TokenForApplication: " + e.Message );
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
 **appId** | **string**| ID of the Application | 
 **tokenId** | **string**| &#x60;id&#x60; of Token | 
 **expand** | **string**|  | [optional] 

### Return type

[**OAuth2Token**](OAuth2Token.md)

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

<a name="listoauth2tokensforapplication"></a>
# **ListOAuth2TokensForApplication**
> List&lt;OAuth2Token&gt; ListOAuth2TokensForApplication (string appId, string expand = null, string after = null, int? limit = null)

List all OAuth 2.0 Tokens

Lists all tokens for the application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListOAuth2TokensForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationTokensApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var expand = "expand_example";  // string |  (optional) 
            var after = "after_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // List all OAuth 2.0 Tokens
                List<OAuth2Token> result = apiInstance.ListOAuth2TokensForApplication(appId, expand, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationTokensApi.ListOAuth2TokensForApplication: " + e.Message );
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
 **appId** | **string**| ID of the Application | 
 **expand** | **string**|  | [optional] 
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to 20]

### Return type

[**List&lt;OAuth2Token&gt;**](OAuth2Token.md)

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

<a name="revokeoauth2tokenforapplication"></a>
# **RevokeOAuth2TokenForApplication**
> void RevokeOAuth2TokenForApplication (string appId, string tokenId)

Revoke an OAuth 2.0 Token

Revokes the specified token for the specified application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeOAuth2TokenForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationTokensApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var tokenId = sHHSth53yJAyNSTQKDJZ;  // string | `id` of Token

            try
            {
                // Revoke an OAuth 2.0 Token
                apiInstance.RevokeOAuth2TokenForApplication(appId, tokenId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationTokensApi.RevokeOAuth2TokenForApplication: " + e.Message );
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
 **appId** | **string**| ID of the Application | 
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

<a name="revokeoauth2tokensforapplication"></a>
# **RevokeOAuth2TokensForApplication**
> void RevokeOAuth2TokensForApplication (string appId)

Revoke all OAuth 2.0 Tokens

Revokes all tokens for the specified application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeOAuth2TokensForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationTokensApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application

            try
            {
                // Revoke all OAuth 2.0 Tokens
                apiInstance.RevokeOAuth2TokensForApplication(appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationTokensApi.RevokeOAuth2TokensForApplication: " + e.Message );
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
 **appId** | **string**| ID of the Application | 

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

