# Okta.Sdk.Api.ProfileMappingApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetProfileMapping**](ProfileMappingApi.md#getprofilemapping) | **GET** /api/v1/mappings/{mappingId} | Retrieve a Profile Mapping
[**ListProfileMappings**](ProfileMappingApi.md#listprofilemappings) | **GET** /api/v1/mappings | List all Profile Mappings
[**UpdateProfileMapping**](ProfileMappingApi.md#updateprofilemapping) | **POST** /api/v1/mappings/{mappingId} | Update a Profile Mapping


<a name="getprofilemapping"></a>
# **GetProfileMapping**
> ProfileMapping GetProfileMapping (string mappingId)

Retrieve a Profile Mapping

Fetches a single Profile Mapping referenced by its ID.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetProfileMappingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ProfileMappingApi(config);
            var mappingId = "mappingId_example";  // string | 

            try
            {
                // Retrieve a Profile Mapping
                ProfileMapping result = apiInstance.GetProfileMapping(mappingId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ProfileMappingApi.GetProfileMapping: " + e.Message );
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
 **mappingId** | **string**|  | 

### Return type

[**ProfileMapping**](ProfileMapping.md)

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

<a name="listprofilemappings"></a>
# **ListProfileMappings**
> List&lt;ProfileMapping&gt; ListProfileMappings (string after = null, int? limit = null, string sourceId = null, string targetId = null)

List all Profile Mappings

Enumerates Profile Mappings in your organization with pagination.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListProfileMappingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ProfileMappingApi(config);
            var after = "after_example";  // string |  (optional) 
            var limit = -1;  // int? |  (optional)  (default to -1)
            var sourceId = "sourceId_example";  // string |  (optional) 
            var targetId = "\"\"";  // string |  (optional)  (default to "")

            try
            {
                // List all Profile Mappings
                List<ProfileMapping> result = apiInstance.ListProfileMappings(after, limit, sourceId, targetId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ProfileMappingApi.ListProfileMappings: " + e.Message );
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
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to -1]
 **sourceId** | **string**|  | [optional] 
 **targetId** | **string**|  | [optional] [default to &quot;&quot;]

### Return type

[**List&lt;ProfileMapping&gt;**](ProfileMapping.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateprofilemapping"></a>
# **UpdateProfileMapping**
> ProfileMapping UpdateProfileMapping (string mappingId, ProfileMapping profileMapping)

Update a Profile Mapping

Updates an existing Profile Mapping by adding, updating, or removing one or many Property Mappings.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateProfileMappingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ProfileMappingApi(config);
            var mappingId = "mappingId_example";  // string | 
            var profileMapping = new ProfileMapping(); // ProfileMapping | 

            try
            {
                // Update a Profile Mapping
                ProfileMapping result = apiInstance.UpdateProfileMapping(mappingId, profileMapping);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ProfileMappingApi.UpdateProfileMapping: " + e.Message );
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
 **mappingId** | **string**|  | 
 **profileMapping** | [**ProfileMapping**](ProfileMapping.md)|  | 

### Return type

[**ProfileMapping**](ProfileMapping.md)

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

