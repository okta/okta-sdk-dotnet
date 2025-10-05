# Okta.Sdk.Api.IdentitySourceApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateIdentitySourceSession**](IdentitySourceApi.md#createidentitysourcesession) | **POST** /api/v1/identity-sources/{identitySourceId}/sessions | Create an identity source session
[**DeleteIdentitySourceSession**](IdentitySourceApi.md#deleteidentitysourcesession) | **DELETE** /api/v1/identity-sources/{identitySourceId}/sessions/{sessionId} | Delete an identity source session
[**GetIdentitySourceSession**](IdentitySourceApi.md#getidentitysourcesession) | **GET** /api/v1/identity-sources/{identitySourceId}/sessions/{sessionId} | Retrieve an identity source session
[**ListIdentitySourceSessions**](IdentitySourceApi.md#listidentitysourcesessions) | **GET** /api/v1/identity-sources/{identitySourceId}/sessions | List all identity source sessions
[**StartImportFromIdentitySource**](IdentitySourceApi.md#startimportfromidentitysource) | **POST** /api/v1/identity-sources/{identitySourceId}/sessions/{sessionId}/start-import | Start the import from the identity source
[**UploadIdentitySourceDataForDelete**](IdentitySourceApi.md#uploadidentitysourcedatafordelete) | **POST** /api/v1/identity-sources/{identitySourceId}/sessions/{sessionId}/bulk-delete | Upload the data to be deleted in Okta
[**UploadIdentitySourceDataForUpsert**](IdentitySourceApi.md#uploadidentitysourcedataforupsert) | **POST** /api/v1/identity-sources/{identitySourceId}/sessions/{sessionId}/bulk-upsert | Upload the data to be upserted in Okta


<a name="createidentitysourcesession"></a>
# **CreateIdentitySourceSession**
> IdentitySourceSession CreateIdentitySourceSession (string identitySourceId)

Create an identity source session

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
            var identitySourceId = 0oa3l6l6WK6h0R0QW0g4;  // string | The ID of the identity source for which the session is created

            try
            {
                // Create an identity source session
                IdentitySourceSession result = apiInstance.CreateIdentitySourceSession(identitySourceId);
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
 **identitySourceId** | **string**| The ID of the identity source for which the session is created | 

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

<a name="deleteidentitysourcesession"></a>
# **DeleteIdentitySourceSession**
> void DeleteIdentitySourceSession (string identitySourceId, string sessionId)

Delete an identity source session

Deletes an identity source session for a given identity source ID and session Id

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
            var identitySourceId = 0oa3l6l6WK6h0R0QW0g4;  // string | The ID of the identity source for which the session is created
            var sessionId = aps1qqonvr2SZv6o70h8;  // string | The ID of the identity source session

            try
            {
                // Delete an identity source session
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
 **identitySourceId** | **string**| The ID of the identity source for which the session is created | 
 **sessionId** | **string**| The ID of the identity source session | 

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

Retrieve an identity source session

Retrieves an identity source session for a given identity source ID and session ID

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
            var identitySourceId = 0oa3l6l6WK6h0R0QW0g4;  // string | The ID of the identity source for which the session is created
            var sessionId = aps1qqonvr2SZv6o70h8;  // string | The ID of the identity source session

            try
            {
                // Retrieve an identity source session
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
 **identitySourceId** | **string**| The ID of the identity source for which the session is created | 
 **sessionId** | **string**| The ID of the identity source session | 

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

List all identity source sessions

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
            var identitySourceId = 0oa3l6l6WK6h0R0QW0g4;  // string | The ID of the identity source for which the session is created

            try
            {
                // List all identity source sessions
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
 **identitySourceId** | **string**| The ID of the identity source for which the session is created | 

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
> IdentitySourceSession StartImportFromIdentitySource (string identitySourceId, string sessionId)

Start the import from the identity source

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
            var identitySourceId = 0oa3l6l6WK6h0R0QW0g4;  // string | The ID of the identity source for which the session is created
            var sessionId = aps1qqonvr2SZv6o70h8;  // string | The ID of the identity source session

            try
            {
                // Start the import from the identity source
                IdentitySourceSession result = apiInstance.StartImportFromIdentitySource(identitySourceId, sessionId);
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
 **identitySourceId** | **string**| The ID of the identity source for which the session is created | 
 **sessionId** | **string**| The ID of the identity source session | 

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

<a name="uploadidentitysourcedatafordelete"></a>
# **UploadIdentitySourceDataForDelete**
> void UploadIdentitySourceDataForDelete (string identitySourceId, string sessionId, BulkDeleteRequestBody bulkDeleteRequestBody = null)

Upload the data to be deleted in Okta

Uploads external IDs of entities that need to be deleted in Okta from the identity source for the given session

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
            var identitySourceId = 0oa3l6l6WK6h0R0QW0g4;  // string | The ID of the identity source for which the session is created
            var sessionId = aps1qqonvr2SZv6o70h8;  // string | The ID of the identity source session
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
 **identitySourceId** | **string**| The ID of the identity source for which the session is created | 
 **sessionId** | **string**| The ID of the identity source session | 
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

Uploads entities that need to be inserted or updated in Okta from the identity source for the given session

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
            var identitySourceId = 0oa3l6l6WK6h0R0QW0g4;  // string | The ID of the identity source for which the session is created
            var sessionId = aps1qqonvr2SZv6o70h8;  // string | The ID of the identity source session
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
 **identitySourceId** | **string**| The ID of the identity source for which the session is created | 
 **sessionId** | **string**| The ID of the identity source session | 
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

