# Okta.Sdk.Api.SSFReceiverApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateSecurityEventsProviderInstance**](SSFReceiverApi.md#activatesecurityeventsproviderinstance) | **POST** /api/v1/security-events-providers/{securityEventProviderId}/lifecycle/activate | Activate a security events provider
[**CreateSecurityEventsProviderInstance**](SSFReceiverApi.md#createsecurityeventsproviderinstance) | **POST** /api/v1/security-events-providers | Create a security events provider
[**DeactivateSecurityEventsProviderInstance**](SSFReceiverApi.md#deactivatesecurityeventsproviderinstance) | **POST** /api/v1/security-events-providers/{securityEventProviderId}/lifecycle/deactivate | Deactivate a security events provider
[**DeleteSecurityEventsProviderInstance**](SSFReceiverApi.md#deletesecurityeventsproviderinstance) | **DELETE** /api/v1/security-events-providers/{securityEventProviderId} | Delete a security events provider
[**GetSecurityEventsProviderInstance**](SSFReceiverApi.md#getsecurityeventsproviderinstance) | **GET** /api/v1/security-events-providers/{securityEventProviderId} | Retrieve the security events provider
[**ListSecurityEventsProviderInstances**](SSFReceiverApi.md#listsecurityeventsproviderinstances) | **GET** /api/v1/security-events-providers | List all security events providers
[**ReplaceSecurityEventsProviderInstance**](SSFReceiverApi.md#replacesecurityeventsproviderinstance) | **PUT** /api/v1/security-events-providers/{securityEventProviderId} | Replace a security events provider


<a name="activatesecurityeventsproviderinstance"></a>
# **ActivateSecurityEventsProviderInstance**
> SecurityEventsProviderResponse ActivateSecurityEventsProviderInstance (string securityEventProviderId)

Activate a security events provider

Activates a Security Events Provider instance by setting its status to `ACTIVE`. This operation resumes the flow of events from the Security Events Provider to Okta.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateSecurityEventsProviderInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SSFReceiverApi(config);
            var securityEventProviderId = sse1qg25RpusjUP6m0g5;  // string | `id` of the Security Events Provider instance

            try
            {
                // Activate a security events provider
                SecurityEventsProviderResponse result = apiInstance.ActivateSecurityEventsProviderInstance(securityEventProviderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SSFReceiverApi.ActivateSecurityEventsProviderInstance: " + e.Message );
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
 **securityEventProviderId** | **string**| &#x60;id&#x60; of the Security Events Provider instance | 

### Return type

[**SecurityEventsProviderResponse**](SecurityEventsProviderResponse.md)

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

<a name="createsecurityeventsproviderinstance"></a>
# **CreateSecurityEventsProviderInstance**
> SecurityEventsProviderResponse CreateSecurityEventsProviderInstance (SecurityEventsProviderRequest instance)

Create a security events provider

Creates a Security Events Provider instance

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateSecurityEventsProviderInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SSFReceiverApi(config);
            var instance = new SecurityEventsProviderRequest(); // SecurityEventsProviderRequest | 

            try
            {
                // Create a security events provider
                SecurityEventsProviderResponse result = apiInstance.CreateSecurityEventsProviderInstance(instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SSFReceiverApi.CreateSecurityEventsProviderInstance: " + e.Message );
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
 **instance** | [**SecurityEventsProviderRequest**](SecurityEventsProviderRequest.md)|  | 

### Return type

[**SecurityEventsProviderResponse**](SecurityEventsProviderResponse.md)

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivatesecurityeventsproviderinstance"></a>
# **DeactivateSecurityEventsProviderInstance**
> SecurityEventsProviderResponse DeactivateSecurityEventsProviderInstance (string securityEventProviderId)

Deactivate a security events provider

Deactivates a Security Events Provider instance by setting its status to `INACTIVE`. This operation stops the flow of events from the Security Events Provider to Okta.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateSecurityEventsProviderInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SSFReceiverApi(config);
            var securityEventProviderId = sse1qg25RpusjUP6m0g5;  // string | `id` of the Security Events Provider instance

            try
            {
                // Deactivate a security events provider
                SecurityEventsProviderResponse result = apiInstance.DeactivateSecurityEventsProviderInstance(securityEventProviderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SSFReceiverApi.DeactivateSecurityEventsProviderInstance: " + e.Message );
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
 **securityEventProviderId** | **string**| &#x60;id&#x60; of the Security Events Provider instance | 

### Return type

[**SecurityEventsProviderResponse**](SecurityEventsProviderResponse.md)

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

<a name="deletesecurityeventsproviderinstance"></a>
# **DeleteSecurityEventsProviderInstance**
> void DeleteSecurityEventsProviderInstance (string securityEventProviderId)

Delete a security events provider

Deletes a Security Events Provider instance specified by `id`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteSecurityEventsProviderInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SSFReceiverApi(config);
            var securityEventProviderId = sse1qg25RpusjUP6m0g5;  // string | `id` of the Security Events Provider instance

            try
            {
                // Delete a security events provider
                apiInstance.DeleteSecurityEventsProviderInstance(securityEventProviderId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SSFReceiverApi.DeleteSecurityEventsProviderInstance: " + e.Message );
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
 **securityEventProviderId** | **string**| &#x60;id&#x60; of the Security Events Provider instance | 

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getsecurityeventsproviderinstance"></a>
# **GetSecurityEventsProviderInstance**
> SecurityEventsProviderResponse GetSecurityEventsProviderInstance (string securityEventProviderId)

Retrieve the security events provider

Retrieves the Security Events Provider instance specified by `id`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetSecurityEventsProviderInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SSFReceiverApi(config);
            var securityEventProviderId = sse1qg25RpusjUP6m0g5;  // string | `id` of the Security Events Provider instance

            try
            {
                // Retrieve the security events provider
                SecurityEventsProviderResponse result = apiInstance.GetSecurityEventsProviderInstance(securityEventProviderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SSFReceiverApi.GetSecurityEventsProviderInstance: " + e.Message );
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
 **securityEventProviderId** | **string**| &#x60;id&#x60; of the Security Events Provider instance | 

### Return type

[**SecurityEventsProviderResponse**](SecurityEventsProviderResponse.md)

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

<a name="listsecurityeventsproviderinstances"></a>
# **ListSecurityEventsProviderInstances**
> List&lt;SecurityEventsProviderResponse&gt; ListSecurityEventsProviderInstances ()

List all security events providers

Lists all Security Events Provider instances

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListSecurityEventsProviderInstancesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SSFReceiverApi(config);

            try
            {
                // List all security events providers
                List<SecurityEventsProviderResponse> result = apiInstance.ListSecurityEventsProviderInstances().ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SSFReceiverApi.ListSecurityEventsProviderInstances: " + e.Message );
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

[**List&lt;SecurityEventsProviderResponse&gt;**](SecurityEventsProviderResponse.md)

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

<a name="replacesecurityeventsproviderinstance"></a>
# **ReplaceSecurityEventsProviderInstance**
> SecurityEventsProviderResponse ReplaceSecurityEventsProviderInstance (string securityEventProviderId, SecurityEventsProviderRequest instance)

Replace a security events provider

Replaces a Security Events Provider instance specified by `id`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceSecurityEventsProviderInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SSFReceiverApi(config);
            var securityEventProviderId = sse1qg25RpusjUP6m0g5;  // string | `id` of the Security Events Provider instance
            var instance = new SecurityEventsProviderRequest(); // SecurityEventsProviderRequest | 

            try
            {
                // Replace a security events provider
                SecurityEventsProviderResponse result = apiInstance.ReplaceSecurityEventsProviderInstance(securityEventProviderId, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SSFReceiverApi.ReplaceSecurityEventsProviderInstance: " + e.Message );
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
 **securityEventProviderId** | **string**| &#x60;id&#x60; of the Security Events Provider instance | 
 **instance** | [**SecurityEventsProviderRequest**](SecurityEventsProviderRequest.md)|  | 

### Return type

[**SecurityEventsProviderResponse**](SecurityEventsProviderResponse.md)

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

