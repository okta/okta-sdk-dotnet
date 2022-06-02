# Okta.Sdk.Api.UserApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateUser**](UserApi.md#activateuser) | **POST** /api/v1/users/{userId}/lifecycle/activate | Activate User
[**AddAllAppsAsTargetToRole**](UserApi.md#addallappsastargettorole) | **PUT** /api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps | Add All Apps as Target to Role
[**AddApplicationTargetToAdminRoleForUser**](UserApi.md#addapplicationtargettoadminroleforuser) | **PUT** /api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps/{appName} | Add Application Target to Admin Role for User
[**AddApplicationTargetToAppAdminRoleForUser**](UserApi.md#addapplicationtargettoappadminroleforuser) | **PUT** /api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps/{appName}/{applicationId} | Add App Instance Target to App Administrator Role given to a User
[**AddGroupTargetToRole**](UserApi.md#addgrouptargettorole) | **PUT** /api/v1/users/{userId}/roles/{roleId}/targets/groups/{groupId} | Add Group Target to Role
[**AssignRoleToUser**](UserApi.md#assignroletouser) | **POST** /api/v1/users/{userId}/roles | Assign Role to User
[**ChangePassword**](UserApi.md#changepassword) | **POST** /api/v1/users/{userId}/credentials/change_password | Change Password
[**ChangeRecoveryQuestion**](UserApi.md#changerecoveryquestion) | **POST** /api/v1/users/{userId}/credentials/change_recovery_question | Change Recovery Question
[**ClearUserSessions**](UserApi.md#clearusersessions) | **DELETE** /api/v1/users/{userId}/sessions | Clear User Sessions
[**CreateUser**](UserApi.md#createuser) | **POST** /api/v1/users | Create User
[**DeactivateOrDeleteUser**](UserApi.md#deactivateordeleteuser) | **DELETE** /api/v1/users/{userId} | Delete User
[**DeactivateUser**](UserApi.md#deactivateuser) | **POST** /api/v1/users/{userId}/lifecycle/deactivate | Deactivate User
[**ExpirePassword**](UserApi.md#expirepassword) | **POST** /api/v1/users/{userId}/lifecycle/expire_password | Expire Password
[**ExpirePasswordAndGetTemporaryPassword**](UserApi.md#expirepasswordandgettemporarypassword) | **POST** /api/v1/users/{userId}/lifecycle/expire_password_with_temp_password | Expire Password and Set Temporary Password
[**ForgotPassword**](UserApi.md#forgotpassword) | **POST** /api/v1/users/{userId}/credentials/forgot_password | Initiate Forgot Password
[**ForgotPasswordSetNewPassword**](UserApi.md#forgotpasswordsetnewpassword) | **POST** /api/v1/users/{userId}/credentials/forgot_password_recovery_question | Reset Password with Recovery Question
[**GetLinkedObjectsForUser**](UserApi.md#getlinkedobjectsforuser) | **GET** /api/v1/users/{userId}/linkedObjects/{relationshipName} | Get Linked Objects for User
[**GetRefreshTokenForUserAndClient**](UserApi.md#getrefreshtokenforuserandclient) | **GET** /api/v1/users/{userId}/clients/{clientId}/tokens/{tokenId} | Get Refresh Token for User and Client
[**GetUser**](UserApi.md#getuser) | **GET** /api/v1/users/{userId} | Get User
[**GetUserGrant**](UserApi.md#getusergrant) | **GET** /api/v1/users/{userId}/grants/{grantId} | Get User Grant
[**GetUserRole**](UserApi.md#getuserrole) | **GET** /api/v1/users/{userId}/roles/{roleId} | Get User Role
[**ListAppLinks**](UserApi.md#listapplinks) | **GET** /api/v1/users/{userId}/appLinks | Get Assigned App Links
[**ListApplicationTargetsForApplicationAdministratorRoleForUser**](UserApi.md#listapplicationtargetsforapplicationadministratorroleforuser) | **GET** /api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps | List Application Targets for Application Administrator Role for User
[**ListAssignedRolesForUser**](UserApi.md#listassignedrolesforuser) | **GET** /api/v1/users/{userId}/roles | List Assigned Roles for User
[**ListGrantsForUserAndClient**](UserApi.md#listgrantsforuserandclient) | **GET** /api/v1/users/{userId}/clients/{clientId}/grants | List Grants for User and Client
[**ListGroupTargetsForRole**](UserApi.md#listgrouptargetsforrole) | **GET** /api/v1/users/{userId}/roles/{roleId}/targets/groups | List Group Targets for Role
[**ListRefreshTokensForUserAndClient**](UserApi.md#listrefreshtokensforuserandclient) | **GET** /api/v1/users/{userId}/clients/{clientId}/tokens | List Refresh Tokens for User and Client
[**ListUserClients**](UserApi.md#listuserclients) | **GET** /api/v1/users/{userId}/clients | List User Clients
[**ListUserGrants**](UserApi.md#listusergrants) | **GET** /api/v1/users/{userId}/grants | List User Grants
[**ListUserGroups**](UserApi.md#listusergroups) | **GET** /api/v1/users/{userId}/groups | Get Member Groups
[**ListUserIdentityProviders**](UserApi.md#listuseridentityproviders) | **GET** /api/v1/users/{userId}/idps | Listing IdPs associated with a user
[**ListUsers**](UserApi.md#listusers) | **GET** /api/v1/users | List Users
[**PartialUpdateUser**](UserApi.md#partialupdateuser) | **POST** /api/v1/users/{userId} | Partial Update User
[**ReactivateUser**](UserApi.md#reactivateuser) | **POST** /api/v1/users/{userId}/lifecycle/reactivate | Reactivate User
[**RemoveApplicationTargetFromAdministratorRoleForUser**](UserApi.md#removeapplicationtargetfromadministratorroleforuser) | **DELETE** /api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps/{appName}/{applicationId} | Remove App Instance Target to App Administrator Role given to a User
[**RemoveApplicationTargetFromApplicationAdministratorRoleForUser**](UserApi.md#removeapplicationtargetfromapplicationadministratorroleforuser) | **DELETE** /api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps/{appName} | Remove Application Target from Application Administrator Role for User
[**RemoveGroupTargetFromRole**](UserApi.md#removegrouptargetfromrole) | **DELETE** /api/v1/users/{userId}/roles/{roleId}/targets/groups/{groupId} | Remove Group Target from Role
[**RemoveLinkedObjectForUser**](UserApi.md#removelinkedobjectforuser) | **DELETE** /api/v1/users/{userId}/linkedObjects/{relationshipName} | Remove Linked Object for User
[**RemoveRoleFromUser**](UserApi.md#removerolefromuser) | **DELETE** /api/v1/users/{userId}/roles/{roleId} | Remove Role from User
[**ResetFactors**](UserApi.md#resetfactors) | **POST** /api/v1/users/{userId}/lifecycle/reset_factors | Reset Factors
[**ResetPassword**](UserApi.md#resetpassword) | **POST** /api/v1/users/{userId}/lifecycle/reset_password | Reset Password
[**RevokeGrantsForUserAndClient**](UserApi.md#revokegrantsforuserandclient) | **DELETE** /api/v1/users/{userId}/clients/{clientId}/grants | Revoke Grants for User and Client
[**RevokeTokenForUserAndClient**](UserApi.md#revoketokenforuserandclient) | **DELETE** /api/v1/users/{userId}/clients/{clientId}/tokens/{tokenId} | Revoke Token for User and Client
[**RevokeTokensForUserAndClient**](UserApi.md#revoketokensforuserandclient) | **DELETE** /api/v1/users/{userId}/clients/{clientId}/tokens | Revoke Tokens for User and Client
[**RevokeUserGrant**](UserApi.md#revokeusergrant) | **DELETE** /api/v1/users/{userId}/grants/{grantId} | Revoke User Grant
[**RevokeUserGrants**](UserApi.md#revokeusergrants) | **DELETE** /api/v1/users/{userId}/grants | Revoke User Grants
[**SetLinkedObjectForUser**](UserApi.md#setlinkedobjectforuser) | **PUT** /api/v1/users/{associatedUserId}/linkedObjects/{primaryRelationshipName}/{primaryUserId} | Set Linked Object for User
[**SuspendUser**](UserApi.md#suspenduser) | **POST** /api/v1/users/{userId}/lifecycle/suspend | Suspend User
[**UnlockUser**](UserApi.md#unlockuser) | **POST** /api/v1/users/{userId}/lifecycle/unlock | Unlock User
[**UnsuspendUser**](UserApi.md#unsuspenduser) | **POST** /api/v1/users/{userId}/lifecycle/unsuspend | Unsuspend User
[**UpdateUser**](UserApi.md#updateuser) | **PUT** /api/v1/users/{userId} | Update User


<a name="activateuser"></a>
# **ActivateUser**
> UserActivationToken ActivateUser (string userId, bool sendEmail)

Activate User

Activates a user.  This operation can only be performed on users with a `STAGED` status.  Activation of a user is an asynchronous operation. The user will have the `transitioningToStatus` property with a value of `ACTIVE` during activation to indicate that the user hasn't completed the asynchronous operation.  The user will have a status of `ACTIVE` when the activation process is complete.

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var sendEmail = true;  // bool | Sends an activation email to the user if true (default to true)

            try
            {
                // Activate User
                UserActivationToken result = apiInstance.ActivateUser(userId, sendEmail);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ActivateUser: " + e.Message );
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
 **sendEmail** | **bool**| Sends an activation email to the user if true | [default to true]

### Return type

[**UserActivationToken**](UserActivationToken.md)

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

<a name="addallappsastargettorole"></a>
# **AddAllAppsAsTargetToRole**
> void AddAllAppsAsTargetToRole (string userId, string roleId)

Add All Apps as Target to Role

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddAllAppsAsTargetToRoleExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 

            try
            {
                // Add All Apps as Target to Role
                apiInstance.AddAllAppsAsTargetToRole(userId, roleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.AddAllAppsAsTargetToRole: " + e.Message );
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
 **roleId** | **string**|  | 

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
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="addapplicationtargettoadminroleforuser"></a>
# **AddApplicationTargetToAdminRoleForUser**
> void AddApplicationTargetToAdminRoleForUser (string userId, string roleId, string appName)

Add Application Target to Admin Role for User

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddApplicationTargetToAdminRoleForUserExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 

            try
            {
                // Add Application Target to Admin Role for User
                apiInstance.AddApplicationTargetToAdminRoleForUser(userId, roleId, appName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.AddApplicationTargetToAdminRoleForUser: " + e.Message );
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
 **roleId** | **string**|  | 
 **appName** | **string**|  | 

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
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="addapplicationtargettoappadminroleforuser"></a>
# **AddApplicationTargetToAppAdminRoleForUser**
> void AddApplicationTargetToAppAdminRoleForUser (string userId, string roleId, string appName, string applicationId)

Add App Instance Target to App Administrator Role given to a User

Add App Instance Target to App Administrator Role given to a User

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddApplicationTargetToAppAdminRoleForUserExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 
            var applicationId = "applicationId_example";  // string | 

            try
            {
                // Add App Instance Target to App Administrator Role given to a User
                apiInstance.AddApplicationTargetToAppAdminRoleForUser(userId, roleId, appName, applicationId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.AddApplicationTargetToAppAdminRoleForUser: " + e.Message );
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
 **roleId** | **string**|  | 
 **appName** | **string**|  | 
 **applicationId** | **string**|  | 

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

<a name="addgrouptargettorole"></a>
# **AddGroupTargetToRole**
> void AddGroupTargetToRole (string userId, string roleId, string groupId)

Add Group Target to Role

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddGroupTargetToRoleExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var groupId = "groupId_example";  // string | 

            try
            {
                // Add Group Target to Role
                apiInstance.AddGroupTargetToRole(userId, roleId, groupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.AddGroupTargetToRole: " + e.Message );
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
 **roleId** | **string**|  | 
 **groupId** | **string**|  | 

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
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="assignroletouser"></a>
# **AssignRoleToUser**
> Role AssignRoleToUser (string userId, AssignRoleRequest assignRoleRequest, bool? disableNotifications = null)

Assign Role to User

Assigns a role to a user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignRoleToUserExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var assignRoleRequest = new AssignRoleRequest(); // AssignRoleRequest | 
            var disableNotifications = true;  // bool? |  (optional) 

            try
            {
                // Assign Role to User
                Role result = apiInstance.AssignRoleToUser(userId, assignRoleRequest, disableNotifications);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.AssignRoleToUser: " + e.Message );
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
 **assignRoleRequest** | [**AssignRoleRequest**](AssignRoleRequest.md)|  | 
 **disableNotifications** | **bool?**|  | [optional] 

### Return type

[**Role**](Role.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="changepassword"></a>
# **ChangePassword**
> UserCredentials ChangePassword (string userId, ChangePasswordRequest changePasswordRequest, bool? strict = null)

Change Password

Changes a user's password by validating the user's current password. This operation can only be performed on users in `STAGED`, `ACTIVE`, `PASSWORD_EXPIRED`, or `RECOVERY` status that have a valid password credential

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var changePasswordRequest = new ChangePasswordRequest(); // ChangePasswordRequest | 
            var strict = true;  // bool? |  (optional) 

            try
            {
                // Change Password
                UserCredentials result = apiInstance.ChangePassword(userId, changePasswordRequest, strict);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ChangePassword: " + e.Message );
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
 **changePasswordRequest** | [**ChangePasswordRequest**](ChangePasswordRequest.md)|  | 
 **strict** | **bool?**|  | [optional] 

### Return type

[**UserCredentials**](UserCredentials.md)

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

<a name="changerecoveryquestion"></a>
# **ChangeRecoveryQuestion**
> UserCredentials ChangeRecoveryQuestion (string userId, UserCredentials userCredentials)

Change Recovery Question

Changes a user's recovery question & answer credential by validating the user's current password.  This operation can only be performed on users in **STAGED**, **ACTIVE** or **RECOVERY** `status` that have a valid password credential

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var userCredentials = new UserCredentials(); // UserCredentials | 

            try
            {
                // Change Recovery Question
                UserCredentials result = apiInstance.ChangeRecoveryQuestion(userId, userCredentials);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ChangeRecoveryQuestion: " + e.Message );
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
 **userCredentials** | [**UserCredentials**](UserCredentials.md)|  | 

### Return type

[**UserCredentials**](UserCredentials.md)

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

<a name="clearusersessions"></a>
# **ClearUserSessions**
> void ClearUserSessions (string userId, bool? oauthTokens = null)

Clear User Sessions

Removes all active identity provider sessions. This forces the user to authenticate on the next operation. Optionally revokes OpenID Connect and OAuth refresh and access tokens issued to the user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ClearUserSessionsExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var oauthTokens = false;  // bool? | Revoke issued OpenID Connect and OAuth refresh and access tokens (optional)  (default to false)

            try
            {
                // Clear User Sessions
                apiInstance.ClearUserSessions(userId, oauthTokens);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ClearUserSessions: " + e.Message );
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
 **oauthTokens** | **bool?**| Revoke issued OpenID Connect and OAuth refresh and access tokens | [optional] [default to false]

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

<a name="createuser"></a>
# **CreateUser**
> User CreateUser (CreateUserRequest body, bool? activate = null, bool? provider = null, UserNextLogin? nextLogin = null)

Create User

Creates a new user in your Okta organization with or without credentials.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateUserExample
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

            var apiInstance = new UserApi(config);
            var body = new CreateUserRequest(); // CreateUserRequest | 
            var activate = true;  // bool? | Executes activation lifecycle operation when creating the user (optional)  (default to true)
            var provider = false;  // bool? | Indicates whether to create a user with a specified authentication provider (optional)  (default to false)
            var nextLogin = (UserNextLogin) "changePassword";  // UserNextLogin? | With activate=true, set nextLogin to \"changePassword\" to have the password be EXPIRED, so user must change it the next time they log in. (optional) 

            try
            {
                // Create User
                User result = apiInstance.CreateUser(body, activate, provider, nextLogin);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.CreateUser: " + e.Message );
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
 **body** | [**CreateUserRequest**](CreateUserRequest.md)|  | 
 **activate** | **bool?**| Executes activation lifecycle operation when creating the user | [optional] [default to true]
 **provider** | **bool?**| Indicates whether to create a user with a specified authentication provider | [optional] [default to false]
 **nextLogin** | **UserNextLogin?**| With activate&#x3D;true, set nextLogin to \&quot;changePassword\&quot; to have the password be EXPIRED, so user must change it the next time they log in. | [optional] 

### Return type

[**User**](User.md)

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

<a name="deactivateordeleteuser"></a>
# **DeactivateOrDeleteUser**
> void DeactivateOrDeleteUser (string userId, bool? sendEmail = null)

Delete User

Deletes a user permanently.  This operation can only be performed on users that have a `DEPROVISIONED` status.  **This action cannot be recovered!**

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateOrDeleteUserExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var sendEmail = false;  // bool? |  (optional)  (default to false)

            try
            {
                // Delete User
                apiInstance.DeactivateOrDeleteUser(userId, sendEmail);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.DeactivateOrDeleteUser: " + e.Message );
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
 **sendEmail** | **bool?**|  | [optional] [default to false]

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
| **202** | ACCEPTED |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivateuser"></a>
# **DeactivateUser**
> void DeactivateUser (string userId, bool? sendEmail = null)

Deactivate User

Deactivates a user. This operation can only be performed on users that do not have a `DEPROVISIONED` status. While the asynchronous operation (triggered by HTTP header `Prefer: respond-async`) is proceeding the user's `transitioningToStatus` property is `DEPROVISIONED`. The user's status is `DEPROVISIONED` when the deactivation process is complete.

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var sendEmail = false;  // bool? |  (optional)  (default to false)

            try
            {
                // Deactivate User
                apiInstance.DeactivateUser(userId, sendEmail);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.DeactivateUser: " + e.Message );
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
 **sendEmail** | **bool?**|  | [optional] [default to false]

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
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="expirepassword"></a>
# **ExpirePassword**
> User ExpirePassword (string userId)

Expire Password

This operation transitions the user to the status of `PASSWORD_EXPIRED` so that the user is required to change their password at their next login.

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // Expire Password
                User result = apiInstance.ExpirePassword(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ExpirePassword: " + e.Message );
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

[**User**](User.md)

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

<a name="expirepasswordandgettemporarypassword"></a>
# **ExpirePasswordAndGetTemporaryPassword**
> TempPassword ExpirePasswordAndGetTemporaryPassword (string userId)

Expire Password and Set Temporary Password

This operation transitions the user to the status of `PASSWORD_EXPIRED` so that the user is required to change their password at their next login, and also sets the user's password to a temporary password returned in the response.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ExpirePasswordAndGetTemporaryPasswordExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // Expire Password and Set Temporary Password
                TempPassword result = apiInstance.ExpirePasswordAndGetTemporaryPassword(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ExpirePasswordAndGetTemporaryPassword: " + e.Message );
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

[**TempPassword**](TempPassword.md)

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

<a name="forgotpassword"></a>
# **ForgotPassword**
> ForgotPasswordResponse ForgotPassword (string userId, bool? sendEmail = null)

Initiate Forgot Password

Initiate forgot password flow. Generates a one-time token (OTT) that can be used to reset a user's password.

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var sendEmail = true;  // bool? |  (optional)  (default to true)

            try
            {
                // Initiate Forgot Password
                ForgotPasswordResponse result = apiInstance.ForgotPassword(userId, sendEmail);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ForgotPassword: " + e.Message );
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
 **sendEmail** | **bool?**|  | [optional] [default to true]

### Return type

[**ForgotPasswordResponse**](ForgotPasswordResponse.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Reset url |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="forgotpasswordsetnewpassword"></a>
# **ForgotPasswordSetNewPassword**
> UserCredentials ForgotPasswordSetNewPassword (string userId, UserCredentials userCredentials, bool? sendEmail = null)

Reset Password with Recovery Question

Resets the user's password to the specified password if the provided answer to the recovery question is correct.

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var userCredentials = new UserCredentials(); // UserCredentials | 
            var sendEmail = true;  // bool? |  (optional)  (default to true)

            try
            {
                // Reset Password with Recovery Question
                UserCredentials result = apiInstance.ForgotPasswordSetNewPassword(userId, userCredentials, sendEmail);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ForgotPasswordSetNewPassword: " + e.Message );
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
 **userCredentials** | [**UserCredentials**](UserCredentials.md)|  | 
 **sendEmail** | **bool?**|  | [optional] [default to true]

### Return type

[**UserCredentials**](UserCredentials.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Credentials |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getlinkedobjectsforuser"></a>
# **GetLinkedObjectsForUser**
> List&lt;Object&gt; GetLinkedObjectsForUser (string userId, string relationshipName, string after = null, int? limit = null)

Get Linked Objects for User

Get linked objects for a user, relationshipName can be a primary or associated relationship name

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetLinkedObjectsForUserExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var relationshipName = "relationshipName_example";  // string | 
            var after = "after_example";  // string |  (optional) 
            var limit = -1;  // int? |  (optional)  (default to -1)

            try
            {
                // Get Linked Objects for User
                List<Object> result = apiInstance.GetLinkedObjectsForUser(userId, relationshipName, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.GetLinkedObjectsForUser: " + e.Message );
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
 **relationshipName** | **string**|  | 
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to -1]

### Return type

**List<Object>**

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

<a name="getrefreshtokenforuserandclient"></a>
# **GetRefreshTokenForUserAndClient**
> OAuth2RefreshToken GetRefreshTokenForUserAndClient (string userId, string clientId, string tokenId, string expand = null, int? limit = null, string after = null)

Get Refresh Token for User and Client

Gets a refresh token issued for the specified User and Client.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRefreshTokenForUserAndClientExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var clientId = "clientId_example";  // string | 
            var tokenId = "tokenId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)
            var after = "after_example";  // string |  (optional) 

            try
            {
                // Get Refresh Token for User and Client
                OAuth2RefreshToken result = apiInstance.GetRefreshTokenForUserAndClient(userId, clientId, tokenId, expand, limit, after);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.GetRefreshTokenForUserAndClient: " + e.Message );
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
 **clientId** | **string**|  | 
 **tokenId** | **string**|  | 
 **expand** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to 20]
 **after** | **string**|  | [optional] 

### Return type

[**OAuth2RefreshToken**](OAuth2RefreshToken.md)

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

<a name="getuser"></a>
# **GetUser**
> User GetUser (string userId)

Get User

Fetches a user from your Okta organization.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetUserExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // Get User
                User result = apiInstance.GetUser(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.GetUser: " + e.Message );
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

[**User**](User.md)

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

<a name="getusergrant"></a>
# **GetUserGrant**
> OAuth2ScopeConsentGrant GetUserGrant (string userId, string grantId, string expand = null)

Get User Grant

Gets a grant for the specified user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetUserGrantExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var grantId = "grantId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // Get User Grant
                OAuth2ScopeConsentGrant result = apiInstance.GetUserGrant(userId, grantId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.GetUserGrant: " + e.Message );
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
 **grantId** | **string**|  | 
 **expand** | **string**|  | [optional] 

### Return type

[**OAuth2ScopeConsentGrant**](OAuth2ScopeConsentGrant.md)

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

<a name="getuserrole"></a>
# **GetUserRole**
> Role GetUserRole (string userId, string roleId)

Get User Role

Gets role that is assigned to user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetUserRoleExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 

            try
            {
                // Get User Role
                Role result = apiInstance.GetUserRole(userId, roleId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.GetUserRole: " + e.Message );
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
 **roleId** | **string**|  | 

### Return type

[**Role**](Role.md)

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

<a name="listapplinks"></a>
# **ListAppLinks**
> List&lt;AppLink&gt; ListAppLinks (string userId)

Get Assigned App Links

Fetches appLinks for all direct or indirect (via group membership) assigned applications.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAppLinksExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // Get Assigned App Links
                List<AppLink> result = apiInstance.ListAppLinks(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ListAppLinks: " + e.Message );
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

[**List&lt;AppLink&gt;**](AppLink.md)

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

<a name="listapplicationtargetsforapplicationadministratorroleforuser"></a>
# **ListApplicationTargetsForApplicationAdministratorRoleForUser**
> List&lt;CatalogApplication&gt; ListApplicationTargetsForApplicationAdministratorRoleForUser (string userId, string roleId, string after = null, int? limit = null)

List Application Targets for Application Administrator Role for User

Lists all App targets for an `APP_ADMIN` Role assigned to a User. This methods return list may include full Applications or Instances. The response for an instance will have an `ID` value, while Application will not have an ID.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListApplicationTargetsForApplicationAdministratorRoleForUserExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var after = "after_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // List Application Targets for Application Administrator Role for User
                List<CatalogApplication> result = apiInstance.ListApplicationTargetsForApplicationAdministratorRoleForUser(userId, roleId, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ListApplicationTargetsForApplicationAdministratorRoleForUser: " + e.Message );
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
 **roleId** | **string**|  | 
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to 20]

### Return type

[**List&lt;CatalogApplication&gt;**](CatalogApplication.md)

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

<a name="listassignedrolesforuser"></a>
# **ListAssignedRolesForUser**
> List&lt;Role&gt; ListAssignedRolesForUser (string userId, string expand = null)

List Assigned Roles for User

Lists all roles assigned to a user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAssignedRolesForUserExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // List Assigned Roles for User
                List<Role> result = apiInstance.ListAssignedRolesForUser(userId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ListAssignedRolesForUser: " + e.Message );
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
 **expand** | **string**|  | [optional] 

### Return type

[**List&lt;Role&gt;**](Role.md)

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

<a name="listgrantsforuserandclient"></a>
# **ListGrantsForUserAndClient**
> List&lt;OAuth2ScopeConsentGrant&gt; ListGrantsForUserAndClient (string userId, string clientId, string expand = null, string after = null, int? limit = null)

List Grants for User and Client

Lists all grants for a specified user and client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGrantsForUserAndClientExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var clientId = "clientId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 
            var after = "after_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // List Grants for User and Client
                List<OAuth2ScopeConsentGrant> result = apiInstance.ListGrantsForUserAndClient(userId, clientId, expand, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ListGrantsForUserAndClient: " + e.Message );
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
 **clientId** | **string**|  | 
 **expand** | **string**|  | [optional] 
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to 20]

### Return type

[**List&lt;OAuth2ScopeConsentGrant&gt;**](OAuth2ScopeConsentGrant.md)

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

<a name="listgrouptargetsforrole"></a>
# **ListGroupTargetsForRole**
> List&lt;Group&gt; ListGroupTargetsForRole (string userId, string roleId, string after = null, int? limit = null)

List Group Targets for Role

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGroupTargetsForRoleExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var after = "after_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // List Group Targets for Role
                List<Group> result = apiInstance.ListGroupTargetsForRole(userId, roleId, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ListGroupTargetsForRole: " + e.Message );
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
 **roleId** | **string**|  | 
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to 20]

### Return type

[**List&lt;Group&gt;**](Group.md)

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

<a name="listrefreshtokensforuserandclient"></a>
# **ListRefreshTokensForUserAndClient**
> List&lt;OAuth2RefreshToken&gt; ListRefreshTokensForUserAndClient (string userId, string clientId, string expand = null, string after = null, int? limit = null)

List Refresh Tokens for User and Client

Lists all refresh tokens issued for the specified User and Client.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListRefreshTokensForUserAndClientExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var clientId = "clientId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 
            var after = "after_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // List Refresh Tokens for User and Client
                List<OAuth2RefreshToken> result = apiInstance.ListRefreshTokensForUserAndClient(userId, clientId, expand, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ListRefreshTokensForUserAndClient: " + e.Message );
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
 **clientId** | **string**|  | 
 **expand** | **string**|  | [optional] 
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to 20]

### Return type

[**List&lt;OAuth2RefreshToken&gt;**](OAuth2RefreshToken.md)

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

<a name="listuserclients"></a>
# **ListUserClients**
> List&lt;OAuth2Client&gt; ListUserClients (string userId)

List User Clients

Lists all client resources for which the specified user has grants or tokens.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListUserClientsExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // List User Clients
                List<OAuth2Client> result = apiInstance.ListUserClients(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ListUserClients: " + e.Message );
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

[**List&lt;OAuth2Client&gt;**](OAuth2Client.md)

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

<a name="listusergrants"></a>
# **ListUserGrants**
> List&lt;OAuth2ScopeConsentGrant&gt; ListUserGrants (string userId, string scopeId = null, string expand = null, string after = null, int? limit = null)

List User Grants

Lists all grants for the specified user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListUserGrantsExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var scopeId = "scopeId_example";  // string |  (optional) 
            var expand = "expand_example";  // string |  (optional) 
            var after = "after_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // List User Grants
                List<OAuth2ScopeConsentGrant> result = apiInstance.ListUserGrants(userId, scopeId, expand, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ListUserGrants: " + e.Message );
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
 **scopeId** | **string**|  | [optional] 
 **expand** | **string**|  | [optional] 
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to 20]

### Return type

[**List&lt;OAuth2ScopeConsentGrant&gt;**](OAuth2ScopeConsentGrant.md)

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

<a name="listusergroups"></a>
# **ListUserGroups**
> List&lt;Group&gt; ListUserGroups (string userId)

Get Member Groups

Fetches the groups of which the user is a member.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListUserGroupsExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // Get Member Groups
                List<Group> result = apiInstance.ListUserGroups(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ListUserGroups: " + e.Message );
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

[**List&lt;Group&gt;**](Group.md)

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

<a name="listuseridentityproviders"></a>
# **ListUserIdentityProviders**
> List&lt;IdentityProvider&gt; ListUserIdentityProviders (string userId)

Listing IdPs associated with a user

Lists the IdPs associated with the user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListUserIdentityProvidersExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // Listing IdPs associated with a user
                List<IdentityProvider> result = apiInstance.ListUserIdentityProviders(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ListUserIdentityProviders: " + e.Message );
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

[**List&lt;IdentityProvider&gt;**](IdentityProvider.md)

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

<a name="listusers"></a>
# **ListUsers**
> List&lt;User&gt; ListUsers (string q = null, string after = null, int? limit = null, string filter = null, string search = null, string sortBy = null, string sortOrder = null)

List Users

Lists users in your organization with pagination in most cases.  A subset of users can be returned that match a supported filter expression or search criteria.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListUsersExample
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

            var apiInstance = new UserApi(config);
            var q = "q_example";  // string | Finds a user that matches firstName, lastName, and email properties (optional) 
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of users (optional) 
            var limit = 10;  // int? | Specifies the number of results returned (optional)  (default to 10)
            var filter = "filter_example";  // string | Filters users with a supported expression for a subset of properties (optional) 
            var search = "search_example";  // string | Searches for users with a supported filtering  expression for most properties (optional) 
            var sortBy = "sortBy_example";  // string |  (optional) 
            var sortOrder = "sortOrder_example";  // string |  (optional) 

            try
            {
                // List Users
                List<User> result = apiInstance.ListUsers(q, after, limit, filter, search, sortBy, sortOrder);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ListUsers: " + e.Message );
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
 **q** | **string**| Finds a user that matches firstName, lastName, and email properties | [optional] 
 **after** | **string**| Specifies the pagination cursor for the next page of users | [optional] 
 **limit** | **int?**| Specifies the number of results returned | [optional] [default to 10]
 **filter** | **string**| Filters users with a supported expression for a subset of properties | [optional] 
 **search** | **string**| Searches for users with a supported filtering  expression for most properties | [optional] 
 **sortBy** | **string**|  | [optional] 
 **sortOrder** | **string**|  | [optional] 

### Return type

[**List&lt;User&gt;**](User.md)

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

<a name="partialupdateuser"></a>
# **PartialUpdateUser**
> User PartialUpdateUser (string userId, User user, bool? strict = null)

Partial Update User

Fetch a user by `id`, `login`, or `login shortname` if the short name is unambiguous.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class PartialUpdateUserExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var user = new User(); // User | 
            var strict = true;  // bool? |  (optional) 

            try
            {
                // Partial Update User
                User result = apiInstance.PartialUpdateUser(userId, user, strict);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.PartialUpdateUser: " + e.Message );
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
 **user** | [**User**](User.md)|  | 
 **strict** | **bool?**|  | [optional] 

### Return type

[**User**](User.md)

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

<a name="reactivateuser"></a>
# **ReactivateUser**
> UserActivationToken ReactivateUser (string userId, bool? sendEmail = null)

Reactivate User

Reactivates a user.  This operation can only be performed on users with a `PROVISIONED` status.  This operation restarts the activation workflow if for some reason the user activation was not completed when using the activationToken from [Activate User](#activate-user).

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var sendEmail = false;  // bool? | Sends an activation email to the user if true (optional)  (default to false)

            try
            {
                // Reactivate User
                UserActivationToken result = apiInstance.ReactivateUser(userId, sendEmail);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ReactivateUser: " + e.Message );
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
 **sendEmail** | **bool?**| Sends an activation email to the user if true | [optional] [default to false]

### Return type

[**UserActivationToken**](UserActivationToken.md)

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

<a name="removeapplicationtargetfromadministratorroleforuser"></a>
# **RemoveApplicationTargetFromAdministratorRoleForUser**
> void RemoveApplicationTargetFromAdministratorRoleForUser (string userId, string roleId, string appName, string applicationId)

Remove App Instance Target to App Administrator Role given to a User

Remove App Instance Target to App Administrator Role given to a User

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveApplicationTargetFromAdministratorRoleForUserExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 
            var applicationId = "applicationId_example";  // string | 

            try
            {
                // Remove App Instance Target to App Administrator Role given to a User
                apiInstance.RemoveApplicationTargetFromAdministratorRoleForUser(userId, roleId, appName, applicationId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.RemoveApplicationTargetFromAdministratorRoleForUser: " + e.Message );
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
 **roleId** | **string**|  | 
 **appName** | **string**|  | 
 **applicationId** | **string**|  | 

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

<a name="removeapplicationtargetfromapplicationadministratorroleforuser"></a>
# **RemoveApplicationTargetFromApplicationAdministratorRoleForUser**
> void RemoveApplicationTargetFromApplicationAdministratorRoleForUser (string userId, string roleId, string appName)

Remove Application Target from Application Administrator Role for User

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveApplicationTargetFromApplicationAdministratorRoleForUserExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 

            try
            {
                // Remove Application Target from Application Administrator Role for User
                apiInstance.RemoveApplicationTargetFromApplicationAdministratorRoleForUser(userId, roleId, appName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.RemoveApplicationTargetFromApplicationAdministratorRoleForUser: " + e.Message );
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
 **roleId** | **string**|  | 
 **appName** | **string**|  | 

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

<a name="removegrouptargetfromrole"></a>
# **RemoveGroupTargetFromRole**
> void RemoveGroupTargetFromRole (string userId, string roleId, string groupId)

Remove Group Target from Role

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveGroupTargetFromRoleExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var groupId = "groupId_example";  // string | 

            try
            {
                // Remove Group Target from Role
                apiInstance.RemoveGroupTargetFromRole(userId, roleId, groupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.RemoveGroupTargetFromRole: " + e.Message );
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
 **roleId** | **string**|  | 
 **groupId** | **string**|  | 

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

<a name="removelinkedobjectforuser"></a>
# **RemoveLinkedObjectForUser**
> void RemoveLinkedObjectForUser (string userId, string relationshipName)

Remove Linked Object for User

Delete linked objects for a user, relationshipName can be ONLY a primary relationship name

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveLinkedObjectForUserExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var relationshipName = "relationshipName_example";  // string | 

            try
            {
                // Remove Linked Object for User
                apiInstance.RemoveLinkedObjectForUser(userId, relationshipName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.RemoveLinkedObjectForUser: " + e.Message );
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
 **relationshipName** | **string**|  | 

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

<a name="removerolefromuser"></a>
# **RemoveRoleFromUser**
> void RemoveRoleFromUser (string userId, string roleId)

Remove Role from User

Unassigns a role from a user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveRoleFromUserExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 

            try
            {
                // Remove Role from User
                apiInstance.RemoveRoleFromUser(userId, roleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.RemoveRoleFromUser: " + e.Message );
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
 **roleId** | **string**|  | 

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

<a name="resetfactors"></a>
# **ResetFactors**
> void ResetFactors (string userId)

Reset Factors

This operation resets all factors for the specified user. All MFA factor enrollments returned to the unenrolled state. The user's status remains ACTIVE. This link is present only if the user is currently enrolled in one or more MFA factors.

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // Reset Factors
                apiInstance.ResetFactors(userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ResetFactors: " + e.Message );
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

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="resetpassword"></a>
# **ResetPassword**
> ResetPasswordToken ResetPassword (string userId, bool sendEmail)

Reset Password

Generates a one-time token (OTT) that can be used to reset a user's password.  The OTT link can be automatically emailed to the user or returned to the API caller and distributed using a custom flow.

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var sendEmail = true;  // bool | 

            try
            {
                // Reset Password
                ResetPasswordToken result = apiInstance.ResetPassword(userId, sendEmail);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.ResetPassword: " + e.Message );
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
 **sendEmail** | **bool**|  | 

### Return type

[**ResetPasswordToken**](ResetPasswordToken.md)

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

<a name="revokegrantsforuserandclient"></a>
# **RevokeGrantsForUserAndClient**
> void RevokeGrantsForUserAndClient (string userId, string clientId)

Revoke Grants for User and Client

Revokes all grants for the specified user and client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeGrantsForUserAndClientExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var clientId = "clientId_example";  // string | 

            try
            {
                // Revoke Grants for User and Client
                apiInstance.RevokeGrantsForUserAndClient(userId, clientId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.RevokeGrantsForUserAndClient: " + e.Message );
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
 **clientId** | **string**|  | 

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

<a name="revoketokenforuserandclient"></a>
# **RevokeTokenForUserAndClient**
> void RevokeTokenForUserAndClient (string userId, string clientId, string tokenId)

Revoke Token for User and Client

Revokes the specified refresh token.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeTokenForUserAndClientExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var clientId = "clientId_example";  // string | 
            var tokenId = "tokenId_example";  // string | 

            try
            {
                // Revoke Token for User and Client
                apiInstance.RevokeTokenForUserAndClient(userId, clientId, tokenId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.RevokeTokenForUserAndClient: " + e.Message );
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
 **clientId** | **string**|  | 
 **tokenId** | **string**|  | 

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

<a name="revoketokensforuserandclient"></a>
# **RevokeTokensForUserAndClient**
> void RevokeTokensForUserAndClient (string userId, string clientId)

Revoke Tokens for User and Client

Revokes all refresh tokens issued for the specified User and Client.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeTokensForUserAndClientExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var clientId = "clientId_example";  // string | 

            try
            {
                // Revoke Tokens for User and Client
                apiInstance.RevokeTokensForUserAndClient(userId, clientId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.RevokeTokensForUserAndClient: " + e.Message );
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
 **clientId** | **string**|  | 

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

<a name="revokeusergrant"></a>
# **RevokeUserGrant**
> void RevokeUserGrant (string userId, string grantId)

Revoke User Grant

Revokes one grant for a specified user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeUserGrantExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var grantId = "grantId_example";  // string | 

            try
            {
                // Revoke User Grant
                apiInstance.RevokeUserGrant(userId, grantId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.RevokeUserGrant: " + e.Message );
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
 **grantId** | **string**|  | 

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

<a name="revokeusergrants"></a>
# **RevokeUserGrants**
> void RevokeUserGrants (string userId)

Revoke User Grants

Revokes all grants for a specified user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeUserGrantsExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // Revoke User Grants
                apiInstance.RevokeUserGrants(userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.RevokeUserGrants: " + e.Message );
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

<a name="setlinkedobjectforuser"></a>
# **SetLinkedObjectForUser**
> void SetLinkedObjectForUser (string associatedUserId, string primaryRelationshipName, string primaryUserId)

Set Linked Object for User

Sets a linked object for a user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class SetLinkedObjectForUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi(config);
            var associatedUserId = "associatedUserId_example";  // string | 
            var primaryRelationshipName = "primaryRelationshipName_example";  // string | 
            var primaryUserId = "primaryUserId_example";  // string | 

            try
            {
                // Set Linked Object for User
                apiInstance.SetLinkedObjectForUser(associatedUserId, primaryRelationshipName, primaryUserId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.SetLinkedObjectForUser: " + e.Message );
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
 **associatedUserId** | **string**|  | 
 **primaryRelationshipName** | **string**|  | 
 **primaryUserId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="suspenduser"></a>
# **SuspendUser**
> void SuspendUser (string userId)

Suspend User

Suspends a user.  This operation can only be performed on users with an `ACTIVE` status.  The user will have a status of `SUSPENDED` when the process is complete.

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // Suspend User
                apiInstance.SuspendUser(userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.SuspendUser: " + e.Message );
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

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="unlockuser"></a>
# **UnlockUser**
> void UnlockUser (string userId)

Unlock User

Unlocks a user with a `LOCKED_OUT` status and returns them to `ACTIVE` status.  Users will be able to login with their current password.

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // Unlock User
                apiInstance.UnlockUser(userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.UnlockUser: " + e.Message );
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

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="unsuspenduser"></a>
# **UnsuspendUser**
> void UnsuspendUser (string userId)

Unsuspend User

Unsuspends a user and returns them to the `ACTIVE` state.  This operation can only be performed on users that have a `SUSPENDED` status.

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // Unsuspend User
                apiInstance.UnsuspendUser(userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.UnsuspendUser: " + e.Message );
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

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateuser"></a>
# **UpdateUser**
> User UpdateUser (string userId, User user, bool? strict = null)

Update User

Update a user's profile and/or credentials using strict-update semantics.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateUserExample
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

            var apiInstance = new UserApi(config);
            var userId = "userId_example";  // string | 
            var user = new User(); // User | 
            var strict = true;  // bool? |  (optional) 

            try
            {
                // Update User
                User result = apiInstance.UpdateUser(userId, user, strict);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.UpdateUser: " + e.Message );
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
 **user** | [**User**](User.md)|  | 
 **strict** | **bool?**|  | [optional] 

### Return type

[**User**](User.md)

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

