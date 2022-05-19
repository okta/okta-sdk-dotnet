# Org.OpenAPITools.Api.NetworkZoneApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateNetworkZone**](NetworkZoneApi.md#activatenetworkzone) | **POST** /api/v1/zones/{zoneId}/lifecycle/activate | Activate Network Zone
[**CreateNetworkZone**](NetworkZoneApi.md#createnetworkzone) | **POST** /api/v1/zones | Add Network Zone
[**DeactivateNetworkZone**](NetworkZoneApi.md#deactivatenetworkzone) | **POST** /api/v1/zones/{zoneId}/lifecycle/deactivate | Deactivate Network Zone
[**DeleteNetworkZone**](NetworkZoneApi.md#deletenetworkzone) | **DELETE** /api/v1/zones/{zoneId} | Delete Network Zone
[**GetNetworkZone**](NetworkZoneApi.md#getnetworkzone) | **GET** /api/v1/zones/{zoneId} | Get Network Zone
[**ListNetworkZones**](NetworkZoneApi.md#listnetworkzones) | **GET** /api/v1/zones | List Network Zones
[**UpdateNetworkZone**](NetworkZoneApi.md#updatenetworkzone) | **PUT** /api/v1/zones/{zoneId} | Update Network Zone


<a name="activatenetworkzone"></a>
# **ActivateNetworkZone**
> NetworkZone ActivateNetworkZone (string zoneId)

Activate Network Zone

Activate Network Zone

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ActivateNetworkZoneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new NetworkZoneApi(config);
            var zoneId = "zoneId_example";  // string | 

            try
            {
                // Activate Network Zone
                NetworkZone result = apiInstance.ActivateNetworkZone(zoneId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NetworkZoneApi.ActivateNetworkZone: " + e.Message );
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
 **zoneId** | **string**|  | 

### Return type

[**NetworkZone**](NetworkZone.md)

### Authorization

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createnetworkzone"></a>
# **CreateNetworkZone**
> NetworkZone CreateNetworkZone (NetworkZone zone)

Add Network Zone

Adds a new network zone to your Okta organization.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class CreateNetworkZoneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new NetworkZoneApi(config);
            var zone = new NetworkZone(); // NetworkZone | 

            try
            {
                // Add Network Zone
                NetworkZone result = apiInstance.CreateNetworkZone(zone);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NetworkZoneApi.CreateNetworkZone: " + e.Message );
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
 **zone** | [**NetworkZone**](NetworkZone.md)|  | 

### Return type

[**NetworkZone**](NetworkZone.md)

### Authorization

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivatenetworkzone"></a>
# **DeactivateNetworkZone**
> NetworkZone DeactivateNetworkZone (string zoneId)

Deactivate Network Zone

Deactivates a network zone.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class DeactivateNetworkZoneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new NetworkZoneApi(config);
            var zoneId = "zoneId_example";  // string | 

            try
            {
                // Deactivate Network Zone
                NetworkZone result = apiInstance.DeactivateNetworkZone(zoneId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NetworkZoneApi.DeactivateNetworkZone: " + e.Message );
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
 **zoneId** | **string**|  | 

### Return type

[**NetworkZone**](NetworkZone.md)

### Authorization

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletenetworkzone"></a>
# **DeleteNetworkZone**
> void DeleteNetworkZone (string zoneId)

Delete Network Zone

Removes network zone.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class DeleteNetworkZoneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new NetworkZoneApi(config);
            var zoneId = "zoneId_example";  // string | 

            try
            {
                // Delete Network Zone
                apiInstance.DeleteNetworkZone(zoneId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NetworkZoneApi.DeleteNetworkZone: " + e.Message );
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
 **zoneId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getnetworkzone"></a>
# **GetNetworkZone**
> NetworkZone GetNetworkZone (string zoneId)

Get Network Zone

Fetches a network zone from your Okta organization by `id`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetNetworkZoneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new NetworkZoneApi(config);
            var zoneId = "zoneId_example";  // string | 

            try
            {
                // Get Network Zone
                NetworkZone result = apiInstance.GetNetworkZone(zoneId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NetworkZoneApi.GetNetworkZone: " + e.Message );
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
 **zoneId** | **string**|  | 

### Return type

[**NetworkZone**](NetworkZone.md)

### Authorization

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listnetworkzones"></a>
# **ListNetworkZones**
> List&lt;NetworkZone&gt; ListNetworkZones (string after = null, int? limit = null, string filter = null)

List Network Zones

Enumerates network zones added to your organization with pagination. A subset of zones can be returned that match a supported filter expression or query.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ListNetworkZonesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new NetworkZoneApi(config);
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of network zones (optional) 
            var limit = -1;  // int? | Specifies the number of results for a page (optional)  (default to -1)
            var filter = "filter_example";  // string | Filters zones by usage or id expression (optional) 

            try
            {
                // List Network Zones
                List<NetworkZone> result = apiInstance.ListNetworkZones(after, limit, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NetworkZoneApi.ListNetworkZones: " + e.Message );
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
 **after** | **string**| Specifies the pagination cursor for the next page of network zones | [optional] 
 **limit** | **int?**| Specifies the number of results for a page | [optional] [default to -1]
 **filter** | **string**| Filters zones by usage or id expression | [optional] 

### Return type

[**List&lt;NetworkZone&gt;**](NetworkZone.md)

### Authorization

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatenetworkzone"></a>
# **UpdateNetworkZone**
> NetworkZone UpdateNetworkZone (string zoneId, NetworkZone zone)

Update Network Zone

Updates a network zone in your organization.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UpdateNetworkZoneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new NetworkZoneApi(config);
            var zoneId = "zoneId_example";  // string | 
            var zone = new NetworkZone(); // NetworkZone | 

            try
            {
                // Update Network Zone
                NetworkZone result = apiInstance.UpdateNetworkZone(zoneId, zone);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NetworkZoneApi.UpdateNetworkZone: " + e.Message );
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
 **zoneId** | **string**|  | 
 **zone** | [**NetworkZone**](NetworkZone.md)|  | 

### Return type

[**NetworkZone**](NetworkZone.md)

### Authorization

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

