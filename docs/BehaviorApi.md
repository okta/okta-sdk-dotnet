# Okta.Sdk.Api.BehaviorApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateBehaviorDetectionRule**](BehaviorApi.md#activatebehaviordetectionrule) | **POST** /api/v1/behaviors/{behaviorId}/lifecycle/activate | Activate a Behavior Detection Rule
[**CreateBehaviorDetectionRule**](BehaviorApi.md#createbehaviordetectionrule) | **POST** /api/v1/behaviors | Create a Behavior Detection Rule
[**DeactivateBehaviorDetectionRule**](BehaviorApi.md#deactivatebehaviordetectionrule) | **POST** /api/v1/behaviors/{behaviorId}/lifecycle/deactivate | Deactivate a Behavior Detection Rule
[**DeleteBehaviorDetectionRule**](BehaviorApi.md#deletebehaviordetectionrule) | **DELETE** /api/v1/behaviors/{behaviorId} | Delete a Behavior Detection Rule
[**GetBehaviorDetectionRule**](BehaviorApi.md#getbehaviordetectionrule) | **GET** /api/v1/behaviors/{behaviorId} | Retrieve a Behavior Detection Rule
[**ListBehaviorDetectionRules**](BehaviorApi.md#listbehaviordetectionrules) | **GET** /api/v1/behaviors | List all Behavior Detection Rules
[**UpdateBehaviorDetectionRule**](BehaviorApi.md#updatebehaviordetectionrule) | **PUT** /api/v1/behaviors/{behaviorId} | Replace a Behavior Detection Rule


<a name="activatebehaviordetectionrule"></a>
# **ActivateBehaviorDetectionRule**
> BehaviorRule ActivateBehaviorDetectionRule (string behaviorId)

Activate a Behavior Detection Rule

Activate Behavior Detection Rule

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateBehaviorDetectionRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BehaviorApi(config);
            var behaviorId = abcd1234;  // string | id of the Behavior Detection Rule

            try
            {
                // Activate a Behavior Detection Rule
                BehaviorRule result = apiInstance.ActivateBehaviorDetectionRule(behaviorId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BehaviorApi.ActivateBehaviorDetectionRule: " + e.Message );
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
 **behaviorId** | **string**| id of the Behavior Detection Rule | 

### Return type

[**BehaviorRule**](BehaviorRule.md)

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

<a name="createbehaviordetectionrule"></a>
# **CreateBehaviorDetectionRule**
> BehaviorRule CreateBehaviorDetectionRule (BehaviorRule rule)

Create a Behavior Detection Rule

Adds a new Behavior Detection Rule to your organization.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateBehaviorDetectionRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BehaviorApi(config);
            var rule = new BehaviorRule(); // BehaviorRule | 

            try
            {
                // Create a Behavior Detection Rule
                BehaviorRule result = apiInstance.CreateBehaviorDetectionRule(rule);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BehaviorApi.CreateBehaviorDetectionRule: " + e.Message );
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
 **rule** | [**BehaviorRule**](BehaviorRule.md)|  | 

### Return type

[**BehaviorRule**](BehaviorRule.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="deactivatebehaviordetectionrule"></a>
# **DeactivateBehaviorDetectionRule**
> BehaviorRule DeactivateBehaviorDetectionRule (string behaviorId)

Deactivate a Behavior Detection Rule

Deactivate Behavior Detection Rule

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateBehaviorDetectionRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BehaviorApi(config);
            var behaviorId = abcd1234;  // string | id of the Behavior Detection Rule

            try
            {
                // Deactivate a Behavior Detection Rule
                BehaviorRule result = apiInstance.DeactivateBehaviorDetectionRule(behaviorId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BehaviorApi.DeactivateBehaviorDetectionRule: " + e.Message );
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
 **behaviorId** | **string**| id of the Behavior Detection Rule | 

### Return type

[**BehaviorRule**](BehaviorRule.md)

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

<a name="deletebehaviordetectionrule"></a>
# **DeleteBehaviorDetectionRule**
> void DeleteBehaviorDetectionRule (string behaviorId)

Delete a Behavior Detection Rule

Delete a Behavior Detection Rule by `behaviorId`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteBehaviorDetectionRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BehaviorApi(config);
            var behaviorId = abcd1234;  // string | id of the Behavior Detection Rule

            try
            {
                // Delete a Behavior Detection Rule
                apiInstance.DeleteBehaviorDetectionRule(behaviorId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BehaviorApi.DeleteBehaviorDetectionRule: " + e.Message );
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
 **behaviorId** | **string**| id of the Behavior Detection Rule | 

### Return type

void (empty response body)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="getbehaviordetectionrule"></a>
# **GetBehaviorDetectionRule**
> List&lt;BehaviorRule&gt; GetBehaviorDetectionRule (string behaviorId)

Retrieve a Behavior Detection Rule

Fetches a Behavior Detection Rule by `behaviorId`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetBehaviorDetectionRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BehaviorApi(config);
            var behaviorId = abcd1234;  // string | id of the Behavior Detection Rule

            try
            {
                // Retrieve a Behavior Detection Rule
                List<BehaviorRule> result = apiInstance.GetBehaviorDetectionRule(behaviorId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BehaviorApi.GetBehaviorDetectionRule: " + e.Message );
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
 **behaviorId** | **string**| id of the Behavior Detection Rule | 

### Return type

[**List&lt;BehaviorRule&gt;**](BehaviorRule.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="listbehaviordetectionrules"></a>
# **ListBehaviorDetectionRules**
> List&lt;BehaviorRule&gt; ListBehaviorDetectionRules ()

List all Behavior Detection Rules

Enumerates Behavior Detection Rules in your organization with pagination.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListBehaviorDetectionRulesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BehaviorApi(config);

            try
            {
                // List all Behavior Detection Rules
                List<BehaviorRule> result = apiInstance.ListBehaviorDetectionRules();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BehaviorApi.ListBehaviorDetectionRules: " + e.Message );
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

[**List&lt;BehaviorRule&gt;**](BehaviorRule.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="updatebehaviordetectionrule"></a>
# **UpdateBehaviorDetectionRule**
> BehaviorRule UpdateBehaviorDetectionRule (string behaviorId, BehaviorRule rule)

Replace a Behavior Detection Rule

Update a Behavior Detection Rule by `behaviorId`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateBehaviorDetectionRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BehaviorApi(config);
            var behaviorId = abcd1234;  // string | id of the Behavior Detection Rule
            var rule = new BehaviorRule(); // BehaviorRule | 

            try
            {
                // Replace a Behavior Detection Rule
                BehaviorRule result = apiInstance.UpdateBehaviorDetectionRule(behaviorId, rule);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BehaviorApi.UpdateBehaviorDetectionRule: " + e.Message );
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
 **behaviorId** | **string**| id of the Behavior Detection Rule | 
 **rule** | [**BehaviorRule**](BehaviorRule.md)|  | 

### Return type

[**BehaviorRule**](BehaviorRule.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Created |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

