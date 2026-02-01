# Okta.Sdk.Api.UserCredApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ChangePassword**](UserCredApi.md#changepassword) | **POST** /api/v1/users/{userId}/credentials/change_password | Update password
[**ChangeRecoveryQuestion**](UserCredApi.md#changerecoveryquestion) | **POST** /api/v1/users/{userId}/credentials/change_recovery_question | Update recovery question
[**ExpirePassword**](UserCredApi.md#expirepassword) | **POST** /api/v1/users/{id}/lifecycle/expire_password | Expire the password
[**ExpirePasswordWithTempPassword**](UserCredApi.md#expirepasswordwithtemppassword) | **POST** /api/v1/users/{id}/lifecycle/expire_password_with_temp_password | Expire the password with a temporary password
[**ForgotPassword**](UserCredApi.md#forgotpassword) | **POST** /api/v1/users/{userId}/credentials/forgot_password | Start forgot password flow
[**ForgotPasswordSetNewPassword**](UserCredApi.md#forgotpasswordsetnewpassword) | **POST** /api/v1/users/{userId}/credentials/forgot_password_recovery_question | Reset password with recovery question
[**ResetPassword**](UserCredApi.md#resetpassword) | **POST** /api/v1/users/{id}/lifecycle/reset_password | Reset a password


<a name="changepassword"></a>
# **ChangePassword**
> UserCredentials ChangePassword (string userId, ChangePasswordRequest changePasswordRequest, bool? strict = null)

Update password

Updates a user's password by validating the user's current password.  This operation provides an option to delete all the sessions of the specified user. However, if the request is made in the context of a session owned by the specified user, that session isn't cleared.  You can only perform this operation on users in `STAGED`, `ACTIVE`, `PASSWORD_EXPIRED`, or `RECOVERY` status that have a valid [password credential](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/User/#tag/User/operation/createUser!path=credentials/password&t=request).  The user transitions to `ACTIVE` status when successfully invoked in `RECOVERY` status.  > **Note:** The Okta account management policy doesn't support the `/users/{userId}/credentials/change_password` endpoint. See [Configure an Okta account management policy](https://developer.okta.com/docs/guides/okta-account-management-policy/main/).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ChangePasswordExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserCredApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var changePasswordRequest = new ChangePasswordRequest(); // ChangePasswordRequest | 
            var strict = false;  // bool? | If true, validates against the password minimum age policy (optional)  (default to false)

            try
            {
                // Update password
                UserCredentials result = apiInstance.ChangePassword(userId, changePasswordRequest, strict);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserCredApi.ChangePassword: " + e.Message );
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
 **changePasswordRequest** | [**ChangePasswordRequest**](ChangePasswordRequest.md)|  | 
 **strict** | **bool?**| If true, validates against the password minimum age policy | [optional] [default to false]

### Return type

[**UserCredentials**](UserCredentials.md)

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

<a name="changerecoveryquestion"></a>
# **ChangeRecoveryQuestion**
> UserCredentials ChangeRecoveryQuestion (string userId, UserCredentials userCredentials)

Update recovery question

Updates a user's recovery question and answer credential by validating the user's current password. You can only perform this operation on users in `STAGED`, `ACTIVE`, or `RECOVERY` status that have a valid [password credential](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/User/#tag/User/operation/createUser!path=credentials/password&t=request).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ChangeRecoveryQuestionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserCredApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var userCredentials = new UserCredentials(); // UserCredentials | 

            try
            {
                // Update recovery question
                UserCredentials result = apiInstance.ChangeRecoveryQuestion(userId, userCredentials);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserCredApi.ChangeRecoveryQuestion: " + e.Message );
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
 **userCredentials** | [**UserCredentials**](UserCredentials.md)|  | 

### Return type

[**UserCredentials**](UserCredentials.md)

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

<a name="expirepassword"></a>
# **ExpirePassword**
> User ExpirePassword (string id)

Expire the password

Expires the password. This operation transitions the user status to `PASSWORD_EXPIRED` so that the user must change their password the next time that they sign in. <br> If you have integrated Okta with your on-premises Active Directory (AD), then setting a user's password as expired in Okta also expires the password in AD. When the user tries to sign in to Okta, delegated authentication finds the password-expired status in AD, and the user is presented with the password-expired page where they can change their password.  > **Note:** The Okta account management policy doesn't support the `/users/{id}/lifecycle/expire_password` endpoint. See [Configure an Okta account management policy](https://developer.okta.com/docs/guides/okta-account-management-policy/main/).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ExpirePasswordExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserCredApi(config);
            var id = "id_example";  // string | An ID, login, or login shortname (as long as the shortname is unambiguous) of an existing Okta user

            try
            {
                // Expire the password
                User result = apiInstance.ExpirePassword(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserCredApi.ExpirePassword: " + e.Message );
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
 **id** | **string**| An ID, login, or login shortname (as long as the shortname is unambiguous) of an existing Okta user | 

### Return type

[**User**](User.md)

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

<a name="expirepasswordwithtemppassword"></a>
# **ExpirePasswordWithTempPassword**
> TempPassword ExpirePasswordWithTempPassword (string id, bool? revokeSessions = null)

Expire the password with a temporary password

Expires the password and resets the user's password to a temporary password. This operation transitions the user status to `PASSWORD_EXPIRED` so that the user must change their password the next time that they sign in. The user's password is reset to a temporary password that's returned, and then the user's password is expired. If `revokeSessions` is included in the request with a value of `true`, the user's current outstanding sessions are revoked and require re-authentication. <br> If you have integrated Okta with your on-premises Active Directory (AD), then setting a user's password as expired in Okta also expires the password in AD. When the user tries to sign in to Okta, delegated authentication finds the password-expired status in AD, and the user is presented with the password-expired page where they can change their password.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ExpirePasswordWithTempPasswordExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserCredApi(config);
            var id = "id_example";  // string | An ID, login, or login shortname (as long as the shortname is unambiguous) of an existing Okta user
            var revokeSessions = false;  // bool? | Revokes the user's existing sessions if `true` (optional)  (default to false)

            try
            {
                // Expire the password with a temporary password
                TempPassword result = apiInstance.ExpirePasswordWithTempPassword(id, revokeSessions);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserCredApi.ExpirePasswordWithTempPassword: " + e.Message );
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
 **id** | **string**| An ID, login, or login shortname (as long as the shortname is unambiguous) of an existing Okta user | 
 **revokeSessions** | **bool?**| Revokes the user&#39;s existing sessions if &#x60;true&#x60; | [optional] [default to false]

### Return type

[**TempPassword**](TempPassword.md)

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

<a name="forgotpassword"></a>
# **ForgotPassword**
> ForgotPasswordResponse ForgotPassword (string userId, bool? sendEmail = null)

Start forgot password flow

Starts the forgot password flow.  Generates a one-time token (OTT) that you can use to reset a user's password.  The user must validate their security question's answer when visiting the reset link. Perform this operation only on users with an `ACTIVE` status and a valid [recovery question credential](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/User/#tag/User/operation/createUser!path=credentials/recovery_question&t=request).  > **Note:** If you have migrated to Identity Engine, you can allow users to recover passwords with any enrolled MFA authenticator. See [Self-service account recovery](https://help.okta.com/oie/en-us/content/topics/identity-engine/authenticators/configure-sspr.htm?cshid=ext-config-sspr).  If an email address is associated with multiple users, keep in mind the following to ensure a successful password recovery lookup:   * Okta no longer includes deactivated users in the lookup.   * The lookup searches sign-in IDs first, then primary email addresses, and then secondary email addresses.  If `sendEmail` is `false`, returns a link for the user to reset their password. This operation doesn't affect the status of the user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ForgotPasswordExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserCredApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var sendEmail = true;  // bool? | Sends a forgot password email to the user if `true` (optional)  (default to true)

            try
            {
                // Start forgot password flow
                ForgotPasswordResponse result = apiInstance.ForgotPassword(userId, sendEmail);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserCredApi.ForgotPassword: " + e.Message );
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
 **sendEmail** | **bool?**| Sends a forgot password email to the user if &#x60;true&#x60; | [optional] [default to true]

### Return type

[**ForgotPasswordResponse**](ForgotPasswordResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Reset URL |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="forgotpasswordsetnewpassword"></a>
# **ForgotPasswordSetNewPassword**
> UserCredentials ForgotPasswordSetNewPassword (string userId, UserCredentials userCredentials, bool? sendEmail = null)

Reset password with recovery question

Resets the user's password to the specified password if the provided answer to the recovery question is correct. You must include the recovery question answer with the submission.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ForgotPasswordSetNewPasswordExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserCredApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var userCredentials = new UserCredentials(); // UserCredentials | 
            var sendEmail = true;  // bool? |  (optional)  (default to true)

            try
            {
                // Reset password with recovery question
                UserCredentials result = apiInstance.ForgotPasswordSetNewPassword(userId, userCredentials, sendEmail);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserCredApi.ForgotPasswordSetNewPassword: " + e.Message );
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
 **userCredentials** | [**UserCredentials**](UserCredentials.md)|  | 
 **sendEmail** | **bool?**|  | [optional] [default to true]

### Return type

[**UserCredentials**](UserCredentials.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Credentials |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="resetpassword"></a>
# **ResetPassword**
> ResetPasswordToken ResetPassword (string id, bool sendEmail, bool? revokeSessions = null)

Reset a password

Resets a password. Generates a one-time token (OTT) that you can use to reset a user's password. You can automatically email the OTT link to the user or return the OTT to the API caller and distribute using a custom flow.  This operation transitions the user to the `RECOVERY` status. The user is then not able to sign in or initiate a forgot password flow until they complete the reset flow.  This operation provides an option to delete all the user's sessions. However, if the request is made in the context of a session owned by the specified user, that session isn't cleared. > **Note:** You can also use this API to convert a user with the Okta credential provider to use a federated provider. After this conversion, the user can't directly sign in with a password. > To convert a federated user back to an Okta user, use the default API call.  If an email address is associated with multiple users, keep in mind the following to ensure a successful password recovery lookup:   * Okta no longer includes deactivated users in the lookup.   * The lookup searches sign-in IDs first, then primary email addresses, and then secondary email addresses.   If `sendEmail` is `false`, returns a link for the user to reset their password.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ResetPasswordExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserCredApi(config);
            var id = "id_example";  // string | An ID, login, or login shortname (as long as the shortname is unambiguous) of an existing Okta user
            var sendEmail = true;  // bool | 
            var revokeSessions = false;  // bool? | Revokes all user sessions, except for the current session, if set to `true` (optional)  (default to false)

            try
            {
                // Reset a password
                ResetPasswordToken result = apiInstance.ResetPassword(id, sendEmail, revokeSessions);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserCredApi.ResetPassword: " + e.Message );
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
 **id** | **string**| An ID, login, or login shortname (as long as the shortname is unambiguous) of an existing Okta user | 
 **sendEmail** | **bool**|  | 
 **revokeSessions** | **bool?**| Revokes all user sessions, except for the current session, if set to &#x60;true&#x60; | [optional] [default to false]

### Return type

[**ResetPasswordToken**](ResetPasswordToken.md)

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

