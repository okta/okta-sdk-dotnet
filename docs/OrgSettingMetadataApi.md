# Okta.Sdk.Api.OrgSettingMetadataApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetWellknownOrgMetadata**](OrgSettingMetadataApi.md#getwellknownorgmetadata) | **GET** /.well-known/okta-organization | Retrieve the Org metadata


<a name="getwellknownorgmetadata"></a>
# **GetWellknownOrgMetadata**
> WellKnownOrgMetadata GetWellknownOrgMetadata ()

Retrieve the Org metadata

Retrieves the org metadata, which includes the org ID, configured custom domains, and authentication pipeline

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetWellknownOrgMetadataExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            var apiInstance = new OrgSettingMetadataApi(config);

            try
            {
                // Retrieve the Org metadata
                WellKnownOrgMetadata result = apiInstance.GetWellknownOrgMetadata();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingMetadataApi.GetWellknownOrgMetadata: " + e.Message );
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

[**WellKnownOrgMetadata**](WellKnownOrgMetadata.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

