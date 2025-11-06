# Okta.Sdk.Api.EmailCustomizationApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**BulkRemoveEmailAddressBounces**](EmailCustomizationApi.md#bulkremoveemailaddressbounces) | **POST** /api/v1/org/email/bounces/remove-list | Remove bounced emails


<a name="bulkremoveemailaddressbounces"></a>
# **BulkRemoveEmailAddressBounces**
> BouncesRemoveListResult BulkRemoveEmailAddressBounces (BouncesRemoveListObj bouncesRemoveListObj = null)

Remove bounced emails

Removes emails from an email service bounce list.  The emails submitted in this operation are removed from the bounce list by an asynchronous job. Any email address that passes validation is accepted for the removal process, even if there are other email addresses in the request that failed validation.  > **Note:** If there are validation errors for all email addresses, a `200 OK` HTTP status is still returned. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class BulkRemoveEmailAddressBouncesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EmailCustomizationApi(config);
            var bouncesRemoveListObj = new BouncesRemoveListObj(); // BouncesRemoveListObj |  (optional) 

            try
            {
                // Remove bounced emails
                BouncesRemoveListResult result = apiInstance.BulkRemoveEmailAddressBounces(bouncesRemoveListObj);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EmailCustomizationApi.BulkRemoveEmailAddressBounces: " + e.Message );
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
 **bouncesRemoveListObj** | [**BouncesRemoveListObj**](BouncesRemoveListObj.md)|  | [optional] 

### Return type

[**BouncesRemoveListResult**](BouncesRemoveListResult.md)

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

