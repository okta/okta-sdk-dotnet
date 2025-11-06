# Okta.Sdk.Api.SessionApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CloseCurrentSession**](SessionApi.md#closecurrentsession) | **DELETE** /api/v1/sessions/me | Close the current session
[**CreateSession**](SessionApi.md#createsession) | **POST** /api/v1/sessions | Create a session with session token
[**GetCurrentSession**](SessionApi.md#getcurrentsession) | **GET** /api/v1/sessions/me | Retrieve the current session
[**GetSession**](SessionApi.md#getsession) | **GET** /api/v1/sessions/{sessionId} | Retrieve a session
[**RefreshCurrentSession**](SessionApi.md#refreshcurrentsession) | **POST** /api/v1/sessions/me/lifecycle/refresh | Refresh the current session
[**RefreshSession**](SessionApi.md#refreshsession) | **POST** /api/v1/sessions/{sessionId}/lifecycle/refresh | Refresh a session
[**RevokeSession**](SessionApi.md#revokesession) | **DELETE** /api/v1/sessions/{sessionId} | Revoke a session


<a name="closecurrentsession"></a>
# **CloseCurrentSession**
> void CloseCurrentSession (string cookie = null)

Close the current session

Closes the Session for the user who is currently signed in. Use this method in a browser-based application to sign out a user.  > **Note:** This operation requires a session cookie for the user. An API token isn't allowed for this operation.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CloseCurrentSessionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            var apiInstance = new SessionApi(config);
            var cookie = sid=abcde-123 or idx=abcde-123;  // string |  (optional) 

            try
            {
                // Close the current session
                apiInstance.CloseCurrentSession(cookie);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SessionApi.CloseCurrentSession: " + e.Message );
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
 **cookie** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createsession"></a>
# **CreateSession**
> Session CreateSession (CreateSessionRequest createSessionRequest)

Create a session with session token

Creates a new Session for a user with a valid session token. Use this API if, for example, you want to set the session cookie yourself instead of allowing Okta to set it, or want to hold the session ID to delete a session through the API instead of visiting the logout URL.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateSessionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";

            var apiInstance = new SessionApi(config);
            var createSessionRequest = new CreateSessionRequest(); // CreateSessionRequest | 

            try
            {
                // Create a session with session token
                Session result = apiInstance.CreateSession(createSessionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SessionApi.CreateSession: " + e.Message );
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
 **createSessionRequest** | [**CreateSessionRequest**](CreateSessionRequest.md)|  | 

### Return type

[**Session**](Session.md)

### Authorization

[apiToken](../README.md#apiToken)

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

<a name="getcurrentsession"></a>
# **GetCurrentSession**
> Session GetCurrentSession (string cookie = null)

Retrieve the current session

Retrieves Session information for the current user. Use this method in a browser-based application to determine if the user is signed in.   > **Note:** This operation requires a session cookie for the user. An API token isn't allowed for this operation.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetCurrentSessionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            var apiInstance = new SessionApi(config);
            var cookie = sid=abcde-123 or idx=abcde-123;  // string |  (optional) 

            try
            {
                // Retrieve the current session
                Session result = apiInstance.GetCurrentSession(cookie);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SessionApi.GetCurrentSession: " + e.Message );
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
 **cookie** | **string**|  | [optional] 

### Return type

[**Session**](Session.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getsession"></a>
# **GetSession**
> Session GetSession (string sessionId)

Retrieve a session

Retrieves information about the Session specified by the given session ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetSessionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SessionApi(config);
            var sessionId = l7FbDVqS8zHSy65uJD85;  // string | `id` of the Session

            try
            {
                // Retrieve a session
                Session result = apiInstance.GetSession(sessionId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SessionApi.GetSession: " + e.Message );
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
 **sessionId** | **string**| &#x60;id&#x60; of the Session | 

### Return type

[**Session**](Session.md)

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

<a name="refreshcurrentsession"></a>
# **RefreshCurrentSession**
> Session RefreshCurrentSession (string cookie = null)

Refresh the current session

Refreshes the Session for the current user  > **Note:** This operation requires a session cookie for the user. An API token isn't allowed for this operation.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RefreshCurrentSessionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            var apiInstance = new SessionApi(config);
            var cookie = sid=abcde-123 or idx=abcde-123;  // string |  (optional) 

            try
            {
                // Refresh the current session
                Session result = apiInstance.RefreshCurrentSession(cookie);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SessionApi.RefreshCurrentSession: " + e.Message );
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
 **cookie** | **string**|  | [optional] 

### Return type

[**Session**](Session.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="refreshsession"></a>
# **RefreshSession**
> Session RefreshSession (string sessionId)

Refresh a session

Refreshes an existing Session using the `id` for that Session. A successful response contains the refreshed Session with an updated `expiresAt` timestamp.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RefreshSessionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SessionApi(config);
            var sessionId = l7FbDVqS8zHSy65uJD85;  // string | `id` of the Session

            try
            {
                // Refresh a session
                Session result = apiInstance.RefreshSession(sessionId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SessionApi.RefreshSession: " + e.Message );
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
 **sessionId** | **string**| &#x60;id&#x60; of the Session | 

### Return type

[**Session**](Session.md)

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

<a name="revokesession"></a>
# **RevokeSession**
> void RevokeSession (string sessionId)

Revoke a session

Revokes the specified Session

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeSessionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SessionApi(config);
            var sessionId = l7FbDVqS8zHSy65uJD85;  // string | `id` of the Session

            try
            {
                // Revoke a session
                apiInstance.RevokeSession(sessionId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SessionApi.RevokeSession: " + e.Message );
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
 **sessionId** | **string**| &#x60;id&#x60; of the Session | 

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

