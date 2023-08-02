# Okta.Sdk.Api.DeviceApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateDevice**](DeviceApi.md#activatedevice) | **POST** /api/v1/devices/{deviceId}/lifecycle/activate | Activate a Device
[**DeactivateDevice**](DeviceApi.md#deactivatedevice) | **POST** /api/v1/devices/{deviceId}/lifecycle/deactivate | Deactivate a Device
[**DeleteDevice**](DeviceApi.md#deletedevice) | **DELETE** /api/v1/devices/{deviceId} | Delete a Device
[**GetDevice**](DeviceApi.md#getdevice) | **GET** /api/v1/devices/{deviceId} | Retrieve a Device
[**ListDeviceUsers**](DeviceApi.md#listdeviceusers) | **GET** /api/v1/devices/{deviceId}/users | List all Users for a Device
[**ListDevices**](DeviceApi.md#listdevices) | **GET** /api/v1/devices | List all Devices
[**SuspendDevice**](DeviceApi.md#suspenddevice) | **POST** /api/v1/devices/{deviceId}/lifecycle/suspend | Suspend a Device
[**UnsuspendDevice**](DeviceApi.md#unsuspenddevice) | **POST** /api/v1/devices/{deviceId}/lifecycle/unsuspend | Unsuspend a Device


<a name="activatedevice"></a>
# **ActivateDevice**
> void ActivateDevice (string deviceId)

Activate a Device

Activates a Device by setting its status to ACTIVE by `deviceId`. Activated devices are used to create and delete Device user links.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateDeviceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceApi(config);
            var deviceId = guo4a5u7JHHhjXrMK0g4;  // string | `id` of the device

            try
            {
                // Activate a Device
                apiInstance.ActivateDevice(deviceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceApi.ActivateDevice: " + e.Message );
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
 **deviceId** | **string**| &#x60;id&#x60; of the device | 

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

<a name="deactivatedevice"></a>
# **DeactivateDevice**
> void DeactivateDevice (string deviceId)

Deactivate a Device

Deactivates a Device by setting its status to DEACTIVATED by `deviceId`. Deactivation causes a Device to lose all device user links. Set the Device status to DEACTIVATED before deleting it. > **Note:** When deactivating a Device, keep in mind the following:   - Device deactivation is a destructive operation for device factors and client certificates. Device reenrollment using Okta Verify allows end users to set up new factors on the device.   - Device deletion removes the device record from Okta. Reenrollment creates a new device record.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateDeviceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceApi(config);
            var deviceId = guo4a5u7JHHhjXrMK0g4;  // string | `id` of the device

            try
            {
                // Deactivate a Device
                apiInstance.DeactivateDevice(deviceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceApi.DeactivateDevice: " + e.Message );
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
 **deviceId** | **string**| &#x60;id&#x60; of the device | 

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

<a name="deletedevice"></a>
# **DeleteDevice**
> void DeleteDevice (string deviceId)

Delete a Device

Deletes (permanently) a device by `deviceId` if it has a status of `DEACTIVATED`. You can transition the device to `DEACTIVATED` status using the [Deactivate a Device](#tag/Device/operation/deactivateDevice) endpoint. This request is destructive and deletes all of the profile data related to the device. Once deleted, device data can't be recovered. However, reenrollment creates a new device record. > **Note:** Attempts to delete a device that isn't in a `DEACTIVATED` state raise an error.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteDeviceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceApi(config);
            var deviceId = guo4a5u7JHHhjXrMK0g4;  // string | `id` of the device

            try
            {
                // Delete a Device
                apiInstance.DeleteDevice(deviceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceApi.DeleteDevice: " + e.Message );
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
 **deviceId** | **string**| &#x60;id&#x60; of the device | 

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

<a name="getdevice"></a>
# **GetDevice**
> Device GetDevice (string deviceId)

Retrieve a Device

Retrieves a device by `deviceId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetDeviceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceApi(config);
            var deviceId = guo4a5u7JHHhjXrMK0g4;  // string | `id` of the device

            try
            {
                // Retrieve a Device
                Device result = apiInstance.GetDevice(deviceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceApi.GetDevice: " + e.Message );
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
 **deviceId** | **string**| &#x60;id&#x60; of the device | 

### Return type

[**Device**](Device.md)

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

<a name="listdeviceusers"></a>
# **ListDeviceUsers**
> List&lt;DeviceUser&gt; ListDeviceUsers (string deviceId)

List all Users for a Device

Lists all Users for a Device by `deviceId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListDeviceUsersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceApi(config);
            var deviceId = guo4a5u7JHHhjXrMK0g4;  // string | `id` of the device

            try
            {
                // List all Users for a Device
                List<DeviceUser> result = apiInstance.ListDeviceUsers(deviceId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceApi.ListDeviceUsers: " + e.Message );
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
 **deviceId** | **string**| &#x60;id&#x60; of the device | 

### Return type

[**List&lt;DeviceUser&gt;**](DeviceUser.md)

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

<a name="listdevices"></a>
# **ListDevices**
> List&lt;Device&gt; ListDevices (string after = null, int? limit = null, string search = null, string expand = null)

List all Devices

Lists all devices with pagination support. You can return a subset of Devices that match a supported search criteria using the `search` query parameter. Searches for devices based on the properties specified in the `search` parameter conforming SCIM filter specifications (case-insensitive). This data is eventually consistent. The API returns different results depending on specified queries in the request. Empty list is returned if no objects match `search` request. > **Note:** Listing devices with `search` should not be used as a part of any critical flows—such as authentication or updates—to prevent potential data loss. `search` results may not reflect the latest information, as this endpoint uses a search index which may not be up-to-date with recent updates to the object. <br> Don't use search results directly for record updates, as the data might be stale and therefore overwrite newer data, resulting in data loss. <br> Use an `id` lookup for records that you update to ensure your results contain the latest data. This operation requires [URL encoding](https://www.w3.org/TR/html4/interact/forms.html#h-17.13.4.1). For example, `search=profile.displayName eq \"Bob\"` is encoded as `search=profile.displayName%20eq%20%22Bob%22`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListDevicesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceApi(config);
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](/#pagination) for more information. (optional) 
            var limit = 200;  // int? | A limit on the number of objects to return (recommend `20`) (optional)  (default to 200)
            var search = status eq "ACTIVE";  // string | A SCIM filter expression that filters the results. Searches include all Device `profile` properties and the Device `id`, `status`, and `lastUpdated` properties. (optional) 
            var expand = "expand_example";  // string | Lists associated users for the device in `_embedded` element (optional) 

            try
            {
                // List all Devices
                List<Device> result = apiInstance.ListDevices(after, limit, search, expand).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceApi.ListDevices: " + e.Message );
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](/#pagination) for more information. | [optional] 
 **limit** | **int?**| A limit on the number of objects to return (recommend &#x60;20&#x60;) | [optional] [default to 200]
 **search** | **string**| A SCIM filter expression that filters the results. Searches include all Device &#x60;profile&#x60; properties and the Device &#x60;id&#x60;, &#x60;status&#x60;, and &#x60;lastUpdated&#x60; properties. | [optional] 
 **expand** | **string**| Lists associated users for the device in &#x60;_embedded&#x60; element | [optional] 

### Return type

[**List&lt;Device&gt;**](Device.md)

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

<a name="suspenddevice"></a>
# **SuspendDevice**
> void SuspendDevice (string deviceId)

Suspend a Device

Suspends a Device by setting its status to SUSPENDED. Use suspended devices to create and delete device user links. You can only unsuspend or deactivate suspended devices. > **Note:** SUSPENDED status is meant to be temporary, so it isn't destructive.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class SuspendDeviceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceApi(config);
            var deviceId = guo4a5u7JHHhjXrMK0g4;  // string | `id` of the device

            try
            {
                // Suspend a Device
                apiInstance.SuspendDevice(deviceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceApi.SuspendDevice: " + e.Message );
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
 **deviceId** | **string**| &#x60;id&#x60; of the device | 

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

<a name="unsuspenddevice"></a>
# **UnsuspendDevice**
> void UnsuspendDevice (string deviceId)

Unsuspend a Device

Unsuspends a Device by returning its `status` to ACTIVE. >**Note:** Only devices with a SUSPENDED status can be unsuspended.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnsuspendDeviceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceApi(config);
            var deviceId = guo4a5u7JHHhjXrMK0g4;  // string | `id` of the device

            try
            {
                // Unsuspend a Device
                apiInstance.UnsuspendDevice(deviceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceApi.UnsuspendDevice: " + e.Message );
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
 **deviceId** | **string**| &#x60;id&#x60; of the device | 

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

