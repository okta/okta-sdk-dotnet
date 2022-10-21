# Okta.Sdk.Api.RiskEventApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SendRiskEvents**](RiskEventApi.md#sendriskevents) | **POST** /api/v1/risk/events/ip | Send multiple Risk Events


<a name="sendriskevents"></a>
# **SendRiskEvents**
> void SendRiskEvents (List<RiskEvent> instance)

Send multiple Risk Events

A Risk Provider can send Risk Events to Okta using this API. This API has a rate limit of 30 requests per minute. The caller should include multiple Risk Events (up to a maximum of 20 events) in a single payload to reduce the number of API calls. If a client has more risk signals to send than what the API supports, we recommend prioritizing posting high risk signals.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class SendRiskEventsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RiskEventApi(config);
            var instance = new List<RiskEvent>(); // List<RiskEvent> | 

            try
            {
                // Send multiple Risk Events
                apiInstance.SendRiskEvents(instance);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RiskEventApi.SendRiskEvents: " + e.Message );
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
 **instance** | [**List&lt;RiskEvent&gt;**](RiskEvent.md)|  | 

### Return type

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Accepted |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

