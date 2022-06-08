# Okta.Sdk.Api.PrincipalRateLimitApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreatePrincipalRateLimitEntity**](PrincipalRateLimitApi.md#createprincipalratelimitentity) | **POST** /api/v1/principal-rate-limits | Create Principal Rate Limit entity
[**GetPrincipalRateLimitEntity**](PrincipalRateLimitApi.md#getprincipalratelimitentity) | **GET** /api/v1/principal-rate-limits/{principalRateLimitId} | Get Principal Rate Limit entity
[**ListPrincipalRateLimitEntities**](PrincipalRateLimitApi.md#listprincipalratelimitentities) | **GET** /api/v1/principal-rate-limits | List Principal Rate Limit entities
[**UpdatePrincipalRateLimitEntity**](PrincipalRateLimitApi.md#updateprincipalratelimitentity) | **PUT** /api/v1/principal-rate-limits/{principalRateLimitId} | Update Principal Rate Limit entity


<a name="createprincipalratelimitentity"></a>
# **CreatePrincipalRateLimitEntity**
> PrincipalRateLimitEntity CreatePrincipalRateLimitEntity (PrincipalRateLimitEntity entity)

Create Principal Rate Limit entity

Adds a new Principal Rate Limit entity to your organization. In the current release, we only allow one Principal Rate Limit entity per org and principal.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreatePrincipalRateLimitEntityExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PrincipalRateLimitApi(config);
            var entity = new PrincipalRateLimitEntity(); // PrincipalRateLimitEntity | 

            try
            {
                // Create Principal Rate Limit entity
                PrincipalRateLimitEntity result = apiInstance.CreatePrincipalRateLimitEntity(entity);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PrincipalRateLimitApi.CreatePrincipalRateLimitEntity: " + e.Message );
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
 **entity** | [**PrincipalRateLimitEntity**](PrincipalRateLimitEntity.md)|  | 

### Return type

[**PrincipalRateLimitEntity**](PrincipalRateLimitEntity.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

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

<a name="getprincipalratelimitentity"></a>
# **GetPrincipalRateLimitEntity**
> PrincipalRateLimitEntity GetPrincipalRateLimitEntity (string principalRateLimitId)

Get Principal Rate Limit entity

Fetches a Principal Rate Limit entity by `principalRateLimitId`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetPrincipalRateLimitEntityExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PrincipalRateLimitApi(config);
            var principalRateLimitId = abcd1234;  // string | id of the Principal Rate Limit

            try
            {
                // Get Principal Rate Limit entity
                PrincipalRateLimitEntity result = apiInstance.GetPrincipalRateLimitEntity(principalRateLimitId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PrincipalRateLimitApi.GetPrincipalRateLimitEntity: " + e.Message );
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
 **principalRateLimitId** | **string**| id of the Principal Rate Limit | 

### Return type

[**PrincipalRateLimitEntity**](PrincipalRateLimitEntity.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

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

<a name="listprincipalratelimitentities"></a>
# **ListPrincipalRateLimitEntities**
> List&lt;PrincipalRateLimitEntity&gt; ListPrincipalRateLimitEntities (string filter = null, string after = null, int? limit = null)

List Principal Rate Limit entities

Lists all Principal Rate Limit entities considering the provided parameters.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListPrincipalRateLimitEntitiesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PrincipalRateLimitApi(config);
            var filter = "filter_example";  // string |  (optional) 
            var after = "after_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // List Principal Rate Limit entities
                List<PrincipalRateLimitEntity> result = apiInstance.ListPrincipalRateLimitEntities(filter, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PrincipalRateLimitApi.ListPrincipalRateLimitEntities: " + e.Message );
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
 **filter** | **string**|  | [optional] 
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to 20]

### Return type

[**List&lt;PrincipalRateLimitEntity&gt;**](PrincipalRateLimitEntity.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateprincipalratelimitentity"></a>
# **UpdatePrincipalRateLimitEntity**
> PrincipalRateLimitEntity UpdatePrincipalRateLimitEntity (string principalRateLimitId, PrincipalRateLimitEntity entity)

Update Principal Rate Limit entity

Update a  Principal Rate Limit entity by `principalRateLimitId`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdatePrincipalRateLimitEntityExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PrincipalRateLimitApi(config);
            var principalRateLimitId = abcd1234;  // string | id of the Principal Rate Limit
            var entity = new PrincipalRateLimitEntity(); // PrincipalRateLimitEntity | 

            try
            {
                // Update Principal Rate Limit entity
                PrincipalRateLimitEntity result = apiInstance.UpdatePrincipalRateLimitEntity(principalRateLimitId, entity);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PrincipalRateLimitApi.UpdatePrincipalRateLimitEntity: " + e.Message );
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
 **principalRateLimitId** | **string**| id of the Principal Rate Limit | 
 **entity** | [**PrincipalRateLimitEntity**](PrincipalRateLimitEntity.md)|  | 

### Return type

[**PrincipalRateLimitEntity**](PrincipalRateLimitEntity.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

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

