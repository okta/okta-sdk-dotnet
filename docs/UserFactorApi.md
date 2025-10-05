# Okta.Sdk.Api.UserFactorApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateFactor**](UserFactorApi.md#activatefactor) | **POST** /api/v1/users/{userId}/factors/{factorId}/lifecycle/activate | Activate a factor
[**EnrollFactor**](UserFactorApi.md#enrollfactor) | **POST** /api/v1/users/{userId}/factors | Enroll a factor
[**GetFactor**](UserFactorApi.md#getfactor) | **GET** /api/v1/users/{userId}/factors/{factorId} | Retrieve a factor
[**GetFactorTransactionStatus**](UserFactorApi.md#getfactortransactionstatus) | **GET** /api/v1/users/{userId}/factors/{factorId}/transactions/{transactionId} | Retrieve a factor transaction status
[**GetYubikeyOtpTokenById**](UserFactorApi.md#getyubikeyotptokenbyid) | **GET** /api/v1/org/factors/yubikey_token/tokens/{tokenId} | Retrieve a YubiKey OTP token
[**ListFactors**](UserFactorApi.md#listfactors) | **GET** /api/v1/users/{userId}/factors | List all enrolled factors
[**ListSupportedFactors**](UserFactorApi.md#listsupportedfactors) | **GET** /api/v1/users/{userId}/factors/catalog | List all supported factors
[**ListSupportedSecurityQuestions**](UserFactorApi.md#listsupportedsecurityquestions) | **GET** /api/v1/users/{userId}/factors/questions | List all supported security questions
[**ListYubikeyOtpTokens**](UserFactorApi.md#listyubikeyotptokens) | **GET** /api/v1/org/factors/yubikey_token/tokens | List all YubiKey OTP tokens
[**ResendEnrollFactor**](UserFactorApi.md#resendenrollfactor) | **POST** /api/v1/users/{userId}/factors/{factorId}/resend | Resend a factor enrollment
[**UnenrollFactor**](UserFactorApi.md#unenrollfactor) | **DELETE** /api/v1/users/{userId}/factors/{factorId} | Unenroll a factor
[**UploadYubikeyOtpTokenSeed**](UserFactorApi.md#uploadyubikeyotptokenseed) | **POST** /api/v1/org/factors/yubikey_token/tokens | Upload a YubiKey OTP seed
[**VerifyFactor**](UserFactorApi.md#verifyfactor) | **POST** /api/v1/users/{userId}/factors/{factorId}/verify | Verify a factor


<a name="activatefactor"></a>
# **ActivateFactor**
> UserFactorActivateResponse ActivateFactor (string userId, string factorId, UserFactorActivateRequest body = null)

Activate a factor

Activates a factor. Some factors (`call`, `email`, `push`, `sms`, `token:software:totp`, `u2f`, and `webauthn`) require activation to complete the enrollment process.  Okta enforces a rate limit of five activation attempts within five minutes. After a user exceeds the rate limit, Okta returns an error message.  > **Notes:**  > * If the user exceeds their SMS, call, or email factor activation rate limit, then an [OTP resend request](./#tag/UserFactor/operation/resendEnrollFactor) isn't allowed for the same factor. > * You can't use the Factors API to activate Okta Fastpass (`signed_nonce`) for a user. See [Configure Okta Fastpass](https://help.okta.com/okta_help.htm?type=oie&id=ext-fp-configure).

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
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var factorId = zAgrsaBe0wVGRugDYtdv;  // string | ID of an existing user factor
            var body = new UserFactorActivateRequest(); // UserFactorActivateRequest |  (optional) 

            try
            {
                // Activate a factor
                UserFactorActivateResponse result = apiInstance.ActivateFactor(userId, factorId, body);
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
 **factorId** | **string**| ID of an existing user factor | 
 **body** | [**UserFactorActivateRequest**](UserFactorActivateRequest.md)|  | [optional] 

### Return type

[**UserFactorActivateResponse**](UserFactorActivateResponse.md)

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

Enroll a factor

Enrolls a supported factor for the specified user  > **Notes:**  >   * All responses return the enrolled factor with a status of either `PENDING_ACTIVATION` or `ACTIVE`. >   * You can't use the Factors API to enroll Okta Fastpass (`signed_nonce`) for a user. See [Configure Okta Fastpass](https://help.okta.com/okta_help.htm?type=oie&id=ext-fp-configure).  #### Additional SMS/Call factor information  * **Rate limits**: Okta may return a `429 Too Many Requests` status code if you attempt to resend an SMS or a voice call challenge (OTP) within the same time window. The current [rate limit](https://developer.okta.com/docs/reference/rate-limits/) is one SMS/CALL challenge per phone number every 30 seconds.  * **Existing phone numbers**: Okta may return a `400 Bad Request` status code if a user attempts to enroll with a different phone number when the user has an existing mobile phone or has an existing phone with voice call capability. A user can enroll only one mobile phone for `sms` and enroll only one voice call capable phone for `call` factor.  #### Additional WebAuthn factor information  * For detailed information on the WebAuthn standard, including an up-to-date list of supported browsers, see [webauthn.me](https://a0.to/webauthnme-okta-docs).  * When you enroll a WebAuthn factor, the `activation` object in `_embedded` contains properties used to help the client to create a new WebAuthn credential for use with Okta. See the [WebAuthn spec for PublicKeyCredentialCreationOptions](https://www.w3.org/TR/webauthn/#dictionary-makecredentialoptions).  #### Additional Custom TOTP factor information  * The enrollment process involves passing both the `factorProfileId` and `sharedSecret` properties for a token.  * A factor profile represents a particular configuration of the Custom TOTP factor. It includes certain properties that match the hardware token that end users possess, such as the HMAC algorithm, passcode length, and time interval. There can be multiple Custom TOTP factor profiles per org, but users can only enroll in one Custom TOTP factor. Admins can [create Custom TOTP factor profiles](https://help.okta.com/okta_help.htm?id=ext-mfa-totp) in the Admin Console. Then, copy the `factorProfileId` from the Admin Console into the API request.  * <x-lifecycle class=\"oie\"></x-lifecycle> For Custom TOTP enrollment, Okta automaticaly enrolls a user with a `token:software:totp` factor and the `push` factor if the user isn't currently enrolled with these factors.

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
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var body = new UserFactor(); // UserFactor | Factor
            var updatePhone = false;  // bool? | If `true`, indicates that you are replacing the currently registered phone number for the specified user. This parameter is ignored if the existing phone number is used by an activated factor. (optional)  (default to false)
            var templateId = cstk2flOtuCMDJK4b0g3;  // string | ID of an existing custom SMS template. See the [SMS Templates API](../Template). This parameter is only used by `sms` factors. If the provided ID doesn't exist, the default template is used instead. (optional) 
            var tokenLifetimeSeconds = 300;  // int? | Defines how long the token remains valid (optional)  (default to 300)
            var activate = false;  // bool? | If `true`, the factor is immediately activated as part of the enrollment. An activation process isn't required. Currently auto-activation is supported by `sms`, `call`, `email` and `token:hotp` (Custom TOTP) factors. (optional)  (default to false)
            var acceptLanguage = fr;  // string | An ISO 639-1 two-letter language code that defines a localized message to send. This parameter is only used by `sms` factors. If a localized message doesn't exist or the `templateId` is incorrect, the default template is used instead. (optional) 

            try
            {
                // Enroll a factor
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
 **updatePhone** | **bool?**| If &#x60;true&#x60;, indicates that you are replacing the currently registered phone number for the specified user. This parameter is ignored if the existing phone number is used by an activated factor. | [optional] [default to false]
 **templateId** | **string**| ID of an existing custom SMS template. See the [SMS Templates API](../Template). This parameter is only used by &#x60;sms&#x60; factors. If the provided ID doesn&#39;t exist, the default template is used instead. | [optional] 
 **tokenLifetimeSeconds** | **int?**| Defines how long the token remains valid | [optional] [default to 300]
 **activate** | **bool?**| If &#x60;true&#x60;, the factor is immediately activated as part of the enrollment. An activation process isn&#39;t required. Currently auto-activation is supported by &#x60;sms&#x60;, &#x60;call&#x60;, &#x60;email&#x60; and &#x60;token:hotp&#x60; (Custom TOTP) factors. | [optional] [default to false]
 **acceptLanguage** | **string**| An ISO 639-1 two-letter language code that defines a localized message to send. This parameter is only used by &#x60;sms&#x60; factors. If a localized message doesn&#39;t exist or the &#x60;templateId&#x60; is incorrect, the default template is used instead. | [optional] 

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

Retrieve a factor

Retrieves an existing factor for the specified user

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
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var factorId = zAgrsaBe0wVGRugDYtdv;  // string | ID of an existing user factor

            try
            {
                // Retrieve a factor
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
 **factorId** | **string**| ID of an existing user factor | 

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

Retrieve a factor transaction status

Retrieves the status of a `push` factor verification transaction   > **Note:**  > The response body for a number matching push challenge to an Okta Verify `push` factor enrollment is different from the response body of a standard push challenge.   > The number matching push challenge [response body](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/UserFactor/#tag/UserFactor/operation/getFactorTransactionStatus!c=200&path=1/_embedded&t=response) contains the correct answer for the challenge.  > Use [Verify a factor](/openapi/okta-management/management/tag/UserFactor/#tag/UserFactor/operation/verifyFactor) to configure which challenge is sent.

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
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var factorId = zAgrsaBe0wVGRugDYtdv;  // string | ID of an existing user factor
            var transactionId = gPAQcN3NDjSGOCAeG2Jv;  // string | ID of an existing factor verification transaction

            try
            {
                // Retrieve a factor transaction status
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
 **factorId** | **string**| ID of an existing user factor | 
 **transactionId** | **string**| ID of an existing factor verification transaction | 

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

<a name="getyubikeyotptokenbyid"></a>
# **GetYubikeyOtpTokenById**
> UserFactorYubikeyOtpToken GetYubikeyOtpTokenById (string tokenId)

Retrieve a YubiKey OTP token

Retrieves the specified YubiKey OTP token by `id`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetYubikeyOtpTokenByIdExample
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
            var tokenId = ykkxdtCA1fKVxyu6R0g3;  // string | ID of a YubiKey token

            try
            {
                // Retrieve a YubiKey OTP token
                UserFactorYubikeyOtpToken result = apiInstance.GetYubikeyOtpTokenById(tokenId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserFactorApi.GetYubikeyOtpTokenById: " + e.Message );
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
 **tokenId** | **string**| ID of a YubiKey token | 

### Return type

[**UserFactorYubikeyOtpToken**](UserFactorYubikeyOtpToken.md)

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

List all enrolled factors

Lists all enrolled factors for the specified user that are included in the highest priority [authenticator enrollment policy](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Policy/) that applies to the user.  Only enrolled factors that are `REQUIRED` or `OPTIONAL` in the highest priority authenticator enrollment policy can be returned.  > **Note:** When admins use this endpoint for other users, the authenticator enrollment policy that's evaluated can vary depending on how client-specific conditions are configured in the rules of an authenticator enrollment policy. The client-specific conditions of the admin's client are used during policy evaluation instead of the client-specific conditions of the user. This can affect which authenticator enrollment policy is evaluated and which factors are returned. > > For example, an admin in Europe lists all enrolled factors for a user in North America. The network zone of the admin's client (in Europe) is used during policy evaluation instead of the network zone of the user (in North America).

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
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // List all enrolled factors
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

List all supported factors

Lists all the supported factors that can be enrolled for the specified user that are included in the highest priority [authenticator enrollment policy](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Policy/) that applies to the user.  Only factors that are `REQUIRED` or `OPTIONAL` in the highest priority authenticator enrollment policy can be returned.  > **Note:** When admins use this endpoint for other users, the authenticator enrollment policy that's evaluated can vary depending on how client-specific conditions are configured in the rules of an authenticator enrollment policy. The client-specific conditions of the admin's client are used during policy evaluation instead of the client-specific conditions of the user. This can affect which authenticator enrollment policy is evaluated and which factors are returned. > > For example, an admin in Europe lists all supported factors for a user in North America. The network zone of the admin's client (in Europe) is used during policy evaluation instead of the network zone of the user (in North America).

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
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // List all supported factors
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

List all supported security questions

Lists all available security questions for the specified user

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
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // List all supported security questions
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

<a name="listyubikeyotptokens"></a>
# **ListYubikeyOtpTokens**
> List&lt;UserFactorYubikeyOtpToken&gt; ListYubikeyOtpTokens (string after = null, string expand = null, YubikeyFilterParameter? filter = null, bool? forDownload = null, int? limit = null, YubikeySortByParameter? sortBy = null, YubikeySortOrderParameter? sortOrder = null)

List all YubiKey OTP tokens

Lists all YubiKey OTP tokens

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListYubikeyOtpTokensExample
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
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of tokens (optional) 
            var expand = "expand_example";  // string | Embeds the [user](/openapi/okta-management/management/tag/User/) resource if the YubiKey token is assigned to a user and `expand` is set to `user` (optional) 
            var filter = (YubikeyFilterParameter) "profile.email";  // YubikeyFilterParameter? | The expression used to filter tokens (optional) 
            var forDownload = false;  // bool? | Returns tokens in a CSV to download instead of in the response. When you use this query parameter, the `limit` default changes to 1000. (optional)  (default to false)
            var limit = 20;  // int? | Specifies the number of results per page (optional)  (default to 20)
            var sortBy = (YubikeySortByParameter) "profile.email";  // YubikeySortByParameter? | The value of how the tokens are sorted (optional) 
            var sortOrder = (YubikeySortOrderParameter) "ASC";  // YubikeySortOrderParameter? | Specifies the sort order, either `ASC` or `DESC` (optional) 

            try
            {
                // List all YubiKey OTP tokens
                List<UserFactorYubikeyOtpToken> result = apiInstance.ListYubikeyOtpTokens(after, expand, filter, forDownload, limit, sortBy, sortOrder).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserFactorApi.ListYubikeyOtpTokens: " + e.Message );
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
 **after** | **string**| Specifies the pagination cursor for the next page of tokens | [optional] 
 **expand** | **string**| Embeds the [user](/openapi/okta-management/management/tag/User/) resource if the YubiKey token is assigned to a user and &#x60;expand&#x60; is set to &#x60;user&#x60; | [optional] 
 **filter** | **YubikeyFilterParameter?**| The expression used to filter tokens | [optional] 
 **forDownload** | **bool?**| Returns tokens in a CSV to download instead of in the response. When you use this query parameter, the &#x60;limit&#x60; default changes to 1000. | [optional] [default to false]
 **limit** | **int?**| Specifies the number of results per page | [optional] [default to 20]
 **sortBy** | **YubikeySortByParameter?**| The value of how the tokens are sorted | [optional] 
 **sortOrder** | **YubikeySortOrderParameter?**| Specifies the sort order, either &#x60;ASC&#x60; or &#x60;DESC&#x60; | [optional] 

### Return type

[**List&lt;UserFactorYubikeyOtpToken&gt;**](UserFactorYubikeyOtpToken.md)

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

<a name="resendenrollfactor"></a>
# **ResendEnrollFactor**
> ResendUserFactor ResendEnrollFactor (string userId, string factorId, ResendUserFactor resendUserFactor, string templateId = null)

Resend a factor enrollment

Resends an `sms`, `call`, or `email` factor challenge as part of an enrollment flow.  For `call` and `sms` factors, Okta enforces a rate limit of one OTP challenge per device every 30 seconds. You can configure your `sms` and `call` factors to use a third-party telephony provider. See the [Telephony inline hook reference](https://developer.okta.com/docs/reference/telephony-hook/). Okta alternates between SMS providers with every resend request to ensure delivery of SMS and Call OTPs across different carriers.  > **Note:** Resend operations aren't allowed after a factor exceeds the activation rate limit. See [Activate a factor](./#tag/UserFactor/operation/activateFactor).

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
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var factorId = zAgrsaBe0wVGRugDYtdv;  // string | ID of an existing user factor
            var resendUserFactor = new ResendUserFactor(); // ResendUserFactor | 
            var templateId = cstk2flOtuCMDJK4b0g3;  // string | ID of an existing custom SMS template. See the [SMS Templates API](../Template). This parameter is only used by `sms` factors. (optional) 

            try
            {
                // Resend a factor enrollment
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
 **factorId** | **string**| ID of an existing user factor | 
 **resendUserFactor** | [**ResendUserFactor**](ResendUserFactor.md)|  | 
 **templateId** | **string**| ID of an existing custom SMS template. See the [SMS Templates API](../Template). This parameter is only used by &#x60;sms&#x60; factors. | [optional] 

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

Unenroll a factor

Unenrolls an existing factor for the specified user. You can't unenroll a factor from a deactivated user. Unenrolling a factor allows the user to enroll a new factor.  > **Note:** If you unenroll the `push` or the `signed_nonce` factors, Okta also unenrolls any other `totp`, `signed_nonce`, or Okta Verify `push` factors associated with the user.

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
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var factorId = zAgrsaBe0wVGRugDYtdv;  // string | ID of an existing user factor
            var removeRecoveryEnrollment = false;  // bool? | If `true`, removes the phone number as both a recovery method and a factor. This parameter is only used for the `sms` and `call` factors. (optional)  (default to false)

            try
            {
                // Unenroll a factor
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
 **factorId** | **string**| ID of an existing user factor | 
 **removeRecoveryEnrollment** | **bool?**| If &#x60;true&#x60;, removes the phone number as both a recovery method and a factor. This parameter is only used for the &#x60;sms&#x60; and &#x60;call&#x60; factors. | [optional] [default to false]

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

<a name="uploadyubikeyotptokenseed"></a>
# **UploadYubikeyOtpTokenSeed**
> UserFactorYubikeyOtpToken UploadYubikeyOtpTokenSeed (UploadYubikeyOtpTokenSeedRequest uploadYubikeyOtpTokenSeedRequest, string after = null, string expand = null, YubikeyFilterParameter? filter = null, bool? forDownload = null, int? limit = null, YubikeySortByParameter? sortBy = null, YubikeySortOrderParameter? sortOrder = null)

Upload a YubiKey OTP seed

Uploads a seed for a user to enroll a YubiKey OTP

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UploadYubikeyOtpTokenSeedExample
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
            var uploadYubikeyOtpTokenSeedRequest = new UploadYubikeyOtpTokenSeedRequest(); // UploadYubikeyOtpTokenSeedRequest | 
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of tokens (optional) 
            var expand = "expand_example";  // string | Embeds the [user](/openapi/okta-management/management/tag/User/) resource if the YubiKey token is assigned to a user and `expand` is set to `user` (optional) 
            var filter = (YubikeyFilterParameter) "profile.email";  // YubikeyFilterParameter? | The expression used to filter tokens (optional) 
            var forDownload = false;  // bool? | Returns tokens in a CSV to download instead of in the response. When you use this query parameter, the `limit` default changes to 1000. (optional)  (default to false)
            var limit = 20;  // int? | Specifies the number of results per page (optional)  (default to 20)
            var sortBy = (YubikeySortByParameter) "profile.email";  // YubikeySortByParameter? | The value of how the tokens are sorted (optional) 
            var sortOrder = (YubikeySortOrderParameter) "ASC";  // YubikeySortOrderParameter? | Specifies the sort order, either `ASC` or `DESC` (optional) 

            try
            {
                // Upload a YubiKey OTP seed
                UserFactorYubikeyOtpToken result = apiInstance.UploadYubikeyOtpTokenSeed(uploadYubikeyOtpTokenSeedRequest, after, expand, filter, forDownload, limit, sortBy, sortOrder);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserFactorApi.UploadYubikeyOtpTokenSeed: " + e.Message );
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
 **uploadYubikeyOtpTokenSeedRequest** | [**UploadYubikeyOtpTokenSeedRequest**](UploadYubikeyOtpTokenSeedRequest.md)|  | 
 **after** | **string**| Specifies the pagination cursor for the next page of tokens | [optional] 
 **expand** | **string**| Embeds the [user](/openapi/okta-management/management/tag/User/) resource if the YubiKey token is assigned to a user and &#x60;expand&#x60; is set to &#x60;user&#x60; | [optional] 
 **filter** | **YubikeyFilterParameter?**| The expression used to filter tokens | [optional] 
 **forDownload** | **bool?**| Returns tokens in a CSV to download instead of in the response. When you use this query parameter, the &#x60;limit&#x60; default changes to 1000. | [optional] [default to false]
 **limit** | **int?**| Specifies the number of results per page | [optional] [default to 20]
 **sortBy** | **YubikeySortByParameter?**| The value of how the tokens are sorted | [optional] 
 **sortOrder** | **YubikeySortOrderParameter?**| Specifies the sort order, either &#x60;ASC&#x60; or &#x60;DESC&#x60; | [optional] 

### Return type

[**UserFactorYubikeyOtpToken**](UserFactorYubikeyOtpToken.md)

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

<a name="verifyfactor"></a>
# **VerifyFactor**
> UserFactorVerifyResponse VerifyFactor (string userId, string factorId, string templateId = null, int? tokenLifetimeSeconds = null, string xForwardedFor = null, string userAgent = null, string acceptLanguage = null, UserFactorVerifyRequest body = null)

Verify a factor

Verifies an OTP for a factor. Some factors (`call`, `email`, `push`, `sms`, `u2f`, and `webauthn`) must first issue a challenge before you can verify the factor. Do this by making a request without a body. After a challenge is issued, make another request to verify the factor.  > **Notes:** > - You can send standard push challenges or number matching push challenges to Okta Verify `push` factor enrollments. Use a [request body](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/UserFactor/#tag/UserFactor/operation/verifyFactor!path=2/useNumberMatchingChallenge&t=request) for number matching push challenges.  > - To verify a `push` factor, use the **poll** link returned when you issue the challenge. See [Retrieve a factor transaction status](/openapi/okta-management/management/tag/UserFactor/#tag/UserFactor/operation/getFactorTransactionStatus).

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
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var factorId = zAgrsaBe0wVGRugDYtdv;  // string | ID of an existing user factor
            var templateId = cstk2flOtuCMDJK4b0g3;  // string | ID of an existing custom SMS template. See the [SMS Templates API](../Template). This parameter is only used by `sms` factors. (optional) 
            var tokenLifetimeSeconds = 300;  // int? | Defines how long the token remains valid (optional)  (default to 300)
            var xForwardedFor = "xForwardedFor_example";  // string | Public IP address for the user agent (optional) 
            var userAgent = "userAgent_example";  // string | Type of user agent detected when the request is made. Required to verify `push` factors. (optional) 
            var acceptLanguage = fr;  // string | An ISO 639-1 two-letter language code that defines a localized message to send. This parameter is only used by `sms` factors. If a localized message doesn't exist or the `templateId` is incorrect, the default template is used instead. (optional) 
            var body = new UserFactorVerifyRequest(); // UserFactorVerifyRequest | Verifies an OTP for a factor. Some factors (`call`, `email`, `push`, `sms`, `u2f`, and `webauthn`) must first issue a challenge before you can verify the factor. Do this by making a request without a body. After a challenge is issued, make another request to verify the factor.  > **Note:** > Unlike standard push challenges that don't require a request body, a number matching [`push`](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/UserFactor/#tag/UserFactor/operation/verifyFactor!path=2/useNumberMatchingChallenge&t=request) challenge requires a request body. `useNumberMatchingChallenge` must be set to `true`. > When a number matching challenge is issued for an Okta Verify `push` factor enrollment, a `correctAnswer` challenge object is returned in the [`_embedded`](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/UserFactor/#tag/UserFactor/operation/verifyFactor!c=200&path=_embedded&t=response) object. (optional) 

            try
            {
                // Verify a factor
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
 **factorId** | **string**| ID of an existing user factor | 
 **templateId** | **string**| ID of an existing custom SMS template. See the [SMS Templates API](../Template). This parameter is only used by &#x60;sms&#x60; factors. | [optional] 
 **tokenLifetimeSeconds** | **int?**| Defines how long the token remains valid | [optional] [default to 300]
 **xForwardedFor** | **string**| Public IP address for the user agent | [optional] 
 **userAgent** | **string**| Type of user agent detected when the request is made. Required to verify &#x60;push&#x60; factors. | [optional] 
 **acceptLanguage** | **string**| An ISO 639-1 two-letter language code that defines a localized message to send. This parameter is only used by &#x60;sms&#x60; factors. If a localized message doesn&#39;t exist or the &#x60;templateId&#x60; is incorrect, the default template is used instead. | [optional] 
 **body** | [**UserFactorVerifyRequest**](UserFactorVerifyRequest.md)| Verifies an OTP for a factor. Some factors (&#x60;call&#x60;, &#x60;email&#x60;, &#x60;push&#x60;, &#x60;sms&#x60;, &#x60;u2f&#x60;, and &#x60;webauthn&#x60;) must first issue a challenge before you can verify the factor. Do this by making a request without a body. After a challenge is issued, make another request to verify the factor.  &gt; **Note:** &gt; Unlike standard push challenges that don&#39;t require a request body, a number matching [&#x60;push&#x60;](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/UserFactor/#tag/UserFactor/operation/verifyFactor!path&#x3D;2/useNumberMatchingChallenge&amp;t&#x3D;request) challenge requires a request body. &#x60;useNumberMatchingChallenge&#x60; must be set to &#x60;true&#x60;. &gt; When a number matching challenge is issued for an Okta Verify &#x60;push&#x60; factor enrollment, a &#x60;correctAnswer&#x60; challenge object is returned in the [&#x60;_embedded&#x60;](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/UserFactor/#tag/UserFactor/operation/verifyFactor!c&#x3D;200&amp;path&#x3D;_embedded&amp;t&#x3D;response) object. | [optional] 

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
| **201** | Created |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

