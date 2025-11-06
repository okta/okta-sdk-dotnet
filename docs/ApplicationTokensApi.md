# Okta.Sdk.Api.ApplicationTokensApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetOAuth2TokenForApplication**](ApplicationTokensApi.md#getoauth2tokenforapplication) | **GET** /api/v1/apps/{appId}/tokens/{tokenId} | Retrieve an application token
[**ListOAuth2TokensForApplication**](ApplicationTokensApi.md#listoauth2tokensforapplication) | **GET** /api/v1/apps/{appId}/tokens | List all application refresh tokens
[**RevokeOAuth2TokenForApplication**](ApplicationTokensApi.md#revokeoauth2tokenforapplication) | **DELETE** /api/v1/apps/{appId}/tokens/{tokenId} | Revoke an application token
[**RevokeOAuth2TokensForApplication**](ApplicationTokensApi.md#revokeoauth2tokensforapplication) | **DELETE** /api/v1/apps/{appId}/tokens | Revoke all application tokens


<a name="getoauth2tokenforapplication"></a>
# **GetOAuth2TokenForApplication**
> OAuth2RefreshToken GetOAuth2TokenForApplication (string appId, string tokenId, string expand = null)

Retrieve an application token

Retrieves a refresh token for the specified app

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
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var tokenId = sHHSth53yJAyNSTQKDJZ;  // string | `id` of Token
            var expand = scope;  // string | An optional parameter to return scope details in the `_embedded` property. Valid value: `scope` (optional) 

            try
            {
                // Retrieve an application token
                OAuth2RefreshToken result = apiInstance.GetOAuth2TokenForApplication(appId, tokenId, expand);
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
 **appId** | **string**| Application ID | 
 **tokenId** | **string**| &#x60;id&#x60; of Token | 
 **expand** | **string**| An optional parameter to return scope details in the &#x60;_embedded&#x60; property. Valid value: &#x60;scope&#x60; | [optional] 

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

<a name="listoauth2tokensforapplication"></a>
# **ListOAuth2TokensForApplication**
> List&lt;OAuth2RefreshToken&gt; ListOAuth2TokensForApplication (string appId, string expand = null, string after = null, int? limit = null)

List all application refresh tokens

Lists all refresh tokens for an app  > **Note:** The results are [paginated](/#pagination) according to the `limit` parameter. > If there are multiple pages of results, the Link header contains a `next` link that you need to use as an opaque value (follow it, don't parse it). 

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
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var expand = scope;  // string | An optional parameter to return scope details in the `_embedded` property. Valid value: `scope` (optional) 
            var after = 16275000448691;  // string | Specifies the pagination cursor for the next page of results. Treat this as an opaque value obtained through the next link relationship. See [Pagination](/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)

            try
            {
                // List all application refresh tokens
                List<OAuth2RefreshToken> result = apiInstance.ListOAuth2TokensForApplication(appId, expand, after, limit).ToListAsync();
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
 **appId** | **string**| Application ID | 
 **expand** | **string**| An optional parameter to return scope details in the &#x60;_embedded&#x60; property. Valid value: &#x60;scope&#x60; | [optional] 
 **after** | **string**| Specifies the pagination cursor for the next page of results. Treat this as an opaque value obtained through the next link relationship. See [Pagination](/#pagination). | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]

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

<a name="revokeoauth2tokenforapplication"></a>
# **RevokeOAuth2TokenForApplication**
> void RevokeOAuth2TokenForApplication (string appId, string tokenId)

Revoke an application token

Revokes the specified token for the specified app

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
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var tokenId = sHHSth53yJAyNSTQKDJZ;  // string | `id` of Token

            try
            {
                // Revoke an application token
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
 **appId** | **string**| Application ID | 
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

Revoke all application tokens

Revokes all OAuth 2.0 refresh tokens for the specified app. Any access tokens issued with these refresh tokens are also revoked, but access tokens issued without a refresh token aren't affected.

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
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // Revoke all application tokens
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
 **appId** | **string**| Application ID | 

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

