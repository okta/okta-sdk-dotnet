# Okta.Sdk.Api.GroupRuleApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateGroupRule**](GroupRuleApi.md#activategrouprule) | **POST** /api/v1/groups/rules/{groupRuleId}/lifecycle/activate | Activate a group rule
[**CreateGroupRule**](GroupRuleApi.md#creategrouprule) | **POST** /api/v1/groups/rules | Create a group rule
[**DeactivateGroupRule**](GroupRuleApi.md#deactivategrouprule) | **POST** /api/v1/groups/rules/{groupRuleId}/lifecycle/deactivate | Deactivate a group rule
[**DeleteGroupRule**](GroupRuleApi.md#deletegrouprule) | **DELETE** /api/v1/groups/rules/{groupRuleId} | Delete a group rule
[**GetGroupRule**](GroupRuleApi.md#getgrouprule) | **GET** /api/v1/groups/rules/{groupRuleId} | Retrieve a group rule
[**ListGroupRules**](GroupRuleApi.md#listgrouprules) | **GET** /api/v1/groups/rules | List all group rules
[**ReplaceGroupRule**](GroupRuleApi.md#replacegrouprule) | **PUT** /api/v1/groups/rules/{groupRuleId} | Replace a group rule


<a name="activategrouprule"></a>
# **ActivateGroupRule**
> void ActivateGroupRule (string groupRuleId)

Activate a group rule

Activates a specific group rule by ID from your org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateGroupRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupRuleApi(config);
            var groupRuleId = 0pr3f7zMZZHPgUoWO0g4;  // string | The `id` of the group rule

            try
            {
                // Activate a group rule
                apiInstance.ActivateGroupRule(groupRuleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupRuleApi.ActivateGroupRule: " + e.Message );
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
 **groupRuleId** | **string**| The &#x60;id&#x60; of the group rule | 

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

<a name="creategrouprule"></a>
# **CreateGroupRule**
> GroupRule CreateGroupRule (CreateGroupRuleRequest groupRule)

Create a group rule

Creates a group rule to dynamically add users to the specified group if they match the condition > **Note:** Group rules are created with the status set to `'INACTIVE'`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateGroupRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupRuleApi(config);
            var groupRule = new CreateGroupRuleRequest(); // CreateGroupRuleRequest | 

            try
            {
                // Create a group rule
                GroupRule result = apiInstance.CreateGroupRule(groupRule);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupRuleApi.CreateGroupRule: " + e.Message );
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
 **groupRule** | [**CreateGroupRuleRequest**](CreateGroupRuleRequest.md)|  | 

### Return type

[**GroupRule**](GroupRule.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivategrouprule"></a>
# **DeactivateGroupRule**
> void DeactivateGroupRule (string groupRuleId)

Deactivate a group rule

Deactivates a specific group rule by ID from your org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateGroupRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupRuleApi(config);
            var groupRuleId = 0pr3f7zMZZHPgUoWO0g4;  // string | The `id` of the group rule

            try
            {
                // Deactivate a group rule
                apiInstance.DeactivateGroupRule(groupRuleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupRuleApi.DeactivateGroupRule: " + e.Message );
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
 **groupRuleId** | **string**| The &#x60;id&#x60; of the group rule | 

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

<a name="deletegrouprule"></a>
# **DeleteGroupRule**
> void DeleteGroupRule (string groupRuleId, bool? removeUsers = null)

Delete a group rule

Deletes a specific group rule by `groupRuleId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteGroupRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupRuleApi(config);
            var groupRuleId = 0pr3f7zMZZHPgUoWO0g4;  // string | The `id` of the group rule
            var removeUsers = false;  // bool? | If set to `true`, removes users from groups assigned by this rule (optional)  (default to false)

            try
            {
                // Delete a group rule
                apiInstance.DeleteGroupRule(groupRuleId, removeUsers);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupRuleApi.DeleteGroupRule: " + e.Message );
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
 **groupRuleId** | **string**| The &#x60;id&#x60; of the group rule | 
 **removeUsers** | **bool?**| If set to &#x60;true&#x60;, removes users from groups assigned by this rule | [optional] [default to false]

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
| **202** | Accepted |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getgrouprule"></a>
# **GetGroupRule**
> GroupRule GetGroupRule (string groupRuleId, string expand = null)

Retrieve a group rule

Retrieves a specific group rule by ID from your org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetGroupRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupRuleApi(config);
            var groupRuleId = 0pr3f7zMZZHPgUoWO0g4;  // string | The `id` of the group rule
            var expand = "expand_example";  // string | If specified as `groupIdToGroupNameMap`, then show group names (optional) 

            try
            {
                // Retrieve a group rule
                GroupRule result = apiInstance.GetGroupRule(groupRuleId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupRuleApi.GetGroupRule: " + e.Message );
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
 **groupRuleId** | **string**| The &#x60;id&#x60; of the group rule | 
 **expand** | **string**| If specified as &#x60;groupIdToGroupNameMap&#x60;, then show group names | [optional] 

### Return type

[**GroupRule**](GroupRule.md)

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

<a name="listgrouprules"></a>
# **ListGroupRules**
> List&lt;GroupRule&gt; ListGroupRules (int? limit = null, string after = null, string search = null, string expand = null)

List all group rules

Lists all group rules for your org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGroupRulesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupRuleApi(config);
            var limit = 50;  // int? | Specifies the number of rule results in a page (optional)  (default to 50)
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of rules (optional) 
            var search = "search_example";  // string | Specifies the keyword to search rules for (optional) 
            var expand = "expand_example";  // string | If specified as `groupIdToGroupNameMap`, then displays group names (optional) 

            try
            {
                // List all group rules
                List<GroupRule> result = apiInstance.ListGroupRules(limit, after, search, expand).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupRuleApi.ListGroupRules: " + e.Message );
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
 **limit** | **int?**| Specifies the number of rule results in a page | [optional] [default to 50]
 **after** | **string**| Specifies the pagination cursor for the next page of rules | [optional] 
 **search** | **string**| Specifies the keyword to search rules for | [optional] 
 **expand** | **string**| If specified as &#x60;groupIdToGroupNameMap&#x60;, then displays group names | [optional] 

### Return type

[**List&lt;GroupRule&gt;**](GroupRule.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacegrouprule"></a>
# **ReplaceGroupRule**
> GroupRule ReplaceGroupRule (string groupRuleId, GroupRule groupRule)

Replace a group rule

Replaces a group rule > **Notes:** You can only update rules with a group whose status is set to `'INACTIVE'`. > > You currently can't update the `action` section.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceGroupRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupRuleApi(config);
            var groupRuleId = 0pr3f7zMZZHPgUoWO0g4;  // string | The `id` of the group rule
            var groupRule = new GroupRule(); // GroupRule | 

            try
            {
                // Replace a group rule
                GroupRule result = apiInstance.ReplaceGroupRule(groupRuleId, groupRule);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupRuleApi.ReplaceGroupRule: " + e.Message );
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
 **groupRuleId** | **string**| The &#x60;id&#x60; of the group rule | 
 **groupRule** | [**GroupRule**](GroupRule.md)|  | 

### Return type

[**GroupRule**](GroupRule.md)

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

