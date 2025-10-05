# Okta.Sdk.Api.ServiceAccountApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateAppServiceAccount**](ServiceAccountApi.md#createappserviceaccount) | **POST** /privileged-access/api/v1/service-accounts | Create an app service account
[**DeleteAppServiceAccount**](ServiceAccountApi.md#deleteappserviceaccount) | **DELETE** /privileged-access/api/v1/service-accounts/{id} | Delete an app service account
[**GetAppServiceAccount**](ServiceAccountApi.md#getappserviceaccount) | **GET** /privileged-access/api/v1/service-accounts/{id} | Retrieve an app service account
[**ListAppServiceAccounts**](ServiceAccountApi.md#listappserviceaccounts) | **GET** /privileged-access/api/v1/service-accounts | List all app service accounts
[**UpdateAppServiceAccount**](ServiceAccountApi.md#updateappserviceaccount) | **PATCH** /privileged-access/api/v1/service-accounts/{id} | Update an existing app service account


<a name="createappserviceaccount"></a>
# **CreateAppServiceAccount**
> AppServiceAccount CreateAppServiceAccount (AppServiceAccount body)

Create an app service account

Creates a new app service account for managing an app account

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateAppServiceAccountExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ServiceAccountApi(config);
            var body = new AppServiceAccount(); // AppServiceAccount | 

            try
            {
                // Create an app service account
                AppServiceAccount result = apiInstance.CreateAppServiceAccount(body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ServiceAccountApi.CreateAppServiceAccount: " + e.Message );
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
 **body** | [**AppServiceAccount**](AppServiceAccount.md)|  | 

### Return type

[**AppServiceAccount**](AppServiceAccount.md)

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

<a name="deleteappserviceaccount"></a>
# **DeleteAppServiceAccount**
> void DeleteAppServiceAccount (string id)

Delete an app service account

Deletes an app service account specified by ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteAppServiceAccountExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ServiceAccountApi(config);
            var id = "id_example";  // string | ID of an existing service account

            try
            {
                // Delete an app service account
                apiInstance.DeleteAppServiceAccount(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ServiceAccountApi.DeleteAppServiceAccount: " + e.Message );
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
 **id** | **string**| ID of an existing service account | 

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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getappserviceaccount"></a>
# **GetAppServiceAccount**
> AppServiceAccount GetAppServiceAccount (string id)

Retrieve an app service account

Retrieves an app service account specified by ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAppServiceAccountExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ServiceAccountApi(config);
            var id = "id_example";  // string | ID of an existing service account

            try
            {
                // Retrieve an app service account
                AppServiceAccount result = apiInstance.GetAppServiceAccount(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ServiceAccountApi.GetAppServiceAccount: " + e.Message );
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
 **id** | **string**| ID of an existing service account | 

### Return type

[**AppServiceAccount**](AppServiceAccount.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
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

<a name="listappserviceaccounts"></a>
# **ListAppServiceAccounts**
> List&lt;AppServiceAccount&gt; ListAppServiceAccounts (int? limit = null, string after = null, string match = null)

List all app service accounts

Lists all app service accounts

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAppServiceAccountsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ServiceAccountApi(config);
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var match = salesforce;  // string | Searches for app service accounts where the account name (`name`), username (`username`), app instance label (`containerInstanceName`), or OIN app key name (`containerGlobalName`) contains the given value (optional) 

            try
            {
                // List all app service accounts
                List<AppServiceAccount> result = apiInstance.ListAppServiceAccounts(limit, after, match).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ServiceAccountApi.ListAppServiceAccounts: " + e.Message );
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
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **match** | **string**| Searches for app service accounts where the account name (&#x60;name&#x60;), username (&#x60;username&#x60;), app instance label (&#x60;containerInstanceName&#x60;), or OIN app key name (&#x60;containerGlobalName&#x60;) contains the given value | [optional] 

### Return type

[**List&lt;AppServiceAccount&gt;**](AppServiceAccount.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
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

<a name="updateappserviceaccount"></a>
# **UpdateAppServiceAccount**
> AppServiceAccount UpdateAppServiceAccount (string id, AppServiceAccountForUpdate body = null)

Update an existing app service account

Updates an existing app service account specified by ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateAppServiceAccountExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ServiceAccountApi(config);
            var id = "id_example";  // string | ID of an existing service account
            var body = new AppServiceAccountForUpdate(); // AppServiceAccountForUpdate |  (optional) 

            try
            {
                // Update an existing app service account
                AppServiceAccount result = apiInstance.UpdateAppServiceAccount(id, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ServiceAccountApi.UpdateAppServiceAccount: " + e.Message );
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
 **id** | **string**| ID of an existing service account | 
 **body** | [**AppServiceAccountForUpdate**](AppServiceAccountForUpdate.md)|  | [optional] 

### Return type

[**AppServiceAccount**](AppServiceAccount.md)

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

