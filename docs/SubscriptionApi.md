# Okta.Sdk.Api.SubscriptionApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetSubscriptionsNotificationTypeRole**](SubscriptionApi.md#getsubscriptionsnotificationtyperole) | **GET** /api/v1/roles/{roleRef}/subscriptions/{notificationType} | Retrieve a subscription for a role
[**GetSubscriptionsNotificationTypeUser**](SubscriptionApi.md#getsubscriptionsnotificationtypeuser) | **GET** /api/v1/users/{userId}/subscriptions/{notificationType} | Retrieve a subscription for a user
[**ListSubscriptionsRole**](SubscriptionApi.md#listsubscriptionsrole) | **GET** /api/v1/roles/{roleRef}/subscriptions | List all subscriptions for a role
[**ListSubscriptionsUser**](SubscriptionApi.md#listsubscriptionsuser) | **GET** /api/v1/users/{userId}/subscriptions | List all subscriptions for a user
[**SubscribeByNotificationTypeRole**](SubscriptionApi.md#subscribebynotificationtyperole) | **POST** /api/v1/roles/{roleRef}/subscriptions/{notificationType}/subscribe | Subscribe a role to a specific notification type
[**SubscribeByNotificationTypeUser**](SubscriptionApi.md#subscribebynotificationtypeuser) | **POST** /api/v1/users/{userId}/subscriptions/{notificationType}/subscribe | Subscribe a user to a specific notification type
[**UnsubscribeByNotificationTypeRole**](SubscriptionApi.md#unsubscribebynotificationtyperole) | **POST** /api/v1/roles/{roleRef}/subscriptions/{notificationType}/unsubscribe | Unsubscribe a role from a specific notification type
[**UnsubscribeByNotificationTypeUser**](SubscriptionApi.md#unsubscribebynotificationtypeuser) | **POST** /api/v1/users/{userId}/subscriptions/{notificationType}/unsubscribe | Unsubscribe a user from a specific notification type


<a name="getsubscriptionsnotificationtyperole"></a>
# **GetSubscriptionsNotificationTypeRole**
> Subscription GetSubscriptionsNotificationTypeRole (ListSubscriptionsRoleRoleRefParameter roleRef, NotificationType notificationType)

Retrieve a subscription for a role

Retrieves a subscription by `notificationType` for a specified Role

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetSubscriptionsNotificationTypeRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SubscriptionApi(config);
            var roleRef = new ListSubscriptionsRoleRoleRefParameter(); // ListSubscriptionsRoleRoleRefParameter | A reference to an existing role. Standard roles require a `roleType`, while Custom Roles require a `roleId`. See [Standard Roles](/openapi/okta-management/guides/roles/#standard-roles).
            var notificationType = (NotificationType) "AD_AGENT";  // NotificationType | 

            try
            {
                // Retrieve a subscription for a role
                Subscription result = apiInstance.GetSubscriptionsNotificationTypeRole(roleRef, notificationType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.GetSubscriptionsNotificationTypeRole: " + e.Message );
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
 **roleRef** | [**ListSubscriptionsRoleRoleRefParameter**](ListSubscriptionsRoleRoleRefParameter.md)| A reference to an existing role. Standard roles require a &#x60;roleType&#x60;, while Custom Roles require a &#x60;roleId&#x60;. See [Standard Roles](/openapi/okta-management/guides/roles/#standard-roles). | 
 **notificationType** | **NotificationType**|  | 

### Return type

[**Subscription**](Subscription.md)

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

<a name="getsubscriptionsnotificationtypeuser"></a>
# **GetSubscriptionsNotificationTypeUser**
> Subscription GetSubscriptionsNotificationTypeUser (NotificationType notificationType, string userId)

Retrieve a subscription for a user

Retrieves a subscription by `notificationType` for a specified user. Returns an `AccessDeniedException` message if requests are made for another user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetSubscriptionsNotificationTypeUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SubscriptionApi(config);
            var notificationType = (NotificationType) "AD_AGENT";  // NotificationType | 
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // Retrieve a subscription for a user
                Subscription result = apiInstance.GetSubscriptionsNotificationTypeUser(notificationType, userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.GetSubscriptionsNotificationTypeUser: " + e.Message );
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
 **notificationType** | **NotificationType**|  | 
 **userId** | **string**| ID of an existing Okta user | 

### Return type

[**Subscription**](Subscription.md)

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

<a name="listsubscriptionsrole"></a>
# **ListSubscriptionsRole**
> List&lt;Subscription&gt; ListSubscriptionsRole (ListSubscriptionsRoleRoleRefParameter roleRef)

List all subscriptions for a role

Lists all subscriptions available to a specified Role

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListSubscriptionsRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SubscriptionApi(config);
            var roleRef = new ListSubscriptionsRoleRoleRefParameter(); // ListSubscriptionsRoleRoleRefParameter | A reference to an existing role. Standard roles require a `roleType`, while Custom Roles require a `roleId`. See [Standard Roles](/openapi/okta-management/guides/roles/#standard-roles).

            try
            {
                // List all subscriptions for a role
                List<Subscription> result = apiInstance.ListSubscriptionsRole(roleRef).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.ListSubscriptionsRole: " + e.Message );
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
 **roleRef** | [**ListSubscriptionsRoleRoleRefParameter**](ListSubscriptionsRoleRoleRefParameter.md)| A reference to an existing role. Standard roles require a &#x60;roleType&#x60;, while Custom Roles require a &#x60;roleId&#x60;. See [Standard Roles](/openapi/okta-management/guides/roles/#standard-roles). | 

### Return type

[**List&lt;Subscription&gt;**](Subscription.md)

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

<a name="listsubscriptionsuser"></a>
# **ListSubscriptionsUser**
> List&lt;Subscription&gt; ListSubscriptionsUser (string userId)

List all subscriptions for a user

Lists all subscriptions available to a specified user. Returns an `AccessDeniedException` message if requests are made for another user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListSubscriptionsUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SubscriptionApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // List all subscriptions for a user
                List<Subscription> result = apiInstance.ListSubscriptionsUser(userId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.ListSubscriptionsUser: " + e.Message );
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

[**List&lt;Subscription&gt;**](Subscription.md)

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

<a name="subscribebynotificationtyperole"></a>
# **SubscribeByNotificationTypeRole**
> void SubscribeByNotificationTypeRole (ListSubscriptionsRoleRoleRefParameter roleRef, NotificationType notificationType)

Subscribe a role to a specific notification type

Subscribes a Role to a specified notification type. Changes to Role subscriptions override the subscription status of any individual users with the Role.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class SubscribeByNotificationTypeRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SubscriptionApi(config);
            var roleRef = new ListSubscriptionsRoleRoleRefParameter(); // ListSubscriptionsRoleRoleRefParameter | A reference to an existing role. Standard roles require a `roleType`, while Custom Roles require a `roleId`. See [Standard Roles](/openapi/okta-management/guides/roles/#standard-roles).
            var notificationType = (NotificationType) "AD_AGENT";  // NotificationType | 

            try
            {
                // Subscribe a role to a specific notification type
                apiInstance.SubscribeByNotificationTypeRole(roleRef, notificationType);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.SubscribeByNotificationTypeRole: " + e.Message );
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
 **roleRef** | [**ListSubscriptionsRoleRoleRefParameter**](ListSubscriptionsRoleRoleRefParameter.md)| A reference to an existing role. Standard roles require a &#x60;roleType&#x60;, while Custom Roles require a &#x60;roleId&#x60;. See [Standard Roles](/openapi/okta-management/guides/roles/#standard-roles). | 
 **notificationType** | **NotificationType**|  | 

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
| **200** | No Content |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="subscribebynotificationtypeuser"></a>
# **SubscribeByNotificationTypeUser**
> void SubscribeByNotificationTypeUser (NotificationType notificationType, string userId)

Subscribe a user to a specific notification type

Subscribes the current user to a specified notification type. Returns an `AccessDeniedException` message if requests are made for another user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class SubscribeByNotificationTypeUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SubscriptionApi(config);
            var notificationType = (NotificationType) "AD_AGENT";  // NotificationType | 
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // Subscribe a user to a specific notification type
                apiInstance.SubscribeByNotificationTypeUser(notificationType, userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.SubscribeByNotificationTypeUser: " + e.Message );
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
 **notificationType** | **NotificationType**|  | 
 **userId** | **string**| ID of an existing Okta user | 

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
| **200** | No Content |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="unsubscribebynotificationtyperole"></a>
# **UnsubscribeByNotificationTypeRole**
> void UnsubscribeByNotificationTypeRole (ListSubscriptionsRoleRoleRefParameter roleRef, NotificationType notificationType)

Unsubscribe a role from a specific notification type

Unsubscribes a Role from a specified notification type. Changes to Role subscriptions override the subscription status of any individual users with the Role.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnsubscribeByNotificationTypeRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SubscriptionApi(config);
            var roleRef = new ListSubscriptionsRoleRoleRefParameter(); // ListSubscriptionsRoleRoleRefParameter | A reference to an existing role. Standard roles require a `roleType`, while Custom Roles require a `roleId`. See [Standard Roles](/openapi/okta-management/guides/roles/#standard-roles).
            var notificationType = (NotificationType) "AD_AGENT";  // NotificationType | 

            try
            {
                // Unsubscribe a role from a specific notification type
                apiInstance.UnsubscribeByNotificationTypeRole(roleRef, notificationType);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.UnsubscribeByNotificationTypeRole: " + e.Message );
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
 **roleRef** | [**ListSubscriptionsRoleRoleRefParameter**](ListSubscriptionsRoleRoleRefParameter.md)| A reference to an existing role. Standard roles require a &#x60;roleType&#x60;, while Custom Roles require a &#x60;roleId&#x60;. See [Standard Roles](/openapi/okta-management/guides/roles/#standard-roles). | 
 **notificationType** | **NotificationType**|  | 

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
| **200** | No Content |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="unsubscribebynotificationtypeuser"></a>
# **UnsubscribeByNotificationTypeUser**
> void UnsubscribeByNotificationTypeUser (NotificationType notificationType, string userId)

Unsubscribe a user from a specific notification type

Unsubscribes the current user from a specified notification type. Returns an `AccessDeniedException` message if requests are made for another user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnsubscribeByNotificationTypeUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SubscriptionApi(config);
            var notificationType = (NotificationType) "AD_AGENT";  // NotificationType | 
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // Unsubscribe a user from a specific notification type
                apiInstance.UnsubscribeByNotificationTypeUser(notificationType, userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.UnsubscribeByNotificationTypeUser: " + e.Message );
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
 **notificationType** | **NotificationType**|  | 
 **userId** | **string**| ID of an existing Okta user | 

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
| **200** | No Content |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

