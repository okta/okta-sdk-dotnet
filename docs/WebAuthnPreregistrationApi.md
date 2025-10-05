# Okta.Sdk.Api.WebAuthnPreregistrationApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivatePreregistrationEnrollment**](WebAuthnPreregistrationApi.md#activatepreregistrationenrollment) | **POST** /webauthn-registration/api/v1/activate | Activate a preregistered WebAuthn factor
[**AssignFulfillmentErrorWebAuthnPreregistrationFactor**](WebAuthnPreregistrationApi.md#assignfulfillmenterrorwebauthnpreregistrationfactor) | **POST** /webauthn-registration/api/v1/users/{userId}/enrollments/{authenticatorEnrollmentId}/mark-error | Assign the fulfillment error status to a WebAuthn preregistration factor
[**DeleteWebAuthnPreregistrationFactor**](WebAuthnPreregistrationApi.md#deletewebauthnpreregistrationfactor) | **DELETE** /webauthn-registration/api/v1/users/{userId}/enrollments/{authenticatorEnrollmentId} | Delete a WebAuthn preregistration factor
[**EnrollPreregistrationEnrollment**](WebAuthnPreregistrationApi.md#enrollpreregistrationenrollment) | **POST** /webauthn-registration/api/v1/enroll | Enroll a preregistered WebAuthn factor
[**GenerateFulfillmentRequest**](WebAuthnPreregistrationApi.md#generatefulfillmentrequest) | **POST** /webauthn-registration/api/v1/initiate-fulfillment-request | Generate a fulfillment request
[**ListWebAuthnPreregistrationFactors**](WebAuthnPreregistrationApi.md#listwebauthnpreregistrationfactors) | **GET** /webauthn-registration/api/v1/users/{userId}/enrollments | List all WebAuthn preregistration factors
[**SendPin**](WebAuthnPreregistrationApi.md#sendpin) | **POST** /webauthn-registration/api/v1/send-pin | Send a PIN to user


<a name="activatepreregistrationenrollment"></a>
# **ActivatePreregistrationEnrollment**
> EnrollmentActivationResponse ActivatePreregistrationEnrollment (EnrollmentActivationRequest body = null)

Activate a preregistered WebAuthn factor

Activates a preregistered WebAuthn factor. As part of this operation, Okta first decrypts and verifies the factor PIN and enrollment data sent by the fulfillment provider.

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
            var body = new EnrollmentActivationRequest(); // EnrollmentActivationRequest | Enrollment activation request (optional) 

            try
            {
                // Activate a preregistered WebAuthn factor
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
 **body** | [**EnrollmentActivationRequest**](EnrollmentActivationRequest.md)| Enrollment activation request | [optional] 

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
| **400** | PIN or cred requests generation failed |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="assignfulfillmenterrorwebauthnpreregistrationfactor"></a>
# **AssignFulfillmentErrorWebAuthnPreregistrationFactor**
> void AssignFulfillmentErrorWebAuthnPreregistrationFactor (string userId, string authenticatorEnrollmentId)

Assign the fulfillment error status to a WebAuthn preregistration factor

Assigns the fulfillment error status to a WebAuthn preregistration factor for a user. The `/mark-error` path indicates that the specific `FULFILLMENT_ERRORED` AuthFactor status is set on the enrollment.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignFulfillmentErrorWebAuthnPreregistrationFactorExample
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
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var authenticatorEnrollmentId = "authenticatorEnrollmentId_example";  // string | ID for a WebAuthn preregistration factor in Okta

            try
            {
                // Assign the fulfillment error status to a WebAuthn preregistration factor
                apiInstance.AssignFulfillmentErrorWebAuthnPreregistrationFactor(userId, authenticatorEnrollmentId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebAuthnPreregistrationApi.AssignFulfillmentErrorWebAuthnPreregistrationFactor: " + e.Message );
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
 **authenticatorEnrollmentId** | **string**| ID for a WebAuthn preregistration factor in Okta | 

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

<a name="deletewebauthnpreregistrationfactor"></a>
# **DeleteWebAuthnPreregistrationFactor**
> void DeleteWebAuthnPreregistrationFactor (string userId, string authenticatorEnrollmentId)

Delete a WebAuthn preregistration factor

Deletes a specific WebAuthn preregistration factor for a user

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
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var authenticatorEnrollmentId = "authenticatorEnrollmentId_example";  // string | ID for a WebAuthn preregistration factor in Okta

            try
            {
                // Delete a WebAuthn preregistration factor
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
 **authenticatorEnrollmentId** | **string**| ID for a WebAuthn preregistration factor in Okta | 

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
> EnrollmentInitializationResponse EnrollPreregistrationEnrollment (EnrollmentInitializationRequest body = null)

Enroll a preregistered WebAuthn factor

Enrolls a preregistered WebAuthn factor. This WebAuthn factor has a longer challenge timeout period to accommodate the fulfillment request process. As part of this operation, Okta generates elliptic curve (EC) key-pairs used to encrypt the factor PIN and enrollment data sent by the fulfillment provider.

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
            var body = new EnrollmentInitializationRequest(); // EnrollmentInitializationRequest | Enrollment initialization request (optional) 

            try
            {
                // Enroll a preregistered WebAuthn factor
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
 **body** | [**EnrollmentInitializationRequest**](EnrollmentInitializationRequest.md)| Enrollment initialization request | [optional] 

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
| **400** | PIN or cred requests generation failed |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="generatefulfillmentrequest"></a>
# **GenerateFulfillmentRequest**
> void GenerateFulfillmentRequest (FulfillmentRequest body = null)

Generate a fulfillment request

Generates a fulfillment request by sending a WebAuthn preregistration event to start the flow. The WebAuthn preregistration integration for Okta Workflows uses a preregistration event to populate the fulfillment request.

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
            var body = new FulfillmentRequest(); // FulfillmentRequest | Fulfillment request (optional) 

            try
            {
                // Generate a fulfillment request
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
 **body** | [**FulfillmentRequest**](FulfillmentRequest.md)| Fulfillment request | [optional] 

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

List all WebAuthn preregistration factors

Lists all WebAuthn preregistration factors for the specified user

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
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // List all WebAuthn preregistration factors
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

<a name="sendpin"></a>
# **SendPin**
> void SendPin (PinRequest body = null)

Send a PIN to user

Sends the decoded PIN for the specified WebAuthn preregistration enrollment. PINs are sent to the user's email. To resend the PIN, call this operation again.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class SendPinExample
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
            var body = new PinRequest(); // PinRequest | Send PIN request (optional) 

            try
            {
                // Send a PIN to user
                apiInstance.SendPin(body);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebAuthnPreregistrationApi.SendPin: " + e.Message );
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
 **body** | [**PinRequest**](PinRequest.md)| Send PIN request | [optional] 

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

