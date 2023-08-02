# Okta.Sdk.Api.EmailServerApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateEmailServer**](EmailServerApi.md#createemailserver) | **POST** /api/v1/email-servers | Create a custom SMTP server
[**DeleteEmailServer**](EmailServerApi.md#deleteemailserver) | **DELETE** /api/v1/email-servers/{emailServerId} | Delete an SMTP Server configuration
[**GetEmailServer**](EmailServerApi.md#getemailserver) | **GET** /api/v1/email-servers/{emailServerId} | Retrieve an SMTP Server configuration
[**ListEmailServers**](EmailServerApi.md#listemailservers) | **GET** /api/v1/email-servers | List all enrolled SMTP servers
[**TestEmailServer**](EmailServerApi.md#testemailserver) | **POST** /api/v1/email-servers/{emailServerId}/test | Test an SMTP Server configuration
[**UpdateEmailServer**](EmailServerApi.md#updateemailserver) | **PATCH** /api/v1/email-servers/{emailServerId} | Update an SMTP Server configuration


<a name="createemailserver"></a>
# **CreateEmailServer**
> EmailServerResponse CreateEmailServer (EmailServerPost emailServerPost = null)

Create a custom SMTP server

Creates a custom email SMTP server configuration for your organization

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateEmailServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EmailServerApi(config);
            var emailServerPost = new EmailServerPost(); // EmailServerPost |  (optional) 

            try
            {
                // Create a custom SMTP server
                EmailServerResponse result = apiInstance.CreateEmailServer(emailServerPost);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EmailServerApi.CreateEmailServer: " + e.Message );
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
 **emailServerPost** | [**EmailServerPost**](EmailServerPost.md)|  | [optional] 

### Return type

[**EmailServerResponse**](EmailServerResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Successfully enrolled server credentials |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteemailserver"></a>
# **DeleteEmailServer**
> void DeleteEmailServer (string emailServerId)

Delete an SMTP Server configuration

Deletes your organization's custom SMTP server with the given ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteEmailServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EmailServerApi(config);
            var emailServerId = "emailServerId_example";  // string | 

            try
            {
                // Delete an SMTP Server configuration
                apiInstance.DeleteEmailServer(emailServerId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EmailServerApi.DeleteEmailServer: " + e.Message );
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
 **emailServerId** | **string**|  | 

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
| **204** | No content |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemailserver"></a>
# **GetEmailServer**
> EmailServerListResponse GetEmailServer (string emailServerId)

Retrieve an SMTP Server configuration

Retrieves a configuration of your organization's custom SMTP server with the given ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetEmailServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EmailServerApi(config);
            var emailServerId = "emailServerId_example";  // string | 

            try
            {
                // Retrieve an SMTP Server configuration
                EmailServerListResponse result = apiInstance.GetEmailServer(emailServerId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EmailServerApi.GetEmailServer: " + e.Message );
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
 **emailServerId** | **string**|  | 

### Return type

[**EmailServerListResponse**](EmailServerListResponse.md)

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
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listemailservers"></a>
# **ListEmailServers**
> EmailServerListResponse ListEmailServers ()

List all enrolled SMTP servers

Lists all the enrolled custom email SMTP servers

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListEmailServersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EmailServerApi(config);

            try
            {
                // List all enrolled SMTP servers
                EmailServerListResponse result = apiInstance.ListEmailServers();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EmailServerApi.ListEmailServers: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**EmailServerListResponse**](EmailServerListResponse.md)

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

<a name="testemailserver"></a>
# **TestEmailServer**
> void TestEmailServer (string emailServerId, EmailTestAddresses emailTestAddresses = null)

Test an SMTP Server configuration

Tests your organization's custom SMTP Server with the given ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class TestEmailServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EmailServerApi(config);
            var emailServerId = "emailServerId_example";  // string | 
            var emailTestAddresses = new EmailTestAddresses(); // EmailTestAddresses |  (optional) 

            try
            {
                // Test an SMTP Server configuration
                apiInstance.TestEmailServer(emailServerId, emailTestAddresses);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EmailServerApi.TestEmailServer: " + e.Message );
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
 **emailServerId** | **string**|  | 
 **emailTestAddresses** | [**EmailTestAddresses**](EmailTestAddresses.md)|  | [optional] 

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
| **204** | No content |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateemailserver"></a>
# **UpdateEmailServer**
> EmailServerResponse UpdateEmailServer (string emailServerId, EmailServerRequest emailServerRequest = null)

Update an SMTP Server configuration

Updates one or more fields of your organization's custom SMTP Server configuration

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateEmailServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EmailServerApi(config);
            var emailServerId = "emailServerId_example";  // string | 
            var emailServerRequest = new EmailServerRequest(); // EmailServerRequest |  (optional) 

            try
            {
                // Update an SMTP Server configuration
                EmailServerResponse result = apiInstance.UpdateEmailServer(emailServerId, emailServerRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EmailServerApi.UpdateEmailServer: " + e.Message );
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
 **emailServerId** | **string**|  | 
 **emailServerRequest** | [**EmailServerRequest**](EmailServerRequest.md)|  | [optional] 

### Return type

[**EmailServerResponse**](EmailServerResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

