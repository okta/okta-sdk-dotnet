# Okta.Sdk.Api.SubscriptionApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetSubscriptionsNotificationTypeRole**](SubscriptionApi.md#getsubscriptionsnotificationtyperole) | **GET** /api/v1/roles/{roleRef}/subscriptions/{notificationType} | Retrieve a Subscription for a Role
[**GetSubscriptionsNotificationTypeUser**](SubscriptionApi.md#getsubscriptionsnotificationtypeuser) | **GET** /api/v1/users/{userId}/subscriptions/{notificationType} | Retrieve a Subscription for a User
[**ListSubscriptionsRole**](SubscriptionApi.md#listsubscriptionsrole) | **GET** /api/v1/roles/{roleRef}/subscriptions | List all Subscriptions for a Role
[**ListSubscriptionsUser**](SubscriptionApi.md#listsubscriptionsuser) | **GET** /api/v1/users/{userId}/subscriptions | List all Subscriptions for a User
[**SubscribeByNotificationTypeRole**](SubscriptionApi.md#subscribebynotificationtyperole) | **POST** /api/v1/roles/{roleRef}/subscriptions/{notificationType}/subscribe | Subscribe a Role to a Specific Notification Type
[**SubscribeByNotificationTypeUser**](SubscriptionApi.md#subscribebynotificationtypeuser) | **POST** /api/v1/users/{userId}/subscriptions/{notificationType}/subscribe | Subscribe a User to a Specific Notification Type
[**UnsubscribeByNotificationTypeRole**](SubscriptionApi.md#unsubscribebynotificationtyperole) | **POST** /api/v1/roles/{roleRef}/subscriptions/{notificationType}/unsubscribe | Unsubscribe a Role from a Specific Notification Type
[**UnsubscribeByNotificationTypeUser**](SubscriptionApi.md#unsubscribebynotificationtypeuser) | **POST** /api/v1/users/{userId}/subscriptions/{notificationType}/unsubscribe | Unsubscribe a User from a Specific Notification Type


<a name="getsubscriptionsnotificationtyperole"></a>
# **GetSubscriptionsNotificationTypeRole**
> Subscription GetSubscriptionsNotificationTypeRole (ListSubscriptionsRoleRoleRefParameter roleRef, NotificationType notificationType)

Retrieve a Subscription for a Role

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
            var roleRef = new ListSubscriptionsRoleRoleRefParameter(); // ListSubscriptionsRoleRoleRefParameter | A reference to an existing role. Standard roles require a `roleType`, while Custom Roles require a `roleId`. See [Standard Role Types](https://developer.okta.com/docs/concepts/role-assignment/#standard-role-types).
            var notificationType = (NotificationType) "AD_AGENT";  // NotificationType | 

            try
            {
                // Retrieve a Subscription for a Role
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
 **roleRef** | [**ListSubscriptionsRoleRoleRefParameter**](ListSubscriptionsRoleRoleRefParameter.md)| A reference to an existing role. Standard roles require a &#x60;roleType&#x60;, while Custom Roles require a &#x60;roleId&#x60;. See [Standard Role Types](https://developer.okta.com/docs/concepts/role-assignment/#standard-role-types). | 
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

Retrieve a Subscription for a User

Retrieves a subscription by `notificationType` for a specified User. Returns an `AccessDeniedException` message if requests are made for another user.

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
            var userId = "userId_example";  // string | 

            try
            {
                // Retrieve a Subscription for a User
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
 **userId** | **string**|  | 

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

List all Subscriptions for a Role

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
            var roleRef = new ListSubscriptionsRoleRoleRefParameter(); // ListSubscriptionsRoleRoleRefParameter | A reference to an existing role. Standard roles require a `roleType`, while Custom Roles require a `roleId`. See [Standard Role Types](https://developer.okta.com/docs/concepts/role-assignment/#standard-role-types).

            try
            {
                // List all Subscriptions for a Role
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
 **roleRef** | [**ListSubscriptionsRoleRoleRefParameter**](ListSubscriptionsRoleRoleRefParameter.md)| A reference to an existing role. Standard roles require a &#x60;roleType&#x60;, while Custom Roles require a &#x60;roleId&#x60;. See [Standard Role Types](https://developer.okta.com/docs/concepts/role-assignment/#standard-role-types). | 

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

List all Subscriptions for a User

Lists all subscriptions available to a specified User. Returns an `AccessDeniedException` message if requests are made for another user.

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
            var userId = "userId_example";  // string | 

            try
            {
                // List all Subscriptions for a User
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
 **userId** | **string**|  | 

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

Subscribe a Role to a Specific Notification Type

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
            var roleRef = new ListSubscriptionsRoleRoleRefParameter(); // ListSubscriptionsRoleRoleRefParameter | A reference to an existing role. Standard roles require a `roleType`, while Custom Roles require a `roleId`. See [Standard Role Types](https://developer.okta.com/docs/concepts/role-assignment/#standard-role-types).
            var notificationType = (NotificationType) "AD_AGENT";  // NotificationType | 

            try
            {
                // Subscribe a Role to a Specific Notification Type
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
 **roleRef** | [**ListSubscriptionsRoleRoleRefParameter**](ListSubscriptionsRoleRoleRefParameter.md)| A reference to an existing role. Standard roles require a &#x60;roleType&#x60;, while Custom Roles require a &#x60;roleId&#x60;. See [Standard Role Types](https://developer.okta.com/docs/concepts/role-assignment/#standard-role-types). | 
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

Subscribe a User to a Specific Notification Type

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
            var userId = "userId_example";  // string | 

            try
            {
                // Subscribe a User to a Specific Notification Type
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
 **userId** | **string**|  | 

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

Unsubscribe a Role from a Specific Notification Type

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
            var roleRef = new ListSubscriptionsRoleRoleRefParameter(); // ListSubscriptionsRoleRoleRefParameter | A reference to an existing role. Standard roles require a `roleType`, while Custom Roles require a `roleId`. See [Standard Role Types](https://developer.okta.com/docs/concepts/role-assignment/#standard-role-types).
            var notificationType = (NotificationType) "AD_AGENT";  // NotificationType | 

            try
            {
                // Unsubscribe a Role from a Specific Notification Type
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
 **roleRef** | [**ListSubscriptionsRoleRoleRefParameter**](ListSubscriptionsRoleRoleRefParameter.md)| A reference to an existing role. Standard roles require a &#x60;roleType&#x60;, while Custom Roles require a &#x60;roleId&#x60;. See [Standard Role Types](https://developer.okta.com/docs/concepts/role-assignment/#standard-role-types). | 
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

Unsubscribe a User from a Specific Notification Type

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
            var userId = "userId_example";  // string | 

            try
            {
                // Unsubscribe a User from a Specific Notification Type
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
 **userId** | **string**|  | 

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

