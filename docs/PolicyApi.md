# Okta.Sdk.Api.PolicyApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivatePolicy**](PolicyApi.md#activatepolicy) | **POST** /api/v1/policies/{policyId}/lifecycle/activate | Activate a policy
[**ActivatePolicyRule**](PolicyApi.md#activatepolicyrule) | **POST** /api/v1/policies/{policyId}/rules/{ruleId}/lifecycle/activate | Activate a policy rule
[**ClonePolicy**](PolicyApi.md#clonepolicy) | **POST** /api/v1/policies/{policyId}/clone | Clone an existing policy
[**CreatePolicy**](PolicyApi.md#createpolicy) | **POST** /api/v1/policies | Create a policy
[**CreatePolicyRule**](PolicyApi.md#createpolicyrule) | **POST** /api/v1/policies/{policyId}/rules | Create a policy rule
[**CreatePolicySimulation**](PolicyApi.md#createpolicysimulation) | **POST** /api/v1/policies/simulate | Create a policy simulation
[**DeactivatePolicy**](PolicyApi.md#deactivatepolicy) | **POST** /api/v1/policies/{policyId}/lifecycle/deactivate | Deactivate a policy
[**DeactivatePolicyRule**](PolicyApi.md#deactivatepolicyrule) | **POST** /api/v1/policies/{policyId}/rules/{ruleId}/lifecycle/deactivate | Deactivate a policy rule
[**DeletePolicy**](PolicyApi.md#deletepolicy) | **DELETE** /api/v1/policies/{policyId} | Delete a policy
[**DeletePolicyResourceMapping**](PolicyApi.md#deletepolicyresourcemapping) | **DELETE** /api/v1/policies/{policyId}/mappings/{mappingId} | Delete a policy resource mapping
[**DeletePolicyRule**](PolicyApi.md#deletepolicyrule) | **DELETE** /api/v1/policies/{policyId}/rules/{ruleId} | Delete a policy rule
[**GetPolicy**](PolicyApi.md#getpolicy) | **GET** /api/v1/policies/{policyId} | Retrieve a policy
[**GetPolicyMapping**](PolicyApi.md#getpolicymapping) | **GET** /api/v1/policies/{policyId}/mappings/{mappingId} | Retrieve a policy resource mapping
[**GetPolicyRule**](PolicyApi.md#getpolicyrule) | **GET** /api/v1/policies/{policyId}/rules/{ruleId} | Retrieve a policy rule
[**ListPolicies**](PolicyApi.md#listpolicies) | **GET** /api/v1/policies | List all policies
[**ListPolicyApps**](PolicyApi.md#listpolicyapps) | **GET** /api/v1/policies/{policyId}/app | List all apps mapped to a policy
[**ListPolicyMappings**](PolicyApi.md#listpolicymappings) | **GET** /api/v1/policies/{policyId}/mappings | List all resources mapped to a policy
[**ListPolicyRules**](PolicyApi.md#listpolicyrules) | **GET** /api/v1/policies/{policyId}/rules | List all policy rules
[**MapResourceToPolicy**](PolicyApi.md#mapresourcetopolicy) | **POST** /api/v1/policies/{policyId}/mappings | Map a resource to a policy
[**ReplacePolicy**](PolicyApi.md#replacepolicy) | **PUT** /api/v1/policies/{policyId} | Replace a policy
[**ReplacePolicyRule**](PolicyApi.md#replacepolicyrule) | **PUT** /api/v1/policies/{policyId}/rules/{ruleId} | Replace a policy rule


<a name="activatepolicy"></a>
# **ActivatePolicy**
> void ActivatePolicy (string policyId)

Activate a policy

Activates a policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivatePolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy

            try
            {
                // Activate a policy
                apiInstance.ActivatePolicy(policyId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.ActivatePolicy: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 

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

<a name="activatepolicyrule"></a>
# **ActivatePolicyRule**
> void ActivatePolicyRule (string policyId, string ruleId)

Activate a policy rule

Activates a policy rule identified by `policyId` and `ruleId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivatePolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var ruleId = ruld3hJ7jZh4fn0st0g3;  // string | `id` of the policy rule

            try
            {
                // Activate a policy rule
                apiInstance.ActivatePolicyRule(policyId, ruleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.ActivatePolicyRule: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **ruleId** | **string**| &#x60;id&#x60; of the policy rule | 

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

<a name="clonepolicy"></a>
# **ClonePolicy**
> Policy ClonePolicy (string policyId)

Clone an existing policy

Clones an existing policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ClonePolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy

            try
            {
                // Clone an existing policy
                Policy result = apiInstance.ClonePolicy(policyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.ClonePolicy: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 

### Return type

[**Policy**](Policy.md)

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

<a name="createpolicy"></a>
# **CreatePolicy**
> Policy CreatePolicy (CreateOrUpdatePolicy policy, bool? activate = null)

Create a policy

Creates a policy. There are many types of policies that you can create. See [Policies](https://developer.okta.com/docs/concepts/policies/) for an overview of the types of policies available and links to more indepth information.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreatePolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policy = new CreateOrUpdatePolicy(); // CreateOrUpdatePolicy | 
            var activate = true;  // bool? | This query parameter is only valid for Classic Engine orgs. (optional)  (default to true)

            try
            {
                // Create a policy
                Policy result = apiInstance.CreatePolicy(policy, activate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.CreatePolicy: " + e.Message );
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
 **policy** | [**CreateOrUpdatePolicy**](CreateOrUpdatePolicy.md)|  | 
 **activate** | **bool?**| This query parameter is only valid for Classic Engine orgs. | [optional] [default to true]

### Return type

[**Policy**](Policy.md)

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

<a name="createpolicyrule"></a>
# **CreatePolicyRule**
> PolicyRule CreatePolicyRule (string policyId, PolicyRule policyRule, string limit = null, bool? activate = null)

Create a policy rule

Creates a policy rule  > **Note:** You can't create additional rules for the `PROFILE_ENROLLMENT` or `POST_AUTH_SESSION` policies.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreatePolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var policyRule = new PolicyRule(); // PolicyRule | 
            var limit = "limit_example";  // string | Defines the number of policy rules returned. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var activate = true;  // bool? | Set this parameter to `false` to create an `INACTIVE` rule. (optional)  (default to true)

            try
            {
                // Create a policy rule
                PolicyRule result = apiInstance.CreatePolicyRule(policyId, policyRule, limit, activate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.CreatePolicyRule: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **policyRule** | [**PolicyRule**](PolicyRule.md)|  | 
 **limit** | **string**| Defines the number of policy rules returned. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **activate** | **bool?**| Set this parameter to &#x60;false&#x60; to create an &#x60;INACTIVE&#x60; rule. | [optional] [default to true]

### Return type

[**PolicyRule**](PolicyRule.md)

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

<a name="createpolicysimulation"></a>
# **CreatePolicySimulation**
> List&lt;SimulatePolicyEvaluations&gt; CreatePolicySimulation (List<SimulatePolicyBody> simulatePolicy, string expand = null)

Create a policy simulation

Creates a policy or policy rule simulation. The access simulation evaluates policy and policy rules based on the existing policy rule configuration. The evaluation result simulates what the real-world authentication flow is and what policy rules have been applied or matched to the authentication flow.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreatePolicySimulationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var simulatePolicy = new List<SimulatePolicyBody>(); // List<SimulatePolicyBody> | 
            var expand = EVALUATED;  // string | Use `expand=EVALUATED` to include a list of evaluated but not matched policies and policy rules. Use `expand=RULE` to include details about why a rule condition wasn't matched. (optional) 

            try
            {
                // Create a policy simulation
                List<SimulatePolicyEvaluations> result = apiInstance.CreatePolicySimulation(simulatePolicy, expand).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.CreatePolicySimulation: " + e.Message );
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
 **simulatePolicy** | [**List&lt;SimulatePolicyBody&gt;**](SimulatePolicyBody.md)|  | 
 **expand** | **string**| Use &#x60;expand&#x3D;EVALUATED&#x60; to include a list of evaluated but not matched policies and policy rules. Use &#x60;expand&#x3D;RULE&#x60; to include details about why a rule condition wasn&#39;t matched. | [optional] 

### Return type

[**List&lt;SimulatePolicyEvaluations&gt;**](SimulatePolicyEvaluations.md)

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
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivatepolicy"></a>
# **DeactivatePolicy**
> void DeactivatePolicy (string policyId)

Deactivate a policy

Deactivates a policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivatePolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy

            try
            {
                // Deactivate a policy
                apiInstance.DeactivatePolicy(policyId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.DeactivatePolicy: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 

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

<a name="deactivatepolicyrule"></a>
# **DeactivatePolicyRule**
> void DeactivatePolicyRule (string policyId, string ruleId)

Deactivate a policy rule

Deactivates a policy rule identified by `policyId` and `ruleId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivatePolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var ruleId = ruld3hJ7jZh4fn0st0g3;  // string | `id` of the policy rule

            try
            {
                // Deactivate a policy rule
                apiInstance.DeactivatePolicyRule(policyId, ruleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.DeactivatePolicyRule: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **ruleId** | **string**| &#x60;id&#x60; of the policy rule | 

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

<a name="deletepolicy"></a>
# **DeletePolicy**
> void DeletePolicy (string policyId)

Delete a policy

Deletes a policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeletePolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy

            try
            {
                // Delete a policy
                apiInstance.DeletePolicy(policyId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.DeletePolicy: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 

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

<a name="deletepolicyresourcemapping"></a>
# **DeletePolicyResourceMapping**
> void DeletePolicyResourceMapping (string policyId, string mappingId)

Delete a policy resource mapping

Deletes the resource mapping for a policy identified by `policyId` and `mappingId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeletePolicyResourceMappingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var mappingId = maplr2rLjZ6NsGn1P0g3;  // string | `id` of the policy resource Mapping

            try
            {
                // Delete a policy resource mapping
                apiInstance.DeletePolicyResourceMapping(policyId, mappingId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.DeletePolicyResourceMapping: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **mappingId** | **string**| &#x60;id&#x60; of the policy resource Mapping | 

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

<a name="deletepolicyrule"></a>
# **DeletePolicyRule**
> void DeletePolicyRule (string policyId, string ruleId)

Delete a policy rule

Deletes a policy rule identified by `policyId` and `ruleId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeletePolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var ruleId = ruld3hJ7jZh4fn0st0g3;  // string | `id` of the policy rule

            try
            {
                // Delete a policy rule
                apiInstance.DeletePolicyRule(policyId, ruleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.DeletePolicyRule: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **ruleId** | **string**| &#x60;id&#x60; of the policy rule | 

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

<a name="getpolicy"></a>
# **GetPolicy**
> Policy GetPolicy (string policyId, string expand = null)

Retrieve a policy

Retrieves a policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetPolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var expand = "\"\"";  // string |  (optional)  (default to "")

            try
            {
                // Retrieve a policy
                Policy result = apiInstance.GetPolicy(policyId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.GetPolicy: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **expand** | **string**|  | [optional] [default to &quot;&quot;]

### Return type

[**Policy**](Policy.md)

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

<a name="getpolicymapping"></a>
# **GetPolicyMapping**
> PolicyMapping GetPolicyMapping (string policyId, string mappingId)

Retrieve a policy resource mapping

Retrieves a resource mapping for a policy identified by `policyId` and `mappingId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetPolicyMappingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var mappingId = maplr2rLjZ6NsGn1P0g3;  // string | `id` of the policy resource Mapping

            try
            {
                // Retrieve a policy resource mapping
                PolicyMapping result = apiInstance.GetPolicyMapping(policyId, mappingId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.GetPolicyMapping: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **mappingId** | **string**| &#x60;id&#x60; of the policy resource Mapping | 

### Return type

[**PolicyMapping**](PolicyMapping.md)

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

<a name="getpolicyrule"></a>
# **GetPolicyRule**
> PolicyRule GetPolicyRule (string policyId, string ruleId)

Retrieve a policy rule

Retrieves a policy rule

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetPolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var ruleId = ruld3hJ7jZh4fn0st0g3;  // string | `id` of the policy rule

            try
            {
                // Retrieve a policy rule
                PolicyRule result = apiInstance.GetPolicyRule(policyId, ruleId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.GetPolicyRule: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **ruleId** | **string**| &#x60;id&#x60; of the policy rule | 

### Return type

[**PolicyRule**](PolicyRule.md)

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

<a name="listpolicies"></a>
# **ListPolicies**
> List&lt;Policy&gt; ListPolicies (PolicyTypeParameter type, string status = null, string q = null, string expand = null, string sortBy = null, string limit = null, string resourceId = null, string after = null)

List all policies

Lists all policies with the specified type

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListPoliciesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var type = (PolicyTypeParameter) "OKTA_SIGN_ON";  // PolicyTypeParameter | Specifies the type of policy to return. The following policy types are available only with the Okta Identity Engine - `ACCESS_POLICY`, <x-lifecycle class=\"ea\"></x-lifecycle> `DEVICE_SIGNAL_COLLECTION`, `PROFILE_ENROLLMENT`, `POST_AUTH_SESSION`, and `ENTITY_RISK`.
            var status = "status_example";  // string | Refines the query by the `status` of the policy - `ACTIVE` or `INACTIVE` (optional) 
            var q = "q_example";  // string | Refines the query by policy name prefix (startWith method) passed in as `q=string` (optional) 
            var expand = "\"\"";  // string |  (optional)  (default to "")
            var sortBy = "sortBy_example";  // string | Refines the query by sorting on the policy `name` in ascending order (optional) 
            var limit = "limit_example";  // string | Defines the number of policies returned, see [Pagination](https://developer.okta.com/docs/api/#pagination) (optional) 
            var resourceId = "resourceId_example";  // string | Reference to the associated authorization server (optional) 
            var after = "after_example";  // string | End page cursor for pagination, see [Pagination](https://developer.okta.com/docs/api/#pagination) (optional) 

            try
            {
                // List all policies
                List<Policy> result = apiInstance.ListPolicies(type, status, q, expand, sortBy, limit, resourceId, after).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.ListPolicies: " + e.Message );
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
 **type** | **PolicyTypeParameter**| Specifies the type of policy to return. The following policy types are available only with the Okta Identity Engine - &#x60;ACCESS_POLICY&#x60;, &lt;x-lifecycle class&#x3D;\&quot;ea\&quot;&gt;&lt;/x-lifecycle&gt; &#x60;DEVICE_SIGNAL_COLLECTION&#x60;, &#x60;PROFILE_ENROLLMENT&#x60;, &#x60;POST_AUTH_SESSION&#x60;, and &#x60;ENTITY_RISK&#x60;. | 
 **status** | **string**| Refines the query by the &#x60;status&#x60; of the policy - &#x60;ACTIVE&#x60; or &#x60;INACTIVE&#x60; | [optional] 
 **q** | **string**| Refines the query by policy name prefix (startWith method) passed in as &#x60;q&#x3D;string&#x60; | [optional] 
 **expand** | **string**|  | [optional] [default to &quot;&quot;]
 **sortBy** | **string**| Refines the query by sorting on the policy &#x60;name&#x60; in ascending order | [optional] 
 **limit** | **string**| Defines the number of policies returned, see [Pagination](https://developer.okta.com/docs/api/#pagination) | [optional] 
 **resourceId** | **string**| Reference to the associated authorization server | [optional] 
 **after** | **string**| End page cursor for pagination, see [Pagination](https://developer.okta.com/docs/api/#pagination) | [optional] 

### Return type

[**List&lt;Policy&gt;**](Policy.md)

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

<a name="listpolicyapps"></a>
# **ListPolicyApps**
> List&lt;Application&gt; ListPolicyApps (string policyId)

List all apps mapped to a policy

Lists all applications mapped to a policy identified by `policyId`  > **Note:** Use [List all resources mapped to a Policy](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Policy/#tag/Policy/operation/listPolicyMappings) to list all applications mapped to a policy.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListPolicyAppsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy

            try
            {
                // List all apps mapped to a policy
                List<Application> result = apiInstance.ListPolicyApps(policyId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.ListPolicyApps: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 

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

<a name="listpolicymappings"></a>
# **ListPolicyMappings**
> List&lt;PolicyMapping&gt; ListPolicyMappings (string policyId)

List all resources mapped to a policy

Lists all resources mapped to a policy identified by `policyId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListPolicyMappingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy

            try
            {
                // List all resources mapped to a policy
                List<PolicyMapping> result = apiInstance.ListPolicyMappings(policyId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.ListPolicyMappings: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 

### Return type

[**List&lt;PolicyMapping&gt;**](PolicyMapping.md)

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

<a name="listpolicyrules"></a>
# **ListPolicyRules**
> List&lt;PolicyRule&gt; ListPolicyRules (string policyId, string limit = null)

List all policy rules

Lists all policy rules

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListPolicyRulesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var limit = "limit_example";  // string | Defines the number of policy rules returned. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 

            try
            {
                // List all policy rules
                List<PolicyRule> result = apiInstance.ListPolicyRules(policyId, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.ListPolicyRules: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **limit** | **string**| Defines the number of policy rules returned. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 

### Return type

[**List&lt;PolicyRule&gt;**](PolicyRule.md)

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

<a name="mapresourcetopolicy"></a>
# **MapResourceToPolicy**
> PolicyMapping MapResourceToPolicy (string policyId, PolicyMappingRequest policyMappingRequest)

Map a resource to a policy

Maps a resource to a policy identified by `policyId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class MapResourceToPolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var policyMappingRequest = new PolicyMappingRequest(); // PolicyMappingRequest | 

            try
            {
                // Map a resource to a policy
                PolicyMapping result = apiInstance.MapResourceToPolicy(policyId, policyMappingRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.MapResourceToPolicy: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **policyMappingRequest** | [**PolicyMappingRequest**](PolicyMappingRequest.md)|  | 

### Return type

[**PolicyMapping**](PolicyMapping.md)

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

<a name="replacepolicy"></a>
# **ReplacePolicy**
> Policy ReplacePolicy (string policyId, CreateOrUpdatePolicy policy)

Replace a policy

Replaces the properties of a policy identified by `policyId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplacePolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var policy = new CreateOrUpdatePolicy(); // CreateOrUpdatePolicy | 

            try
            {
                // Replace a policy
                Policy result = apiInstance.ReplacePolicy(policyId, policy);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.ReplacePolicy: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **policy** | [**CreateOrUpdatePolicy**](CreateOrUpdatePolicy.md)|  | 

### Return type

[**Policy**](Policy.md)

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

<a name="replacepolicyrule"></a>
# **ReplacePolicyRule**
> PolicyRule ReplacePolicyRule (string policyId, string ruleId, PolicyRule policyRule)

Replace a policy rule

Replaces the properties for a policy rule identified by `policyId` and `ruleId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplacePolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PolicyApi(config);
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var ruleId = ruld3hJ7jZh4fn0st0g3;  // string | `id` of the policy rule
            var policyRule = new PolicyRule(); // PolicyRule | 

            try
            {
                // Replace a policy rule
                PolicyRule result = apiInstance.ReplacePolicyRule(policyId, ruleId, policyRule);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PolicyApi.ReplacePolicyRule: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **ruleId** | **string**| &#x60;id&#x60; of the policy rule | 
 **policyRule** | [**PolicyRule**](PolicyRule.md)|  | 

### Return type

[**PolicyRule**](PolicyRule.md)

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

