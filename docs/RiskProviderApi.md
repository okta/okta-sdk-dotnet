# Okta.Sdk.Api.RiskProviderApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateRiskProvider**](RiskProviderApi.md#createriskprovider) | **POST** /api/v1/risk/providers | Create a Risk Provider
[**DeleteRiskProvider**](RiskProviderApi.md#deleteriskprovider) | **DELETE** /api/v1/risk/providers/{riskProviderId} | Delete a Risk Provider
[**GetRiskProvider**](RiskProviderApi.md#getriskprovider) | **GET** /api/v1/risk/providers/{riskProviderId} | Retrieve a Risk Provider
[**ListRiskProviders**](RiskProviderApi.md#listriskproviders) | **GET** /api/v1/risk/providers | List all Risk Providers
[**UpdateRiskProvider**](RiskProviderApi.md#updateriskprovider) | **PUT** /api/v1/risk/providers/{riskProviderId} | Replace a Risk Provider


<a name="createriskprovider"></a>
# **CreateRiskProvider**
> RiskProvider CreateRiskProvider (RiskProvider instance)

Create a Risk Provider

Creates a risk provider. A maximum of 3 providers can be created. By default, one risk provider is created by Okta.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateRiskProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RiskProviderApi(config);
            var instance = new RiskProvider(); // RiskProvider | 

            try
            {
                // Create a Risk Provider
                RiskProvider result = apiInstance.CreateRiskProvider(instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RiskProviderApi.CreateRiskProvider: " + e.Message );
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
 **instance** | [**RiskProvider**](RiskProvider.md)|  | 

### Return type

[**RiskProvider**](RiskProvider.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteriskprovider"></a>
# **DeleteRiskProvider**
> void DeleteRiskProvider (string riskProviderId)

Delete a Risk Provider

Delete a CAPTCHA instance by `riskProviderId`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteRiskProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RiskProviderApi(config);
            var riskProviderId = 00rp12r4skkjkjgsn;  // string | `id` of the risk provider

            try
            {
                // Delete a Risk Provider
                apiInstance.DeleteRiskProvider(riskProviderId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RiskProviderApi.DeleteRiskProvider: " + e.Message );
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
 **riskProviderId** | **string**| &#x60;id&#x60; of the risk provider | 

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

<a name="getriskprovider"></a>
# **GetRiskProvider**
> RiskProvider GetRiskProvider (string riskProviderId)

Retrieve a Risk Provider

Retrieves a risk provider by `riskProviderId`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRiskProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RiskProviderApi(config);
            var riskProviderId = 00rp12r4skkjkjgsn;  // string | `id` of the risk provider

            try
            {
                // Retrieve a Risk Provider
                RiskProvider result = apiInstance.GetRiskProvider(riskProviderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RiskProviderApi.GetRiskProvider: " + e.Message );
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
 **riskProviderId** | **string**| &#x60;id&#x60; of the risk provider | 

### Return type

[**RiskProvider**](RiskProvider.md)

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

<a name="listriskproviders"></a>
# **ListRiskProviders**
> List&lt;RiskProvider&gt; ListRiskProviders ()

List all Risk Providers

Lists all Risk Providers

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListRiskProvidersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RiskProviderApi(config);

            try
            {
                // List all Risk Providers
                List<RiskProvider> result = apiInstance.ListRiskProviders().ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RiskProviderApi.ListRiskProviders: " + e.Message );
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

[**List&lt;RiskProvider&gt;**](RiskProvider.md)

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

<a name="updateriskprovider"></a>
# **UpdateRiskProvider**
> RiskProvider UpdateRiskProvider (string riskProviderId, RiskProvider instance)

Replace a Risk Provider

Replaces a risk provider by `riskProviderId`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateRiskProviderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RiskProviderApi(config);
            var riskProviderId = 00rp12r4skkjkjgsn;  // string | `id` of the risk provider
            var instance = new RiskProvider(); // RiskProvider | 

            try
            {
                // Replace a Risk Provider
                RiskProvider result = apiInstance.UpdateRiskProvider(riskProviderId, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RiskProviderApi.UpdateRiskProvider: " + e.Message );
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
 **riskProviderId** | **string**| &#x60;id&#x60; of the risk provider | 
 **instance** | [**RiskProvider**](RiskProvider.md)|  | 

### Return type

[**RiskProvider**](RiskProvider.md)

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

