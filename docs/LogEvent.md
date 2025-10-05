# Okta.Sdk.Model.LogEvent

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Actor** | [**LogActor**](LogActor.md) |  | [optional] 
**AuthenticationContext** | [**LogAuthenticationContext**](LogAuthenticationContext.md) |  | [optional] 
**_Client** | [**LogClient**](LogClient.md) |  | [optional] 
**DebugContext** | [**LogDebugContext**](LogDebugContext.md) |  | [optional] 
**DisplayMessage** | **string** | The display message for an event | [optional] [readonly] 
**EventType** | **string** | The published event type. Event instances are categorized by action in the event type attribute. This attribute is key to navigating the System Log through expression filters. See [Event Types catalog](https://developer.okta.com/docs/reference/api/event-types/#catalog) for a complete list of System Log event types. | [optional] [readonly] 
**LegacyEventType** | **string** | Associated Events API Action &#x60;objectType&#x60; attribute value | [optional] [readonly] 
**Outcome** | [**LogOutcome**](LogOutcome.md) |  | [optional] 
**Published** | **DateTimeOffset** | Timestamp when the event is published | [optional] [readonly] 
**Request** | [**LogRequest**](LogRequest.md) |  | [optional] 
**SecurityContext** | [**LogSecurityContext**](LogSecurityContext.md) |  | [optional] 
**Severity** | **LogSeverity** |  | [optional] 
**Target** | [**List&lt;LogTarget&gt;**](LogTarget.md) | The entity that an actor performs an action on. Targets can be anything, such as an app user, a sign-in token, or anything else.  &gt; **Note:** When searching the target array, search for a given &#x60;type&#x60; rather than the array location. Target types, such as &#x60;User&#x60; and &#x60;AppInstance&#x60;,  for a given &#x60;eventType&#x60; are not always in the same array location. | [optional] [readonly] 
**Transaction** | [**LogTransaction**](LogTransaction.md) |  | [optional] 
**Uuid** | **string** | Unique identifier for an individual event | [optional] [readonly] 
**_Version** | **string** | Versioning indicator | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

