# Okta.Sdk.Api.DevicePostureCheckApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateDevicePostureCheck**](DevicePostureCheckApi.md#createdeviceposturecheck) | **POST** /api/v1/device-posture-checks | Create a device posture check
[**DeleteDevicePostureCheck**](DevicePostureCheckApi.md#deletedeviceposturecheck) | **DELETE** /api/v1/device-posture-checks/{postureCheckId} | Delete a device posture check
[**GetDevicePostureCheck**](DevicePostureCheckApi.md#getdeviceposturecheck) | **GET** /api/v1/device-posture-checks/{postureCheckId} | Retrieve a device posture check
[**ListDefaultDevicePostureChecks**](DevicePostureCheckApi.md#listdefaultdeviceposturechecks) | **GET** /api/v1/device-posture-checks/default | List all default device posture checks
[**ListDevicePostureChecks**](DevicePostureCheckApi.md#listdeviceposturechecks) | **GET** /api/v1/device-posture-checks | List all device posture checks
[**ReplaceDevicePostureCheck**](DevicePostureCheckApi.md#replacedeviceposturecheck) | **PUT** /api/v1/device-posture-checks/{postureCheckId} | Replace a device posture check


<a name="createdeviceposturecheck"></a>
# **CreateDevicePostureCheck**
> DevicePostureCheck CreateDevicePostureCheck (DevicePostureCheck devicePostureCheck)

Create a device posture check

Creates a device posture check

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateDevicePostureCheckExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DevicePostureCheckApi(config);
            var devicePostureCheck = new DevicePostureCheck(); // DevicePostureCheck | 

            try
            {
                // Create a device posture check
                DevicePostureCheck result = apiInstance.CreateDevicePostureCheck(devicePostureCheck);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DevicePostureCheckApi.CreateDevicePostureCheck: " + e.Message );
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
 **devicePostureCheck** | [**DevicePostureCheck**](DevicePostureCheck.md)|  | 

### Return type

[**DevicePostureCheck**](DevicePostureCheck.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletedeviceposturecheck"></a>
# **DeleteDevicePostureCheck**
> void DeleteDevicePostureCheck (string postureCheckId)

Delete a device posture check

Deletes a device posture check by `postureCheckId`. You can't delete the device posture check if it's used in a device assurance policy.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteDevicePostureCheckExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DevicePostureCheckApi(config);
            var postureCheckId = "postureCheckId_example";  // string | ID of the device posture check

            try
            {
                // Delete a device posture check
                apiInstance.DeleteDevicePostureCheck(postureCheckId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DevicePostureCheckApi.DeleteDevicePostureCheck: " + e.Message );
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
 **postureCheckId** | **string**| ID of the device posture check | 

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
| **409** | Conflict |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getdeviceposturecheck"></a>
# **GetDevicePostureCheck**
> DevicePostureCheck GetDevicePostureCheck (string postureCheckId)

Retrieve a device posture check

Retrieves a device posture check by `postureCheckId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetDevicePostureCheckExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DevicePostureCheckApi(config);
            var postureCheckId = "postureCheckId_example";  // string | ID of the device posture check

            try
            {
                // Retrieve a device posture check
                DevicePostureCheck result = apiInstance.GetDevicePostureCheck(postureCheckId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DevicePostureCheckApi.GetDevicePostureCheck: " + e.Message );
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
 **postureCheckId** | **string**| ID of the device posture check | 

### Return type

[**DevicePostureCheck**](DevicePostureCheck.md)

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

<a name="listdefaultdeviceposturechecks"></a>
# **ListDefaultDevicePostureChecks**
> List&lt;DevicePostureCheck&gt; ListDefaultDevicePostureChecks ()

List all default device posture checks

Lists all default device posture checks. Default device posture checks are defined by Okta. Their type will always be `BUILTIN`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListDefaultDevicePostureChecksExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DevicePostureCheckApi(config);

            try
            {
                // List all default device posture checks
                List<DevicePostureCheck> result = apiInstance.ListDefaultDevicePostureChecks().ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DevicePostureCheckApi.ListDefaultDevicePostureChecks: " + e.Message );
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

[**List&lt;DevicePostureCheck&gt;**](DevicePostureCheck.md)

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

<a name="listdeviceposturechecks"></a>
# **ListDevicePostureChecks**
> List&lt;DevicePostureCheck&gt; ListDevicePostureChecks ()

List all device posture checks

Lists all device posture checks

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListDevicePostureChecksExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DevicePostureCheckApi(config);

            try
            {
                // List all device posture checks
                List<DevicePostureCheck> result = apiInstance.ListDevicePostureChecks().ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DevicePostureCheckApi.ListDevicePostureChecks: " + e.Message );
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

[**List&lt;DevicePostureCheck&gt;**](DevicePostureCheck.md)

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

<a name="replacedeviceposturecheck"></a>
# **ReplaceDevicePostureCheck**
> DevicePostureCheck ReplaceDevicePostureCheck (string postureCheckId, DevicePostureCheck devicePostureCheck)

Replace a device posture check

Replaces a device posture check by `postureCheckId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceDevicePostureCheckExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DevicePostureCheckApi(config);
            var postureCheckId = "postureCheckId_example";  // string | ID of the device posture check
            var devicePostureCheck = new DevicePostureCheck(); // DevicePostureCheck | 

            try
            {
                // Replace a device posture check
                DevicePostureCheck result = apiInstance.ReplaceDevicePostureCheck(postureCheckId, devicePostureCheck);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DevicePostureCheckApi.ReplaceDevicePostureCheck: " + e.Message );
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
 **postureCheckId** | **string**| ID of the device posture check | 
 **devicePostureCheck** | [**DevicePostureCheck**](DevicePostureCheck.md)|  | 

### Return type

[**DevicePostureCheck**](DevicePostureCheck.md)

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

