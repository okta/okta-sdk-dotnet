# Okta.Sdk.Api.DeviceIntegrationsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateDeviceIntegration**](DeviceIntegrationsApi.md#activatedeviceintegration) | **POST** /api/v1/device-integrations/{deviceIntegrationId}/lifecycle/activate | Activate a device integration
[**DeactivateDeviceIntegration**](DeviceIntegrationsApi.md#deactivatedeviceintegration) | **POST** /api/v1/device-integrations/{deviceIntegrationId}/lifecycle/deactivate | Deactivate a device integration
[**GetDeviceIntegration**](DeviceIntegrationsApi.md#getdeviceintegration) | **GET** /api/v1/device-integrations/{deviceIntegrationId} | Retrieve a device integration
[**ListDeviceIntegrations**](DeviceIntegrationsApi.md#listdeviceintegrations) | **GET** /api/v1/device-integrations | List all device integrations


<a name="activatedeviceintegration"></a>
# **ActivateDeviceIntegration**
> DeviceIntegrations ActivateDeviceIntegration (string deviceIntegrationId)

Activate a device integration

Activates a device integration and populates the related configurations by `deviceIntegrationId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateDeviceIntegrationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceIntegrationsApi(config);
            var deviceIntegrationId = "deviceIntegrationId_example";  // string | The ID of the device integration

            try
            {
                // Activate a device integration
                DeviceIntegrations result = apiInstance.ActivateDeviceIntegration(deviceIntegrationId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceIntegrationsApi.ActivateDeviceIntegration: " + e.Message );
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
 **deviceIntegrationId** | **string**| The ID of the device integration | 

### Return type

[**DeviceIntegrations**](DeviceIntegrations.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivatedeviceintegration"></a>
# **DeactivateDeviceIntegration**
> DeviceIntegrations DeactivateDeviceIntegration (string deviceIntegrationId)

Deactivate a device integration

Deactivates a device integration by `deviceIntegrationId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateDeviceIntegrationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceIntegrationsApi(config);
            var deviceIntegrationId = "deviceIntegrationId_example";  // string | The ID of the device integration

            try
            {
                // Deactivate a device integration
                DeviceIntegrations result = apiInstance.DeactivateDeviceIntegration(deviceIntegrationId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceIntegrationsApi.DeactivateDeviceIntegration: " + e.Message );
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
 **deviceIntegrationId** | **string**| The ID of the device integration | 

### Return type

[**DeviceIntegrations**](DeviceIntegrations.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getdeviceintegration"></a>
# **GetDeviceIntegration**
> DeviceIntegrations GetDeviceIntegration (string deviceIntegrationId)

Retrieve a device integration

Retrieves a device integration by `deviceIntegrationId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetDeviceIntegrationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceIntegrationsApi(config);
            var deviceIntegrationId = "deviceIntegrationId_example";  // string | The ID of the device integration

            try
            {
                // Retrieve a device integration
                DeviceIntegrations result = apiInstance.GetDeviceIntegration(deviceIntegrationId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceIntegrationsApi.GetDeviceIntegration: " + e.Message );
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
 **deviceIntegrationId** | **string**| The ID of the device integration | 

### Return type

[**DeviceIntegrations**](DeviceIntegrations.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listdeviceintegrations"></a>
# **ListDeviceIntegrations**
> List&lt;DeviceIntegrations&gt; ListDeviceIntegrations ()

List all device integrations

Lists all device integrations for your org. Examples include Device Posture Provider, Windows Security Center, Chrome Device Trust, OSQuery, and Android Device Trust.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListDeviceIntegrationsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceIntegrationsApi(config);

            try
            {
                // List all device integrations
                List<DeviceIntegrations> result = apiInstance.ListDeviceIntegrations().ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceIntegrationsApi.ListDeviceIntegrations: " + e.Message );
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

[**List&lt;DeviceIntegrations&gt;**](DeviceIntegrations.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

