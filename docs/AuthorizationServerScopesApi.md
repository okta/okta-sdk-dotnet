# Okta.Sdk.Api.AuthorizationServerScopesApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateOAuth2Scope**](AuthorizationServerScopesApi.md#createoauth2scope) | **POST** /api/v1/authorizationServers/{authServerId}/scopes | Create a custom token scope
[**DeleteOAuth2Scope**](AuthorizationServerScopesApi.md#deleteoauth2scope) | **DELETE** /api/v1/authorizationServers/{authServerId}/scopes/{scopeId} | Delete a custom token scope
[**GetOAuth2Scope**](AuthorizationServerScopesApi.md#getoauth2scope) | **GET** /api/v1/authorizationServers/{authServerId}/scopes/{scopeId} | Retrieve a custom token scope
[**ListOAuth2Scopes**](AuthorizationServerScopesApi.md#listoauth2scopes) | **GET** /api/v1/authorizationServers/{authServerId}/scopes | List all custom token scopes
[**ReplaceOAuth2Scope**](AuthorizationServerScopesApi.md#replaceoauth2scope) | **PUT** /api/v1/authorizationServers/{authServerId}/scopes/{scopeId} | Replace a custom token scope


<a name="createoauth2scope"></a>
# **CreateOAuth2Scope**
> OAuth2Scope CreateOAuth2Scope (string authServerId, OAuth2Scope oAuth2Scope)

Create a custom token scope

Creates a custom token scope

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateOAuth2ScopeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerScopesApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var oAuth2Scope = new OAuth2Scope(); // OAuth2Scope | 

            try
            {
                // Create a custom token scope
                OAuth2Scope result = apiInstance.CreateOAuth2Scope(authServerId, oAuth2Scope);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerScopesApi.CreateOAuth2Scope: " + e.Message );
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
 **oAuth2Scope** | [**OAuth2Scope**](OAuth2Scope.md)|  | 

### Return type

[**OAuth2Scope**](OAuth2Scope.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Success |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteoauth2scope"></a>
# **DeleteOAuth2Scope**
> void DeleteOAuth2Scope (string authServerId, string scopeId)

Delete a custom token scope

Deletes a custom token scope

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteOAuth2ScopeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerScopesApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var scopeId = 0TMRpCWXRKFjP7HiPFNM;  // string | `id` of Scope

            try
            {
                // Delete a custom token scope
                apiInstance.DeleteOAuth2Scope(authServerId, scopeId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerScopesApi.DeleteOAuth2Scope: " + e.Message );
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
 **scopeId** | **string**| &#x60;id&#x60; of Scope | 

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

<a name="getoauth2scope"></a>
# **GetOAuth2Scope**
> OAuth2Scope GetOAuth2Scope (string authServerId, string scopeId)

Retrieve a custom token scope

Retrieves a custom token scope

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetOAuth2ScopeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerScopesApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var scopeId = 0TMRpCWXRKFjP7HiPFNM;  // string | `id` of Scope

            try
            {
                // Retrieve a custom token scope
                OAuth2Scope result = apiInstance.GetOAuth2Scope(authServerId, scopeId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerScopesApi.GetOAuth2Scope: " + e.Message );
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
 **scopeId** | **string**| &#x60;id&#x60; of Scope | 

### Return type

[**OAuth2Scope**](OAuth2Scope.md)

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

<a name="listoauth2scopes"></a>
# **ListOAuth2Scopes**
> List&lt;OAuth2Scope&gt; ListOAuth2Scopes (string authServerId, string q = null, string filter = null, string after = null, int? limit = null)

List all custom token scopes

Lists all custom token scopes

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListOAuth2ScopesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerScopesApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var q = "q_example";  // string | Searches the `name` of Custom Token Scopes for matching values (optional) 
            var filter = "filter_example";  // string | Filter expression for Custom Token Scopes (optional) 
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of scopes. Treat the after cursor as an opaque value and obtain it through the next link relationship. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 56;  // int? | Specifies the number of objects to return per page. If there are multiple pages of results, the Link header contains a `next` link that you need to use as an opaque value (follow it, don't parse it). See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 

            try
            {
                // List all custom token scopes
                List<OAuth2Scope> result = apiInstance.ListOAuth2Scopes(authServerId, q, filter, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerScopesApi.ListOAuth2Scopes: " + e.Message );
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
 **q** | **string**| Searches the &#x60;name&#x60; of Custom Token Scopes for matching values | [optional] 
 **filter** | **string**| Filter expression for Custom Token Scopes | [optional] 
 **after** | **string**| Specifies the pagination cursor for the next page of scopes. Treat the after cursor as an opaque value and obtain it through the next link relationship. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| Specifies the number of objects to return per page. If there are multiple pages of results, the Link header contains a &#x60;next&#x60; link that you need to use as an opaque value (follow it, don&#39;t parse it). See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 

### Return type

[**List&lt;OAuth2Scope&gt;**](OAuth2Scope.md)

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

<a name="replaceoauth2scope"></a>
# **ReplaceOAuth2Scope**
> OAuth2Scope ReplaceOAuth2Scope (string authServerId, string scopeId, OAuth2Scope oAuth2Scope)

Replace a custom token scope

Replaces a custom token scope

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceOAuth2ScopeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerScopesApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var scopeId = 0TMRpCWXRKFjP7HiPFNM;  // string | `id` of Scope
            var oAuth2Scope = new OAuth2Scope(); // OAuth2Scope | 

            try
            {
                // Replace a custom token scope
                OAuth2Scope result = apiInstance.ReplaceOAuth2Scope(authServerId, scopeId, oAuth2Scope);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerScopesApi.ReplaceOAuth2Scope: " + e.Message );
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
 **scopeId** | **string**| &#x60;id&#x60; of Scope | 
 **oAuth2Scope** | [**OAuth2Scope**](OAuth2Scope.md)|  | 

### Return type

[**OAuth2Scope**](OAuth2Scope.md)

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

