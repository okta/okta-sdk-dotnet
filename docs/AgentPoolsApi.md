# Okta.Sdk.Api.AgentPoolsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateAgentPoolsUpdate**](AgentPoolsApi.md#activateagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates/{updateId}/activate | Activate an agent pool update
[**CreateAgentPoolsUpdate**](AgentPoolsApi.md#createagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates | Create an agent pool update
[**DeactivateAgentPoolsUpdate**](AgentPoolsApi.md#deactivateagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates/{updateId}/deactivate | Deactivate an agent pool update
[**DeleteAgentPoolsUpdate**](AgentPoolsApi.md#deleteagentpoolsupdate) | **DELETE** /api/v1/agentPools/{poolId}/updates/{updateId} | Delete an agent pool update
[**GetAgentPoolsUpdateInstance**](AgentPoolsApi.md#getagentpoolsupdateinstance) | **GET** /api/v1/agentPools/{poolId}/updates/{updateId} | Retrieve an agent pool update by ID
[**GetAgentPoolsUpdateSettings**](AgentPoolsApi.md#getagentpoolsupdatesettings) | **GET** /api/v1/agentPools/{poolId}/updates/settings | Retrieve an agent pool update&#39;s settings
[**ListAgentPools**](AgentPoolsApi.md#listagentpools) | **GET** /api/v1/agentPools | List all agent pools
[**ListAgentPoolsUpdates**](AgentPoolsApi.md#listagentpoolsupdates) | **GET** /api/v1/agentPools/{poolId}/updates | List all agent pool updates
[**PauseAgentPoolsUpdate**](AgentPoolsApi.md#pauseagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates/{updateId}/pause | Pause an agent pool update
[**ResumeAgentPoolsUpdate**](AgentPoolsApi.md#resumeagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates/{updateId}/resume | Resume an agent pool update
[**RetryAgentPoolsUpdate**](AgentPoolsApi.md#retryagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates/{updateId}/retry | Retry an agent pool update
[**StopAgentPoolsUpdate**](AgentPoolsApi.md#stopagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates/{updateId}/stop | Stop an agent pool update
[**UpdateAgentPoolsUpdate**](AgentPoolsApi.md#updateagentpoolsupdate) | **POST** /api/v1/agentPools/{poolId}/updates/{updateId} | Update an agent pool update by ID
[**UpdateAgentPoolsUpdateSettings**](AgentPoolsApi.md#updateagentpoolsupdatesettings) | **POST** /api/v1/agentPools/{poolId}/updates/settings | Update an agent pool update settings


<a name="activateagentpoolsupdate"></a>
# **ActivateAgentPoolsUpdate**
> AgentPoolUpdate ActivateAgentPoolsUpdate (string poolId, string updateId)

Activate an agent pool update

Activates a scheduled agent pool update

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | ID of the agent pool for which the settings apply to
            var updateId = "updateId_example";  // string | ID of the update

            try
            {
                // Activate an agent pool update
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
 **poolId** | **string**| ID of the agent pool for which the settings apply to | 
 **updateId** | **string**| ID of the update | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

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

Create an agent pool update

Creates an agent pool update

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | ID of the agent pool for which the settings apply to
            var agentPoolUpdate = new AgentPoolUpdate(); // AgentPoolUpdate | 

            try
            {
                // Create an agent pool update
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
 **poolId** | **string**| ID of the agent pool for which the settings apply to | 
 **agentPoolUpdate** | [**AgentPoolUpdate**](AgentPoolUpdate.md)|  | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

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

<a name="deactivateagentpoolsupdate"></a>
# **DeactivateAgentPoolsUpdate**
> AgentPoolUpdate DeactivateAgentPoolsUpdate (string poolId, string updateId)

Deactivate an agent pool update

Deactivates scheduled agent pool update

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | ID of the agent pool for which the settings apply to
            var updateId = "updateId_example";  // string | ID of the update

            try
            {
                // Deactivate an agent pool update
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
 **poolId** | **string**| ID of the agent pool for which the settings apply to | 
 **updateId** | **string**| ID of the update | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

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

Delete an agent pool update

Deletes agent pool update

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | ID of the agent pool for which the settings apply to
            var updateId = "updateId_example";  // string | ID of the update

            try
            {
                // Delete an agent pool update
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
 **poolId** | **string**| ID of the agent pool for which the settings apply to | 
 **updateId** | **string**| ID of the update | 

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
| **204** | Deleted |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getagentpoolsupdateinstance"></a>
# **GetAgentPoolsUpdateInstance**
> AgentPoolUpdate GetAgentPoolsUpdateInstance (string poolId, string updateId)

Retrieve an agent pool update by ID

Retrieves an agent pool update by its `updateId`

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | ID of the agent pool for which the settings apply to
            var updateId = "updateId_example";  // string | ID of the update

            try
            {
                // Retrieve an agent pool update by ID
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
 **poolId** | **string**| ID of the agent pool for which the settings apply to | 
 **updateId** | **string**| ID of the update | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

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

<a name="getagentpoolsupdatesettings"></a>
# **GetAgentPoolsUpdateSettings**
> AgentPoolUpdateSetting GetAgentPoolsUpdateSettings (string poolId)

Retrieve an agent pool update's settings

Retrieves the current state of the agent pool update instance settings

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | ID of the agent pool for which the settings apply to

            try
            {
                // Retrieve an agent pool update's settings
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
 **poolId** | **string**| ID of the agent pool for which the settings apply to | 

### Return type

[**AgentPoolUpdateSetting**](AgentPoolUpdateSetting.md)

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

<a name="listagentpools"></a>
# **ListAgentPools**
> List&lt;AgentPool&gt; ListAgentPools (int? limitPerPoolType = null, AgentType? poolType = null, string after = null)

List all agent pools

Lists all agent pools with pagination support

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAgentPoolsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var limitPerPoolType = 5;  // int? | Maximum number of agent pools returned (optional)  (default to 5)
            var poolType = (AgentType) "AD";  // AgentType? | Agent type to search for (optional) 
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 

            try
            {
                // List all agent pools
                List<AgentPool> result = apiInstance.ListAgentPools(limitPerPoolType, poolType, after).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.ListAgentPools: " + e.Message );
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
 **limitPerPoolType** | **int?**| Maximum number of agent pools returned | [optional] [default to 5]
 **poolType** | **AgentType?**| Agent type to search for | [optional] 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 

### Return type

[**List&lt;AgentPool&gt;**](AgentPool.md)

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

<a name="listagentpoolsupdates"></a>
# **ListAgentPoolsUpdates**
> List&lt;AgentPoolUpdate&gt; ListAgentPoolsUpdates (string poolId, bool? scheduled = null)

List all agent pool updates

Lists all agent pool updates

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAgentPoolsUpdatesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | ID of the agent pool for which the settings apply to
            var scheduled = true;  // bool? | Return only scheduled or ad-hoc updates. If this parameter isn't provided, Okta returns the entire list of updates. (optional) 

            try
            {
                // List all agent pool updates
                List<AgentPoolUpdate> result = apiInstance.ListAgentPoolsUpdates(poolId, scheduled).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.ListAgentPoolsUpdates: " + e.Message );
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
 **poolId** | **string**| ID of the agent pool for which the settings apply to | 
 **scheduled** | **bool?**| Return only scheduled or ad-hoc updates. If this parameter isn&#39;t provided, Okta returns the entire list of updates. | [optional] 

### Return type

[**List&lt;AgentPoolUpdate&gt;**](AgentPoolUpdate.md)

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

<a name="pauseagentpoolsupdate"></a>
# **PauseAgentPoolsUpdate**
> AgentPoolUpdate PauseAgentPoolsUpdate (string poolId, string updateId)

Pause an agent pool update

Pauses a running or queued agent pool update

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | ID of the agent pool for which the settings apply to
            var updateId = "updateId_example";  // string | ID of the update

            try
            {
                // Pause an agent pool update
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
 **poolId** | **string**| ID of the agent pool for which the settings apply to | 
 **updateId** | **string**| ID of the update | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

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

Resume an agent pool update

Resumes a running or queued agent pool update

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | ID of the agent pool for which the settings apply to
            var updateId = "updateId_example";  // string | ID of the update

            try
            {
                // Resume an agent pool update
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
 **poolId** | **string**| ID of the agent pool for which the settings apply to | 
 **updateId** | **string**| ID of the update | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

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

Retry an agent pool update

Retries an agent pool update if the update is unsuccessful or communication with Okta was interrupted during an agent auto-update

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | ID of the agent pool for which the settings apply to
            var updateId = "updateId_example";  // string | ID of the update

            try
            {
                // Retry an agent pool update
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
 **poolId** | **string**| ID of the agent pool for which the settings apply to | 
 **updateId** | **string**| ID of the update | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

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

<a name="stopagentpoolsupdate"></a>
# **StopAgentPoolsUpdate**
> AgentPoolUpdate StopAgentPoolsUpdate (string poolId, string updateId)

Stop an agent pool update

Stops an agent pool update

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | ID of the agent pool for which the settings apply to
            var updateId = "updateId_example";  // string | ID of the update

            try
            {
                // Stop an agent pool update
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
 **poolId** | **string**| ID of the agent pool for which the settings apply to | 
 **updateId** | **string**| ID of the update | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

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

Update an agent pool update by ID

Updates an agent pool update instance and returns the latest agent pool update

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | ID of the agent pool for which the settings apply to
            var updateId = "updateId_example";  // string | ID of the update
            var agentPoolUpdate = new AgentPoolUpdate(); // AgentPoolUpdate | 

            try
            {
                // Update an agent pool update by ID
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
 **poolId** | **string**| ID of the agent pool for which the settings apply to | 
 **updateId** | **string**| ID of the update | 
 **agentPoolUpdate** | [**AgentPoolUpdate**](AgentPoolUpdate.md)|  | 

### Return type

[**AgentPoolUpdate**](AgentPoolUpdate.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

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

<a name="updateagentpoolsupdatesettings"></a>
# **UpdateAgentPoolsUpdateSettings**
> AgentPoolUpdateSetting UpdateAgentPoolsUpdateSettings (string poolId, AgentPoolUpdateSetting agentPoolUpdateSetting)

Update an agent pool update settings

Updates an agent pool update instance settings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateAgentPoolsUpdateSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | ID of the agent pool for which the settings apply to
            var agentPoolUpdateSetting = new AgentPoolUpdateSetting(); // AgentPoolUpdateSetting | 

            try
            {
                // Update an agent pool update settings
                AgentPoolUpdateSetting result = apiInstance.UpdateAgentPoolsUpdateSettings(poolId, agentPoolUpdateSetting);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.UpdateAgentPoolsUpdateSettings: " + e.Message );
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
 **poolId** | **string**| ID of the agent pool for which the settings apply to | 
 **agentPoolUpdateSetting** | [**AgentPoolUpdateSetting**](AgentPoolUpdateSetting.md)|  | 

### Return type

[**AgentPoolUpdateSetting**](AgentPoolUpdateSetting.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

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

