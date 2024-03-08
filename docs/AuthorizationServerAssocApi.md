# Okta.Sdk.Api.AuthorizationServerAssocApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateAssociatedServers**](AuthorizationServerAssocApi.md#createassociatedservers) | **POST** /api/v1/authorizationServers/{authServerId}/associatedServers | Create an associated Authorization Server
[**DeleteAssociatedServer**](AuthorizationServerAssocApi.md#deleteassociatedserver) | **DELETE** /api/v1/authorizationServers/{authServerId}/associatedServers/{associatedServerId} | Delete an associated Authorization Server
[**ListAssociatedServersByTrustedType**](AuthorizationServerAssocApi.md#listassociatedserversbytrustedtype) | **GET** /api/v1/authorizationServers/{authServerId}/associatedServers | List all associated Authorization Servers


<a name="createassociatedservers"></a>
# **CreateAssociatedServers**
> List&lt;AuthorizationServer&gt; CreateAssociatedServers (string authServerId, AssociatedServerMediated associatedServerMediated)

Create an associated Authorization Server

Creates trusted relationships between the given authorization server and other authorization servers

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateAssociatedServersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerAssocApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var associatedServerMediated = new AssociatedServerMediated(); // AssociatedServerMediated | 

            try
            {
                // Create an associated Authorization Server
                List<AuthorizationServer> result = apiInstance.CreateAssociatedServers(authServerId, associatedServerMediated).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerAssocApi.CreateAssociatedServers: " + e.Message );
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
 **associatedServerMediated** | [**AssociatedServerMediated**](AssociatedServerMediated.md)|  | 

### Return type

[**List&lt;AuthorizationServer&gt;**](AuthorizationServer.md)

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

<a name="deleteassociatedserver"></a>
# **DeleteAssociatedServer**
> void DeleteAssociatedServer (string authServerId, string associatedServerId)

Delete an associated Authorization Server

Deletes an associated Authorization Server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteAssociatedServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerAssocApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var associatedServerId = aus6xt9jKPmCyn6kg0g4;  // string | `id` of the associated Authorization Server

            try
            {
                // Delete an associated Authorization Server
                apiInstance.DeleteAssociatedServer(authServerId, associatedServerId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerAssocApi.DeleteAssociatedServer: " + e.Message );
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
 **associatedServerId** | **string**| &#x60;id&#x60; of the associated Authorization Server | 

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

<a name="listassociatedserversbytrustedtype"></a>
# **ListAssociatedServersByTrustedType**
> List&lt;AuthorizationServer&gt; ListAssociatedServersByTrustedType (string authServerId, bool? trusted = null, string? q = null, int? limit = null, string? after = null)

List all associated Authorization Servers

Lists all associated Authorization Servers by trusted type for the given `authServerId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAssociatedServersByTrustedTypeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerAssocApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var trusted = true;  // bool? | Searches trusted authorization servers when `true` or searches untrusted authorization servers when `false` (optional) 
            var q = customasone;  // string? | Searches for the name or audience of the associated authorization servers (optional) 
            var limit = 200;  // int? | Specifies the number of results for a page (optional)  (default to 200)
            var after = "after_example";  // string? | Specifies the pagination cursor for the next page of the associated authorization servers (optional) 

            try
            {
                // List all associated Authorization Servers
                List<AuthorizationServer> result = apiInstance.ListAssociatedServersByTrustedType(authServerId, trusted, q, limit, after).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerAssocApi.ListAssociatedServersByTrustedType: " + e.Message );
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
 **trusted** | **bool?**| Searches trusted authorization servers when &#x60;true&#x60; or searches untrusted authorization servers when &#x60;false&#x60; | [optional] 
 **q** | **string?**| Searches for the name or audience of the associated authorization servers | [optional] 
 **limit** | **int?**| Specifies the number of results for a page | [optional] [default to 200]
 **after** | **string?**| Specifies the pagination cursor for the next page of the associated authorization servers | [optional] 

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
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

