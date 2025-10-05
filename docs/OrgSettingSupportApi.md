# Okta.Sdk.Api.OrgSettingSupportApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ExtendOktaSupport**](OrgSettingSupportApi.md#extendoktasupport) | **POST** /api/v1/org/privacy/oktaSupport/extend | Extend Okta Support access
[**GetAerialConsent**](OrgSettingSupportApi.md#getaerialconsent) | **GET** /api/v1/org/privacy/aerial | Retrieve Okta Aerial consent for your org
[**GetOrgOktaSupportSettings**](OrgSettingSupportApi.md#getorgoktasupportsettings) | **GET** /api/v1/org/privacy/oktaSupport | Retrieve the Okta Support settings
[**GrantAerialConsent**](OrgSettingSupportApi.md#grantaerialconsent) | **POST** /api/v1/org/privacy/aerial/grant | Grant Okta Aerial access to your org
[**GrantOktaSupport**](OrgSettingSupportApi.md#grantoktasupport) | **POST** /api/v1/org/privacy/oktaSupport/grant | Grant Okta Support access
[**ListOktaSupportCases**](OrgSettingSupportApi.md#listoktasupportcases) | **GET** /api/v1/org/privacy/oktaSupport/cases | List all Okta Support cases
[**RevokeAerialConsent**](OrgSettingSupportApi.md#revokeaerialconsent) | **POST** /api/v1/org/privacy/aerial/revoke | Revoke Okta Aerial access to your org
[**RevokeOktaSupport**](OrgSettingSupportApi.md#revokeoktasupport) | **POST** /api/v1/org/privacy/oktaSupport/revoke | Revoke Okta Support access
[**UpdateOktaSupportCase**](OrgSettingSupportApi.md#updateoktasupportcase) | **PATCH** /api/v1/org/privacy/oktaSupport/cases/{caseNumber} | Update an Okta Support case


<a name="extendoktasupport"></a>
# **ExtendOktaSupport**
> void ExtendOktaSupport ()

Extend Okta Support access

Extends the length of time that Okta Support can access your org by 24 hours. This means that 24 hours are added to the remaining access time.  > **Note:** This resource is deprecated. Use the [Update an Okta Support case](/openapi/okta-management/management/tag/OrgSettingSupport/#tag/OrgSettingSupport/operation/updateOktaSupportCase) resource to extend Okta Support access for a support case. > For the corresponding Okta Admin Console feature, see [Give access to Okta Support](https://help.okta.com/okta_help.htm?type=oie&id=settings-support-access).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ExtendOktaSupportExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingSupportApi(config);

            try
            {
                // Extend Okta Support access
                apiInstance.ExtendOktaSupport();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingSupportApi.ExtendOktaSupport: " + e.Message );
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

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **301** | Moved Permanently |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getaerialconsent"></a>
# **GetAerialConsent**
> OrgAerialConsentDetails GetAerialConsent ()

Retrieve Okta Aerial consent for your org

Retrieves the Okta Aerial consent grant details for your Org. Returns a 404 Not Found error if no consent has been granted.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAerialConsentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingSupportApi(config);

            try
            {
                // Retrieve Okta Aerial consent for your org
                OrgAerialConsentDetails result = apiInstance.GetAerialConsent();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingSupportApi.GetAerialConsent: " + e.Message );
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

[**OrgAerialConsentDetails**](OrgAerialConsentDetails.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Can&#39;t complete request due to errors |  -  |
| **403** | Forbidden |  -  |
| **404** | Consent hasn&#39;t been given and there are no grants to any Aerial Accounts |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getorgoktasupportsettings"></a>
# **GetOrgOktaSupportSettings**
> OrgOktaSupportSettingsObj GetOrgOktaSupportSettings ()

Retrieve the Okta Support settings

Retrieves Okta Support Settings for your org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetOrgOktaSupportSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingSupportApi(config);

            try
            {
                // Retrieve the Okta Support settings
                OrgOktaSupportSettingsObj result = apiInstance.GetOrgOktaSupportSettings();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingSupportApi.GetOrgOktaSupportSettings: " + e.Message );
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

[**OrgOktaSupportSettingsObj**](OrgOktaSupportSettingsObj.md)

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

<a name="grantaerialconsent"></a>
# **GrantAerialConsent**
> OrgAerialConsentDetails GrantAerialConsent (OrgAerialConsent orgAerialConsent = null)

Grant Okta Aerial access to your org

Grants an Okta Aerial account consent to manage your org. If the org is a child org, consent is taken from the parent org. Grant calls directly to the child are not allowed.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GrantAerialConsentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingSupportApi(config);
            var orgAerialConsent = new OrgAerialConsent(); // OrgAerialConsent |  (optional) 

            try
            {
                // Grant Okta Aerial access to your org
                OrgAerialConsentDetails result = apiInstance.GrantAerialConsent(orgAerialConsent);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingSupportApi.GrantAerialConsent: " + e.Message );
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
 **orgAerialConsent** | [**OrgAerialConsent**](OrgAerialConsent.md)|  | [optional] 

### Return type

[**OrgAerialConsentDetails**](OrgAerialConsentDetails.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Can&#39;t complete request due to errors |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="grantoktasupport"></a>
# **GrantOktaSupport**
> void GrantOktaSupport ()

Grant Okta Support access

Grants Okta Support temporary access to your org as an administrator for eight hours  > **Note:** This resource is deprecated. Use the [Update an Okta Support case](/openapi/okta-management/management/tag/OrgSettingSupport/#tag/OrgSettingSupport/operation/updateOktaSupportCase) resource to grant Okta Support access for a support case. > For the corresponding Okta Admin Console feature, see [Give access to Okta Support](https://help.okta.com/okta_help.htm?type=oie&id=settings-support-access).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GrantOktaSupportExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingSupportApi(config);

            try
            {
                // Grant Okta Support access
                apiInstance.GrantOktaSupport();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingSupportApi.GrantOktaSupport: " + e.Message );
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

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **301** | Moved Permanently |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listoktasupportcases"></a>
# **ListOktaSupportCases**
> OktaSupportCases ListOktaSupportCases ()

List all Okta Support cases

Lists all Okta Support cases that the requesting principal has permission to view

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListOktaSupportCasesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingSupportApi(config);

            try
            {
                // List all Okta Support cases
                OktaSupportCases result = apiInstance.ListOktaSupportCases();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingSupportApi.ListOktaSupportCases: " + e.Message );
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

[**OktaSupportCases**](OktaSupportCases.md)

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

<a name="revokeaerialconsent"></a>
# **RevokeAerialConsent**
> OrgAerialConsentRevoked RevokeAerialConsent (OrgAerialConsent orgAerialConsent = null)

Revoke Okta Aerial access to your org

Revokes access of an Okta Aerial account to your Org. The revoke operation will fail if the org has already been added to an Aerial account.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeAerialConsentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingSupportApi(config);
            var orgAerialConsent = new OrgAerialConsent(); // OrgAerialConsent |  (optional) 

            try
            {
                // Revoke Okta Aerial access to your org
                OrgAerialConsentRevoked result = apiInstance.RevokeAerialConsent(orgAerialConsent);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingSupportApi.RevokeAerialConsent: " + e.Message );
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
 **orgAerialConsent** | [**OrgAerialConsent**](OrgAerialConsent.md)|  | [optional] 

### Return type

[**OrgAerialConsentRevoked**](OrgAerialConsentRevoked.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Can&#39;t complete request due to errors |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="revokeoktasupport"></a>
# **RevokeOktaSupport**
> void RevokeOktaSupport ()

Revoke Okta Support access

Revokes Okta Support access to your org  > **Note:** This resource is deprecated. Use the [Update an Okta Support case](/openapi/okta-management/management/tag/OrgSettingSupport/#tag/OrgSettingSupport/operation/updateOktaSupportCase) resource to revoke Okta Support access for a support case. > For the corresponding Okta Admin Console feature, see [Give access to Okta Support](https://help.okta.com/okta_help.htm?type=oie&id=settings-support-access).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeOktaSupportExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingSupportApi(config);

            try
            {
                // Revoke Okta Support access
                apiInstance.RevokeOktaSupport();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingSupportApi.RevokeOktaSupport: " + e.Message );
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

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **301** | Moved Permanently |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateoktasupportcase"></a>
# **UpdateOktaSupportCase**
> OktaSupportCase UpdateOktaSupportCase (string caseNumber, OktaSupportCase oktaSupportCase = null)

Update an Okta Support case

Updates access to the org for an Okta Support case:  * You can enable, disable, or extend access to your org for an Okta Support case.  * You can approve Okta Support access to your org for self-assigned cases. A self-assigned case is created and assigned by the same Okta Support user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateOktaSupportCaseExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingSupportApi(config);
            var caseNumber = 00000144;  // string | 
            var oktaSupportCase = new OktaSupportCase(); // OktaSupportCase |  (optional) 

            try
            {
                // Update an Okta Support case
                OktaSupportCase result = apiInstance.UpdateOktaSupportCase(caseNumber, oktaSupportCase);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingSupportApi.UpdateOktaSupportCase: " + e.Message );
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
 **caseNumber** | **string**|  | 
 **oktaSupportCase** | [**OktaSupportCase**](OktaSupportCase.md)|  | [optional] 

### Return type

[**OktaSupportCase**](OktaSupportCase.md)

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

