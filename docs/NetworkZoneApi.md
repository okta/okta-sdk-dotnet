# Okta.Sdk.Api.NetworkZoneApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateNetworkZone**](NetworkZoneApi.md#activatenetworkzone) | **POST** /api/v1/zones/{zoneId}/lifecycle/activate | Activate a network zone
[**CreateNetworkZone**](NetworkZoneApi.md#createnetworkzone) | **POST** /api/v1/zones | Create a network zone
[**DeactivateNetworkZone**](NetworkZoneApi.md#deactivatenetworkzone) | **POST** /api/v1/zones/{zoneId}/lifecycle/deactivate | Deactivate a network zone
[**DeleteNetworkZone**](NetworkZoneApi.md#deletenetworkzone) | **DELETE** /api/v1/zones/{zoneId} | Delete a network zone
[**GetNetworkZone**](NetworkZoneApi.md#getnetworkzone) | **GET** /api/v1/zones/{zoneId} | Retrieve a network zone
[**ListNetworkZones**](NetworkZoneApi.md#listnetworkzones) | **GET** /api/v1/zones | List all network zones
[**ReplaceNetworkZone**](NetworkZoneApi.md#replacenetworkzone) | **PUT** /api/v1/zones/{zoneId} | Replace a network zone


<a name="activatenetworkzone"></a>
# **ActivateNetworkZone**
> NetworkZone ActivateNetworkZone (string zoneId)

Activate a network zone

Activates a Network Zone by `zoneId`

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
                // Activate a network zone
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createnetworkzone"></a>
# **CreateNetworkZone**
> NetworkZone CreateNetworkZone (NetworkZone zone)

Create a network zone

Creates a Network Zone * For an IP Network Zone, you must define either `gateways` or `proxies`. * For a Dynamic Network Zone, you must define at least one of the following: `asns`, `locations`, or `proxyType`. * For an Enhanced Dynamic Network Zone, you must define at least one of the following: `asns`, `locations`, or `ipServiceCategories`.

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
                // Create a network zone
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivatenetworkzone"></a>
# **DeactivateNetworkZone**
> NetworkZone DeactivateNetworkZone (string zoneId)

Deactivate a network zone

Deactivates a Network Zone by `zoneId`

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
                // Deactivate a network zone
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletenetworkzone"></a>
# **DeleteNetworkZone**
> void DeleteNetworkZone (string zoneId)

Delete a network zone

Deletes a Network Zone by `zoneId` > **Notes:** > * You can't delete a Network Zone that's used by a [Policy](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Policy/) or [Rule](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Policy/#tag/Policy/operation/listPolicyRules). > * For Okta Identity Engine orgs, you can't delete a Network Zone with an ACTIVE `status`. <x-lifecycle class=\"oie\"></x-lifecycle>

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
                // Delete a network zone
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getnetworkzone"></a>
# **GetNetworkZone**
> NetworkZone GetNetworkZone (string zoneId)

Retrieve a network zone

Retrieves a Network Zone by `zoneId`

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
                // Retrieve a network zone
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listnetworkzones"></a>
# **ListNetworkZones**
> List&lt;NetworkZone&gt; ListNetworkZones (string after = null, int? limit = null, string filter = null)

List all network zones

Lists all Network Zones with pagination. A subset of zones can be returned that match a supported filter expression or query.  This operation requires URL encoding. For example, `filter=(id eq \"nzoul0wf9jyb8xwZm0g3\" or id eq \"nzoul1MxmGN18NDQT0g3\")` is encoded as `filter=%28id+eq+%22nzoul0wf9jyb8xwZm0g3%22+or+id+eq+%22nzoul1MxmGN18NDQT0g3%22%29`.  Okta supports filtering on the `id`, `usage`, and `system` properties. See [Filter](https://developer.okta.com/docs/api/#filter) for more information on the expressions that are used in filtering.

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
            var after = BlockedIpZones;  // string |  (optional) 
            var limit = 5;  // int? |  (optional)  (default to -1)
            var filter = id eq "nzowc1U5Jh5xuAK0o0g3";  // string |  (optional) 

            try
            {
                // List all network zones
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
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to -1]
 **filter** | **string**|  | [optional] 

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
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacenetworkzone"></a>
# **ReplaceNetworkZone**
> NetworkZone ReplaceNetworkZone (string zoneId, NetworkZone zone)

Replace a network zone

Replaces a Network Zone by `zoneId`. The replaced Network Zone type must be the same as the existing type. You can replace the usage (`POLICY`, `BLOCKLIST`) of a Network Zone by updating the `usage` attribute.  **IP exempt zone**<br> If you have the IP exempt zone feature enabled, you can allow traffic from specific gateway IPs irrespective of Okta ThreatInsight configurations, blocked network zones, or IP change events within Identity Threat Protection with Okta AI.<br> <br> When you enable this feature, Okta creates a zone called `DefaultExemptIpZone`. Gateway IPs that you add to this zone always have access to Okta resources. See [IP exempt zone](https://help.okta.com/okta_help.htm?type=oie&id=csh-about-ip-exempt-zone).  > **Note:** You can't add trusted proxy IPs to this zone, delete the zone, or create additional exempt IP zones.

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
                // Replace a network zone
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

