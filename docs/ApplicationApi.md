# Okta.Sdk.Api.ApplicationApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateApplication**](ApplicationApi.md#activateapplication) | **POST** /api/v1/apps/{appId}/lifecycle/activate | Activate an application
[**CreateApplication**](ApplicationApi.md#createapplication) | **POST** /api/v1/apps | Create an application
[**DeactivateApplication**](ApplicationApi.md#deactivateapplication) | **POST** /api/v1/apps/{appId}/lifecycle/deactivate | Deactivate an application
[**DeleteApplication**](ApplicationApi.md#deleteapplication) | **DELETE** /api/v1/apps/{appId} | Delete an application
[**GetApplication**](ApplicationApi.md#getapplication) | **GET** /api/v1/apps/{appId} | Retrieve an application
[**ListApplications**](ApplicationApi.md#listapplications) | **GET** /api/v1/apps | List all applications
[**ReplaceApplication**](ApplicationApi.md#replaceapplication) | **PUT** /api/v1/apps/{appId} | Replace an application


<a name="activateapplication"></a>
# **ActivateApplication**
> void ActivateApplication (string appId)

Activate an application

Activates an inactive application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // Activate an application
                apiInstance.ActivateApplication(appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.ActivateApplication: " + e.Message );
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
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createapplication"></a>
# **CreateApplication**
> Application CreateApplication (Application application, bool? activate = null, string oktaAccessGatewayAgent = null)

Create an application

Creates an app instance in your Okta org.  You can either create an OIN app instance or a custom app instance: * OIN app instances have prescribed `name` (key app definition) and `signOnMode` options. See the [OIN schemas](/openapi/okta-management/management/tag/Application/#tag/Application/schema/GoogleApplication) for the request body. * For custom app instances, select the [signOnMode](/openapi/okta-management/management/tag/Application/#tag/Application/operation/createApplication!path=0/signOnMode&t=request) that pertains to your app and specify the required parameters in the request body. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var application = new Application(); // Application | 
            var activate = true;  // bool? | Executes activation lifecycle operation when creating the app (optional)  (default to true)
            var oktaAccessGatewayAgent = "oktaAccessGatewayAgent_example";  // string |  (optional) 

            try
            {
                // Create an application
                Application result = apiInstance.CreateApplication(application, activate, oktaAccessGatewayAgent);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.CreateApplication: " + e.Message );
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
 **application** | [**Application**](Application.md)|  | 
 **activate** | **bool?**| Executes activation lifecycle operation when creating the app | [optional] [default to true]
 **oktaAccessGatewayAgent** | **string**|  | [optional] 

### Return type

[**Application**](Application.md)

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

<a name="deactivateapplication"></a>
# **DeactivateApplication**
> void DeactivateApplication (string appId)

Deactivate an application

Deactivates an active application  > **Note:** Deactivating an app triggers a full reconciliation of all users assigned to the app by groups. This reconcile process removes the app assignment for the deactivated app, and might also correct assignments that were supposed to be removed but failed previously.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // Deactivate an application
                apiInstance.DeactivateApplication(appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.DeactivateApplication: " + e.Message );
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
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteapplication"></a>
# **DeleteApplication**
> void DeleteApplication (string appId)

Delete an application

Deletes an inactive application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // Delete an application
                apiInstance.DeleteApplication(appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.DeleteApplication: " + e.Message );
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

<a name="getapplication"></a>
# **GetApplication**
> Application GetApplication (string appId, string expand = null)

Retrieve an application

Retrieves an application from your Okta organization by `id`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var expand = user/0oa1gjh63g214q0Hq0g4;  // string | An optional query parameter to return the specified [Application User](/openapi/okta-management/management/tag/ApplicationUsers/) in the `_embedded` property. Valid value: `expand=user/{userId}` (optional) 

            try
            {
                // Retrieve an application
                Application result = apiInstance.GetApplication(appId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.GetApplication: " + e.Message );
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
 **expand** | **string**| An optional query parameter to return the specified [Application User](/openapi/okta-management/management/tag/ApplicationUsers/) in the &#x60;_embedded&#x60; property. Valid value: &#x60;expand&#x3D;user/{userId}&#x60; | [optional] 

### Return type

[**Application**](Application.md)

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

<a name="listapplications"></a>
# **ListApplications**
> List&lt;Application&gt; ListApplications (string q = null, string after = null, bool? useOptimization = null, int? limit = null, string filter = null, string expand = null, bool? includeNonDeleted = null)

List all applications

Lists all apps in the org with pagination. A subset of apps can be returned that match a supported filter expression or query. The results are [paginated](/#pagination) according to the `limit` parameter. If there are multiple pages of results, the header contains a `next` link. Treat the link as an opaque value (follow it, don't parse it).  > **Note:** To list all of a member's assigned app links, use the [List all assigned app links endpoint in the User Resources API](/openapi/okta-management/management/tag/UserResources/#tag/UserResources/operation/listAppLinks).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListApplicationsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var q = Okta;  // string | Searches for apps with `name` or `label` properties that starts with the `q` value using the `startsWith` operation (optional) 
            var after = 16278919418571;  // string | Specifies the [pagination](/#pagination) cursor for the next page of results. Treat this as an opaque value obtained through the `next` link relationship. (optional) 
            var useOptimization = false;  // bool? | Specifies whether to use query optimization. If you specify `useOptimization=true` in the request query, the response contains a subset of app instance properties. (optional)  (default to false)
            var limit = -1;  // int? | Specifies the number of results per page (optional)  (default to -1)
            var filter = status%20eq%20%22ACTIVE%22;  // string | Filters apps by `status`, `user.id`, `group.id`, `credentials.signing.kid` or `name` expression that supports the `eq` operator (optional) 
            var expand = user/0oa1gjh63g214q0Hq0g4;  // string | An optional parameter used for link expansion to embed more resources in the response. Only supports `expand=user/{userId}` and must be used with the `user.id eq \"{userId}\"` filter query for the same user. Returns the assigned [application user](/openapi/okta-management/management/tag/ApplicationUsers/) in the `_embedded` property. (optional) 
            var includeNonDeleted = false;  // bool? | Specifies whether to include non-active, but not deleted apps in the results (optional)  (default to false)

            try
            {
                // List all applications
                List<Application> result = apiInstance.ListApplications(q, after, useOptimization, limit, filter, expand, includeNonDeleted).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.ListApplications: " + e.Message );
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
 **q** | **string**| Searches for apps with &#x60;name&#x60; or &#x60;label&#x60; properties that starts with the &#x60;q&#x60; value using the &#x60;startsWith&#x60; operation | [optional] 
 **after** | **string**| Specifies the [pagination](/#pagination) cursor for the next page of results. Treat this as an opaque value obtained through the &#x60;next&#x60; link relationship. | [optional] 
 **useOptimization** | **bool?**| Specifies whether to use query optimization. If you specify &#x60;useOptimization&#x3D;true&#x60; in the request query, the response contains a subset of app instance properties. | [optional] [default to false]
 **limit** | **int?**| Specifies the number of results per page | [optional] [default to -1]
 **filter** | **string**| Filters apps by &#x60;status&#x60;, &#x60;user.id&#x60;, &#x60;group.id&#x60;, &#x60;credentials.signing.kid&#x60; or &#x60;name&#x60; expression that supports the &#x60;eq&#x60; operator | [optional] 
 **expand** | **string**| An optional parameter used for link expansion to embed more resources in the response. Only supports &#x60;expand&#x3D;user/{userId}&#x60; and must be used with the &#x60;user.id eq \&quot;{userId}\&quot;&#x60; filter query for the same user. Returns the assigned [application user](/openapi/okta-management/management/tag/ApplicationUsers/) in the &#x60;_embedded&#x60; property. | [optional] 
 **includeNonDeleted** | **bool?**| Specifies whether to include non-active, but not deleted apps in the results | [optional] [default to false]

### Return type

[**List&lt;Application&gt;**](Application.md)

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

<a name="replaceapplication"></a>
# **ReplaceApplication**
> Application ReplaceApplication (string appId, Application application)

Replace an application

Replaces properties for an application > **Notes:** > * All required properties must be specified in the request body > * You can't modify system-assigned properties, such as `id`, `name`, `status`, `created`, and `lastUpdated`. The values for these properties in the PUT request body are ignored. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var application = new Application(); // Application | 

            try
            {
                // Replace an application
                Application result = apiInstance.ReplaceApplication(appId, application);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.ReplaceApplication: " + e.Message );
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
 **application** | [**Application**](Application.md)|  | 

### Return type

[**Application**](Application.md)

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

