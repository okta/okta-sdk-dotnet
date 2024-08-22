# Okta.Sdk.Api.RealmAssignmentApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateRealmAssignment**](RealmAssignmentApi.md#activaterealmassignment) | **POST** /api/v1/realm-assignments/{assignmentId}/lifecycle/activate | Activate a Realm Assignment
[**CreateRealmAssignment**](RealmAssignmentApi.md#createrealmassignment) | **POST** /api/v1/realm-assignments | Create a Realm Assignment
[**DeactivateRealmAssignment**](RealmAssignmentApi.md#deactivaterealmassignment) | **POST** /api/v1/realm-assignments/{assignmentId}/lifecycle/deactivate | Deactivate a Realm Assignment
[**DeleteRealmAssignment**](RealmAssignmentApi.md#deleterealmassignment) | **DELETE** /api/v1/realm-assignments/{assignmentId} | Delete a Realm Assignment
[**ExecuteRealmAssignment**](RealmAssignmentApi.md#executerealmassignment) | **POST** /api/v1/realm-assignments/operations | Execute a Realm Assignment
[**GetRealmAssignment**](RealmAssignmentApi.md#getrealmassignment) | **GET** /api/v1/realm-assignments/{assignmentId} | Retrieve a Realm Assignment
[**ListRealmAssignmentOperations**](RealmAssignmentApi.md#listrealmassignmentoperations) | **GET** /api/v1/realm-assignments/operations | List all Realm Assignment operations
[**ListRealmAssignments**](RealmAssignmentApi.md#listrealmassignments) | **GET** /api/v1/realm-assignments | List all Realm Assignments
[**ReplaceRealmAssignment**](RealmAssignmentApi.md#replacerealmassignment) | **PUT** /api/v1/realm-assignments/{assignmentId} | Replace a Realm Assignment


<a name="activaterealmassignment"></a>
# **ActivateRealmAssignment**
> void ActivateRealmAssignment (string assignmentId)

Activate a Realm Assignment

Activates a Realm Assignment

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
            var assignmentId = rul2jy7jLUlnO3ng00g4;  // string | `id` of the Realm Assignment

            try
            {
                // Activate a Realm Assignment
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
 **assignmentId** | **string**| &#x60;id&#x60; of the Realm Assignment | 

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

Create a Realm Assignment

Creates a new Realm Assignment

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
                // Create a Realm Assignment
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

Deactivate a Realm Assignment

Deactivates a Realm Assignment

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
            var assignmentId = rul2jy7jLUlnO3ng00g4;  // string | `id` of the Realm Assignment

            try
            {
                // Deactivate a Realm Assignment
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
 **assignmentId** | **string**| &#x60;id&#x60; of the Realm Assignment | 

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

Delete a Realm Assignment

Deletes a Realm Assignment

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
            var assignmentId = rul2jy7jLUlnO3ng00g4;  // string | `id` of the Realm Assignment

            try
            {
                // Delete a Realm Assignment
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
 **assignmentId** | **string**| &#x60;id&#x60; of the Realm Assignment | 

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

Execute a Realm Assignment

Executes a Realm Assignment

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
                // Execute a Realm Assignment
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

Retrieve a Realm Assignment

Retrieves a Realm Assignment

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
            var assignmentId = rul2jy7jLUlnO3ng00g4;  // string | `id` of the Realm Assignment

            try
            {
                // Retrieve a Realm Assignment
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
 **assignmentId** | **string**| &#x60;id&#x60; of the Realm Assignment | 

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

List all Realm Assignment operations

Lists all Realm Assignment operations. The upper limit is 200 and operations are sorted in descending order from most recent to oldest by id

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
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](/#pagination). (optional) 

            try
            {
                // List all Realm Assignment operations
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](/#pagination). | [optional] 

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

List all Realm Assignments

Lists all Realm Assignments

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
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](/#pagination). (optional) 

            try
            {
                // List all Realm Assignments
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](/#pagination). | [optional] 

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

Replace a Realm Assignment

Replaces a Realm Assignment

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
            var assignmentId = rul2jy7jLUlnO3ng00g4;  // string | `id` of the Realm Assignment
            var body = new UpdateRealmAssignmentRequest(); // UpdateRealmAssignmentRequest | 

            try
            {
                // Replace a Realm Assignment
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
 **assignmentId** | **string**| &#x60;id&#x60; of the Realm Assignment | 
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

