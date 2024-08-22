# Okta.Sdk.Api.UserFactorApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateFactor**](UserFactorApi.md#activatefactor) | **POST** /api/v1/users/{userId}/factors/{factorId}/lifecycle/activate | Activate a Factor
[**EnrollFactor**](UserFactorApi.md#enrollfactor) | **POST** /api/v1/users/{userId}/factors | Enroll a Factor
[**GetFactor**](UserFactorApi.md#getfactor) | **GET** /api/v1/users/{userId}/factors/{factorId} | Retrieve a Factor
[**GetFactorTransactionStatus**](UserFactorApi.md#getfactortransactionstatus) | **GET** /api/v1/users/{userId}/factors/{factorId}/transactions/{transactionId} | Retrieve a Factor transaction status
[**ListFactors**](UserFactorApi.md#listfactors) | **GET** /api/v1/users/{userId}/factors | List all enrolled Factors
[**ListSupportedFactors**](UserFactorApi.md#listsupportedfactors) | **GET** /api/v1/users/{userId}/factors/catalog | List all supported Factors
[**ListSupportedSecurityQuestions**](UserFactorApi.md#listsupportedsecurityquestions) | **GET** /api/v1/users/{userId}/factors/questions | List all supported Security Questions
[**ResendEnrollFactor**](UserFactorApi.md#resendenrollfactor) | **POST** /api/v1/users/{userId}/factors/{factorId}/resend | Resend a Factor enrollment
[**UnenrollFactor**](UserFactorApi.md#unenrollfactor) | **DELETE** /api/v1/users/{userId}/factors/{factorId} | Unenroll a Factor
[**VerifyFactor**](UserFactorApi.md#verifyfactor) | **POST** /api/v1/users/{userId}/factors/{factorId}/verify | Verify a Factor


<a name="activatefactor"></a>
# **ActivateFactor**
> UserFactor ActivateFactor (string userId, string factorId, UserFactorActivateRequest body = null)

Activate a Factor

Activates a Factor. Some Factors (`call`, `email`, `push`, `sms`, `token:software:totp`, `u2f`, and `webauthn`) require activation to complete the enrollment process.  Okta enforces a rate limit of five activation attempts within five minutes. After a user exceeds the rate limit, Okta returns an error message.

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | ID of an existing Okta user
            var factorId = zAgrsaBe0wVGRugDYtdv;  // string | ID of an existing user Factor
            var body = new UserFactorActivateRequest(); // UserFactorActivateRequest |  (optional) 

            try
            {
                // Activate a Factor
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
 **userId** | **string**| ID of an existing Okta user | 
 **factorId** | **string**| ID of an existing user Factor | 
 **body** | [**UserFactorActivateRequest**](UserFactorActivateRequest.md)|  | [optional] 

### Return type

[**UserFactor**](UserFactor.md)

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

<a name="enrollfactor"></a>
# **EnrollFactor**
> UserFactor EnrollFactor (string userId, UserFactor body, bool? updatePhone = null, string templateId = null, int? tokenLifetimeSeconds = null, bool? activate = null, string acceptLanguage = null)

Enroll a Factor

Enrolls a supported Factor for the specified user. Some Factor types require a seperate activation to complete the enrollment process. See [Activate a Factor](./#tag/UserFactor/operation/activateFactor).

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | ID of an existing Okta user
            var body = new UserFactor(); // UserFactor | Factor
            var updatePhone = false;  // bool? | If `true`, indicates you are replacing the currently registered phone number for the specified user. This parameter is ignored if the existing phone number is used by an activated Factor. (optional)  (default to false)
            var templateId = cstk2flOtuCMDJK4b0g3;  // string | ID of an existing custom SMS template. See the [SMS Templates API](../Template). Only used by `sms` Factors. If the provided ID doesn't exist, the default template is used instead. (optional) 
            var tokenLifetimeSeconds = 300;  // int? | Defines how long the token remains valid (optional)  (default to 300)
            var activate = false;  // bool? | If `true`, the `sms` Factor is immediately activated as part of the enrollment. An activation text message isn't sent to the device. (optional)  (default to false)
            var acceptLanguage = fr;  // string | An ISO 639-1 two-letter language code that defines a localized message to send. Only used by `sms` Factors. If a localized message doesn't exist or the `templateId` is incorrect, the default template is used instead. (optional) 

            try
            {
                // Enroll a Factor
                UserFactor result = apiInstance.EnrollFactor(userId, body, updatePhone, templateId, tokenLifetimeSeconds, activate, acceptLanguage);
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
 **userId** | **string**| ID of an existing Okta user | 
 **body** | [**UserFactor**](UserFactor.md)| Factor | 
 **updatePhone** | **bool?**| If &#x60;true&#x60;, indicates you are replacing the currently registered phone number for the specified user. This parameter is ignored if the existing phone number is used by an activated Factor. | [optional] [default to false]
 **templateId** | **string**| ID of an existing custom SMS template. See the [SMS Templates API](../Template). Only used by &#x60;sms&#x60; Factors. If the provided ID doesn&#39;t exist, the default template is used instead. | [optional] 
 **tokenLifetimeSeconds** | **int?**| Defines how long the token remains valid | [optional] [default to 300]
 **activate** | **bool?**| If &#x60;true&#x60;, the &#x60;sms&#x60; Factor is immediately activated as part of the enrollment. An activation text message isn&#39;t sent to the device. | [optional] [default to false]
 **acceptLanguage** | **string**| An ISO 639-1 two-letter language code that defines a localized message to send. Only used by &#x60;sms&#x60; Factors. If a localized message doesn&#39;t exist or the &#x60;templateId&#x60; is incorrect, the default template is used instead. | [optional] 

### Return type

[**UserFactor**](UserFactor.md)

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

<a name="getfactor"></a>
# **GetFactor**
> UserFactor GetFactor (string userId, string factorId)

Retrieve a Factor

Retrieves an existing Factor for the specified user

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | ID of an existing Okta user
            var factorId = zAgrsaBe0wVGRugDYtdv;  // string | ID of an existing user Factor

            try
            {
                // Retrieve a Factor
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
 **userId** | **string**| ID of an existing Okta user | 
 **factorId** | **string**| ID of an existing user Factor | 

### Return type

[**UserFactor**](UserFactor.md)

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

<a name="getfactortransactionstatus"></a>
# **GetFactorTransactionStatus**
> UserFactorPushTransaction GetFactorTransactionStatus (string userId, string factorId, string transactionId)

Retrieve a Factor transaction status

Retrieves the status of a `push` Factor verification transaction

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | ID of an existing Okta user
            var factorId = zAgrsaBe0wVGRugDYtdv;  // string | ID of an existing user Factor
            var transactionId = gPAQcN3NDjSGOCAeG2Jv;  // string | ID of an existing Factor verification transaction

            try
            {
                // Retrieve a Factor transaction status
                UserFactorPushTransaction result = apiInstance.GetFactorTransactionStatus(userId, factorId, transactionId);
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
 **userId** | **string**| ID of an existing Okta user | 
 **factorId** | **string**| ID of an existing user Factor | 
 **transactionId** | **string**| ID of an existing Factor verification transaction | 

### Return type

[**UserFactorPushTransaction**](UserFactorPushTransaction.md)

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

<a name="listfactors"></a>
# **ListFactors**
> List&lt;UserFactor&gt; ListFactors (string userId)

List all enrolled Factors

Lists all enrolled Factors for the specified user

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | ID of an existing Okta user

            try
            {
                // List all enrolled Factors
                List<UserFactor> result = apiInstance.ListFactors(userId).ToListAsync();
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
 **userId** | **string**| ID of an existing Okta user | 

### Return type

[**List&lt;UserFactor&gt;**](UserFactor.md)

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

<a name="listsupportedfactors"></a>
# **ListSupportedFactors**
> List&lt;UserFactorSupported&gt; ListSupportedFactors (string userId)

List all supported Factors

Lists all the supported Factors that can be enrolled for the specified user

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | ID of an existing Okta user

            try
            {
                // List all supported Factors
                List<UserFactorSupported> result = apiInstance.ListSupportedFactors(userId).ToListAsync();
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
 **userId** | **string**| ID of an existing Okta user | 

### Return type

[**List&lt;UserFactorSupported&gt;**](UserFactorSupported.md)

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

<a name="listsupportedsecurityquestions"></a>
# **ListSupportedSecurityQuestions**
> List&lt;UserFactorSecurityQuestionProfile&gt; ListSupportedSecurityQuestions (string userId)

List all supported Security Questions

Lists all available Security Questions for the specified user

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | ID of an existing Okta user

            try
            {
                // List all supported Security Questions
                List<UserFactorSecurityQuestionProfile> result = apiInstance.ListSupportedSecurityQuestions(userId).ToListAsync();
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
 **userId** | **string**| ID of an existing Okta user | 

### Return type

[**List&lt;UserFactorSecurityQuestionProfile&gt;**](UserFactorSecurityQuestionProfile.md)

### Authorization

[apiToken](../README.md#apiToken)

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

<a name="resendenrollfactor"></a>
# **ResendEnrollFactor**
> ResendUserFactor ResendEnrollFactor (string userId, string factorId, ResendUserFactor resendUserFactor, string templateId = null)

Resend a Factor enrollment

Resends an `sms`, `call`, or `email` factor challenge as part of an enrollment flow.  For `call` and `sms` factors, Okta enforces a rate limit of one OTP challenge per device every 30 seconds. You can configure your `sms` and `call` factors to use a third-party telephony provider. See the [Telephony inline hook reference](https://developer.okta.com/docs/reference/telephony-hook/). Okta round-robins between SMS providers with every resend request to help ensure delivery of an SMS and Call OTPs across different carriers.  > **Note**: Resend operations aren't allowed after a factor exceeds the activation rate limit. See [Activate a Factor](./#tag/UserFactor/operation/activateFactor).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ResendEnrollFactorExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | ID of an existing Okta user
            var factorId = zAgrsaBe0wVGRugDYtdv;  // string | ID of an existing user Factor
            var resendUserFactor = new ResendUserFactor(); // ResendUserFactor | 
            var templateId = cstk2flOtuCMDJK4b0g3;  // string | ID of an existing custom SMS template. See the [SMS Templates API](../Template). Only used by `sms` Factors. (optional) 

            try
            {
                // Resend a Factor enrollment
                ResendUserFactor result = apiInstance.ResendEnrollFactor(userId, factorId, resendUserFactor, templateId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserFactorApi.ResendEnrollFactor: " + e.Message );
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
 **factorId** | **string**| ID of an existing user Factor | 
 **resendUserFactor** | [**ResendUserFactor**](ResendUserFactor.md)|  | 
 **templateId** | **string**| ID of an existing custom SMS template. See the [SMS Templates API](../Template). Only used by &#x60;sms&#x60; Factors. | [optional] 

### Return type

[**ResendUserFactor**](ResendUserFactor.md)

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

<a name="unenrollfactor"></a>
# **UnenrollFactor**
> void UnenrollFactor (string userId, string factorId, bool? removeRecoveryEnrollment = null)

Unenroll a Factor

Unenrolls an existing Factor for the specified user. This allows the user to enroll a new Factor.  > **Note**: If you unenroll the `push` or the `signed_nonce` Factors, Okta also unenrolls any other `totp`, `signed_nonce`, or Okta Verify `push` Factors associated with the user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnenrollFactorExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | ID of an existing Okta user
            var factorId = zAgrsaBe0wVGRugDYtdv;  // string | ID of an existing user Factor
            var removeRecoveryEnrollment = false;  // bool? | If `true`, removes the the phone number as both a recovery method and a Factor. Only used for `sms` and `call` Factors. (optional)  (default to false)

            try
            {
                // Unenroll a Factor
                apiInstance.UnenrollFactor(userId, factorId, removeRecoveryEnrollment);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserFactorApi.UnenrollFactor: " + e.Message );
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
 **factorId** | **string**| ID of an existing user Factor | 
 **removeRecoveryEnrollment** | **bool?**| If &#x60;true&#x60;, removes the the phone number as both a recovery method and a Factor. Only used for &#x60;sms&#x60; and &#x60;call&#x60; Factors. | [optional] [default to false]

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

<a name="verifyfactor"></a>
# **VerifyFactor**
> UserFactorVerifyResponse VerifyFactor (string userId, string factorId, string templateId = null, int? tokenLifetimeSeconds = null, string xForwardedFor = null, string userAgent = null, string acceptLanguage = null, UserFactorVerifyRequest body = null)

Verify a Factor

Verifies an OTP for a Factor. Some Factors (`call`, `email`, `push`, `sms`, `u2f`, and `webauthn`) must first issue a challenge before you can verify the Factor. Do this by making a request without a body. After a challenge is issued, make another request to verify the Factor.  **Note**: To verify a `push` factor, use the **poll** link returned when you issue the challenge. See [Retrieve a Factor Transaction Status](/openapi/okta-management/management/tag/UserFactor/#tag/UserFactor/operation/getFactorTransactionStatus).

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserFactorApi(config);
            var userId = "userId_example";  // string | ID of an existing Okta user
            var factorId = zAgrsaBe0wVGRugDYtdv;  // string | ID of an existing user Factor
            var templateId = cstk2flOtuCMDJK4b0g3;  // string | ID of an existing custom SMS template. See the [SMS Templates API](../Template). Only used by `sms` Factors. (optional) 
            var tokenLifetimeSeconds = 300;  // int? | Defines how long the token remains valid (optional)  (default to 300)
            var xForwardedFor = "xForwardedFor_example";  // string | Public IP address for the user agent (optional) 
            var userAgent = "userAgent_example";  // string | Type of user agent detected when the request is made. Required to verify `push` Factors. (optional) 
            var acceptLanguage = fr;  // string | An ISO 639-1 two-letter language code that defines a localized message to send. Only used by `sms` Factors. If a localized message doesn't exist or the `templateId` is incorrect, the default template is used instead. (optional) 
            var body = new UserFactorVerifyRequest(); // UserFactorVerifyRequest | Some Factors (`call`, `email`, `push`, `sms`, `u2f`, and `webauthn`) must first issue a challenge before you can verify the Factor. Do this by making a request without a body. After a challenge is issued, make another request to verify the Factor. (optional) 

            try
            {
                // Verify a Factor
                UserFactorVerifyResponse result = apiInstance.VerifyFactor(userId, factorId, templateId, tokenLifetimeSeconds, xForwardedFor, userAgent, acceptLanguage, body);
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
 **userId** | **string**| ID of an existing Okta user | 
 **factorId** | **string**| ID of an existing user Factor | 
 **templateId** | **string**| ID of an existing custom SMS template. See the [SMS Templates API](../Template). Only used by &#x60;sms&#x60; Factors. | [optional] 
 **tokenLifetimeSeconds** | **int?**| Defines how long the token remains valid | [optional] [default to 300]
 **xForwardedFor** | **string**| Public IP address for the user agent | [optional] 
 **userAgent** | **string**| Type of user agent detected when the request is made. Required to verify &#x60;push&#x60; Factors. | [optional] 
 **acceptLanguage** | **string**| An ISO 639-1 two-letter language code that defines a localized message to send. Only used by &#x60;sms&#x60; Factors. If a localized message doesn&#39;t exist or the &#x60;templateId&#x60; is incorrect, the default template is used instead. | [optional] 
 **body** | [**UserFactorVerifyRequest**](UserFactorVerifyRequest.md)| Some Factors (&#x60;call&#x60;, &#x60;email&#x60;, &#x60;push&#x60;, &#x60;sms&#x60;, &#x60;u2f&#x60;, and &#x60;webauthn&#x60;) must first issue a challenge before you can verify the Factor. Do this by making a request without a body. After a challenge is issued, make another request to verify the Factor. | [optional] 

### Return type

[**UserFactorVerifyResponse**](UserFactorVerifyResponse.md)

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

