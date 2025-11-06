# Okta.Sdk.Api.PrincipalRateLimitApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreatePrincipalRateLimitEntity**](PrincipalRateLimitApi.md#createprincipalratelimitentity) | **POST** /api/v1/principal-rate-limits | Create a principal rate limit
[**GetPrincipalRateLimitEntity**](PrincipalRateLimitApi.md#getprincipalratelimitentity) | **GET** /api/v1/principal-rate-limits/{principalRateLimitId} | Retrieve a principal rate limit
[**ListPrincipalRateLimitEntities**](PrincipalRateLimitApi.md#listprincipalratelimitentities) | **GET** /api/v1/principal-rate-limits | List all principal rate limits
[**ReplacePrincipalRateLimitEntity**](PrincipalRateLimitApi.md#replaceprincipalratelimitentity) | **PUT** /api/v1/principal-rate-limits/{principalRateLimitId} | Replace a principal rate limit


<a name="createprincipalratelimitentity"></a>
# **CreatePrincipalRateLimitEntity**
> PrincipalRateLimitEntity CreatePrincipalRateLimitEntity (PrincipalRateLimitEntity entity)

Create a principal rate limit

Creates a new principal rate limit entity. Okta only allows one principal rate limit entity per org and principal.

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
                // Create a principal rate limit
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getprincipalratelimitentity"></a>
# **GetPrincipalRateLimitEntity**
> PrincipalRateLimitEntity GetPrincipalRateLimitEntity (string principalRateLimitId)

Retrieve a principal rate limit

Retrieves a principal rate limit entity by `principalRateLimitId`

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
            var principalRateLimitId = 0oacamvryxiyMqgiY1d7;  // string | ID of the principal rate limit

            try
            {
                // Retrieve a principal rate limit
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
 **principalRateLimitId** | **string**| ID of the principal rate limit | 

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listprincipalratelimitentities"></a>
# **ListPrincipalRateLimitEntities**
> List&lt;PrincipalRateLimitEntity&gt; ListPrincipalRateLimitEntities (string filter, string after = null, int? limit = null)

List all principal rate limits

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
            var filter = "filter_example";  // string | Filters the list of principal rate limit entities by the provided principal type (`principalType`). For example, `filter=principalType eq \"SSWS_TOKEN\"` or `filter=principalType eq \"OAUTH_CLIENT\"`.
            var after = "after_example";  // string | The cursor to use for pagination. It's an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | Specifies the number of items to return in a single response page. (optional)  (default to 20)

            try
            {
                // List all principal rate limits
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
 **filter** | **string**| Filters the list of principal rate limit entities by the provided principal type (&#x60;principalType&#x60;). For example, &#x60;filter&#x3D;principalType eq \&quot;SSWS_TOKEN\&quot;&#x60; or &#x60;filter&#x3D;principalType eq \&quot;OAUTH_CLIENT\&quot;&#x60;. | 
 **after** | **string**| The cursor to use for pagination. It&#39;s an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| Specifies the number of items to return in a single response page. | [optional] [default to 20]

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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceprincipalratelimitentity"></a>
# **ReplacePrincipalRateLimitEntity**
> PrincipalRateLimitEntity ReplacePrincipalRateLimitEntity (string principalRateLimitId, PrincipalRateLimitEntity entity)

Replace a principal rate limit

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
            var principalRateLimitId = 0oacamvryxiyMqgiY1d7;  // string | ID of the principal rate limit
            var entity = new PrincipalRateLimitEntity(); // PrincipalRateLimitEntity | 

            try
            {
                // Replace a principal rate limit
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
 **principalRateLimitId** | **string**| ID of the principal rate limit | 
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

