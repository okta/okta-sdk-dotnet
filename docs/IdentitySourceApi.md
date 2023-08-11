# Okta.Sdk.Api.IdentitySourceApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateIdentitySourceSession**](IdentitySourceApi.md#createidentitysourcesession) | **POST** /api/v1/identity-sources/{identitySourceId}/sessions | Create an Identity Source Session
[**DeleteIdentitySourceSession**](IdentitySourceApi.md#deleteidentitysourcesession) | **DELETE** /api/v1/identity-sources/{identitySourceId}/sessions/{sessionId} | Delete an Identity Source Session
[**GetIdentitySourceSession**](IdentitySourceApi.md#getidentitysourcesession) | **GET** /api/v1/identity-sources/{identitySourceId}/sessions/{sessionId} | Retrieve an Identity Source Session
[**ListIdentitySourceSessions**](IdentitySourceApi.md#listidentitysourcesessions) | **GET** /api/v1/identity-sources/{identitySourceId}/sessions | List all Identity Source Sessions
[**StartImportFromIdentitySource**](IdentitySourceApi.md#startimportfromidentitysource) | **POST** /api/v1/identity-sources/{identitySourceId}/sessions/{sessionId}/start-import | Start the import from the Identity Source
[**UploadIdentitySourceDataForDelete**](IdentitySourceApi.md#uploadidentitysourcedatafordelete) | **POST** /api/v1/identity-sources/{identitySourceId}/sessions/{sessionId}/bulk-delete | Upload the data to be deleted in Okta
[**UploadIdentitySourceDataForUpsert**](IdentitySourceApi.md#uploadidentitysourcedataforupsert) | **POST** /api/v1/identity-sources/{identitySourceId}/sessions/{sessionId}/bulk-upsert | Upload the data to be upserted in Okta


<a name="createidentitysourcesession"></a>
# **CreateIdentitySourceSession**
> List&lt;IdentitySourceSession&gt; CreateIdentitySourceSession (string identitySourceId)

Create an Identity Source Session

Creates an identity source session for the given identity source instance

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateIdentitySourceSessionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentitySourceApi(config);
            var identitySourceId = "identitySourceId_example";  // string | 

            try
            {
                // Create an Identity Source Session
                List<IdentitySourceSession> result = apiInstance.CreateIdentitySourceSession(identitySourceId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentitySourceApi.CreateIdentitySourceSession: " + e.Message );
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
 **identitySourceId** | **string**|  | 

### Return type

[**List&lt;IdentitySourceSession&gt;**](IdentitySourceSession.md)

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

<a name="deleteidentitysourcesession"></a>
# **DeleteIdentitySourceSession**
> void DeleteIdentitySourceSession (string identitySourceId, string sessionId)

Delete an Identity Source Session

Deletes an identity source session for a given `identitySourceId` and `sessionId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteIdentitySourceSessionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentitySourceApi(config);
            var identitySourceId = "identitySourceId_example";  // string | 
            var sessionId = "sessionId_example";  // string | 

            try
            {
                // Delete an Identity Source Session
                apiInstance.DeleteIdentitySourceSession(identitySourceId, sessionId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentitySourceApi.DeleteIdentitySourceSession: " + e.Message );
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
 **identitySourceId** | **string**|  | 
 **sessionId** | **string**|  | 

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

<a name="getidentitysourcesession"></a>
# **GetIdentitySourceSession**
> IdentitySourceSession GetIdentitySourceSession (string identitySourceId, string sessionId)

Retrieve an Identity Source Session

Retrieves an identity source session for a given identity source id and session id

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetIdentitySourceSessionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentitySourceApi(config);
            var identitySourceId = "identitySourceId_example";  // string | 
            var sessionId = "sessionId_example";  // string | 

            try
            {
                // Retrieve an Identity Source Session
                IdentitySourceSession result = apiInstance.GetIdentitySourceSession(identitySourceId, sessionId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentitySourceApi.GetIdentitySourceSession: " + e.Message );
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
 **identitySourceId** | **string**|  | 
 **sessionId** | **string**|  | 

### Return type

[**IdentitySourceSession**](IdentitySourceSession.md)

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

<a name="listidentitysourcesessions"></a>
# **ListIdentitySourceSessions**
> List&lt;IdentitySourceSession&gt; ListIdentitySourceSessions (string identitySourceId)

List all Identity Source Sessions

Lists all identity source sessions for the given identity source instance

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListIdentitySourceSessionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentitySourceApi(config);
            var identitySourceId = "identitySourceId_example";  // string | 

            try
            {
                // List all Identity Source Sessions
                List<IdentitySourceSession> result = apiInstance.ListIdentitySourceSessions(identitySourceId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentitySourceApi.ListIdentitySourceSessions: " + e.Message );
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
 **identitySourceId** | **string**|  | 

### Return type

[**List&lt;IdentitySourceSession&gt;**](IdentitySourceSession.md)

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

<a name="startimportfromidentitysource"></a>
# **StartImportFromIdentitySource**
> List&lt;IdentitySourceSession&gt; StartImportFromIdentitySource (string identitySourceId, string sessionId)

Start the import from the Identity Source

Starts the import from the identity source described by the uploaded bulk operations

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class StartImportFromIdentitySourceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentitySourceApi(config);
            var identitySourceId = "identitySourceId_example";  // string | 
            var sessionId = "sessionId_example";  // string | 

            try
            {
                // Start the import from the Identity Source
                List<IdentitySourceSession> result = apiInstance.StartImportFromIdentitySource(identitySourceId, sessionId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentitySourceApi.StartImportFromIdentitySource: " + e.Message );
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
 **identitySourceId** | **string**|  | 
 **sessionId** | **string**|  | 

### Return type

[**List&lt;IdentitySourceSession&gt;**](IdentitySourceSession.md)

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

<a name="uploadidentitysourcedatafordelete"></a>
# **UploadIdentitySourceDataForDelete**
> void UploadIdentitySourceDataForDelete (string identitySourceId, string sessionId, BulkDeleteRequestBody bulkDeleteRequestBody = null)

Upload the data to be deleted in Okta

Uploads entities that need to be deleted in Okta from the identity source for the given session

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UploadIdentitySourceDataForDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentitySourceApi(config);
            var identitySourceId = "identitySourceId_example";  // string | 
            var sessionId = "sessionId_example";  // string | 
            var bulkDeleteRequestBody = new BulkDeleteRequestBody(); // BulkDeleteRequestBody |  (optional) 

            try
            {
                // Upload the data to be deleted in Okta
                apiInstance.UploadIdentitySourceDataForDelete(identitySourceId, sessionId, bulkDeleteRequestBody);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentitySourceApi.UploadIdentitySourceDataForDelete: " + e.Message );
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
 **identitySourceId** | **string**|  | 
 **sessionId** | **string**|  | 
 **bulkDeleteRequestBody** | [**BulkDeleteRequestBody**](BulkDeleteRequestBody.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Accepted |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadidentitysourcedataforupsert"></a>
# **UploadIdentitySourceDataForUpsert**
> void UploadIdentitySourceDataForUpsert (string identitySourceId, string sessionId, BulkUpsertRequestBody bulkUpsertRequestBody = null)

Upload the data to be upserted in Okta

Uploads entities that need to be upserted in Okta from the identity source for the given session

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UploadIdentitySourceDataForUpsertExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentitySourceApi(config);
            var identitySourceId = "identitySourceId_example";  // string | 
            var sessionId = "sessionId_example";  // string | 
            var bulkUpsertRequestBody = new BulkUpsertRequestBody(); // BulkUpsertRequestBody |  (optional) 

            try
            {
                // Upload the data to be upserted in Okta
                apiInstance.UploadIdentitySourceDataForUpsert(identitySourceId, sessionId, bulkUpsertRequestBody);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentitySourceApi.UploadIdentitySourceDataForUpsert: " + e.Message );
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
 **identitySourceId** | **string**|  | 
 **sessionId** | **string**|  | 
 **bulkUpsertRequestBody** | [**BulkUpsertRequestBody**](BulkUpsertRequestBody.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Accepted |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

