# Okta.Sdk.Api.FeatureApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetFeature**](FeatureApi.md#getfeature) | **GET** /api/v1/features/{featureId} | Retrieve a Feature
[**ListFeatureDependencies**](FeatureApi.md#listfeaturedependencies) | **GET** /api/v1/features/{featureId}/dependencies | List all Dependencies
[**ListFeatureDependents**](FeatureApi.md#listfeaturedependents) | **GET** /api/v1/features/{featureId}/dependents | List all Dependents
[**ListFeatures**](FeatureApi.md#listfeatures) | **GET** /api/v1/features | List all Features
[**UpdateFeatureLifecycle**](FeatureApi.md#updatefeaturelifecycle) | **POST** /api/v1/features/{featureId}/{lifecycle} | Update a Feature Lifecycle


<a name="getfeature"></a>
# **GetFeature**
> Feature GetFeature (string featureId)

Retrieve a Feature

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetFeatureExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FeatureApi(config);
            var featureId = "featureId_example";  // string | 

            try
            {
                // Retrieve a Feature
                Feature result = apiInstance.GetFeature(featureId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FeatureApi.GetFeature: " + e.Message );
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
 **featureId** | **string**|  | 

### Return type

[**Feature**](Feature.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="listfeaturedependencies"></a>
# **ListFeatureDependencies**
> List&lt;Feature&gt; ListFeatureDependencies (string featureId)

List all Dependencies

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListFeatureDependenciesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FeatureApi(config);
            var featureId = "featureId_example";  // string | 

            try
            {
                // List all Dependencies
                List<Feature> result = apiInstance.ListFeatureDependencies(featureId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FeatureApi.ListFeatureDependencies: " + e.Message );
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
 **featureId** | **string**|  | 

### Return type

[**List&lt;Feature&gt;**](Feature.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="listfeaturedependents"></a>
# **ListFeatureDependents**
> List&lt;Feature&gt; ListFeatureDependents (string featureId)

List all Dependents

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListFeatureDependentsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FeatureApi(config);
            var featureId = "featureId_example";  // string | 

            try
            {
                // List all Dependents
                List<Feature> result = apiInstance.ListFeatureDependents(featureId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FeatureApi.ListFeatureDependents: " + e.Message );
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
 **featureId** | **string**|  | 

### Return type

[**List&lt;Feature&gt;**](Feature.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="listfeatures"></a>
# **ListFeatures**
> List&lt;Feature&gt; ListFeatures ()

List all Features

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListFeaturesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FeatureApi(config);

            try
            {
                // List all Features
                List<Feature> result = apiInstance.ListFeatures().ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FeatureApi.ListFeatures: " + e.Message );
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

[**List&lt;Feature&gt;**](Feature.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="updatefeaturelifecycle"></a>
# **UpdateFeatureLifecycle**
> Feature UpdateFeatureLifecycle (string featureId, string lifecycle, string mode = null)

Update a Feature Lifecycle

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateFeatureLifecycleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FeatureApi(config);
            var featureId = "featureId_example";  // string | 
            var lifecycle = "lifecycle_example";  // string | 
            var mode = "mode_example";  // string |  (optional) 

            try
            {
                // Update a Feature Lifecycle
                Feature result = apiInstance.UpdateFeatureLifecycle(featureId, lifecycle, mode);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FeatureApi.UpdateFeatureLifecycle: " + e.Message );
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
 **featureId** | **string**|  | 
 **lifecycle** | **string**|  | 
 **mode** | **string**|  | [optional] 

### Return type

[**Feature**](Feature.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

