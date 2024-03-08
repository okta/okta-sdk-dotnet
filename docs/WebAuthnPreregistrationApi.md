# Okta.Sdk.Api.WebAuthnPreregistrationApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivatePreregistrationEnrollment**](WebAuthnPreregistrationApi.md#activatepreregistrationenrollment) | **POST** /webauthn-registration/api/v1/activate | Activate a Preregistered WebAuthn Factor
[**DeleteWebAuthnPreregistrationFactor**](WebAuthnPreregistrationApi.md#deletewebauthnpreregistrationfactor) | **DELETE** /webauthn-registration/api/v1/users/{userId}/enrollments/{authenticatorEnrollmentId} | Delete a WebAuthn Preregistration Factor
[**EnrollPreregistrationEnrollment**](WebAuthnPreregistrationApi.md#enrollpreregistrationenrollment) | **POST** /webauthn-registration/api/v1/enroll | Enroll a Preregistered WebAuthn Factor
[**GenerateFulfillmentRequest**](WebAuthnPreregistrationApi.md#generatefulfillmentrequest) | **POST** /webauthn-registration/api/v1/initiate-fulfillment-request | Generate a Fulfillment Request
[**ListWebAuthnPreregistrationFactors**](WebAuthnPreregistrationApi.md#listwebauthnpreregistrationfactors) | **GET** /webauthn-registration/api/v1/users/{userId}/enrollments | List all WebAuthn Preregistration Factors


<a name="activatepreregistrationenrollment"></a>
# **ActivatePreregistrationEnrollment**
> EnrollmentActivationResponse ActivatePreregistrationEnrollment (EnrollmentActivationRequest? body = null)

Activate a Preregistered WebAuthn Factor

Activates a preregistered WebAuthn Factor. As part of this operation, Okta first decrypts and verifies the Factor PIN and enrollment data sent by the fulfillment provider.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivatePreregistrationEnrollmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebAuthnPreregistrationApi(config);
            var body = new EnrollmentActivationRequest?(); // EnrollmentActivationRequest? | Enrollment Activation Request (optional) 

            try
            {
                // Activate a Preregistered WebAuthn Factor
                EnrollmentActivationResponse result = apiInstance.ActivatePreregistrationEnrollment(body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebAuthnPreregistrationApi.ActivatePreregistrationEnrollment: " + e.Message );
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
 **body** | [**EnrollmentActivationRequest?**](EnrollmentActivationRequest?.md)| Enrollment Activation Request | [optional] 

### Return type

[**EnrollmentActivationResponse**](EnrollmentActivationResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | PIN or Cred Requests Generation Failed |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletewebauthnpreregistrationfactor"></a>
# **DeleteWebAuthnPreregistrationFactor**
> void DeleteWebAuthnPreregistrationFactor (string userId, string authenticatorEnrollmentId)

Delete a WebAuthn Preregistration Factor

Deletes a specific WebAuthn Preregistration Factor for a user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteWebAuthnPreregistrationFactorExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebAuthnPreregistrationApi(config);
            var userId = "userId_example";  // string | ID of an existing Okta user
            var authenticatorEnrollmentId = "authenticatorEnrollmentId_example";  // string | ID for a WebAuthn Preregistration Factor in Okta

            try
            {
                // Delete a WebAuthn Preregistration Factor
                apiInstance.DeleteWebAuthnPreregistrationFactor(userId, authenticatorEnrollmentId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebAuthnPreregistrationApi.DeleteWebAuthnPreregistrationFactor: " + e.Message );
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
 **authenticatorEnrollmentId** | **string**| ID for a WebAuthn Preregistration Factor in Okta | 

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

<a name="enrollpreregistrationenrollment"></a>
# **EnrollPreregistrationEnrollment**
> EnrollmentInitializationResponse EnrollPreregistrationEnrollment (EnrollmentInitializationRequest? body = null)

Enroll a Preregistered WebAuthn Factor

Enrolls a preregistered WebAuthn Factor. This WebAuthn Factor has a longer challenge timeout period to accommodate the fulfillment request process. As part of this operation, Okta generates EC key-pairs used to encrypt the Factor PIN and enrollment data sent by the fulfillment provider.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class EnrollPreregistrationEnrollmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebAuthnPreregistrationApi(config);
            var body = new EnrollmentInitializationRequest?(); // EnrollmentInitializationRequest? | Enrollment Initialization Request (optional) 

            try
            {
                // Enroll a Preregistered WebAuthn Factor
                EnrollmentInitializationResponse result = apiInstance.EnrollPreregistrationEnrollment(body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebAuthnPreregistrationApi.EnrollPreregistrationEnrollment: " + e.Message );
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
 **body** | [**EnrollmentInitializationRequest?**](EnrollmentInitializationRequest?.md)| Enrollment Initialization Request | [optional] 

### Return type

[**EnrollmentInitializationResponse**](EnrollmentInitializationResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | PIN or Cred Requests Generation Failed |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="generatefulfillmentrequest"></a>
# **GenerateFulfillmentRequest**
> void GenerateFulfillmentRequest (FulfillmentRequest? body = null)

Generate a Fulfillment Request

Generates a fulfillment request by sending a WebAuthn Preregistration event to start the flow. The Okta Workflows WebAuthn preregistration integration uses this to populate the fulfillment request.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GenerateFulfillmentRequestExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebAuthnPreregistrationApi(config);
            var body = new FulfillmentRequest?(); // FulfillmentRequest? | Fulfillment Request (optional) 

            try
            {
                // Generate a Fulfillment Request
                apiInstance.GenerateFulfillmentRequest(body);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebAuthnPreregistrationApi.GenerateFulfillmentRequest: " + e.Message );
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
 **body** | [**FulfillmentRequest?**](FulfillmentRequest?.md)| Fulfillment Request | [optional] 

### Return type

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listwebauthnpreregistrationfactors"></a>
# **ListWebAuthnPreregistrationFactors**
> List&lt;WebAuthnPreregistrationFactor&gt; ListWebAuthnPreregistrationFactors (string userId)

List all WebAuthn Preregistration Factors

Lists all WebAuthn Preregistration Factors for the specified user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListWebAuthnPreregistrationFactorsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebAuthnPreregistrationApi(config);
            var userId = "userId_example";  // string | ID of an existing Okta user

            try
            {
                // List all WebAuthn Preregistration Factors
                List<WebAuthnPreregistrationFactor> result = apiInstance.ListWebAuthnPreregistrationFactors(userId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebAuthnPreregistrationApi.ListWebAuthnPreregistrationFactors: " + e.Message );
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

[**List&lt;WebAuthnPreregistrationFactor&gt;**](WebAuthnPreregistrationFactor.md)

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

