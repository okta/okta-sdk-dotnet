# Okta.Sdk.Api.UserClassificationApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetUserClassification**](UserClassificationApi.md#getuserclassification) | **GET** /api/v1/users/{userId}/classification | Retrieve a user&#39;s classification
[**ReplaceUserClassification**](UserClassificationApi.md#replaceuserclassification) | **PUT** /api/v1/users/{userId}/classification | Replace the user&#39;s classification


<a name="getuserclassification"></a>
# **GetUserClassification**
> UserClassification GetUserClassification (string userId)

Retrieve a user's classification

Retrieves a user's classification

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetUserClassificationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserClassificationApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // Retrieve a user's classification
                UserClassification result = apiInstance.GetUserClassification(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserClassificationApi.GetUserClassification: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 

### Return type

[**UserClassification**](UserClassification.md)

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

<a name="replaceuserclassification"></a>
# **ReplaceUserClassification**
> UserClassification ReplaceUserClassification (string userId, ReplaceUserClassification replaceUserClassification)

Replace the user's classification

Replaces the user's classification

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceUserClassificationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserClassificationApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var replaceUserClassification = new ReplaceUserClassification(); // ReplaceUserClassification | 

            try
            {
                // Replace the user's classification
                UserClassification result = apiInstance.ReplaceUserClassification(userId, replaceUserClassification);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserClassificationApi.ReplaceUserClassification: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 
 **replaceUserClassification** | [**ReplaceUserClassification**](ReplaceUserClassification.md)|  | 

### Return type

[**UserClassification**](UserClassification.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

