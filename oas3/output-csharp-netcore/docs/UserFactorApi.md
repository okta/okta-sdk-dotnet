# Okta.Sdk.Api.UserFactorApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateFactor**](UserFactorApi.md#activatefactor) | **POST** /api/v1/users/{userId}/factors/{factorId}/lifecycle/activate | Activate Factor
[**DeleteFactor**](UserFactorApi.md#deletefactor) | **DELETE** /api/v1/users/{userId}/factors/{factorId} | Delete Factor
[**EnrollFactor**](UserFactorApi.md#enrollfactor) | **POST** /api/v1/users/{userId}/factors | Enroll Factor
[**GetFactor**](UserFactorApi.md#getfactor) | **GET** /api/v1/users/{userId}/factors/{factorId} | Get Factor
[**GetFactorTransactionStatus**](UserFactorApi.md#getfactortransactionstatus) | **GET** /api/v1/users/{userId}/factors/{factorId}/transactions/{transactionId} | Get Factor Transaction Status
[**ListFactors**](UserFactorApi.md#listfactors) | **GET** /api/v1/users/{userId}/factors | List Factors
[**ListSupportedFactors**](UserFactorApi.md#listsupportedfactors) | **GET** /api/v1/users/{userId}/factors/catalog | List Supported Factors
[**ListSupportedSecurityQuestions**](UserFactorApi.md#listsupportedsecurityquestions) | **GET** /api/v1/users/{userId}/factors/questions | List Supported Security Questions
[**VerifyFactor**](UserFactorApi.md#verifyfactor) | **POST** /api/v1/users/{userId}/factors/{factorId}/verify | Verify MFA Factor


<a name="activatefactor"></a>
# **ActivateFactor**
> UserFactor ActivateFactor (string userId, string factorId, ActivateFactorRequest body = null)

Activate Factor

The `sms` and `token:software:totp` factor types require activation to complete the enrollment process.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateFactorExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | 
            var factorId = "factorId_example";  // string | 
            var body = new ActivateFactorRequest(); // ActivateFactorRequest |  (optional) 

            try
            {
                // Activate Factor
                UserFactor result = apiInstance.ActivateFactor(userId, factorId, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserFactorApi.ActivateFactor: " + e.Message );
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
 **userId** | **string**|  | 
 **factorId** | **string**|  | 
 **body** | [**ActivateFactorRequest**](ActivateFactorRequest.md)|  | [optional] 

### Return type

[**UserFactor**](UserFactor.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletefactor"></a>
# **DeleteFactor**
> void DeleteFactor (string userId, string factorId)

Delete Factor

Unenrolls an existing factor for the specified user, allowing the user to enroll a new factor.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteFactorExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | 
            var factorId = "factorId_example";  // string | 

            try
            {
                // Delete Factor
                apiInstance.DeleteFactor(userId, factorId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserFactorApi.DeleteFactor: " + e.Message );
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
 **userId** | **string**|  | 
 **factorId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="enrollfactor"></a>
# **EnrollFactor**
> UserFactor EnrollFactor (string userId, UserFactor body, bool? updatePhone = null, string templateId = null, int? tokenLifetimeSeconds = null, bool? activate = null)

Enroll Factor

Enrolls a user with a supported factor.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class EnrollFactorExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | 
            var body = new UserFactor(); // UserFactor | Factor
            var updatePhone = false;  // bool? |  (optional)  (default to false)
            var templateId = "templateId_example";  // string | id of SMS template (only for SMS factor) (optional) 
            var tokenLifetimeSeconds = 300;  // int? |  (optional)  (default to 300)
            var activate = false;  // bool? |  (optional)  (default to false)

            try
            {
                // Enroll Factor
                UserFactor result = apiInstance.EnrollFactor(userId, body, updatePhone, templateId, tokenLifetimeSeconds, activate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserFactorApi.EnrollFactor: " + e.Message );
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
 **userId** | **string**|  | 
 **body** | [**UserFactor**](UserFactor.md)| Factor | 
 **updatePhone** | **bool?**|  | [optional] [default to false]
 **templateId** | **string**| id of SMS template (only for SMS factor) | [optional] 
 **tokenLifetimeSeconds** | **int?**|  | [optional] [default to 300]
 **activate** | **bool?**|  | [optional] [default to false]

### Return type

[**UserFactor**](UserFactor.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getfactor"></a>
# **GetFactor**
> UserFactor GetFactor (string userId, string factorId)

Get Factor

Fetches a factor for the specified user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetFactorExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | 
            var factorId = "factorId_example";  // string | 

            try
            {
                // Get Factor
                UserFactor result = apiInstance.GetFactor(userId, factorId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserFactorApi.GetFactor: " + e.Message );
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
 **userId** | **string**|  | 
 **factorId** | **string**|  | 

### Return type

[**UserFactor**](UserFactor.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getfactortransactionstatus"></a>
# **GetFactorTransactionStatus**
> VerifyUserFactorResponse GetFactorTransactionStatus (string userId, string factorId, string transactionId)

Get Factor Transaction Status

Polls factors verification transaction for status.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetFactorTransactionStatusExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | 
            var factorId = "factorId_example";  // string | 
            var transactionId = "transactionId_example";  // string | 

            try
            {
                // Get Factor Transaction Status
                VerifyUserFactorResponse result = apiInstance.GetFactorTransactionStatus(userId, factorId, transactionId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserFactorApi.GetFactorTransactionStatus: " + e.Message );
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
 **userId** | **string**|  | 
 **factorId** | **string**|  | 
 **transactionId** | **string**|  | 

### Return type

[**VerifyUserFactorResponse**](VerifyUserFactorResponse.md)

### Authorization

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listfactors"></a>
# **ListFactors**
> List&lt;UserFactor&gt; ListFactors (string userId)

List Factors

Enumerates all the enrolled factors for the specified user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListFactorsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // List Factors
                List<UserFactor> result = apiInstance.ListFactors(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserFactorApi.ListFactors: " + e.Message );
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
 **userId** | **string**|  | 

### Return type

[**List&lt;UserFactor&gt;**](UserFactor.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listsupportedfactors"></a>
# **ListSupportedFactors**
> List&lt;UserFactor&gt; ListSupportedFactors (string userId)

List Supported Factors

Enumerates all the supported factors that can be enrolled for the specified user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListSupportedFactorsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // List Supported Factors
                List<UserFactor> result = apiInstance.ListSupportedFactors(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserFactorApi.ListSupportedFactors: " + e.Message );
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
 **userId** | **string**|  | 

### Return type

[**List&lt;UserFactor&gt;**](UserFactor.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listsupportedsecurityquestions"></a>
# **ListSupportedSecurityQuestions**
> List&lt;SecurityQuestion&gt; ListSupportedSecurityQuestions (string userId)

List Supported Security Questions

Enumerates all available security questions for a user's `question` factor

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListSupportedSecurityQuestionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // List Supported Security Questions
                List<SecurityQuestion> result = apiInstance.ListSupportedSecurityQuestions(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserFactorApi.ListSupportedSecurityQuestions: " + e.Message );
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
 **userId** | **string**|  | 

### Return type

[**List&lt;SecurityQuestion&gt;**](SecurityQuestion.md)

### Authorization

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="verifyfactor"></a>
# **VerifyFactor**
> VerifyUserFactorResponse VerifyFactor (string userId, string factorId, string templateId = null, int? tokenLifetimeSeconds = null, string xForwardedFor = null, string userAgent = null, string acceptLanguage = null, VerifyFactorRequest body = null)

Verify MFA Factor

Verifies an OTP for a `token` or `token:hardware` factor

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class VerifyFactorExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | 
            var factorId = "factorId_example";  // string | 
            var templateId = "templateId_example";  // string |  (optional) 
            var tokenLifetimeSeconds = 300;  // int? |  (optional)  (default to 300)
            var xForwardedFor = "xForwardedFor_example";  // string |  (optional) 
            var userAgent = "userAgent_example";  // string |  (optional) 
            var acceptLanguage = "acceptLanguage_example";  // string |  (optional) 
            var body = new VerifyFactorRequest(); // VerifyFactorRequest |  (optional) 

            try
            {
                // Verify MFA Factor
                VerifyUserFactorResponse result = apiInstance.VerifyFactor(userId, factorId, templateId, tokenLifetimeSeconds, xForwardedFor, userAgent, acceptLanguage, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserFactorApi.VerifyFactor: " + e.Message );
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
 **userId** | **string**|  | 
 **factorId** | **string**|  | 
 **templateId** | **string**|  | [optional] 
 **tokenLifetimeSeconds** | **int?**|  | [optional] [default to 300]
 **xForwardedFor** | **string**|  | [optional] 
 **userAgent** | **string**|  | [optional] 
 **acceptLanguage** | **string**|  | [optional] 
 **body** | [**VerifyFactorRequest**](VerifyFactorRequest.md)|  | [optional] 

### Return type

[**VerifyUserFactorResponse**](VerifyUserFactorResponse.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

