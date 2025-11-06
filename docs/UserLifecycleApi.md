# Okta.Sdk.Api.UserLifecycleApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateUser**](UserLifecycleApi.md#activateuser) | **POST** /api/v1/users/{id}/lifecycle/activate | Activate a user
[**DeactivateUser**](UserLifecycleApi.md#deactivateuser) | **POST** /api/v1/users/{id}/lifecycle/deactivate | Deactivate a user
[**ReactivateUser**](UserLifecycleApi.md#reactivateuser) | **POST** /api/v1/users/{id}/lifecycle/reactivate | Reactivate a user
[**ResetFactors**](UserLifecycleApi.md#resetfactors) | **POST** /api/v1/users/{id}/lifecycle/reset_factors | Reset the factors
[**SuspendUser**](UserLifecycleApi.md#suspenduser) | **POST** /api/v1/users/{id}/lifecycle/suspend | Suspend a user
[**UnlockUser**](UserLifecycleApi.md#unlockuser) | **POST** /api/v1/users/{id}/lifecycle/unlock | Unlock a user
[**UnsuspendUser**](UserLifecycleApi.md#unsuspenduser) | **POST** /api/v1/users/{id}/lifecycle/unsuspend | Unsuspend a user


<a name="activateuser"></a>
# **ActivateUser**
> UserActivationToken ActivateUser (string id, bool? sendEmail = null)

Activate a user

Activates a user.  Perform this operation only on users with a `STAGED` or `DEPROVISIONED` status. Activation of a user is an asynchronous operation. * The user has the `transitioningToStatus` property with an `ACTIVE` value during activation. This indicates that the user hasn't completed the asynchronous operation. * The user has an `ACTIVE` status when the activation process completes.  Users who don't have a password must complete the welcome flow by visiting the activation link to complete the transition to `ACTIVE` status.  > **Note:** If you want to send a branded user activation email, change the subdomain of your request to the custom domain that's associated with the brand. > For example, change `subdomain.okta.com` to `custom.domain.one`. See [Multibrand and custom domains](https://developer.okta.com/docs/concepts/brands/#multibrand-and-custom-domains).  > **Note:** If you have optional password enabled, visiting the activation link is optional for users who aren't required to enroll a password. > See [Create user with optional password](/openapi/okta-management/management/tag/User/#create-user-with-optional-password).  > **Legal disclaimer** > After a user is added to the Okta directory, they receive an activation email. As part of signing up for this service, > you agreed not to use Okta's service/product to spam and/or send unsolicited messages. > Please refrain from adding unrelated accounts to the directory as Okta is not responsible for, and disclaims any and all > liability associated with, the activation email's content. You, and you alone, bear responsibility for the emails sent to any recipients.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserLifecycleApi(config);
            var id = "id_example";  // string | An ID, login, or login shortname (as long as the shortname is unambiguous) of an existing Okta user
            var sendEmail = true;  // bool? | Sends an activation email to the user if `true` (optional)  (default to true)

            try
            {
                // Activate a user
                UserActivationToken result = apiInstance.ActivateUser(id, sendEmail);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserLifecycleApi.ActivateUser: " + e.Message );
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
 **sendEmail** | **bool?**| Sends an activation email to the user if &#x60;true&#x60; | [optional] [default to true]

### Return type

[**UserActivationToken**](UserActivationToken.md)

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

<a name="deactivateuser"></a>
# **DeactivateUser**
> void DeactivateUser (string id, bool? sendEmail = null, PreferHeader? prefer = null)

Deactivate a user

Deactivates a user.  Perform this operation only on users that do not have a `DEPROVISIONED` status. * The user's `transitioningToStatus` property is `DEPROVISIONED` during deactivation to indicate that the user hasn't completed the asynchronous operation. * The user's status is `DEPROVISIONED` when the deactivation process is complete.  > **Important:** Deactivating a user is a **destructive** operation. The user is deprovisioned from all assigned apps, which might destroy their data such as email or files. **This action cannot be recovered!**  You can also perform user deactivation asynchronously. To invoke asynchronous user deactivation, pass an HTTP header `Prefer: respond-async` with the request.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserLifecycleApi(config);
            var id = "id_example";  // string | An ID, login, or login shortname (as long as the shortname is unambiguous) of an existing Okta user
            var sendEmail = false;  // bool? | Sends a deactivation email to the admin if `true` (optional)  (default to false)
            var prefer = (PreferHeader) "respond-async";  // PreferHeader? | Request asynchronous processing (optional) 

            try
            {
                // Deactivate a user
                apiInstance.DeactivateUser(id, sendEmail, prefer);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserLifecycleApi.DeactivateUser: " + e.Message );
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
 **sendEmail** | **bool?**| Sends a deactivation email to the admin if &#x60;true&#x60; | [optional] [default to false]
 **prefer** | **PreferHeader?**| Request asynchronous processing | [optional] 

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
| **200** | OK |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="reactivateuser"></a>
# **ReactivateUser**
> UserActivationToken ReactivateUser (string id, bool? sendEmail = null)

Reactivate a user

Reactivates a user.  Perform this operation only on users with a `PROVISIONED` or `RECOVERY` [status](/openapi/okta-management/management/tag/User/#tag/User/operation/listUsers!c=200&path=status&t=response). This operation restarts the activation workflow if for some reason the user activation wasn't completed when using the `activationToken` from [Activate User](/openapi/okta-management/management/tag/UserLifecycle/#tag/UserLifecycle/operation/activateUser).  Users that don't have a password must complete the flow by completing the [Reset password](/openapi/okta-management/management/tag/UserCred/#tag/UserCred/operation/resetPassword) flow and MFA enrollment steps to transition the user to `ACTIVE` status.  If `sendEmail` is `false`, returns an activation link for the user to set up their account. The activation token can be used to create a custom activation link.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReactivateUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserLifecycleApi(config);
            var id = "id_example";  // string | An ID, login, or login shortname (as long as the shortname is unambiguous) of an existing Okta user
            var sendEmail = false;  // bool? | Sends an activation email to the user if `true` (optional)  (default to false)

            try
            {
                // Reactivate a user
                UserActivationToken result = apiInstance.ReactivateUser(id, sendEmail);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserLifecycleApi.ReactivateUser: " + e.Message );
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
 **sendEmail** | **bool?**| Sends an activation email to the user if &#x60;true&#x60; | [optional] [default to false]

### Return type

[**UserActivationToken**](UserActivationToken.md)

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

<a name="resetfactors"></a>
# **ResetFactors**
> void ResetFactors (string id)

Reset the factors

Resets all factors for the specified user. All MFA factor enrollments return to the unenrolled state. The user's status remains `ACTIVE`. This link is present only if the user is currently enrolled in one or more MFA factors.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ResetFactorsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserLifecycleApi(config);
            var id = "id_example";  // string | An ID, login, or login shortname (as long as the shortname is unambiguous) of an existing Okta user

            try
            {
                // Reset the factors
                apiInstance.ResetFactors(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserLifecycleApi.ResetFactors: " + e.Message );
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

void (empty response body)

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

<a name="suspenduser"></a>
# **SuspendUser**
> void SuspendUser (string id)

Suspend a user

Suspends a user. Perform this operation only on users with an `ACTIVE` status. The user has a `SUSPENDED` status when the process completes.  Suspended users can't sign in to Okta. They can only be unsuspended or deactivated. Their group and app assignments are retained.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class SuspendUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserLifecycleApi(config);
            var id = "id_example";  // string | An ID, login, or login shortname (as long as the shortname is unambiguous) of an existing Okta user

            try
            {
                // Suspend a user
                apiInstance.SuspendUser(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserLifecycleApi.SuspendUser: " + e.Message );
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

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
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

<a name="unlockuser"></a>
# **UnlockUser**
> void UnlockUser (string id)

Unlock a user

Unlocks a user with a `LOCKED_OUT` status or unlocks a user with an `ACTIVE` status that's blocked from unknown devices. Unlocked users have an `ACTIVE` status and can sign in with their current password. > **Note:** This operation works with Okta-sourced users. It doesn't support directory-sourced accounts such as Active Directory.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnlockUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserLifecycleApi(config);
            var id = "id_example";  // string | An ID, login, or login shortname (as long as the shortname is unambiguous) of an existing Okta user

            try
            {
                // Unlock a user
                apiInstance.UnlockUser(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserLifecycleApi.UnlockUser: " + e.Message );
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

void (empty response body)

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

<a name="unsuspenduser"></a>
# **UnsuspendUser**
> void UnsuspendUser (string id)

Unsuspend a user

Unsuspends a user and returns them to the `ACTIVE` state. This operation can only be performed on users that have a `SUSPENDED` status.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnsuspendUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserLifecycleApi(config);
            var id = "id_example";  // string | An ID, login, or login shortname (as long as the shortname is unambiguous) of an existing Okta user

            try
            {
                // Unsuspend a user
                apiInstance.UnsuspendUser(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserLifecycleApi.UnsuspendUser: " + e.Message );
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

void (empty response body)

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

