# Okta.Sdk.Api.ThreatInsightApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetCurrentConfiguration**](ThreatInsightApi.md#getcurrentconfiguration) | **GET** /api/v1/threats/configuration | Retrieve the ThreatInsight Configuration
[**UpdateConfiguration**](ThreatInsightApi.md#updateconfiguration) | **POST** /api/v1/threats/configuration | Update the ThreatInsight Configuration


<a name="getcurrentconfiguration"></a>
# **GetCurrentConfiguration**
> ThreatInsightConfiguration GetCurrentConfiguration ()

Retrieve the ThreatInsight Configuration

Retrieves the ThreatInsight configuration for the org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetCurrentConfigurationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ThreatInsightApi(config);

            try
            {
                // Retrieve the ThreatInsight Configuration
                ThreatInsightConfiguration result = apiInstance.GetCurrentConfiguration();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ThreatInsightApi.GetCurrentConfiguration: " + e.Message );
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

[**ThreatInsightConfiguration**](ThreatInsightConfiguration.md)

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

<a name="updateconfiguration"></a>
# **UpdateConfiguration**
> ThreatInsightConfiguration UpdateConfiguration (ThreatInsightConfiguration threatInsightConfiguration)

Update the ThreatInsight Configuration

Updates the ThreatInsight configuration for the org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateConfigurationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ThreatInsightApi(config);
            var threatInsightConfiguration = new ThreatInsightConfiguration(); // ThreatInsightConfiguration | 

            try
            {
                // Update the ThreatInsight Configuration
                ThreatInsightConfiguration result = apiInstance.UpdateConfiguration(threatInsightConfiguration);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ThreatInsightApi.UpdateConfiguration: " + e.Message );
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
 **threatInsightConfiguration** | [**ThreatInsightConfiguration**](ThreatInsightConfiguration.md)|  | 

### Return type

[**ThreatInsightConfiguration**](ThreatInsightConfiguration.md)

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

