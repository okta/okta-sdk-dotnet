# Okta.Sdk.Api.GovernanceBundleApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateGovernanceBundle**](GovernanceBundleApi.md#creategovernancebundle) | **POST** /api/v1/iam/governance/bundles | Create a governance bundle for the Admin Console in RAMP
[**DeleteGovernanceBundle**](GovernanceBundleApi.md#deletegovernancebundle) | **DELETE** /api/v1/iam/governance/bundles/{bundleId} | Delete a governance bundle from RAMP
[**GetGovernanceBundle**](GovernanceBundleApi.md#getgovernancebundle) | **GET** /api/v1/iam/governance/bundles/{bundleId} | Retrieve a governance bundle from RAMP
[**GetOptInStatus**](GovernanceBundleApi.md#getoptinstatus) | **GET** /api/v1/iam/governance/optIn | Retrieve the opt-in status from RAMP
[**ListBundleEntitlementValues**](GovernanceBundleApi.md#listbundleentitlementvalues) | **GET** /api/v1/iam/governance/bundles/{bundleId}/entitlements/{entitlementId}/values | List all entitlement values for a bundle entitlement
[**ListBundleEntitlements**](GovernanceBundleApi.md#listbundleentitlements) | **GET** /api/v1/iam/governance/bundles/{bundleId}/entitlements | List all entitlements for a governance bundle
[**ListGovernanceBundles**](GovernanceBundleApi.md#listgovernancebundles) | **GET** /api/v1/iam/governance/bundles | List all governance bundles for the Admin Console
[**OptIn**](GovernanceBundleApi.md#optin) | **POST** /api/v1/iam/governance/optIn | Opt in the Admin Console to RAMP
[**OptOut**](GovernanceBundleApi.md#optout) | **POST** /api/v1/iam/governance/optOut | Opt out the Admin Console from RAMP
[**ReplaceGovernanceBundle**](GovernanceBundleApi.md#replacegovernancebundle) | **PUT** /api/v1/iam/governance/bundles/{bundleId} | Replace a governance bundle in RAMP


<a name="creategovernancebundle"></a>
# **CreateGovernanceBundle**
> GovernanceBundle CreateGovernanceBundle (GovernanceBundleCreateRequest governanceBundleCreateRequest)

Create a governance bundle for the Admin Console in RAMP

Creates a Governance Bundle for the Admin Console in RAMP

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateGovernanceBundleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GovernanceBundleApi(config);
            var governanceBundleCreateRequest = new GovernanceBundleCreateRequest(); // GovernanceBundleCreateRequest | 

            try
            {
                // Create a governance bundle for the Admin Console in RAMP
                GovernanceBundle result = apiInstance.CreateGovernanceBundle(governanceBundleCreateRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GovernanceBundleApi.CreateGovernanceBundle: " + e.Message );
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
 **governanceBundleCreateRequest** | [**GovernanceBundleCreateRequest**](GovernanceBundleCreateRequest.md)|  | 

### Return type

[**GovernanceBundle**](GovernanceBundle.md)

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

<a name="deletegovernancebundle"></a>
# **DeleteGovernanceBundle**
> void DeleteGovernanceBundle (string bundleId)

Delete a governance bundle from RAMP

Deletes a Governance Bundle from RAMP

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteGovernanceBundleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GovernanceBundleApi(config);
            var bundleId = enbllojq9J9J105DL1d6;  // string | The `id` of a bundle

            try
            {
                // Delete a governance bundle from RAMP
                apiInstance.DeleteGovernanceBundle(bundleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GovernanceBundleApi.DeleteGovernanceBundle: " + e.Message );
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
 **bundleId** | **string**| The &#x60;id&#x60; of a bundle | 

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getgovernancebundle"></a>
# **GetGovernanceBundle**
> GovernanceBundle GetGovernanceBundle (string bundleId)

Retrieve a governance bundle from RAMP

Retrieves a Governance Bundle from RAMP

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetGovernanceBundleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GovernanceBundleApi(config);
            var bundleId = enbllojq9J9J105DL1d6;  // string | The `id` of a bundle

            try
            {
                // Retrieve a governance bundle from RAMP
                GovernanceBundle result = apiInstance.GetGovernanceBundle(bundleId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GovernanceBundleApi.GetGovernanceBundle: " + e.Message );
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
 **bundleId** | **string**| The &#x60;id&#x60; of a bundle | 

### Return type

[**GovernanceBundle**](GovernanceBundle.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getoptinstatus"></a>
# **GetOptInStatus**
> OptInStatusResponse GetOptInStatus ()

Retrieve the opt-in status from RAMP

Retrieves the opt-in status of the Admin Console from RAMP

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetOptInStatusExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GovernanceBundleApi(config);

            try
            {
                // Retrieve the opt-in status from RAMP
                OptInStatusResponse result = apiInstance.GetOptInStatus();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GovernanceBundleApi.GetOptInStatus: " + e.Message );
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

[**OptInStatusResponse**](OptInStatusResponse.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listbundleentitlementvalues"></a>
# **ListBundleEntitlementValues**
> EntitlementValuesResponse ListBundleEntitlementValues (string bundleId, string entitlementId, string after = null, int? limit = null)

List all entitlement values for a bundle entitlement

Lists all Entitlement Values specific to a Bundle Entitlement

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListBundleEntitlementValuesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GovernanceBundleApi(config);
            var bundleId = enbllojq9J9J105DL1d6;  // string | The `id` of a bundle
            var entitlementId = ent4rg7fltWSgrlDT8g6;  // string | The `id` of a bundle entitlement
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)

            try
            {
                // List all entitlement values for a bundle entitlement
                EntitlementValuesResponse result = apiInstance.ListBundleEntitlementValues(bundleId, entitlementId, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GovernanceBundleApi.ListBundleEntitlementValues: " + e.Message );
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
 **bundleId** | **string**| The &#x60;id&#x60; of a bundle | 
 **entitlementId** | **string**| The &#x60;id&#x60; of a bundle entitlement | 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]

### Return type

[**EntitlementValuesResponse**](EntitlementValuesResponse.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listbundleentitlements"></a>
# **ListBundleEntitlements**
> BundleEntitlementsResponse ListBundleEntitlements (string bundleId, string after = null, int? limit = null)

List all entitlements for a governance bundle

Lists all Entitlements specific to a Governance Bundle

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListBundleEntitlementsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GovernanceBundleApi(config);
            var bundleId = enbllojq9J9J105DL1d6;  // string | The `id` of a bundle
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)

            try
            {
                // List all entitlements for a governance bundle
                BundleEntitlementsResponse result = apiInstance.ListBundleEntitlements(bundleId, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GovernanceBundleApi.ListBundleEntitlements: " + e.Message );
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
 **bundleId** | **string**| The &#x60;id&#x60; of a bundle | 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]

### Return type

[**BundleEntitlementsResponse**](BundleEntitlementsResponse.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listgovernancebundles"></a>
# **ListGovernanceBundles**
> GovernanceBundlesResponse ListGovernanceBundles (string after = null, int? limit = null)

List all governance bundles for the Admin Console

Lists all Governance Bundles for the Admin Console in your org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGovernanceBundlesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GovernanceBundleApi(config);
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)

            try
            {
                // List all governance bundles for the Admin Console
                GovernanceBundlesResponse result = apiInstance.ListGovernanceBundles(after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GovernanceBundleApi.ListGovernanceBundles: " + e.Message );
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]

### Return type

[**GovernanceBundlesResponse**](GovernanceBundlesResponse.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="optin"></a>
# **OptIn**
> OptInStatusResponse OptIn ()

Opt in the Admin Console to RAMP

Opts in the Admin Console to RAMP

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class OptInExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GovernanceBundleApi(config);

            try
            {
                // Opt in the Admin Console to RAMP
                OptInStatusResponse result = apiInstance.OptIn();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GovernanceBundleApi.OptIn: " + e.Message );
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

[**OptInStatusResponse**](OptInStatusResponse.md)

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

<a name="optout"></a>
# **OptOut**
> OptInStatusResponse OptOut ()

Opt out the Admin Console from RAMP

Opts out the Admin Console from RAMP

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class OptOutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GovernanceBundleApi(config);

            try
            {
                // Opt out the Admin Console from RAMP
                OptInStatusResponse result = apiInstance.OptOut();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GovernanceBundleApi.OptOut: " + e.Message );
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

[**OptInStatusResponse**](OptInStatusResponse.md)

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

<a name="replacegovernancebundle"></a>
# **ReplaceGovernanceBundle**
> GovernanceBundle ReplaceGovernanceBundle (string bundleId, GovernanceBundleUpdateRequest governanceBundleUpdateRequest)

Replace a governance bundle in RAMP

Replaces a Governance Bundle in RAMP

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceGovernanceBundleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GovernanceBundleApi(config);
            var bundleId = enbllojq9J9J105DL1d6;  // string | The `id` of a bundle
            var governanceBundleUpdateRequest = new GovernanceBundleUpdateRequest(); // GovernanceBundleUpdateRequest | 

            try
            {
                // Replace a governance bundle in RAMP
                GovernanceBundle result = apiInstance.ReplaceGovernanceBundle(bundleId, governanceBundleUpdateRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GovernanceBundleApi.ReplaceGovernanceBundle: " + e.Message );
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
 **bundleId** | **string**| The &#x60;id&#x60; of a bundle | 
 **governanceBundleUpdateRequest** | [**GovernanceBundleUpdateRequest**](GovernanceBundleUpdateRequest.md)|  | 

### Return type

[**GovernanceBundle**](GovernanceBundle.md)

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

