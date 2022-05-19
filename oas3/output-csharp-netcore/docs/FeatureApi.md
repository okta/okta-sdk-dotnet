# Org.OpenAPITools.Api.FeatureApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetFeature**](FeatureApi.md#getfeature) | **GET** /api/v1/features/{featureId} | Get Feature
[**ListFeatureDependencies**](FeatureApi.md#listfeaturedependencies) | **GET** /api/v1/features/{featureId}/dependencies | List Feature Dependencies
[**ListFeatureDependents**](FeatureApi.md#listfeaturedependents) | **GET** /api/v1/features/{featureId}/dependents | List Feature Dependents
[**ListFeatures**](FeatureApi.md#listfeatures) | **GET** /api/v1/features | List Features
[**UpdateFeatureLifecycle**](FeatureApi.md#updatefeaturelifecycle) | **POST** /api/v1/features/{featureId}/{lifecycle} | Update Feature Lifecycle


<a name="getfeature"></a>
# **GetFeature**
> Feature GetFeature (string featureId)

Get Feature

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetFeatureExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new FeatureApi(config);
            var featureId = "featureId_example";  // string | 

            try
            {
                // Get Feature
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

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listfeaturedependencies"></a>
# **ListFeatureDependencies**
> List&lt;Feature&gt; ListFeatureDependencies (string featureId)

List Feature Dependencies

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ListFeatureDependenciesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new FeatureApi(config);
            var featureId = "featureId_example";  // string | 

            try
            {
                // List Feature Dependencies
                List<Feature> result = apiInstance.ListFeatureDependencies(featureId);
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

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listfeaturedependents"></a>
# **ListFeatureDependents**
> List&lt;Feature&gt; ListFeatureDependents (string featureId)

List Feature Dependents

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ListFeatureDependentsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new FeatureApi(config);
            var featureId = "featureId_example";  // string | 

            try
            {
                // List Feature Dependents
                List<Feature> result = apiInstance.ListFeatureDependents(featureId);
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

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listfeatures"></a>
# **ListFeatures**
> List&lt;Feature&gt; ListFeatures ()

List Features

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ListFeaturesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new FeatureApi(config);

            try
            {
                // List Features
                List<Feature> result = apiInstance.ListFeatures();
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

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatefeaturelifecycle"></a>
# **UpdateFeatureLifecycle**
> Feature UpdateFeatureLifecycle (string featureId, string lifecycle, string mode = null)

Update Feature Lifecycle

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UpdateFeatureLifecycleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new FeatureApi(config);
            var featureId = "featureId_example";  // string | 
            var lifecycle = "lifecycle_example";  // string | 
            var mode = "mode_example";  // string |  (optional) 

            try
            {
                // Update Feature Lifecycle
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

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

