# Okta.Sdk.Api.GroupApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddGroup**](GroupApi.md#addgroup) | **POST** /api/v1/groups | Add a group
[**AssignUserToGroup**](GroupApi.md#assignusertogroup) | **PUT** /api/v1/groups/{groupId}/users/{userId} | Assign a user to a group
[**DeleteGroup**](GroupApi.md#deletegroup) | **DELETE** /api/v1/groups/{groupId} | Delete a group
[**GetGroup**](GroupApi.md#getgroup) | **GET** /api/v1/groups/{groupId} | Retrieve a group
[**ListAssignedApplicationsForGroup**](GroupApi.md#listassignedapplicationsforgroup) | **GET** /api/v1/groups/{groupId}/apps | List all assigned apps
[**ListGroupUsers**](GroupApi.md#listgroupusers) | **GET** /api/v1/groups/{groupId}/users | List all member users
[**ListGroups**](GroupApi.md#listgroups) | **GET** /api/v1/groups | List all groups
[**ReplaceGroup**](GroupApi.md#replacegroup) | **PUT** /api/v1/groups/{groupId} | Replace a group
[**UnassignUserFromGroup**](GroupApi.md#unassignuserfromgroup) | **DELETE** /api/v1/groups/{groupId}/users/{userId} | Unassign a user from a group


<a name="addgroup"></a>
# **AddGroup**
> Group AddGroup (AddGroupRequest group)

Add a group

Adds a new group with the `OKTA_GROUP` type to your org. > **Note:** App import operations are responsible for syncing groups with `APP_GROUP` type such as Active Directory groups. See [About groups](https://help.okta.com/okta_help.htm?id=Directory_Groups) in the help documentation.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var group = new AddGroupRequest(); // AddGroupRequest | 

            try
            {
                // Add a group
                Group result = apiInstance.AddGroup(group);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.AddGroup: " + e.Message );
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
 **group** | [**AddGroupRequest**](AddGroupRequest.md)|  | 

### Return type

[**Group**](Group.md)

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

<a name="assignusertogroup"></a>
# **AssignUserToGroup**
> void AssignUserToGroup (string groupId, string userId)

Assign a user to a group

Assigns a user to a group with the `OKTA_GROUP` type. > **Note:** You only can modify memberships for groups of the `OKTA_GROUP` type. App imports are responsible for managing group memberships for groups of the `APP_GROUP` type, such as Active Directory groups.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignUserToGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // Assign a user to a group
                apiInstance.AssignUserToGroup(groupId, userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.AssignUserToGroup: " + e.Message );
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 
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
| **204** | No Content |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletegroup"></a>
# **DeleteGroup**
> void DeleteGroup (string groupId)

Delete a group

Deletes a group of the `OKTA_GROUP` or `APP_GROUP` type from your org. > **Note:** You can't remove groups of type `APP_GROUP` if they are used in a group push mapping.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group

            try
            {
                // Delete a group
                apiInstance.DeleteGroup(groupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.DeleteGroup: " + e.Message );
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 

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

<a name="getgroup"></a>
# **GetGroup**
> Group GetGroup (string groupId)

Retrieve a group

Retrieves a specific group by `id` from your org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group

            try
            {
                // Retrieve a group
                Group result = apiInstance.GetGroup(groupId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.GetGroup: " + e.Message );
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 

### Return type

[**Group**](Group.md)

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

<a name="listassignedapplicationsforgroup"></a>
# **ListAssignedApplicationsForGroup**
> List&lt;Application&gt; ListAssignedApplicationsForGroup (string groupId, string after = null, int? limit = null)

List all assigned apps

Lists all apps that are assigned to a group. See [Application Groups API](/openapi/okta-management/management/tag/ApplicationGroups/).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAssignedApplicationsForGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of apps (optional) 
            var limit = 20;  // int? | Specifies the number of app results for a page (optional)  (default to 20)

            try
            {
                // List all assigned apps
                List<Application> result = apiInstance.ListAssignedApplicationsForGroup(groupId, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.ListAssignedApplicationsForGroup: " + e.Message );
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 
 **after** | **string**| Specifies the pagination cursor for the next page of apps | [optional] 
 **limit** | **int?**| Specifies the number of app results for a page | [optional] [default to 20]

### Return type

[**List&lt;Application&gt;**](Application.md)

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

<a name="listgroupusers"></a>
# **ListGroupUsers**
> List&lt;User&gt; ListGroupUsers (string groupId, string after = null, int? limit = null)

List all member users

Lists all users that are a member of a group. The default user limit is set to a very high number due to historical reasons that are no longer valid for most orgs. This will change in a future version of this API. The recommended page limit is now `limit=200`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGroupUsersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 1000;  // int? | Specifies the number of user results in a page (optional)  (default to 1000)

            try
            {
                // List all member users
                List<User> result = apiInstance.ListGroupUsers(groupId, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.ListGroupUsers: " + e.Message );
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| Specifies the number of user results in a page | [optional] [default to 1000]

### Return type

[**List&lt;User&gt;**](User.md)

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

<a name="listgroups"></a>
# **ListGroups**
> List&lt;Group&gt; ListGroups (string search = null, string filter = null, string q = null, string after = null, int? limit = null, string expand = null, string sortBy = null, string sortOrder = null)

List all groups

Lists all groups with pagination support.  > **Note:** To list all groups belonging to a member, use the [List all groups endpoint in the User Resources API](/openapi/okta-management/management/tag/UserResources/#tag/UserResources/operation/listUserGroups).  The number of groups returned depends on the specified [`limit`](/openapi/okta-management/management/tag/Group/#tag/Group/operation/listGroups!in=query&path=limit&t=request), if you have a search, filter, and/or query parameter set, and if that parameter is not null. We recommend using a limit less than or equal to 200.  A subset of groups can be returned that match a supported filter expression, query, or search criteria.  > **Note:** Results from the filter or query parameter are driven from an eventually consistent datasource. The synchronization lag is typically less than one second.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGroupsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var search = type%20eq%20%22APP_GROUP%22;  // string | Searches for groups with a supported [filtering](https://developer.okta.com/docs/api/#filter) expression for all properties except for `_embedded`, `_links`, and `objectClass`. This operation supports [pagination](https://developer.okta.com/docs/api/#pagination).  Using search requires [URL encoding](https://developer.mozilla.org/en-US/docs/Glossary/Percent-encoding), for example, `search=type eq \"OKTA_GROUP\"` is encoded as `search=type+eq+%22OKTA_GROUP%22`.  This operation searches many properties:  * Any group profile attribute, including imported app group profile attributes. * The top-level properties: `id`, `created`, `lastMembershipUpdated`, `lastUpdated`, and `type`. * The [source](/openapi/okta-management/management/tag/Group/#tag/Group/operation/listGroups!c=200&path=_links/source&t=response) of groups with type of `APP_GROUP`, accessed as `source.id`.  You can also use the `sortBy` and `sortOrder` parameters.  Searches for groups can be filtered by the following operators: `sw`, `eq`, and `co`. You can only use `co` with these select profile attributes: `profile.name` and `profile.description`. See [Operators](https://developer.okta.com/docs/api/#operators).              (optional) 
            var filter = id%20eq%20%2200g1emaKYZTWRYYRRTSK%22;  // string | Filter expression for groups. See [Filter](https://developer.okta.com/docs/api/#filter).  > **Note:** All filters must be [URL encoded](https://developer.mozilla.org/en-US/docs/Glossary/Percent-encoding). For example, `filter=lastUpdated gt \"2013-06-01T00:00:00.000Z\"` is encoded as `filter=lastUpdated%20gt%20%222013-06-01T00:00:00.000Z%22`. (optional) 
            var q = West&limit=10;  // string | Finds a group that matches the `name` property. > **Note:** Paging and searching are currently mutually exclusive. You can't page a query. The default limit for a query is 300 results. Query is intended for an auto-complete picker use case where users refine their search string to constrain the results. (optional) 
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of groups. The `after` cursor should be treated as an opaque value and obtained through the next link relation. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 56;  // int? | Specifies the number of group results in a page.  Okta recommends using a specific value other than the default or maximum. If your request times out, retry your request with a smaller `limit` and [page the results](https://developer.okta.com/docs/api/#pagination).  The Okta default `Everyone` group isn't returned for users with a group admin role. (optional) 
            var expand = "expand_example";  // string | If specified, additional metadata is included in the response. Possible values are `stats` and `app`. This additional metadata is listed in the [`_embedded`](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Group/#tag/Group/operation/addGroup!c=200&path=_embedded&t=response) property of the response.  > **Note:** You can use the `stats` value to return the number of users within a group. This is listed as the `_embedded.stats.usersCount` value in the response. See this [Knowledge Base article](https://support.okta.com/help/s/article/Is-there-an-API-that-returns-the-number-of-users-in-a-group?language=en_US) for more information and an example. (optional) 
            var sortBy = lastUpdated;  // string | Specifies field to sort by **(for search queries only)**. `sortBy` can be any single property, for example `sortBy=profile.name`. (optional) 
            var sortOrder = "\"asc\"";  // string | Specifies sort order: `asc` or `desc` (for search queries only). This parameter is ignored if `sortBy` isn't present. Groups with the same value for the `sortBy` property are ordered by `id`'. (optional)  (default to "asc")

            try
            {
                // List all groups
                List<Group> result = apiInstance.ListGroups(search, filter, q, after, limit, expand, sortBy, sortOrder).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.ListGroups: " + e.Message );
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
 **search** | **string**| Searches for groups with a supported [filtering](https://developer.okta.com/docs/api/#filter) expression for all properties except for &#x60;_embedded&#x60;, &#x60;_links&#x60;, and &#x60;objectClass&#x60;. This operation supports [pagination](https://developer.okta.com/docs/api/#pagination).  Using search requires [URL encoding](https://developer.mozilla.org/en-US/docs/Glossary/Percent-encoding), for example, &#x60;search&#x3D;type eq \&quot;OKTA_GROUP\&quot;&#x60; is encoded as &#x60;search&#x3D;type+eq+%22OKTA_GROUP%22&#x60;.  This operation searches many properties:  * Any group profile attribute, including imported app group profile attributes. * The top-level properties: &#x60;id&#x60;, &#x60;created&#x60;, &#x60;lastMembershipUpdated&#x60;, &#x60;lastUpdated&#x60;, and &#x60;type&#x60;. * The [source](/openapi/okta-management/management/tag/Group/#tag/Group/operation/listGroups!c&#x3D;200&amp;path&#x3D;_links/source&amp;t&#x3D;response) of groups with type of &#x60;APP_GROUP&#x60;, accessed as &#x60;source.id&#x60;.  You can also use the &#x60;sortBy&#x60; and &#x60;sortOrder&#x60; parameters.  Searches for groups can be filtered by the following operators: &#x60;sw&#x60;, &#x60;eq&#x60;, and &#x60;co&#x60;. You can only use &#x60;co&#x60; with these select profile attributes: &#x60;profile.name&#x60; and &#x60;profile.description&#x60;. See [Operators](https://developer.okta.com/docs/api/#operators).              | [optional] 
 **filter** | **string**| Filter expression for groups. See [Filter](https://developer.okta.com/docs/api/#filter).  &gt; **Note:** All filters must be [URL encoded](https://developer.mozilla.org/en-US/docs/Glossary/Percent-encoding). For example, &#x60;filter&#x3D;lastUpdated gt \&quot;2013-06-01T00:00:00.000Z\&quot;&#x60; is encoded as &#x60;filter&#x3D;lastUpdated%20gt%20%222013-06-01T00:00:00.000Z%22&#x60;. | [optional] 
 **q** | **string**| Finds a group that matches the &#x60;name&#x60; property. &gt; **Note:** Paging and searching are currently mutually exclusive. You can&#39;t page a query. The default limit for a query is 300 results. Query is intended for an auto-complete picker use case where users refine their search string to constrain the results. | [optional] 
 **after** | **string**| Specifies the pagination cursor for the next page of groups. The &#x60;after&#x60; cursor should be treated as an opaque value and obtained through the next link relation. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| Specifies the number of group results in a page.  Okta recommends using a specific value other than the default or maximum. If your request times out, retry your request with a smaller &#x60;limit&#x60; and [page the results](https://developer.okta.com/docs/api/#pagination).  The Okta default &#x60;Everyone&#x60; group isn&#39;t returned for users with a group admin role. | [optional] 
 **expand** | **string**| If specified, additional metadata is included in the response. Possible values are &#x60;stats&#x60; and &#x60;app&#x60;. This additional metadata is listed in the [&#x60;_embedded&#x60;](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Group/#tag/Group/operation/addGroup!c&#x3D;200&amp;path&#x3D;_embedded&amp;t&#x3D;response) property of the response.  &gt; **Note:** You can use the &#x60;stats&#x60; value to return the number of users within a group. This is listed as the &#x60;_embedded.stats.usersCount&#x60; value in the response. See this [Knowledge Base article](https://support.okta.com/help/s/article/Is-there-an-API-that-returns-the-number-of-users-in-a-group?language&#x3D;en_US) for more information and an example. | [optional] 
 **sortBy** | **string**| Specifies field to sort by **(for search queries only)**. &#x60;sortBy&#x60; can be any single property, for example &#x60;sortBy&#x3D;profile.name&#x60;. | [optional] 
 **sortOrder** | **string**| Specifies sort order: &#x60;asc&#x60; or &#x60;desc&#x60; (for search queries only). This parameter is ignored if &#x60;sortBy&#x60; isn&#39;t present. Groups with the same value for the &#x60;sortBy&#x60; property are ordered by &#x60;id&#x60;&#39;. | [optional] [default to &quot;asc&quot;]

### Return type

[**List&lt;Group&gt;**](Group.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacegroup"></a>
# **ReplaceGroup**
> Group ReplaceGroup (string groupId, AddGroupRequest group)

Replace a group

Replaces the profile for a group of `OKTA_GROUP` type from your org. > **Note :** You only can modify profiles for groups of the `OKTA_GROUP` type. > > App imports are responsible for updating profiles for groups of the `APP_GROUP` type, such as Active Directory groups.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var group = new AddGroupRequest(); // AddGroupRequest | 

            try
            {
                // Replace a group
                Group result = apiInstance.ReplaceGroup(groupId, group);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.ReplaceGroup: " + e.Message );
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 
 **group** | [**AddGroupRequest**](AddGroupRequest.md)|  | 

### Return type

[**Group**](Group.md)

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

<a name="unassignuserfromgroup"></a>
# **UnassignUserFromGroup**
> void UnassignUserFromGroup (string groupId, string userId)

Unassign a user from a group

Unassigns a user from a group with the `OKTA_GROUP` type. > **Note:** You only can modify memberships for groups of the `OKTA_GROUP` type. > > App imports are responsible for managing group memberships for groups of the `APP_GROUP` type, such as Active Directory groups.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnassignUserFromGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // Unassign a user from a group
                apiInstance.UnassignUserFromGroup(groupId, userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.UnassignUserFromGroup: " + e.Message );
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 
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
| **204** | No Content |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

