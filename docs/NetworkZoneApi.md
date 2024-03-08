# Okta.Sdk.Api.NetworkZoneApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateNetworkZone**](NetworkZoneApi.md#activatenetworkzone) | **POST** /api/v1/zones/{zoneId}/lifecycle/activate | Activate a Network Zone
[**CreateNetworkZone**](NetworkZoneApi.md#createnetworkzone) | **POST** /api/v1/zones | Create a Network Zone
[**DeactivateNetworkZone**](NetworkZoneApi.md#deactivatenetworkzone) | **POST** /api/v1/zones/{zoneId}/lifecycle/deactivate | Deactivate a Network Zone
[**DeleteNetworkZone**](NetworkZoneApi.md#deletenetworkzone) | **DELETE** /api/v1/zones/{zoneId} | Delete a Network Zone
[**GetNetworkZone**](NetworkZoneApi.md#getnetworkzone) | **GET** /api/v1/zones/{zoneId} | Retrieve a Network Zone
[**ListNetworkZones**](NetworkZoneApi.md#listnetworkzones) | **GET** /api/v1/zones | List all Network Zones
[**ReplaceNetworkZone**](NetworkZoneApi.md#replacenetworkzone) | **PUT** /api/v1/zones/{zoneId} | Replace a Network Zone


<a name="activatenetworkzone"></a>
# **ActivateNetworkZone**
> NetworkZone ActivateNetworkZone (string zoneId)

Activate a Network Zone

Activates a network zone by `zoneId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateNetworkZoneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new NetworkZoneApi(config);
            var zoneId = nzowc1U5Jh5xuAK0o0g3;  // string | `id` of the Network Zone

            try
            {
                // Activate a Network Zone
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
 **zoneId** | **string**| &#x60;id&#x60; of the Network Zone | 

### Return type

[**NetworkZone**](NetworkZone.md)

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

<a name="createnetworkzone"></a>
# **CreateNetworkZone**
> NetworkZone CreateNetworkZone (NetworkZone zone)

Create a Network Zone

Creates a new network zone. * At least one of either the `gateways` attribute or `proxies` attribute must be defined when creating a Network Zone. * At least one of the following attributes must be defined: `proxyType`, `locations`, or `asns`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateNetworkZoneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new NetworkZoneApi(config);
            var zone = new NetworkZone(); // NetworkZone | 

            try
            {
                // Create a Network Zone
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
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivatenetworkzone"></a>
# **DeactivateNetworkZone**
> NetworkZone DeactivateNetworkZone (string zoneId)

Deactivate a Network Zone

Deactivates a network zone by `zoneId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateNetworkZoneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new NetworkZoneApi(config);
            var zoneId = nzowc1U5Jh5xuAK0o0g3;  // string | `id` of the Network Zone

            try
            {
                // Deactivate a Network Zone
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
 **zoneId** | **string**| &#x60;id&#x60; of the Network Zone | 

### Return type

[**NetworkZone**](NetworkZone.md)

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

<a name="deletenetworkzone"></a>
# **DeleteNetworkZone**
> void DeleteNetworkZone (string zoneId)

Delete a Network Zone

Deletes network zone by `zoneId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteNetworkZoneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new NetworkZoneApi(config);
            var zoneId = nzowc1U5Jh5xuAK0o0g3;  // string | `id` of the Network Zone

            try
            {
                // Delete a Network Zone
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
 **zoneId** | **string**| &#x60;id&#x60; of the Network Zone | 

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getnetworkzone"></a>
# **GetNetworkZone**
> NetworkZone GetNetworkZone (string zoneId)

Retrieve a Network Zone

Retrieves a network zone by `zoneId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetNetworkZoneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new NetworkZoneApi(config);
            var zoneId = nzowc1U5Jh5xuAK0o0g3;  // string | `id` of the Network Zone

            try
            {
                // Retrieve a Network Zone
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
 **zoneId** | **string**| &#x60;id&#x60; of the Network Zone | 

### Return type

[**NetworkZone**](NetworkZone.md)

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

<a name="listnetworkzones"></a>
# **ListNetworkZones**
> List&lt;NetworkZone&gt; ListNetworkZones (string after = null, int? limit = null, string filter = null)

List all Network Zones

Lists all network zones with pagination. A subset of zones can be returned that match a supported filter expression or query.  This operation requires URL encoding. For example, `filter=(id eq \"nzoul0wf9jyb8xwZm0g3\" or id eq \"nzoul1MxmGN18NDQT0g3\")` is encoded as `filter=%28id+eq+%22nzoul0wf9jyb8xwZm0g3%22+or+id+eq+%22nzoul1MxmGN18NDQT0g3%22%29`.  Okta supports filtering on the `id` and `usage` properties. See [Filtering](https://developer.okta.com/docs/reference/core-okta-api/#filter) for more information on the expressions that are used in filtering.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListNetworkZonesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new NetworkZoneApi(config);
            var after = 200u7yq5goxNFTiMjW1d7;  // string | Specifies the pagination cursor for the next page of network zones (optional) 
            var limit = 5;  // int? | Specifies the number of results for a page (optional)  (default to -1)
            var filter = filter=%28id+eq+%22nzowc1U5Jh5xuAK0o0g3%22%29;  // string | Filters zones by usage or ID expression (optional) 

            try
            {
                // List all Network Zones
                List<NetworkZone> result = apiInstance.ListNetworkZones(after, limit, filter).ToListAsync();
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
 **filter** | **string**| Filters zones by usage or ID expression | [optional] 

### Return type

[**List&lt;NetworkZone&gt;**](NetworkZone.md)

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

<a name="replacenetworkzone"></a>
# **ReplaceNetworkZone**
> NetworkZone ReplaceNetworkZone (string zoneId, NetworkZone zone)

Replace a Network Zone

Replaces a network zone by `zoneId`. The replaced network zone type must be the same as the existing type. You may replace the usage (`POLICY`, `BLOCKLIST`) of a network zone by updating the `usage` attribute.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceNetworkZoneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new NetworkZoneApi(config);
            var zoneId = nzowc1U5Jh5xuAK0o0g3;  // string | `id` of the Network Zone
            var zone = new NetworkZone(); // NetworkZone | 

            try
            {
                // Replace a Network Zone
                NetworkZone result = apiInstance.ReplaceNetworkZone(zoneId, zone);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NetworkZoneApi.ReplaceNetworkZone: " + e.Message );
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
 **zoneId** | **string**| &#x60;id&#x60; of the Network Zone | 
 **zone** | [**NetworkZone**](NetworkZone.md)|  | 

### Return type

[**NetworkZone**](NetworkZone.md)

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

