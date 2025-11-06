# Okta.Sdk.Api.ApiTokenApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetApiToken**](ApiTokenApi.md#getapitoken) | **GET** /api/v1/api-tokens/{apiTokenId} | Retrieve an API token&#39;s metadata
[**ListApiTokens**](ApiTokenApi.md#listapitokens) | **GET** /api/v1/api-tokens | List all API token metadata
[**RevokeApiToken**](ApiTokenApi.md#revokeapitoken) | **DELETE** /api/v1/api-tokens/{apiTokenId} | Revoke an API token
[**RevokeCurrentApiToken**](ApiTokenApi.md#revokecurrentapitoken) | **DELETE** /api/v1/api-tokens/current | Revoke the current API token
[**UpsertApiToken**](ApiTokenApi.md#upsertapitoken) | **PUT** /api/v1/api-tokens/{apiTokenId} | Upsert an API token network condition


<a name="getapitoken"></a>
# **GetApiToken**
> ApiToken GetApiToken (string apiTokenId)

Retrieve an API token's metadata

Retrieves the metadata for an active API token by `apiTokenId`

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
                // Retrieve an API token's metadata
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
> List&lt;ApiToken&gt; ListApiTokens ()

List all API token metadata

Lists all the metadata of the active API tokens

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

            try
            {
                // List all API token metadata
                List<ApiToken> result = apiInstance.ListApiTokens().ToListAsync();
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
This endpoint does not need any parameter.

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

Revoke an API token

Revokes an API token by `apiTokenId`

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
                // Revoke an API token
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

Revoke the current API token

Revokes the API token provided in the Authorization header

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
                // Revoke the current API token
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

<a name="upsertapitoken"></a>
# **UpsertApiToken**
> ApiToken UpsertApiToken (string apiTokenId, ApiTokenUpdate apiTokenUpdate)

Upsert an API token network condition

Upserts an API Token Network Condition by `apiTokenId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpsertApiTokenExample
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
            var apiTokenUpdate = new ApiTokenUpdate(); // ApiTokenUpdate | 

            try
            {
                // Upsert an API token network condition
                ApiToken result = apiInstance.UpsertApiToken(apiTokenId, apiTokenUpdate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApiTokenApi.UpsertApiToken: " + e.Message );
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
 **apiTokenUpdate** | [**ApiTokenUpdate**](ApiTokenUpdate.md)|  | 

### Return type

[**ApiToken**](ApiToken.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

