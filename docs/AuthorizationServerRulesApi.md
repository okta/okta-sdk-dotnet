# Okta.Sdk.Api.AuthorizationServerRulesApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateAuthorizationServerPolicyRule**](AuthorizationServerRulesApi.md#activateauthorizationserverpolicyrule) | **POST** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}/lifecycle/activate | Activate a Policy Rule
[**CreateAuthorizationServerPolicyRule**](AuthorizationServerRulesApi.md#createauthorizationserverpolicyrule) | **POST** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules | Create a Policy Rule
[**DeactivateAuthorizationServerPolicyRule**](AuthorizationServerRulesApi.md#deactivateauthorizationserverpolicyrule) | **POST** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}/lifecycle/deactivate | Deactivate a Policy Rule
[**DeleteAuthorizationServerPolicyRule**](AuthorizationServerRulesApi.md#deleteauthorizationserverpolicyrule) | **DELETE** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId} | Delete a Policy Rule
[**GetAuthorizationServerPolicyRule**](AuthorizationServerRulesApi.md#getauthorizationserverpolicyrule) | **GET** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId} | Retrieve a Policy Rule
[**ListAuthorizationServerPolicyRules**](AuthorizationServerRulesApi.md#listauthorizationserverpolicyrules) | **GET** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules | List all Policy Rules
[**ReplaceAuthorizationServerPolicyRule**](AuthorizationServerRulesApi.md#replaceauthorizationserverpolicyrule) | **PUT** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId} | Replace a Policy Rule


<a name="activateauthorizationserverpolicyrule"></a>
# **ActivateAuthorizationServerPolicyRule**
> void ActivateAuthorizationServerPolicyRule (string authServerId, string policyId, string ruleId)

Activate a Policy Rule

Activates an authorization server policy rule

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateAuthorizationServerPolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerRulesApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var ruleId = ruld3hJ7jZh4fn0st0g3;  // string | `id` of the Policy Rule

            try
            {
                // Activate a Policy Rule
                apiInstance.ActivateAuthorizationServerPolicyRule(authServerId, policyId, ruleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerRulesApi.ActivateAuthorizationServerPolicyRule: " + e.Message );
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
 **authServerId** | **string**| &#x60;id&#x60; of the Authorization Server | 
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **ruleId** | **string**| &#x60;id&#x60; of the Policy Rule | 

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

<a name="createauthorizationserverpolicyrule"></a>
# **CreateAuthorizationServerPolicyRule**
> AuthorizationServerPolicyRule CreateAuthorizationServerPolicyRule (string authServerId, string policyId, AuthorizationServerPolicyRule policyRule)

Create a Policy Rule

Creates a policy rule for the specified Custom Authorization Server and Policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateAuthorizationServerPolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerRulesApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var policyRule = new AuthorizationServerPolicyRule(); // AuthorizationServerPolicyRule | 

            try
            {
                // Create a Policy Rule
                AuthorizationServerPolicyRule result = apiInstance.CreateAuthorizationServerPolicyRule(authServerId, policyId, policyRule);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerRulesApi.CreateAuthorizationServerPolicyRule: " + e.Message );
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
 **authServerId** | **string**| &#x60;id&#x60; of the Authorization Server | 
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **policyRule** | [**AuthorizationServerPolicyRule**](AuthorizationServerPolicyRule.md)|  | 

### Return type

[**AuthorizationServerPolicyRule**](AuthorizationServerPolicyRule.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivateauthorizationserverpolicyrule"></a>
# **DeactivateAuthorizationServerPolicyRule**
> void DeactivateAuthorizationServerPolicyRule (string authServerId, string policyId, string ruleId)

Deactivate a Policy Rule

Deactivates an authorization server policy rule

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateAuthorizationServerPolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerRulesApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var ruleId = ruld3hJ7jZh4fn0st0g3;  // string | `id` of the Policy Rule

            try
            {
                // Deactivate a Policy Rule
                apiInstance.DeactivateAuthorizationServerPolicyRule(authServerId, policyId, ruleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerRulesApi.DeactivateAuthorizationServerPolicyRule: " + e.Message );
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
 **authServerId** | **string**| &#x60;id&#x60; of the Authorization Server | 
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **ruleId** | **string**| &#x60;id&#x60; of the Policy Rule | 

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

<a name="deleteauthorizationserverpolicyrule"></a>
# **DeleteAuthorizationServerPolicyRule**
> void DeleteAuthorizationServerPolicyRule (string authServerId, string policyId, string ruleId)

Delete a Policy Rule

Deletes a Policy Rule defined in the specified Custom Authorization Server and Policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteAuthorizationServerPolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerRulesApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var ruleId = ruld3hJ7jZh4fn0st0g3;  // string | `id` of the Policy Rule

            try
            {
                // Delete a Policy Rule
                apiInstance.DeleteAuthorizationServerPolicyRule(authServerId, policyId, ruleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerRulesApi.DeleteAuthorizationServerPolicyRule: " + e.Message );
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
 **authServerId** | **string**| &#x60;id&#x60; of the Authorization Server | 
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **ruleId** | **string**| &#x60;id&#x60; of the Policy Rule | 

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

<a name="getauthorizationserverpolicyrule"></a>
# **GetAuthorizationServerPolicyRule**
> AuthorizationServerPolicyRule GetAuthorizationServerPolicyRule (string authServerId, string policyId, string ruleId)

Retrieve a Policy Rule

Retrieves a policy rule by `ruleId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAuthorizationServerPolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerRulesApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var ruleId = ruld3hJ7jZh4fn0st0g3;  // string | `id` of the Policy Rule

            try
            {
                // Retrieve a Policy Rule
                AuthorizationServerPolicyRule result = apiInstance.GetAuthorizationServerPolicyRule(authServerId, policyId, ruleId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerRulesApi.GetAuthorizationServerPolicyRule: " + e.Message );
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
 **authServerId** | **string**| &#x60;id&#x60; of the Authorization Server | 
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **ruleId** | **string**| &#x60;id&#x60; of the Policy Rule | 

### Return type

[**AuthorizationServerPolicyRule**](AuthorizationServerPolicyRule.md)

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

<a name="listauthorizationserverpolicyrules"></a>
# **ListAuthorizationServerPolicyRules**
> List&lt;AuthorizationServerPolicyRule&gt; ListAuthorizationServerPolicyRules (string authServerId, string policyId)

List all Policy Rules

Lists all policy rules for the specified Custom Authorization Server and Policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAuthorizationServerPolicyRulesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerRulesApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy

            try
            {
                // List all Policy Rules
                List<AuthorizationServerPolicyRule> result = apiInstance.ListAuthorizationServerPolicyRules(authServerId, policyId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerRulesApi.ListAuthorizationServerPolicyRules: " + e.Message );
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
 **authServerId** | **string**| &#x60;id&#x60; of the Authorization Server | 
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 

### Return type

[**List&lt;AuthorizationServerPolicyRule&gt;**](AuthorizationServerPolicyRule.md)

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

<a name="replaceauthorizationserverpolicyrule"></a>
# **ReplaceAuthorizationServerPolicyRule**
> AuthorizationServerPolicyRule ReplaceAuthorizationServerPolicyRule (string authServerId, string policyId, string ruleId, AuthorizationServerPolicyRule policyRule)

Replace a Policy Rule

Replaces the configuration of the Policy Rule defined in the specified Custom Authorization Server and Policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceAuthorizationServerPolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerRulesApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var ruleId = ruld3hJ7jZh4fn0st0g3;  // string | `id` of the Policy Rule
            var policyRule = new AuthorizationServerPolicyRule(); // AuthorizationServerPolicyRule | 

            try
            {
                // Replace a Policy Rule
                AuthorizationServerPolicyRule result = apiInstance.ReplaceAuthorizationServerPolicyRule(authServerId, policyId, ruleId, policyRule);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerRulesApi.ReplaceAuthorizationServerPolicyRule: " + e.Message );
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
 **authServerId** | **string**| &#x60;id&#x60; of the Authorization Server | 
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **ruleId** | **string**| &#x60;id&#x60; of the Policy Rule | 
 **policyRule** | [**AuthorizationServerPolicyRule**](AuthorizationServerPolicyRule.md)|  | 

### Return type

[**AuthorizationServerPolicyRule**](AuthorizationServerPolicyRule.md)

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

