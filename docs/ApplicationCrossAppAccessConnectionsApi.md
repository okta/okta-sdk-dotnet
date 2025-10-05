# Okta.Sdk.Api.ApplicationCrossAppAccessConnectionsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateCrossAppAccessConnection**](ApplicationCrossAppAccessConnectionsApi.md#createcrossappaccessconnection) | **POST** /api/v1/apps/{appId}/cwo/connections | Create a Cross App Access connection
[**DeleteCrossAppAccessConnection**](ApplicationCrossAppAccessConnectionsApi.md#deletecrossappaccessconnection) | **DELETE** /api/v1/apps/{appId}/cwo/connections/{connectionId} | Delete a Cross App Access connection
[**GetAllCrossAppAccessConnections**](ApplicationCrossAppAccessConnectionsApi.md#getallcrossappaccessconnections) | **GET** /api/v1/apps/{appId}/cwo/connections | Retrieve all Cross App Access connections
[**GetCrossAppAccessConnection**](ApplicationCrossAppAccessConnectionsApi.md#getcrossappaccessconnection) | **GET** /api/v1/apps/{appId}/cwo/connections/{connectionId} | Retrieve a Cross App Access connection
[**UpdateCrossAppAccessConnection**](ApplicationCrossAppAccessConnectionsApi.md#updatecrossappaccessconnection) | **PATCH** /api/v1/apps/{appId}/cwo/connections/{connectionId} | Update a Cross App Access connection


<a name="createcrossappaccessconnection"></a>
# **CreateCrossAppAccessConnection**
> OrgCrossAppAccessConnection CreateCrossAppAccessConnection (string appId, OrgCrossAppAccessConnection orgCrossAppAccessConnection)

Create a Cross App Access connection

Creates a Cross App Access connection 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateCrossAppAccessConnectionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationCrossAppAccessConnectionsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var orgCrossAppAccessConnection = new OrgCrossAppAccessConnection(); // OrgCrossAppAccessConnection | 

            try
            {
                // Create a Cross App Access connection
                OrgCrossAppAccessConnection result = apiInstance.CreateCrossAppAccessConnection(appId, orgCrossAppAccessConnection);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationCrossAppAccessConnectionsApi.CreateCrossAppAccessConnection: " + e.Message );
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
 **orgCrossAppAccessConnection** | [**OrgCrossAppAccessConnection**](OrgCrossAppAccessConnection.md)|  | 

### Return type

[**OrgCrossAppAccessConnection**](OrgCrossAppAccessConnection.md)

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletecrossappaccessconnection"></a>
# **DeleteCrossAppAccessConnection**
> void DeleteCrossAppAccessConnection (string appId, string connectionId)

Delete a Cross App Access connection

Deletes a Cross App Access connection with the specified ID 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteCrossAppAccessConnectionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationCrossAppAccessConnectionsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var connectionId = 0oafxqCAJWWGELFTYASJ;  // string | Connection ID

            try
            {
                // Delete a Cross App Access connection
                apiInstance.DeleteCrossAppAccessConnection(appId, connectionId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationCrossAppAccessConnectionsApi.DeleteCrossAppAccessConnection: " + e.Message );
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
 **connectionId** | **string**| Connection ID | 

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getallcrossappaccessconnections"></a>
# **GetAllCrossAppAccessConnections**
> List&lt;OrgCrossAppAccessConnection&gt; GetAllCrossAppAccessConnections (string appId, string after = null, int? limit = null)

Retrieve all Cross App Access connections

Retrieves inbound and outbound Cross App Access connections associated with an app 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAllCrossAppAccessConnectionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationCrossAppAccessConnectionsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of connection results (optional) 
            var limit = -1;  // int? | Specifies the number of results to return per page. The values:   * -1: Return all results (up to system maximum)   * 0: Return an empty result set   * Positive integer: Return up to that many results (capped at system maximum)  (optional)  (default to -1)

            try
            {
                // Retrieve all Cross App Access connections
                List<OrgCrossAppAccessConnection> result = apiInstance.GetAllCrossAppAccessConnections(appId, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationCrossAppAccessConnectionsApi.GetAllCrossAppAccessConnections: " + e.Message );
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
 **after** | **string**| Specifies the pagination cursor for the next page of connection results | [optional] 
 **limit** | **int?**| Specifies the number of results to return per page. The values:   * -1: Return all results (up to system maximum)   * 0: Return an empty result set   * Positive integer: Return up to that many results (capped at system maximum)  | [optional] [default to -1]

### Return type

[**List&lt;OrgCrossAppAccessConnection&gt;**](OrgCrossAppAccessConnection.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcrossappaccessconnection"></a>
# **GetCrossAppAccessConnection**
> OrgCrossAppAccessConnection GetCrossAppAccessConnection (string appId, string connectionId)

Retrieve a Cross App Access connection

Retrieves the Cross App Access connection with the specified ID 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetCrossAppAccessConnectionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationCrossAppAccessConnectionsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var connectionId = 0oafxqCAJWWGELFTYASJ;  // string | Connection ID

            try
            {
                // Retrieve a Cross App Access connection
                OrgCrossAppAccessConnection result = apiInstance.GetCrossAppAccessConnection(appId, connectionId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationCrossAppAccessConnectionsApi.GetCrossAppAccessConnection: " + e.Message );
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
 **connectionId** | **string**| Connection ID | 

### Return type

[**OrgCrossAppAccessConnection**](OrgCrossAppAccessConnection.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatecrossappaccessconnection"></a>
# **UpdateCrossAppAccessConnection**
> OrgCrossAppAccessConnection UpdateCrossAppAccessConnection (string appId, string connectionId, OrgCrossAppAccessConnectionPatchRequest orgCrossAppAccessConnectionPatchRequest)

Update a Cross App Access connection

Updates the Cross App Access connection with the specified ID 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateCrossAppAccessConnectionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationCrossAppAccessConnectionsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var connectionId = 0oafxqCAJWWGELFTYASJ;  // string | Connection ID
            var orgCrossAppAccessConnectionPatchRequest = new OrgCrossAppAccessConnectionPatchRequest(); // OrgCrossAppAccessConnectionPatchRequest | 

            try
            {
                // Update a Cross App Access connection
                OrgCrossAppAccessConnection result = apiInstance.UpdateCrossAppAccessConnection(appId, connectionId, orgCrossAppAccessConnectionPatchRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationCrossAppAccessConnectionsApi.UpdateCrossAppAccessConnection: " + e.Message );
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
 **connectionId** | **string**| Connection ID | 
 **orgCrossAppAccessConnectionPatchRequest** | [**OrgCrossAppAccessConnectionPatchRequest**](OrgCrossAppAccessConnectionPatchRequest.md)|  | 

### Return type

[**OrgCrossAppAccessConnection**](OrgCrossAppAccessConnection.md)

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

