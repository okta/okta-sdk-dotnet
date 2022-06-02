# Okta.Sdk.Api.SubscriptionApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetRoleSubscriptionByNotificationType**](SubscriptionApi.md#getrolesubscriptionbynotificationtype) | **GET** /api/v1/roles/{roleTypeOrRoleId}/subscriptions/{notificationType} | Get subscriptions of a Custom Role with a specific notification type
[**GetUserSubscriptionByNotificationType**](SubscriptionApi.md#getusersubscriptionbynotificationtype) | **GET** /api/v1/users/{userId}/subscriptions/{notificationType} | Get the subscription of a User with a specific notification type
[**ListRoleSubscriptions**](SubscriptionApi.md#listrolesubscriptions) | **GET** /api/v1/roles/{roleTypeOrRoleId}/subscriptions | List all subscriptions of a Custom Role
[**ListUserSubscriptions**](SubscriptionApi.md#listusersubscriptions) | **GET** /api/v1/users/{userId}/subscriptions | List subscriptions of a User
[**SubscribeRoleSubscriptionByNotificationType**](SubscriptionApi.md#subscriberolesubscriptionbynotificationtype) | **POST** /api/v1/roles/{roleTypeOrRoleId}/subscriptions/{notificationType}/subscribe | Subscribe a Custom Role to a specific notification type
[**SubscribeUserSubscriptionByNotificationType**](SubscriptionApi.md#subscribeusersubscriptionbynotificationtype) | **POST** /api/v1/users/{userId}/subscriptions/{notificationType}/subscribe | Subscribe to a specific notification type
[**UnsubscribeRoleSubscriptionByNotificationType**](SubscriptionApi.md#unsubscriberolesubscriptionbynotificationtype) | **POST** /api/v1/roles/{roleTypeOrRoleId}/subscriptions/{notificationType}/unsubscribe | Unsubscribe a Custom Role from a specific notification type
[**UnsubscribeUserSubscriptionByNotificationType**](SubscriptionApi.md#unsubscribeusersubscriptionbynotificationtype) | **POST** /api/v1/users/{userId}/subscriptions/{notificationType}/unsubscribe | Unsubscribe from a specific notification type


<a name="getrolesubscriptionbynotificationtype"></a>
# **GetRoleSubscriptionByNotificationType**
> Subscription GetRoleSubscriptionByNotificationType (string roleTypeOrRoleId, string notificationType)

Get subscriptions of a Custom Role with a specific notification type

When roleType Get subscriptions of a Role with a specific notification type. Else when roleId Get subscription of a Custom Role with a specific notification type.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRoleSubscriptionByNotificationTypeExample
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

            var apiInstance = new SubscriptionApi(config);
            var roleTypeOrRoleId = "roleTypeOrRoleId_example";  // string | 
            var notificationType = "notificationType_example";  // string | 

            try
            {
                // Get subscriptions of a Custom Role with a specific notification type
                Subscription result = apiInstance.GetRoleSubscriptionByNotificationType(roleTypeOrRoleId, notificationType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.GetRoleSubscriptionByNotificationType: " + e.Message );
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
 **roleTypeOrRoleId** | **string**|  | 
 **notificationType** | **string**|  | 

### Return type

[**Subscription**](Subscription.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getusersubscriptionbynotificationtype"></a>
# **GetUserSubscriptionByNotificationType**
> Subscription GetUserSubscriptionByNotificationType (string userId, string notificationType)

Get the subscription of a User with a specific notification type

Get the subscriptions of a User with a specific notification type. Only gets subscriptions for current user. An AccessDeniedException message is sent if requests are made from other users.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetUserSubscriptionByNotificationTypeExample
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

            var apiInstance = new SubscriptionApi(config);
            var userId = "userId_example";  // string | 
            var notificationType = "notificationType_example";  // string | 

            try
            {
                // Get the subscription of a User with a specific notification type
                Subscription result = apiInstance.GetUserSubscriptionByNotificationType(userId, notificationType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.GetUserSubscriptionByNotificationType: " + e.Message );
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
 **notificationType** | **string**|  | 

### Return type

[**Subscription**](Subscription.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listrolesubscriptions"></a>
# **ListRoleSubscriptions**
> List&lt;Subscription&gt; ListRoleSubscriptions (string roleTypeOrRoleId)

List all subscriptions of a Custom Role

When roleType List all subscriptions of a Role. Else when roleId List subscriptions of a Custom Role

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListRoleSubscriptionsExample
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

            var apiInstance = new SubscriptionApi(config);
            var roleTypeOrRoleId = "roleTypeOrRoleId_example";  // string | 

            try
            {
                // List all subscriptions of a Custom Role
                List<Subscription> result = apiInstance.ListRoleSubscriptions(roleTypeOrRoleId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.ListRoleSubscriptions: " + e.Message );
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
 **roleTypeOrRoleId** | **string**|  | 

### Return type

[**List&lt;Subscription&gt;**](Subscription.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listusersubscriptions"></a>
# **ListUserSubscriptions**
> List&lt;Subscription&gt; ListUserSubscriptions (string userId)

List subscriptions of a User

List subscriptions of a User. Only lists subscriptions for current user. An AccessDeniedException message is sent if requests are made from other users.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListUserSubscriptionsExample
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

            var apiInstance = new SubscriptionApi(config);
            var userId = "userId_example";  // string | 

            try
            {
                // List subscriptions of a User
                List<Subscription> result = apiInstance.ListUserSubscriptions(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.ListUserSubscriptions: " + e.Message );
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

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="subscriberolesubscriptionbynotificationtype"></a>
# **SubscribeRoleSubscriptionByNotificationType**
> void SubscribeRoleSubscriptionByNotificationType (string roleTypeOrRoleId, string notificationType)

Subscribe a Custom Role to a specific notification type

When roleType Subscribes a Role to a specific notification type. When you change the subscription status of a Role, it overrides the subscription of any individual user of that Role. Else when roleId Subscribes a Custom Role to a specific notification type. When you change the subscription status of a Custom Role, it overrides the subscription of any individual user of that Custom Role.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class SubscribeRoleSubscriptionByNotificationTypeExample
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

            var apiInstance = new SubscriptionApi(config);
            var roleTypeOrRoleId = "roleTypeOrRoleId_example";  // string | 
            var notificationType = "notificationType_example";  // string | 

            try
            {
                // Subscribe a Custom Role to a specific notification type
                apiInstance.SubscribeRoleSubscriptionByNotificationType(roleTypeOrRoleId, notificationType);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.SubscribeRoleSubscriptionByNotificationType: " + e.Message );
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
 **roleTypeOrRoleId** | **string**|  | 
 **notificationType** | **string**|  | 

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
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="subscribeusersubscriptionbynotificationtype"></a>
# **SubscribeUserSubscriptionByNotificationType**
> void SubscribeUserSubscriptionByNotificationType (string userId, string notificationType)

Subscribe to a specific notification type

Subscribes a User to a specific notification type. Only the current User can subscribe to a specific notification type. An AccessDeniedException message is sent if requests are made from other users.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class SubscribeUserSubscriptionByNotificationTypeExample
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

            var apiInstance = new SubscriptionApi(config);
            var userId = "userId_example";  // string | 
            var notificationType = "notificationType_example";  // string | 

            try
            {
                // Subscribe to a specific notification type
                apiInstance.SubscribeUserSubscriptionByNotificationType(userId, notificationType);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.SubscribeUserSubscriptionByNotificationType: " + e.Message );
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
 **notificationType** | **string**|  | 

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
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="unsubscriberolesubscriptionbynotificationtype"></a>
# **UnsubscribeRoleSubscriptionByNotificationType**
> void UnsubscribeRoleSubscriptionByNotificationType (string roleTypeOrRoleId, string notificationType)

Unsubscribe a Custom Role from a specific notification type

When roleType Unsubscribes a Role from a specific notification type. When you change the subscription status of a Role, it overrides the subscription of any individual user of that Role. Else when roleId Unsubscribes a Custom Role from a specific notification type. When you change the subscription status of a Custom Role, it overrides the subscription of any individual user of that Custom Role.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnsubscribeRoleSubscriptionByNotificationTypeExample
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

            var apiInstance = new SubscriptionApi(config);
            var roleTypeOrRoleId = "roleTypeOrRoleId_example";  // string | 
            var notificationType = "notificationType_example";  // string | 

            try
            {
                // Unsubscribe a Custom Role from a specific notification type
                apiInstance.UnsubscribeRoleSubscriptionByNotificationType(roleTypeOrRoleId, notificationType);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.UnsubscribeRoleSubscriptionByNotificationType: " + e.Message );
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
 **roleTypeOrRoleId** | **string**|  | 
 **notificationType** | **string**|  | 

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
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="unsubscribeusersubscriptionbynotificationtype"></a>
# **UnsubscribeUserSubscriptionByNotificationType**
> void UnsubscribeUserSubscriptionByNotificationType (string userId, string notificationType)

Unsubscribe from a specific notification type

Unsubscribes a User from a specific notification type. Only the current User can unsubscribe from a specific notification type. An AccessDeniedException message is sent if requests are made from other users.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnsubscribeUserSubscriptionByNotificationTypeExample
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

            var apiInstance = new SubscriptionApi(config);
            var userId = "userId_example";  // string | 
            var notificationType = "notificationType_example";  // string | 

            try
            {
                // Unsubscribe from a specific notification type
                apiInstance.UnsubscribeUserSubscriptionByNotificationType(userId, notificationType);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubscriptionApi.UnsubscribeUserSubscriptionByNotificationType: " + e.Message );
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
 **notificationType** | **string**|  | 

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
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

