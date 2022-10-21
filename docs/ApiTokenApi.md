# Okta.Sdk.Api.ApiTokenApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetApiToken**](ApiTokenApi.md#getapitoken) | **GET** /api/v1/api-tokens/{apiTokenId} | Retrieve an API Token&#39;s Metadata
[**ListApiTokens**](ApiTokenApi.md#listapitokens) | **GET** /api/v1/api-tokens | List all API Token Metadata
[**RevokeApiToken**](ApiTokenApi.md#revokeapitoken) | **DELETE** /api/v1/api-tokens/{apiTokenId} | Revoke an API Token
[**RevokeCurrentApiToken**](ApiTokenApi.md#revokecurrentapitoken) | **DELETE** /api/v1/api-tokens/current | Revoke the Current API Token


<a name="getapitoken"></a>
# **GetApiToken**
> ApiToken GetApiToken (string apiTokenId)

Retrieve an API Token's Metadata

Get the metadata for an active API token by id.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetApiTokenExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApiTokenApi(config);
            var apiTokenId = 00Tabcdefg1234567890;  // string | id of the API Token

            try
            {
                // Retrieve an API Token's Metadata
                ApiToken result = apiInstance.GetApiToken(apiTokenId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApiTokenApi.GetApiToken: " + e.Message );
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
 **apiTokenId** | **string**| id of the API Token | 

### Return type

[**ApiToken**](ApiToken.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listapitokens"></a>
# **ListApiTokens**
> List&lt;ApiToken&gt; ListApiTokens (string after = null, int? limit = null, string q = null)

List all API Token Metadata

Enumerates the metadata of the active API tokens in your organization.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListApiTokensExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApiTokenApi(config);
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](/#pagination) for more information. (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return. (optional)  (default to 20)
            var q = "q_example";  // string | Finds a token that matches the name or clientName. (optional) 

            try
            {
                // List all API Token Metadata
                List<ApiToken> result = apiInstance.ListApiTokens(after, limit, q).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApiTokenApi.ListApiTokens: " + e.Message );
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](/#pagination) for more information. | [optional] 
 **limit** | **int?**| A limit on the number of objects to return. | [optional] [default to 20]
 **q** | **string**| Finds a token that matches the name or clientName. | [optional] 

### Return type

[**List&lt;ApiToken&gt;**](ApiToken.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="revokeapitoken"></a>
# **RevokeApiToken**
> void RevokeApiToken (string apiTokenId)

Revoke an API Token

Revoke an API token by id.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeApiTokenExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApiTokenApi(config);
            var apiTokenId = 00Tabcdefg1234567890;  // string | id of the API Token

            try
            {
                // Revoke an API Token
                apiInstance.RevokeApiToken(apiTokenId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApiTokenApi.RevokeApiToken: " + e.Message );
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
 **apiTokenId** | **string**| id of the API Token | 

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

<a name="revokecurrentapitoken"></a>
# **RevokeCurrentApiToken**
> void RevokeCurrentApiToken ()

Revoke the Current API Token

Revokes the API token provided in the Authorization header.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeCurrentApiTokenExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";

            var apiInstance = new ApiTokenApi(config);

            try
            {
                // Revoke the Current API Token
                apiInstance.RevokeCurrentApiToken();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApiTokenApi.RevokeCurrentApiToken: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

