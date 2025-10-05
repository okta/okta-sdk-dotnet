# Okta.Sdk.Api.UserAuthenticatorEnrollmentsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateAuthenticatorEnrollment**](UserAuthenticatorEnrollmentsApi.md#createauthenticatorenrollment) | **POST** /api/v1/users/{userId}/authenticator-enrollments/phone | Create an auto-activated Phone authenticator enrollment
[**CreateTacAuthenticatorEnrollment**](UserAuthenticatorEnrollmentsApi.md#createtacauthenticatorenrollment) | **POST** /api/v1/users/{userId}/authenticator-enrollments/tac | Create an auto-activated TAC authenticator enrollment
[**DeleteAuthenticatorEnrollment**](UserAuthenticatorEnrollmentsApi.md#deleteauthenticatorenrollment) | **DELETE** /api/v1/users/{userId}/authenticator-enrollments/{enrollmentId} | Delete an authenticator enrollment
[**GetAuthenticatorEnrollment**](UserAuthenticatorEnrollmentsApi.md#getauthenticatorenrollment) | **GET** /api/v1/users/{userId}/authenticator-enrollments/{enrollmentId} | Retrieve an authenticator enrollment
[**ListAuthenticatorEnrollments**](UserAuthenticatorEnrollmentsApi.md#listauthenticatorenrollments) | **GET** /api/v1/users/{userId}/authenticator-enrollments | List all authenticator enrollments


<a name="createauthenticatorenrollment"></a>
# **CreateAuthenticatorEnrollment**
> AuthenticatorEnrollment CreateAuthenticatorEnrollment (string userId, AuthenticatorEnrollmentCreateRequest authenticator)

Create an auto-activated Phone authenticator enrollment

Creates a Phone authenticator enrollment that's automatically activated

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateAuthenticatorEnrollmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserAuthenticatorEnrollmentsApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var authenticator = new AuthenticatorEnrollmentCreateRequest(); // AuthenticatorEnrollmentCreateRequest | 

            try
            {
                // Create an auto-activated Phone authenticator enrollment
                AuthenticatorEnrollment result = apiInstance.CreateAuthenticatorEnrollment(userId, authenticator);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserAuthenticatorEnrollmentsApi.CreateAuthenticatorEnrollment: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 
 **authenticator** | [**AuthenticatorEnrollmentCreateRequest**](AuthenticatorEnrollmentCreateRequest.md)|  | 

### Return type

[**AuthenticatorEnrollment**](AuthenticatorEnrollment.md)

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

<a name="createtacauthenticatorenrollment"></a>
# **CreateTacAuthenticatorEnrollment**
> TacAuthenticatorEnrollment CreateTacAuthenticatorEnrollment (string userId, AuthenticatorEnrollmentCreateRequestTac authenticator)

Create an auto-activated TAC authenticator enrollment

Creates an auto-activated Temporary access code (TAC) authenticator enrollment

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateTacAuthenticatorEnrollmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserAuthenticatorEnrollmentsApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var authenticator = new AuthenticatorEnrollmentCreateRequestTac(); // AuthenticatorEnrollmentCreateRequestTac | 

            try
            {
                // Create an auto-activated TAC authenticator enrollment
                TacAuthenticatorEnrollment result = apiInstance.CreateTacAuthenticatorEnrollment(userId, authenticator);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserAuthenticatorEnrollmentsApi.CreateTacAuthenticatorEnrollment: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 
 **authenticator** | [**AuthenticatorEnrollmentCreateRequestTac**](AuthenticatorEnrollmentCreateRequestTac.md)|  | 

### Return type

[**TacAuthenticatorEnrollment**](TacAuthenticatorEnrollment.md)

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

<a name="deleteauthenticatorenrollment"></a>
# **DeleteAuthenticatorEnrollment**
> void DeleteAuthenticatorEnrollment (string userId, string enrollmentId)

Delete an authenticator enrollment

Deletes an existing enrollment for the specified user. The user can enroll the authenticator again.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteAuthenticatorEnrollmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserAuthenticatorEnrollmentsApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var enrollmentId = sms8lqwuzSpWT4kVs0g4;  // string | Unique identifier of an enrollment

            try
            {
                // Delete an authenticator enrollment
                apiInstance.DeleteAuthenticatorEnrollment(userId, enrollmentId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserAuthenticatorEnrollmentsApi.DeleteAuthenticatorEnrollment: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 
 **enrollmentId** | **string**| Unique identifier of an enrollment | 

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

<a name="getauthenticatorenrollment"></a>
# **GetAuthenticatorEnrollment**
> AuthenticatorEnrollment GetAuthenticatorEnrollment (string userId, string enrollmentId)

Retrieve an authenticator enrollment

Retrieves a user's authenticator enrollment by `enrollmentId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAuthenticatorEnrollmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserAuthenticatorEnrollmentsApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var enrollmentId = sms8lqwuzSpWT4kVs0g4;  // string | Unique identifier of an enrollment

            try
            {
                // Retrieve an authenticator enrollment
                AuthenticatorEnrollment result = apiInstance.GetAuthenticatorEnrollment(userId, enrollmentId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserAuthenticatorEnrollmentsApi.GetAuthenticatorEnrollment: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 
 **enrollmentId** | **string**| Unique identifier of an enrollment | 

### Return type

[**AuthenticatorEnrollment**](AuthenticatorEnrollment.md)

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

<a name="listauthenticatorenrollments"></a>
# **ListAuthenticatorEnrollments**
> AuthenticatorEnrollment ListAuthenticatorEnrollments (string userId)

List all authenticator enrollments

Lists all authenticator enrollments of the specified user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAuthenticatorEnrollmentsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserAuthenticatorEnrollmentsApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // List all authenticator enrollments
                AuthenticatorEnrollment result = apiInstance.ListAuthenticatorEnrollments(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserAuthenticatorEnrollmentsApi.ListAuthenticatorEnrollments: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 

### Return type

[**AuthenticatorEnrollment**](AuthenticatorEnrollment.md)

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

