# Okta.Sdk.Api.RealmAssignmentApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateRealmAssignment**](RealmAssignmentApi.md#activaterealmassignment) | **POST** /api/v1/realm-assignments/{assignmentId}/lifecycle/activate | Activate a realm assignment
[**CreateRealmAssignment**](RealmAssignmentApi.md#createrealmassignment) | **POST** /api/v1/realm-assignments | Create a realm assignment
[**DeactivateRealmAssignment**](RealmAssignmentApi.md#deactivaterealmassignment) | **POST** /api/v1/realm-assignments/{assignmentId}/lifecycle/deactivate | Deactivate a realm assignment
[**DeleteRealmAssignment**](RealmAssignmentApi.md#deleterealmassignment) | **DELETE** /api/v1/realm-assignments/{assignmentId} | Delete a realm assignment
[**ExecuteRealmAssignment**](RealmAssignmentApi.md#executerealmassignment) | **POST** /api/v1/realm-assignments/operations | Execute a realm assignment
[**GetRealmAssignment**](RealmAssignmentApi.md#getrealmassignment) | **GET** /api/v1/realm-assignments/{assignmentId} | Retrieve a realm assignment
[**ListRealmAssignmentOperations**](RealmAssignmentApi.md#listrealmassignmentoperations) | **GET** /api/v1/realm-assignments/operations | List all realm assignment operations
[**ListRealmAssignments**](RealmAssignmentApi.md#listrealmassignments) | **GET** /api/v1/realm-assignments | List all realm assignments
[**ReplaceRealmAssignment**](RealmAssignmentApi.md#replacerealmassignment) | **PUT** /api/v1/realm-assignments/{assignmentId} | Replace a realm assignment


<a name="activaterealmassignment"></a>
# **ActivateRealmAssignment**
> void ActivateRealmAssignment (string assignmentId)

Activate a realm assignment

Activates a realm assignment

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateRealmAssignmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RealmAssignmentApi(config);
            var assignmentId = rul2jy7jLUlnO3ng00g4;  // string | ID of the realm assignment

            try
            {
                // Activate a realm assignment
                apiInstance.ActivateRealmAssignment(assignmentId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RealmAssignmentApi.ActivateRealmAssignment: " + e.Message );
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
 **assignmentId** | **string**| ID of the realm assignment | 

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

<a name="createrealmassignment"></a>
# **CreateRealmAssignment**
> RealmAssignment CreateRealmAssignment (CreateRealmAssignmentRequest body)

Create a realm assignment

Creates a new realm assignment

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateRealmAssignmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RealmAssignmentApi(config);
            var body = new CreateRealmAssignmentRequest(); // CreateRealmAssignmentRequest | 

            try
            {
                // Create a realm assignment
                RealmAssignment result = apiInstance.CreateRealmAssignment(body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RealmAssignmentApi.CreateRealmAssignment: " + e.Message );
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
 **body** | [**CreateRealmAssignmentRequest**](CreateRealmAssignmentRequest.md)|  | 

### Return type

[**RealmAssignment**](RealmAssignment.md)

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

<a name="deactivaterealmassignment"></a>
# **DeactivateRealmAssignment**
> void DeactivateRealmAssignment (string assignmentId)

Deactivate a realm assignment

Deactivates a realm assignment

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateRealmAssignmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RealmAssignmentApi(config);
            var assignmentId = rul2jy7jLUlnO3ng00g4;  // string | ID of the realm assignment

            try
            {
                // Deactivate a realm assignment
                apiInstance.DeactivateRealmAssignment(assignmentId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RealmAssignmentApi.DeactivateRealmAssignment: " + e.Message );
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
 **assignmentId** | **string**| ID of the realm assignment | 

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

<a name="deleterealmassignment"></a>
# **DeleteRealmAssignment**
> void DeleteRealmAssignment (string assignmentId)

Delete a realm assignment

Deletes a realm assignment

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteRealmAssignmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RealmAssignmentApi(config);
            var assignmentId = rul2jy7jLUlnO3ng00g4;  // string | ID of the realm assignment

            try
            {
                // Delete a realm assignment
                apiInstance.DeleteRealmAssignment(assignmentId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RealmAssignmentApi.DeleteRealmAssignment: " + e.Message );
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
 **assignmentId** | **string**| ID of the realm assignment | 

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

<a name="executerealmassignment"></a>
# **ExecuteRealmAssignment**
> OperationResponse ExecuteRealmAssignment (OperationRequest body)

Execute a realm assignment

Executes a realm assignment

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ExecuteRealmAssignmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RealmAssignmentApi(config);
            var body = new OperationRequest(); // OperationRequest | 

            try
            {
                // Execute a realm assignment
                OperationResponse result = apiInstance.ExecuteRealmAssignment(body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RealmAssignmentApi.ExecuteRealmAssignment: " + e.Message );
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
 **body** | [**OperationRequest**](OperationRequest.md)|  | 

### Return type

[**OperationResponse**](OperationResponse.md)

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

<a name="getrealmassignment"></a>
# **GetRealmAssignment**
> RealmAssignment GetRealmAssignment (string assignmentId)

Retrieve a realm assignment

Retrieves a realm assignment

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRealmAssignmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RealmAssignmentApi(config);
            var assignmentId = rul2jy7jLUlnO3ng00g4;  // string | ID of the realm assignment

            try
            {
                // Retrieve a realm assignment
                RealmAssignment result = apiInstance.GetRealmAssignment(assignmentId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RealmAssignmentApi.GetRealmAssignment: " + e.Message );
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
 **assignmentId** | **string**| ID of the realm assignment | 

### Return type

[**RealmAssignment**](RealmAssignment.md)

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

<a name="listrealmassignmentoperations"></a>
# **ListRealmAssignmentOperations**
> List&lt;OperationResponse&gt; ListRealmAssignmentOperations (int? limit = null, string after = null)

List all realm assignment operations

Lists all realm assignment operations. The upper limit is 200 and operations are sorted in descending order from most recent to oldest by ID.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListRealmAssignmentOperationsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RealmAssignmentApi(config);
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 

            try
            {
                // List all realm assignment operations
                List<OperationResponse> result = apiInstance.ListRealmAssignmentOperations(limit, after).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RealmAssignmentApi.ListRealmAssignmentOperations: " + e.Message );
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

### Return type

[**List&lt;OperationResponse&gt;**](OperationResponse.md)

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

<a name="listrealmassignments"></a>
# **ListRealmAssignments**
> List&lt;RealmAssignment&gt; ListRealmAssignments (int? limit = null, string after = null)

List all realm assignments

Lists all realm assignments

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListRealmAssignmentsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RealmAssignmentApi(config);
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)
            var after = "after_example";  // string | The cursor used for pagination. It represents the priority of the last realm assignment returned in the previous fetch operation. (optional) 

            try
            {
                // List all realm assignments
                List<RealmAssignment> result = apiInstance.ListRealmAssignments(limit, after).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RealmAssignmentApi.ListRealmAssignments: " + e.Message );
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
 **after** | **string**| The cursor used for pagination. It represents the priority of the last realm assignment returned in the previous fetch operation. | [optional] 

### Return type

[**List&lt;RealmAssignment&gt;**](RealmAssignment.md)

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

<a name="replacerealmassignment"></a>
# **ReplaceRealmAssignment**
> RealmAssignment ReplaceRealmAssignment (string assignmentId, UpdateRealmAssignmentRequest body)

Replace a realm assignment

Replaces a realm assignment

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceRealmAssignmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RealmAssignmentApi(config);
            var assignmentId = rul2jy7jLUlnO3ng00g4;  // string | ID of the realm assignment
            var body = new UpdateRealmAssignmentRequest(); // UpdateRealmAssignmentRequest | 

            try
            {
                // Replace a realm assignment
                RealmAssignment result = apiInstance.ReplaceRealmAssignment(assignmentId, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RealmAssignmentApi.ReplaceRealmAssignment: " + e.Message );
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
 **assignmentId** | **string**| ID of the realm assignment | 
 **body** | [**UpdateRealmAssignmentRequest**](UpdateRealmAssignmentRequest.md)|  | 

### Return type

[**RealmAssignment**](RealmAssignment.md)

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

