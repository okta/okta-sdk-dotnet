# Okta.Sdk.Api.DeviceAssuranceApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateDeviceAssurancePolicy**](DeviceAssuranceApi.md#createdeviceassurancepolicy) | **POST** /api/v1/device-assurances | Create a device assurance policy
[**DeleteDeviceAssurancePolicy**](DeviceAssuranceApi.md#deletedeviceassurancepolicy) | **DELETE** /api/v1/device-assurances/{deviceAssuranceId} | Delete a device assurance policy
[**GetDeviceAssurancePolicy**](DeviceAssuranceApi.md#getdeviceassurancepolicy) | **GET** /api/v1/device-assurances/{deviceAssuranceId} | Retrieve a device assurance policy
[**ListDeviceAssurancePolicies**](DeviceAssuranceApi.md#listdeviceassurancepolicies) | **GET** /api/v1/device-assurances | List all device assurance policies
[**ReplaceDeviceAssurancePolicy**](DeviceAssuranceApi.md#replacedeviceassurancepolicy) | **PUT** /api/v1/device-assurances/{deviceAssuranceId} | Replace a device assurance policy


<a name="createdeviceassurancepolicy"></a>
# **CreateDeviceAssurancePolicy**
> DeviceAssurance CreateDeviceAssurancePolicy (DeviceAssurance deviceAssurance)

Create a device assurance policy

Creates a new device assurance policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateDeviceAssurancePolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceAssuranceApi(config);
            var deviceAssurance = new DeviceAssurance(); // DeviceAssurance | 

            try
            {
                // Create a device assurance policy
                DeviceAssurance result = apiInstance.CreateDeviceAssurancePolicy(deviceAssurance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceAssuranceApi.CreateDeviceAssurancePolicy: " + e.Message );
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
 **deviceAssurance** | [**DeviceAssurance**](DeviceAssurance.md)|  | 

### Return type

[**DeviceAssurance**](DeviceAssurance.md)

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

<a name="deletedeviceassurancepolicy"></a>
# **DeleteDeviceAssurancePolicy**
> void DeleteDeviceAssurancePolicy (string deviceAssuranceId)

Delete a device assurance policy

Deletes a device assurance policy by `deviceAssuranceId`. If the device assurance policy is currently being used in the org Authentication Policies, the delete will not be allowed.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteDeviceAssurancePolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceAssuranceApi(config);
            var deviceAssuranceId = "deviceAssuranceId_example";  // string | Id of the device assurance policy

            try
            {
                // Delete a device assurance policy
                apiInstance.DeleteDeviceAssurancePolicy(deviceAssuranceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceAssuranceApi.DeleteDeviceAssurancePolicy: " + e.Message );
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
 **deviceAssuranceId** | **string**| Id of the device assurance policy | 

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

<a name="getdeviceassurancepolicy"></a>
# **GetDeviceAssurancePolicy**
> DeviceAssurance GetDeviceAssurancePolicy (string deviceAssuranceId)

Retrieve a device assurance policy

Retrieves a device assurance policy by `deviceAssuranceId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetDeviceAssurancePolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceAssuranceApi(config);
            var deviceAssuranceId = "deviceAssuranceId_example";  // string | Id of the device assurance policy

            try
            {
                // Retrieve a device assurance policy
                DeviceAssurance result = apiInstance.GetDeviceAssurancePolicy(deviceAssuranceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceAssuranceApi.GetDeviceAssurancePolicy: " + e.Message );
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
 **deviceAssuranceId** | **string**| Id of the device assurance policy | 

### Return type

[**DeviceAssurance**](DeviceAssurance.md)

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

<a name="listdeviceassurancepolicies"></a>
# **ListDeviceAssurancePolicies**
> List&lt;DeviceAssurance&gt; ListDeviceAssurancePolicies ()

List all device assurance policies

Lists all device assurance policies

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListDeviceAssurancePoliciesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceAssuranceApi(config);

            try
            {
                // List all device assurance policies
                List<DeviceAssurance> result = apiInstance.ListDeviceAssurancePolicies().ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceAssuranceApi.ListDeviceAssurancePolicies: " + e.Message );
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

[**List&lt;DeviceAssurance&gt;**](DeviceAssurance.md)

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

<a name="replacedeviceassurancepolicy"></a>
# **ReplaceDeviceAssurancePolicy**
> DeviceAssurance ReplaceDeviceAssurancePolicy (string deviceAssuranceId, DeviceAssurance deviceAssurance)

Replace a device assurance policy

Replaces a device assurance policy by `deviceAssuranceId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceDeviceAssurancePolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceAssuranceApi(config);
            var deviceAssuranceId = "deviceAssuranceId_example";  // string | Id of the device assurance policy
            var deviceAssurance = new DeviceAssurance(); // DeviceAssurance | 

            try
            {
                // Replace a device assurance policy
                DeviceAssurance result = apiInstance.ReplaceDeviceAssurancePolicy(deviceAssuranceId, deviceAssurance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceAssuranceApi.ReplaceDeviceAssurancePolicy: " + e.Message );
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
 **deviceAssuranceId** | **string**| Id of the device assurance policy | 
 **deviceAssurance** | [**DeviceAssurance**](DeviceAssurance.md)|  | 

### Return type

[**DeviceAssurance**](DeviceAssurance.md)

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

