# Okta.Sdk.Api.BehaviorApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateBehaviorDetectionRule**](BehaviorApi.md#activatebehaviordetectionrule) | **POST** /api/v1/behaviors/{behaviorId}/lifecycle/activate | Activate a behavior detection rule
[**CreateBehaviorDetectionRule**](BehaviorApi.md#createbehaviordetectionrule) | **POST** /api/v1/behaviors | Create a behavior detection rule
[**DeactivateBehaviorDetectionRule**](BehaviorApi.md#deactivatebehaviordetectionrule) | **POST** /api/v1/behaviors/{behaviorId}/lifecycle/deactivate | Deactivate a behavior detection rule
[**DeleteBehaviorDetectionRule**](BehaviorApi.md#deletebehaviordetectionrule) | **DELETE** /api/v1/behaviors/{behaviorId} | Delete a behavior detection rule
[**GetBehaviorDetectionRule**](BehaviorApi.md#getbehaviordetectionrule) | **GET** /api/v1/behaviors/{behaviorId} | Retrieve a behavior detection rule
[**ListBehaviorDetectionRules**](BehaviorApi.md#listbehaviordetectionrules) | **GET** /api/v1/behaviors | List all behavior detection rules
[**ReplaceBehaviorDetectionRule**](BehaviorApi.md#replacebehaviordetectionrule) | **PUT** /api/v1/behaviors/{behaviorId} | Replace a behavior detection rule


<a name="activatebehaviordetectionrule"></a>
# **ActivateBehaviorDetectionRule**
> BehaviorRule ActivateBehaviorDetectionRule (string behaviorId)

Activate a behavior detection rule

Activates a behavior detection rule

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BehaviorApi(config);
            var behaviorId = abcd1234;  // string | ID of the Behavior Detection Rule

            try
            {
                // Activate a behavior detection rule
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
 **behaviorId** | **string**| ID of the Behavior Detection Rule | 

### Return type

[**BehaviorRule**](BehaviorRule.md)

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

<a name="createbehaviordetectionrule"></a>
# **CreateBehaviorDetectionRule**
> BehaviorRule CreateBehaviorDetectionRule (BehaviorRule rule)

Create a behavior detection rule

Creates a new behavior detection rule

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BehaviorApi(config);
            var rule = new BehaviorRule(); // BehaviorRule | 

            try
            {
                // Create a behavior detection rule
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

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Created |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivatebehaviordetectionrule"></a>
# **DeactivateBehaviorDetectionRule**
> BehaviorRule DeactivateBehaviorDetectionRule (string behaviorId)

Deactivate a behavior detection rule

Deactivates a behavior detection rule

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BehaviorApi(config);
            var behaviorId = abcd1234;  // string | ID of the Behavior Detection Rule

            try
            {
                // Deactivate a behavior detection rule
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
 **behaviorId** | **string**| ID of the Behavior Detection Rule | 

### Return type

[**BehaviorRule**](BehaviorRule.md)

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

<a name="deletebehaviordetectionrule"></a>
# **DeleteBehaviorDetectionRule**
> void DeleteBehaviorDetectionRule (string behaviorId)

Delete a behavior detection rule

Deletes a Behavior Detection Rule by `behaviorId`

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BehaviorApi(config);
            var behaviorId = abcd1234;  // string | ID of the Behavior Detection Rule

            try
            {
                // Delete a behavior detection rule
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
 **behaviorId** | **string**| ID of the Behavior Detection Rule | 

### Return type

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

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
> BehaviorRule GetBehaviorDetectionRule (string behaviorId)

Retrieve a behavior detection rule

Retrieves a Behavior Detection Rule by `behaviorId`

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BehaviorApi(config);
            var behaviorId = abcd1234;  // string | ID of the Behavior Detection Rule

            try
            {
                // Retrieve a behavior detection rule
                BehaviorRule result = apiInstance.GetBehaviorDetectionRule(behaviorId);
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
 **behaviorId** | **string**| ID of the Behavior Detection Rule | 

### Return type

[**BehaviorRule**](BehaviorRule.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

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

List all behavior detection rules

Lists all behavior detection rules with pagination support

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BehaviorApi(config);

            try
            {
                // List all behavior detection rules
                List<BehaviorRule> result = apiInstance.ListBehaviorDetectionRules().ToListAsync();
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

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

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

<a name="replacebehaviordetectionrule"></a>
# **ReplaceBehaviorDetectionRule**
> BehaviorRule ReplaceBehaviorDetectionRule (string behaviorId, BehaviorRule rule)

Replace a behavior detection rule

Replaces a Behavior Detection Rule by `behaviorId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceBehaviorDetectionRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BehaviorApi(config);
            var behaviorId = abcd1234;  // string | ID of the Behavior Detection Rule
            var rule = new BehaviorRule(); // BehaviorRule | 

            try
            {
                // Replace a behavior detection rule
                BehaviorRule result = apiInstance.ReplaceBehaviorDetectionRule(behaviorId, rule);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BehaviorApi.ReplaceBehaviorDetectionRule: " + e.Message );
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
 **behaviorId** | **string**| ID of the Behavior Detection Rule | 
 **rule** | [**BehaviorRule**](BehaviorRule.md)|  | 

### Return type

[**BehaviorRule**](BehaviorRule.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

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

