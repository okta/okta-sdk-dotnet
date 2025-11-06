# Okta.Sdk.Model.ProfileEnrollmentPolicyRuleAction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Access** | **string** | Indicates if the user profile is granted access  &gt; **Note:** You can&#39;t set the &#x60;access&#x60; property to &#x60;DENY&#x60; after you create the policy | [optional] 
**ActivationRequirements** | [**ProfileEnrollmentPolicyRuleActivationRequirement**](ProfileEnrollmentPolicyRuleActivationRequirement.md) |  | [optional] 
**AllowedIdentifiers** | **List&lt;string&gt;** | A list of attributes to identify an end user. Can be used across Okta sign-in, unlock, and recovery flows. | [optional] 
**EnrollAuthenticatorTypes** | **List&lt;string&gt;** | Additional authenticator fields that can be used on the first page of user registration. Valid values only includes &#x60;&#39;password&#39;&#x60;. | [optional] 
**PreRegistrationInlineHooks** | [**List&lt;PreRegistrationInlineHook&gt;**](PreRegistrationInlineHook.md) | (Optional) The &#x60;id&#x60; of at most one registration inline hook | [optional] 
**ProfileAttributes** | [**List&lt;ProfileEnrollmentPolicyRuleProfileAttribute&gt;**](ProfileEnrollmentPolicyRuleProfileAttribute.md) | A list of attributes to prompt the user for during registration or progressive profiling. Where defined on the user schema, these attributes are persisted in the user profile. You can also add non-schema attributes, which aren&#39;t persisted to the user&#39;s profile, but are included in requests to the registration inline hook. A maximum of 10 profile properties is supported. | [optional] 
**ProgressiveProfilingAction** | **string** | Progressive profile enrollment helps evaluate the user profile policy at every user login. Users can be prompted to provide input for newly required attributes. | [optional] 
**TargetGroupIds** | **List&lt;string&gt;** | (Optional, max 1 entry) The &#x60;id&#x60; of a group that this user should be added to | [optional] 
**UiSchemaId** | **string** | Value created by the backend. If present, all policy updates must include this attribute/value. | [optional] 
**UnknownUserAction** | **string** | Which action should be taken if this user is new | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

