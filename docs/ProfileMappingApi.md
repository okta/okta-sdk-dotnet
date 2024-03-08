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

Retrieves a single Profile Mapping referenced by its ID

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
            var mappingId = cB6u7X8mptebWkffatKA;  // string | `id` of the Mapping

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
 **mappingId** | **string**| &#x60;id&#x60; of the Mapping | 

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listprofilemappings"></a>
# **ListProfileMappings**
> List&lt;ListProfileMappings&gt; ListProfileMappings (string after = null, int? limit = null, string sourceId = null, string targetId = null)

List all Profile Mappings

Lists all profile mappings in your organization with [pagination](https://developer.okta.com/docs/api/#pagination). You can return a subset of profile mappings that match a supported `sourceId` and/or `targetId`. The results are [paginated](/#pagination) according to the limit parameter. If there are multiple pages of results, the Link header contains a `next` link that should be treated as an opaque value (follow it, don't parse it).  The response is a collection of profile mappings that include a subset of the profile mapping object's parameters. The profile mapping object describes the properties mapping between an Okta User and an App User Profile using [JSON Schema Draft 4](https://datatracker.ietf.org/doc/html/draft-zyp-json-schema-04).

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
            var after = "after_example";  // string | Mapping `id` that specifies the pagination cursor for the next page of mappings (optional) 
            var limit = 20;  // int? | Specifies the number of results per page (maximum 200) (optional)  (default to 20)
            var sourceId = "sourceId_example";  // string | The UserType or App Instance `id` that acts as the source of expressions in a mapping. If this parameter is included, all returned mappings have this as their `source.id`. (optional) 
            var targetId = "targetId_example";  // string | The UserType or App Instance `id` that acts as the target of expressions in a mapping. If this parameter is included, all returned mappings have this as their `target.id`. (optional) 

            try
            {
                // List all Profile Mappings
                List<ListProfileMappings> result = apiInstance.ListProfileMappings(after, limit, sourceId, targetId).ToListAsync();
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
 **after** | **string**| Mapping &#x60;id&#x60; that specifies the pagination cursor for the next page of mappings | [optional] 
 **limit** | **int?**| Specifies the number of results per page (maximum 200) | [optional] [default to 20]
 **sourceId** | **string**| The UserType or App Instance &#x60;id&#x60; that acts as the source of expressions in a mapping. If this parameter is included, all returned mappings have this as their &#x60;source.id&#x60;. | [optional] 
 **targetId** | **string**| The UserType or App Instance &#x60;id&#x60; that acts as the target of expressions in a mapping. If this parameter is included, all returned mappings have this as their &#x60;target.id&#x60;. | [optional] 

### Return type

[**List&lt;ListProfileMappings&gt;**](ListProfileMappings.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateprofilemapping"></a>
# **UpdateProfileMapping**
> ProfileMapping UpdateProfileMapping (string mappingId, ProfileMappingRequest profileMapping)

Update a Profile Mapping

Updates an existing profile mapping by adding, updating, or removing one or many property mappings

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
            var mappingId = cB6u7X8mptebWkffatKA;  // string | `id` of the Mapping
            var profileMapping = new ProfileMappingRequest(); // ProfileMappingRequest | 

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
 **mappingId** | **string**| &#x60;id&#x60; of the Mapping | 
 **profileMapping** | [**ProfileMappingRequest**](ProfileMappingRequest.md)|  | 

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
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

