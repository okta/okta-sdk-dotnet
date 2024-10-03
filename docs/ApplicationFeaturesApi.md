# Okta.Sdk.Api.ApplicationFeaturesApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetFeatureForApplication**](ApplicationFeaturesApi.md#getfeatureforapplication) | **GET** /api/v1/apps/{appId}/features/{featureName} | Retrieve a Feature
[**ListFeaturesForApplication**](ApplicationFeaturesApi.md#listfeaturesforapplication) | **GET** /api/v1/apps/{appId}/features | List all Features
[**UpdateFeatureForApplication**](ApplicationFeaturesApi.md#updatefeatureforapplication) | **PUT** /api/v1/apps/{appId}/features/{featureName} | Update a Feature


<a name="getfeatureforapplication"></a>
# **GetFeatureForApplication**
> ApplicationFeature GetFeatureForApplication (string appId, ApplicationFeatureType featureName)

Retrieve a Feature

Retrieves a Feature object for an application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetFeatureForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationFeaturesApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var featureName = (ApplicationFeatureType) "USER_PROVISIONING";  // ApplicationFeatureType | Name of the Feature

            try
            {
                // Retrieve a Feature
                ApplicationFeature result = apiInstance.GetFeatureForApplication(appId, featureName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationFeaturesApi.GetFeatureForApplication: " + e.Message );
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
 **appId** | **string**| Application ID | 
 **featureName** | **ApplicationFeatureType**| Name of the Feature | 

### Return type

[**ApplicationFeature**](ApplicationFeature.md)

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
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listfeaturesforapplication"></a>
# **ListFeaturesForApplication**
> List&lt;ApplicationFeature&gt; ListFeaturesForApplication (string appId)

List all Features

Lists all features for an application > **Note:** This request returns an error if provisioning isn't enabled for the application. > To set up provisioning, see [Update the default Provisioning Connection](/openapi/okta-management/management/tag/ApplicationConnections/#tag/ApplicationConnections/operation/updateDefaultProvisioningConnectionForApplication). 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListFeaturesForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationFeaturesApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // List all Features
                List<ApplicationFeature> result = apiInstance.ListFeaturesForApplication(appId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationFeaturesApi.ListFeaturesForApplication: " + e.Message );
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
 **appId** | **string**| Application ID | 

### Return type

[**List&lt;ApplicationFeature&gt;**](ApplicationFeature.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatefeatureforapplication"></a>
# **UpdateFeatureForApplication**
> ApplicationFeature UpdateFeatureForApplication (string appId, ApplicationFeatureType featureName, UpdateFeatureForApplicationRequest updateFeatureForApplicationRequest)

Update a Feature

Updates a Feature object for an application > **Note:** This endpoint supports partial updates. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateFeatureForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationFeaturesApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var featureName = (ApplicationFeatureType) "USER_PROVISIONING";  // ApplicationFeatureType | Name of the Feature
            var updateFeatureForApplicationRequest = new UpdateFeatureForApplicationRequest(); // UpdateFeatureForApplicationRequest | 

            try
            {
                // Update a Feature
                ApplicationFeature result = apiInstance.UpdateFeatureForApplication(appId, featureName, updateFeatureForApplicationRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationFeaturesApi.UpdateFeatureForApplication: " + e.Message );
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
 **appId** | **string**| Application ID | 
 **featureName** | **ApplicationFeatureType**| Name of the Feature | 
 **updateFeatureForApplicationRequest** | [**UpdateFeatureForApplicationRequest**](UpdateFeatureForApplicationRequest.md)|  | 

### Return type

[**ApplicationFeature**](ApplicationFeature.md)

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
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

