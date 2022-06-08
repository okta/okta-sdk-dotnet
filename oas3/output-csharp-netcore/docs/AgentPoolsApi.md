# Okta.Sdk.Api.AgentPoolsApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateAgentPoolsUpdate**](AgentPoolsApi.md#activateagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates/{updateId}/activate | Activate Agent pool update
[**CreateAgentPoolsUpdate**](AgentPoolsApi.md#createagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates | Create an Agent pool update
[**DeactivateAgentPoolsUpdate**](AgentPoolsApi.md#deactivateagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates/{updateId}/deactivate | Deactivate Agent pool update
[**DeleteAgentPoolsUpdate**](AgentPoolsApi.md#deleteagentpoolsupdate) | **DELETE** /api/v1/agentPools/{poolId}/updates/{updateId} | Delete Agent pool update
[**GetAgentPools**](AgentPoolsApi.md#getagentpools) | **GET** /api/v1/agentPools | Fetch AgentPools
[**GetAgentPoolsUpdateInstance**](AgentPoolsApi.md#getagentpoolsupdateinstance) | **GET** /api/v1/agentPools/{poolId}/updates/{updateId} | Get Agent pool update by id
[**GetAgentPoolsUpdateSettings**](AgentPoolsApi.md#getagentpoolsupdatesettings) | **GET** /api/v1/agentPools/{poolId}/updates/settings | Get Agent pool update settings
[**GetAgentPoolsUpdates**](AgentPoolsApi.md#getagentpoolsupdates) | **GET** /api/v1/agentPools/{poolId}/updates | List Agent pool updates
[**PauseAgentPoolsUpdate**](AgentPoolsApi.md#pauseagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates/{updateId}/pause | Pause Agent pool update
[**ResumeAgentPoolsUpdate**](AgentPoolsApi.md#resumeagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates/{updateId}/resume | Resume Agent pool update
[**RetryAgentPoolsUpdate**](AgentPoolsApi.md#retryagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates/{updateId}/retry | Retry Agent pool update
[**SetAgentPoolsUpdateSettings**](AgentPoolsApi.md#setagentpoolsupdatesettings) | **POST** /api/v1/agentPools/{poolId}/updates/settings | Update Agent pool update settings
[**StopAgentPoolsUpdate**](AgentPoolsApi.md#stopagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates/{updateId}/stop | Stop Agent pool update
[**UpdateAgentPoolsUpdate**](AgentPoolsApi.md#updateagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates/{updateId} | Change Agent pool update by id


<a name="activateagentpoolsupdate"></a>
# **ActivateAgentPoolsUpdate**
> AgentPoolUpdate ActivateAgentPoolsUpdate (string poolId, string updateId)

Activate Agent pool update

Activates scheduled Agent pool update

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateAgentPoolsUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | Id of the agent pool for which the settings will apply
            var updateId = "updateId_example";  // string | Id of the update

            try
            {
                // Activate Agent pool update
                AgentPoolUpdate result = apiInstance.ActivateAgentPoolsUpdate(poolId, updateId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.ActivateAgentPoolsUpdate: " + e.Message );
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
 **poolId** | **string**| Id of the agent pool for which the settings will apply | 
 **updateId** | **string**| Id of the update | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Activated |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createagentpoolsupdate"></a>
# **CreateAgentPoolsUpdate**
> AgentPoolUpdate CreateAgentPoolsUpdate (string poolId, AgentPoolUpdate agentPoolUpdate)

Create an Agent pool update

Creates an Agent pool update \\n For user flow 2 manual update, starts the update immediately. \\n For user flow 3, schedules the update based on the configured update window and delay.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateAgentPoolsUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | Id of the agent pool for which the settings will apply
            var agentPoolUpdate = new AgentPoolUpdate(); // AgentPoolUpdate | 

            try
            {
                // Create an Agent pool update
                AgentPoolUpdate result = apiInstance.CreateAgentPoolsUpdate(poolId, agentPoolUpdate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.CreateAgentPoolsUpdate: " + e.Message );
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
 **poolId** | **string**| Id of the agent pool for which the settings will apply | 
 **agentPoolUpdate** | [**AgentPoolUpdate**](AgentPoolUpdate.md)|  | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

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

<a name="deactivateagentpoolsupdate"></a>
# **DeactivateAgentPoolsUpdate**
> AgentPoolUpdate DeactivateAgentPoolsUpdate (string poolId, string updateId)

Deactivate Agent pool update

Deactivates scheduled Agent pool update

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateAgentPoolsUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | Id of the agent pool for which the settings will apply
            var updateId = "updateId_example";  // string | Id of the update

            try
            {
                // Deactivate Agent pool update
                AgentPoolUpdate result = apiInstance.DeactivateAgentPoolsUpdate(poolId, updateId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.DeactivateAgentPoolsUpdate: " + e.Message );
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
 **poolId** | **string**| Id of the agent pool for which the settings will apply | 
 **updateId** | **string**| Id of the update | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Deactivated |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteagentpoolsupdate"></a>
# **DeleteAgentPoolsUpdate**
> void DeleteAgentPoolsUpdate (string poolId, string updateId)

Delete Agent pool update

Deletes Agent pool update

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteAgentPoolsUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | Id of the agent pool for which the settings will apply
            var updateId = "updateId_example";  // string | Id of the update

            try
            {
                // Delete Agent pool update
                apiInstance.DeleteAgentPoolsUpdate(poolId, updateId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.DeleteAgentPoolsUpdate: " + e.Message );
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
 **poolId** | **string**| Id of the agent pool for which the settings will apply | 
 **updateId** | **string**| Id of the update | 

### Return type

void (empty response body)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Deleted |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getagentpools"></a>
# **GetAgentPools**
> List&lt;AgentPool&gt; GetAgentPools (int? limitPerPoolType = null, AgentType? poolType = null, string after = null)

Fetch AgentPools

Fetches AgentPools based on request parameters for a given org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAgentPoolsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var limitPerPoolType = 5;  // int? | Maximum number of AgentPools being returned (optional)  (default to 5)
            var poolType = (AgentType) "AD";  // AgentType? | Agent type to search for (optional) 
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/reference/core-okta-api/#pagination) for more information. (optional) 

            try
            {
                // Fetch AgentPools
                List<AgentPool> result = apiInstance.GetAgentPools(limitPerPoolType, poolType, after);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.GetAgentPools: " + e.Message );
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
 **limitPerPoolType** | **int?**| Maximum number of AgentPools being returned | [optional] [default to 5]
 **poolType** | **AgentType?**| Agent type to search for | [optional] 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/reference/core-okta-api/#pagination) for more information. | [optional] 

### Return type

[**List&lt;AgentPool&gt;**](AgentPool.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

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

<a name="getagentpoolsupdateinstance"></a>
# **GetAgentPoolsUpdateInstance**
> AgentPoolUpdate GetAgentPoolsUpdateInstance (string poolId, string updateId)

Get Agent pool update by id

Gets Agent pool update from updateId

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAgentPoolsUpdateInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | Id of the agent pool for which the settings will apply
            var updateId = "updateId_example";  // string | Id of the update

            try
            {
                // Get Agent pool update by id
                AgentPoolUpdate result = apiInstance.GetAgentPoolsUpdateInstance(poolId, updateId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.GetAgentPoolsUpdateInstance: " + e.Message );
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
 **poolId** | **string**| Id of the agent pool for which the settings will apply | 
 **updateId** | **string**| Id of the update | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

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

<a name="getagentpoolsupdatesettings"></a>
# **GetAgentPoolsUpdateSettings**
> AgentPoolUpdateSetting GetAgentPoolsUpdateSettings (string poolId)

Get Agent pool update settings

Gets the current state of the agent pool update instance settings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAgentPoolsUpdateSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | Id of the agent pool for which the settings will apply

            try
            {
                // Get Agent pool update settings
                AgentPoolUpdateSetting result = apiInstance.GetAgentPoolsUpdateSettings(poolId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.GetAgentPoolsUpdateSettings: " + e.Message );
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
 **poolId** | **string**| Id of the agent pool for which the settings will apply | 

### Return type

[**AgentPoolUpdateSetting**](AgentPoolUpdateSetting.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

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

<a name="getagentpoolsupdates"></a>
# **GetAgentPoolsUpdates**
> List&lt;AgentPoolUpdate&gt; GetAgentPoolsUpdates (string poolId, bool? scheduled = null)

List Agent pool updates

Gets List of Agent pool updates

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAgentPoolsUpdatesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | Id of the agent pool for which the settings will apply
            var scheduled = true;  // bool? | Scope the list only to scheduled or ad-hoc updates. If the parameter is not provided we will return the whole list of updates. (optional) 

            try
            {
                // List Agent pool updates
                List<AgentPoolUpdate> result = apiInstance.GetAgentPoolsUpdates(poolId, scheduled);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.GetAgentPoolsUpdates: " + e.Message );
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
 **poolId** | **string**| Id of the agent pool for which the settings will apply | 
 **scheduled** | **bool?**| Scope the list only to scheduled or ad-hoc updates. If the parameter is not provided we will return the whole list of updates. | [optional] 

### Return type

[**List&lt;AgentPoolUpdate&gt;**](AgentPoolUpdate.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

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

<a name="pauseagentpoolsupdate"></a>
# **PauseAgentPoolsUpdate**
> AgentPoolUpdate PauseAgentPoolsUpdate (string poolId, string updateId)

Pause Agent pool update

Pauses running or queued Agent pool update

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class PauseAgentPoolsUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | Id of the agent pool for which the settings will apply
            var updateId = "updateId_example";  // string | Id of the update

            try
            {
                // Pause Agent pool update
                AgentPoolUpdate result = apiInstance.PauseAgentPoolsUpdate(poolId, updateId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.PauseAgentPoolsUpdate: " + e.Message );
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
 **poolId** | **string**| Id of the agent pool for which the settings will apply | 
 **updateId** | **string**| Id of the update | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Paused |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="resumeagentpoolsupdate"></a>
# **ResumeAgentPoolsUpdate**
> AgentPoolUpdate ResumeAgentPoolsUpdate (string poolId, string updateId)

Resume Agent pool update

Resumes running or queued Agent pool update

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ResumeAgentPoolsUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | Id of the agent pool for which the settings will apply
            var updateId = "updateId_example";  // string | Id of the update

            try
            {
                // Resume Agent pool update
                AgentPoolUpdate result = apiInstance.ResumeAgentPoolsUpdate(poolId, updateId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.ResumeAgentPoolsUpdate: " + e.Message );
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
 **poolId** | **string**| Id of the agent pool for which the settings will apply | 
 **updateId** | **string**| Id of the update | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Resumed |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="retryagentpoolsupdate"></a>
# **RetryAgentPoolsUpdate**
> AgentPoolUpdate RetryAgentPoolsUpdate (string poolId, string updateId)

Retry Agent pool update

Retries Agent pool update

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RetryAgentPoolsUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | Id of the agent pool for which the settings will apply
            var updateId = "updateId_example";  // string | Id of the update

            try
            {
                // Retry Agent pool update
                AgentPoolUpdate result = apiInstance.RetryAgentPoolsUpdate(poolId, updateId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.RetryAgentPoolsUpdate: " + e.Message );
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
 **poolId** | **string**| Id of the agent pool for which the settings will apply | 
 **updateId** | **string**| Id of the update | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Retried |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="setagentpoolsupdatesettings"></a>
# **SetAgentPoolsUpdateSettings**
> AgentPoolUpdateSetting SetAgentPoolsUpdateSettings (string poolId, AgentPoolUpdateSetting agentPoolUpdateSetting)

Update Agent pool update settings

Updates Agent pool update settings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class SetAgentPoolsUpdateSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | Id of the agent pool for which the settings will apply
            var agentPoolUpdateSetting = new AgentPoolUpdateSetting(); // AgentPoolUpdateSetting | 

            try
            {
                // Update Agent pool update settings
                AgentPoolUpdateSetting result = apiInstance.SetAgentPoolsUpdateSettings(poolId, agentPoolUpdateSetting);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.SetAgentPoolsUpdateSettings: " + e.Message );
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
 **poolId** | **string**| Id of the agent pool for which the settings will apply | 
 **agentPoolUpdateSetting** | [**AgentPoolUpdateSetting**](AgentPoolUpdateSetting.md)|  | 

### Return type

[**AgentPoolUpdateSetting**](AgentPoolUpdateSetting.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Updated |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stopagentpoolsupdate"></a>
# **StopAgentPoolsUpdate**
> AgentPoolUpdate StopAgentPoolsUpdate (string poolId, string updateId)

Stop Agent pool update

Stops Agent pool update

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class StopAgentPoolsUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | Id of the agent pool for which the settings will apply
            var updateId = "updateId_example";  // string | Id of the update

            try
            {
                // Stop Agent pool update
                AgentPoolUpdate result = apiInstance.StopAgentPoolsUpdate(poolId, updateId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.StopAgentPoolsUpdate: " + e.Message );
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
 **poolId** | **string**| Id of the agent pool for which the settings will apply | 
 **updateId** | **string**| Id of the update | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Stopped |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateagentpoolsupdate"></a>
# **UpdateAgentPoolsUpdate**
> AgentPoolUpdate UpdateAgentPoolsUpdate (string poolId, string updateId, AgentPoolUpdate agentPoolUpdate)

Change Agent pool update by id

Updates Agent pool update and return latest agent pool update

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateAgentPoolsUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | Id of the agent pool for which the settings will apply
            var updateId = "updateId_example";  // string | Id of the update
            var agentPoolUpdate = new AgentPoolUpdate(); // AgentPoolUpdate | 

            try
            {
                // Change Agent pool update by id
                AgentPoolUpdate result = apiInstance.UpdateAgentPoolsUpdate(poolId, updateId, agentPoolUpdate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.UpdateAgentPoolsUpdate: " + e.Message );
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
 **poolId** | **string**| Id of the agent pool for which the settings will apply | 
 **updateId** | **string**| Id of the update | 
 **agentPoolUpdate** | [**AgentPoolUpdate**](AgentPoolUpdate.md)|  | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Updated |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

