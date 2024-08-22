# Okta.Sdk.Api.SSFTransmitterApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetWellknownSsfMetadata**](SSFTransmitterApi.md#getwellknownssfmetadata) | **GET** /.well-known/ssf-configuration | Retrieve the SSF Transmitter metadata


<a name="getwellknownssfmetadata"></a>
# **GetWellknownSsfMetadata**
> WellKnownSSFMetadata GetWellknownSsfMetadata ()

Retrieve the SSF Transmitter metadata

Retrieves SSF Transmitter configuration metadata. This includes all supported endpoints and key information about certain properties of the Okta org as the transmitter, such as `delivery_methods_supported`, `issuer`, and `jwks_uri`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetWellknownSsfMetadataExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            var apiInstance = new SSFTransmitterApi(config);

            try
            {
                // Retrieve the SSF Transmitter metadata
                WellKnownSSFMetadata result = apiInstance.GetWellknownSsfMetadata();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SSFTransmitterApi.GetWellknownSsfMetadata: " + e.Message );
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

[**WellKnownSSFMetadata**](WellKnownSSFMetadata.md)

### Authorization

No authorization required

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

