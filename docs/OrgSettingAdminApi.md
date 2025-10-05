# Okta.Sdk.Api.OrgSettingAdminApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignClientPrivilegesSetting**](OrgSettingAdminApi.md#assignclientprivilegessetting) | **PUT** /api/v1/org/settings/clientPrivilegesSetting | Assign the default public client app role setting
[**GetAutoAssignAdminAppSetting**](OrgSettingAdminApi.md#getautoassignadminappsetting) | **GET** /api/v1/org/settings/autoAssignAdminAppSetting | Retrieve the Okta Admin Console assignment setting
[**GetClientPrivilegesSetting**](OrgSettingAdminApi.md#getclientprivilegessetting) | **GET** /api/v1/org/settings/clientPrivilegesSetting | Retrieve the default public client app role setting
[**GetThirdPartyAdminSetting**](OrgSettingAdminApi.md#getthirdpartyadminsetting) | **GET** /api/v1/org/orgSettings/thirdPartyAdminSetting | Retrieve the org third-party admin setting
[**UpdateAutoAssignAdminAppSetting**](OrgSettingAdminApi.md#updateautoassignadminappsetting) | **POST** /api/v1/org/settings/autoAssignAdminAppSetting | Update the Okta Admin Console assignment setting
[**UpdateThirdPartyAdminSetting**](OrgSettingAdminApi.md#updatethirdpartyadminsetting) | **POST** /api/v1/org/orgSettings/thirdPartyAdminSetting | Update the org third-party admin setting


<a name="assignclientprivilegessetting"></a>
# **AssignClientPrivilegesSetting**
> ClientPrivilegesSetting AssignClientPrivilegesSetting (ClientPrivilegesSetting clientPrivilegesSetting = null)

Assign the default public client app role setting

Assigns the [Super Admin role](https://help.okta.com/okta_help.htm?type=oie&id=ext_superadmin) as the default role for new public client apps

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignClientPrivilegesSettingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingAdminApi(config);
            var clientPrivilegesSetting = new ClientPrivilegesSetting(); // ClientPrivilegesSetting |  (optional) 

            try
            {
                // Assign the default public client app role setting
                ClientPrivilegesSetting result = apiInstance.AssignClientPrivilegesSetting(clientPrivilegesSetting);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingAdminApi.AssignClientPrivilegesSetting: " + e.Message );
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
 **clientPrivilegesSetting** | [**ClientPrivilegesSetting**](ClientPrivilegesSetting.md)|  | [optional] 

### Return type

[**ClientPrivilegesSetting**](ClientPrivilegesSetting.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getautoassignadminappsetting"></a>
# **GetAutoAssignAdminAppSetting**
> AutoAssignAdminAppSetting GetAutoAssignAdminAppSetting ()

Retrieve the Okta Admin Console assignment setting

Retrieves the org setting to automatically assign the Okta Admin Console when an admin role is assigned

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAutoAssignAdminAppSettingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingAdminApi(config);

            try
            {
                // Retrieve the Okta Admin Console assignment setting
                AutoAssignAdminAppSetting result = apiInstance.GetAutoAssignAdminAppSetting();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingAdminApi.GetAutoAssignAdminAppSetting: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**AutoAssignAdminAppSetting**](AutoAssignAdminAppSetting.md)

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

<a name="getclientprivilegessetting"></a>
# **GetClientPrivilegesSetting**
> ClientPrivilegesSetting GetClientPrivilegesSetting ()

Retrieve the default public client app role setting

Retrieves the org setting to assign the [Super Admin role](https://help.okta.com/okta_help.htm?type=oie&id=ext_superadmin) to new public client apps

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetClientPrivilegesSettingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingAdminApi(config);

            try
            {
                // Retrieve the default public client app role setting
                ClientPrivilegesSetting result = apiInstance.GetClientPrivilegesSetting();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingAdminApi.GetClientPrivilegesSetting: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**ClientPrivilegesSetting**](ClientPrivilegesSetting.md)

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

<a name="getthirdpartyadminsetting"></a>
# **GetThirdPartyAdminSetting**
> ThirdPartyAdminSetting GetThirdPartyAdminSetting ()

Retrieve the org third-party admin setting

Retrieves the third-party admin setting. See [Configure third-party administrators](https://help.okta.com/okta_help.htm?type=oie&id=csh_admin-third) in the Okta product documentation.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetThirdPartyAdminSettingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingAdminApi(config);

            try
            {
                // Retrieve the org third-party admin setting
                ThirdPartyAdminSetting result = apiInstance.GetThirdPartyAdminSetting();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingAdminApi.GetThirdPartyAdminSetting: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**ThirdPartyAdminSetting**](ThirdPartyAdminSetting.md)

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

<a name="updateautoassignadminappsetting"></a>
# **UpdateAutoAssignAdminAppSetting**
> AutoAssignAdminAppSetting UpdateAutoAssignAdminAppSetting (AutoAssignAdminAppSetting autoAssignAdminAppSetting = null)

Update the Okta Admin Console assignment setting

Updates the org setting to automatically assign the Okta Admin Console when an admin role is assigned  > **Note:** This setting doesn't apply to the `SUPER_ADMIN` role. > When you assign the `SUPER_ADMIN` role to a user, the Admin Console is always assigned to the user regardless of the `autoAssignAdminAppSetting` setting.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateAutoAssignAdminAppSettingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingAdminApi(config);
            var autoAssignAdminAppSetting = new AutoAssignAdminAppSetting(); // AutoAssignAdminAppSetting |  (optional) 

            try
            {
                // Update the Okta Admin Console assignment setting
                AutoAssignAdminAppSetting result = apiInstance.UpdateAutoAssignAdminAppSetting(autoAssignAdminAppSetting);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingAdminApi.UpdateAutoAssignAdminAppSetting: " + e.Message );
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
 **autoAssignAdminAppSetting** | [**AutoAssignAdminAppSetting**](AutoAssignAdminAppSetting.md)|  | [optional] 

### Return type

[**AutoAssignAdminAppSetting**](AutoAssignAdminAppSetting.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatethirdpartyadminsetting"></a>
# **UpdateThirdPartyAdminSetting**
> ThirdPartyAdminSetting UpdateThirdPartyAdminSetting (ThirdPartyAdminSetting thirdPartyAdminSetting)

Update the org third-party admin setting

Updates the third-party admin setting. This setting allows third-party admins to perform administrative actions in the Admin Console, but they can't do any of the following:   * Receive Okta admin email notifications   * Contact Okta support   * Sign in to the Okta Help Center  See [Configure third-party administrators](https://help.okta.com/okta_help.htm?type=oie&id=csh_admin-third) in the Okta product documentation. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateThirdPartyAdminSettingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingAdminApi(config);
            var thirdPartyAdminSetting = new ThirdPartyAdminSetting(); // ThirdPartyAdminSetting | 

            try
            {
                // Update the org third-party admin setting
                ThirdPartyAdminSetting result = apiInstance.UpdateThirdPartyAdminSetting(thirdPartyAdminSetting);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingAdminApi.UpdateThirdPartyAdminSetting: " + e.Message );
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
 **thirdPartyAdminSetting** | [**ThirdPartyAdminSetting**](ThirdPartyAdminSetting.md)|  | 

### Return type

[**ThirdPartyAdminSetting**](ThirdPartyAdminSetting.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

