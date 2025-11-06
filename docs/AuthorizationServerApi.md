# Okta.Sdk.Api.AuthorizationServerApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateAuthorizationServer**](AuthorizationServerApi.md#activateauthorizationserver) | **POST** /api/v1/authorizationServers/{authServerId}/lifecycle/activate | Activate an authorization server
[**CreateAuthorizationServer**](AuthorizationServerApi.md#createauthorizationserver) | **POST** /api/v1/authorizationServers | Create an authorization server
[**DeactivateAuthorizationServer**](AuthorizationServerApi.md#deactivateauthorizationserver) | **POST** /api/v1/authorizationServers/{authServerId}/lifecycle/deactivate | Deactivate an authorization server
[**DeleteAuthorizationServer**](AuthorizationServerApi.md#deleteauthorizationserver) | **DELETE** /api/v1/authorizationServers/{authServerId} | Delete an authorization server
[**GetAuthorizationServer**](AuthorizationServerApi.md#getauthorizationserver) | **GET** /api/v1/authorizationServers/{authServerId} | Retrieve an authorization server
[**ListAuthorizationServers**](AuthorizationServerApi.md#listauthorizationservers) | **GET** /api/v1/authorizationServers | List all authorization servers
[**ReplaceAuthorizationServer**](AuthorizationServerApi.md#replaceauthorizationserver) | **PUT** /api/v1/authorizationServers/{authServerId} | Replace an authorization server


<a name="activateauthorizationserver"></a>
# **ActivateAuthorizationServer**
> void ActivateAuthorizationServer (string authServerId)

Activate an authorization server

Activates an authorization server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateAuthorizationServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server

            try
            {
                // Activate an authorization server
                apiInstance.ActivateAuthorizationServer(authServerId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ActivateAuthorizationServer: " + e.Message );
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

<a name="createauthorizationserver"></a>
# **CreateAuthorizationServer**
> AuthorizationServer CreateAuthorizationServer (AuthorizationServer authorizationServer)

Create an authorization server

Creates an authorization server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateAuthorizationServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authorizationServer = new AuthorizationServer(); // AuthorizationServer | 

            try
            {
                // Create an authorization server
                AuthorizationServer result = apiInstance.CreateAuthorizationServer(authorizationServer);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.CreateAuthorizationServer: " + e.Message );
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
 **authorizationServer** | [**AuthorizationServer**](AuthorizationServer.md)|  | 

### Return type

[**AuthorizationServer**](AuthorizationServer.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivateauthorizationserver"></a>
# **DeactivateAuthorizationServer**
> void DeactivateAuthorizationServer (string authServerId)

Deactivate an authorization server

Deactivates an authorization server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateAuthorizationServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server

            try
            {
                // Deactivate an authorization server
                apiInstance.DeactivateAuthorizationServer(authServerId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.DeactivateAuthorizationServer: " + e.Message );
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

<a name="deleteauthorizationserver"></a>
# **DeleteAuthorizationServer**
> void DeleteAuthorizationServer (string authServerId)

Delete an authorization server

Deletes an authorization server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteAuthorizationServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server

            try
            {
                // Delete an authorization server
                apiInstance.DeleteAuthorizationServer(authServerId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.DeleteAuthorizationServer: " + e.Message );
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

<a name="getauthorizationserver"></a>
# **GetAuthorizationServer**
> AuthorizationServer GetAuthorizationServer (string authServerId)

Retrieve an authorization server

Retrieves an authorization server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAuthorizationServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server

            try
            {
                // Retrieve an authorization server
                AuthorizationServer result = apiInstance.GetAuthorizationServer(authServerId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.GetAuthorizationServer: " + e.Message );
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

### Return type

[**AuthorizationServer**](AuthorizationServer.md)

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

<a name="listauthorizationservers"></a>
# **ListAuthorizationServers**
> List&lt;AuthorizationServer&gt; ListAuthorizationServers (string q = null, int? limit = null, string after = null)

List all authorization servers

Lists all custom authorization servers in the org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAuthorizationServersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var q = customasone;  // string | Searches the `name` and `audiences` of authorization servers for matching values (optional) 
            var limit = 200;  // int? | Specifies the number of authorization server results on a page. Maximum value: 200 (optional)  (default to 200)
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of authorization servers. Treat as an opaque value and obtain through the next link relationship. (optional) 

            try
            {
                // List all authorization servers
                List<AuthorizationServer> result = apiInstance.ListAuthorizationServers(q, limit, after).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ListAuthorizationServers: " + e.Message );
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
 **q** | **string**| Searches the &#x60;name&#x60; and &#x60;audiences&#x60; of authorization servers for matching values | [optional] 
 **limit** | **int?**| Specifies the number of authorization server results on a page. Maximum value: 200 | [optional] [default to 200]
 **after** | **string**| Specifies the pagination cursor for the next page of authorization servers. Treat as an opaque value and obtain through the next link relationship. | [optional] 

### Return type

[**List&lt;AuthorizationServer&gt;**](AuthorizationServer.md)

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

<a name="replaceauthorizationserver"></a>
# **ReplaceAuthorizationServer**
> AuthorizationServer ReplaceAuthorizationServer (string authServerId, AuthorizationServer authorizationServer)

Replace an authorization server

Replaces an authorization server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceAuthorizationServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var authorizationServer = new AuthorizationServer(); // AuthorizationServer | 

            try
            {
                // Replace an authorization server
                AuthorizationServer result = apiInstance.ReplaceAuthorizationServer(authServerId, authorizationServer);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ReplaceAuthorizationServer: " + e.Message );
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
 **authorizationServer** | [**AuthorizationServer**](AuthorizationServer.md)|  | 

### Return type

[**AuthorizationServer**](AuthorizationServer.md)

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

