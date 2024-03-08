# Okta.Sdk.Api.PrincipalRateLimitApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreatePrincipalRateLimitEntity**](PrincipalRateLimitApi.md#createprincipalratelimitentity) | **POST** /api/v1/principal-rate-limits | Create a Principal Rate Limit
[**GetPrincipalRateLimitEntity**](PrincipalRateLimitApi.md#getprincipalratelimitentity) | **GET** /api/v1/principal-rate-limits/{principalRateLimitId} | Retrieve a Principal Rate Limit
[**ListPrincipalRateLimitEntities**](PrincipalRateLimitApi.md#listprincipalratelimitentities) | **GET** /api/v1/principal-rate-limits | List all Principal Rate Limits
[**ReplacePrincipalRateLimitEntity**](PrincipalRateLimitApi.md#replaceprincipalratelimitentity) | **PUT** /api/v1/principal-rate-limits/{principalRateLimitId} | Replace a Principal Rate Limit


<a name="createprincipalratelimitentity"></a>
# **CreatePrincipalRateLimitEntity**
> PrincipalRateLimitEntity CreatePrincipalRateLimitEntity (PrincipalRateLimitEntity entity)

Create a Principal Rate Limit

Creates a new Principal Rate Limit entity. In the current release, we only allow one Principal Rate Limit entity per org and principal.

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PrincipalRateLimitApi(config);
            var entity = new PrincipalRateLimitEntity(); // PrincipalRateLimitEntity | 

            try
            {
                // Create a Principal Rate Limit
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

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getprincipalratelimitentity"></a>
# **GetPrincipalRateLimitEntity**
> PrincipalRateLimitEntity GetPrincipalRateLimitEntity (string principalRateLimitId)

Retrieve a Principal Rate Limit

Retrieves a Principal Rate Limit entity by `principalRateLimitId`

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PrincipalRateLimitApi(config);
            var principalRateLimitId = abcd1234;  // string | id of the Principal Rate Limit

            try
            {
                // Retrieve a Principal Rate Limit
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

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listprincipalratelimitentities"></a>
# **ListPrincipalRateLimitEntities**
> List&lt;PrincipalRateLimitEntity&gt; ListPrincipalRateLimitEntities (string filter = null, string after = null, int? limit = null)

List all Principal Rate Limits

Lists all Principal Rate Limit entities considering the provided parameters

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PrincipalRateLimitApi(config);
            var filter = "filter_example";  // string |  (optional) 
            var after = "after_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // List all Principal Rate Limits
                List<PrincipalRateLimitEntity> result = apiInstance.ListPrincipalRateLimitEntities(filter, after, limit).ToListAsync();
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

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceprincipalratelimitentity"></a>
# **ReplacePrincipalRateLimitEntity**
> PrincipalRateLimitEntity ReplacePrincipalRateLimitEntity (string principalRateLimitId, PrincipalRateLimitEntity entity)

Replace a Principal Rate Limit

Replaces a principal rate limit entity by `principalRateLimitId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplacePrincipalRateLimitEntityExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PrincipalRateLimitApi(config);
            var principalRateLimitId = abcd1234;  // string | id of the Principal Rate Limit
            var entity = new PrincipalRateLimitEntity(); // PrincipalRateLimitEntity | 

            try
            {
                // Replace a Principal Rate Limit
                PrincipalRateLimitEntity result = apiInstance.ReplacePrincipalRateLimitEntity(principalRateLimitId, entity);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PrincipalRateLimitApi.ReplacePrincipalRateLimitEntity: " + e.Message );
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

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

