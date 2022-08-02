# Okta.Sdk.Api.DeviceAssuranceApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateDeviceAssurancePolicy**](DeviceAssuranceApi.md#createdeviceassurancepolicy) | **POST** /api/v1/device-assurances | Create a Device Assurance Policy
[**DeleteDeviceAssurancePolicy**](DeviceAssuranceApi.md#deletedeviceassurancepolicy) | **DELETE** /api/v1/device-assurances/{deviceAssuranceId} | Delete a Device Assurance Policy
[**GetDeviceAssurancePolicy**](DeviceAssuranceApi.md#getdeviceassurancepolicy) | **GET** /api/v1/device-assurances/{deviceAssuranceId} | Retrieve a Device Assurance Policy
[**ListDeviceAssurancePolicies**](DeviceAssuranceApi.md#listdeviceassurancepolicies) | **GET** /api/v1/device-assurances | List all Device Assurance Policies
[**UpdateDeviceAssurancePolicy**](DeviceAssuranceApi.md#updatedeviceassurancepolicy) | **PUT** /api/v1/device-assurances/{deviceAssuranceId} | Replace a Device Assurance Policy


<a name="createdeviceassurancepolicy"></a>
# **CreateDeviceAssurancePolicy**
> DeviceAssurance CreateDeviceAssurancePolicy (DeviceAssurance deviceAssurance)

Create a Device Assurance Policy

Adds a new Device Assurance Policy.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceAssuranceApi(config);
            var deviceAssurance = new DeviceAssurance(); // DeviceAssurance | 

            try
            {
                // Create a Device Assurance Policy
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

Delete a Device Assurance Policy

Delete a Device Assurance Policy by `deviceAssuranceId`. If the Device Assurance Policy is currently being used in the org Authentication Policies, the delete will not be allowed.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceAssuranceApi(config);
            var deviceAssuranceId = "deviceAssuranceId_example";  // string | Id of the Device Assurance Policy

            try
            {
                // Delete a Device Assurance Policy
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
 **deviceAssuranceId** | **string**| Id of the Device Assurance Policy | 

### Return type

void (empty response body)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

Retrieve a Device Assurance Policy

Fetches a Device Assurance Policy by `deviceAssuranceId`.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceAssuranceApi(config);
            var deviceAssuranceId = "deviceAssuranceId_example";  // string | Id of the Device Assurance Policy

            try
            {
                // Retrieve a Device Assurance Policy
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
 **deviceAssuranceId** | **string**| Id of the Device Assurance Policy | 

### Return type

[**DeviceAssurance**](DeviceAssurance.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

List all Device Assurance Policies

Enumerates Device Assurance Policies in your organization.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceAssuranceApi(config);

            try
            {
                // List all Device Assurance Policies
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="updatedeviceassurancepolicy"></a>
# **UpdateDeviceAssurancePolicy**
> DeviceAssurance UpdateDeviceAssurancePolicy (string deviceAssuranceId, DeviceAssurance deviceAssurance)

Replace a Device Assurance Policy

Updates a Device Assurance Policy by `deviceAssuranceId`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateDeviceAssurancePolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceAssuranceApi(config);
            var deviceAssuranceId = "deviceAssuranceId_example";  // string | Id of the Device Assurance Policy
            var deviceAssurance = new DeviceAssurance(); // DeviceAssurance | 

            try
            {
                // Replace a Device Assurance Policy
                DeviceAssurance result = apiInstance.UpdateDeviceAssurancePolicy(deviceAssuranceId, deviceAssurance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceAssuranceApi.UpdateDeviceAssurancePolicy: " + e.Message );
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
 **deviceAssuranceId** | **string**| Id of the Device Assurance Policy | 
 **deviceAssurance** | [**DeviceAssurance**](DeviceAssurance.md)|  | 

### Return type

[**DeviceAssurance**](DeviceAssurance.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

