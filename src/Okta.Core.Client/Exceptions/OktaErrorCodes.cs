namespace Okta.Core
{
    /// <summary>
    /// A list of possible Okta error codes
    /// </summary>
    public static class OktaErrorCodes
    {
        ///<summary>E0000001: Api validation failed: {0}</summary>
        public const string ApiValidationException = "E0000001";

        ///<summary>E0000002: The request was not valid: {0}</summary>
        public const string IllegalApiArgumentException = "E0000002";

        ///<summary>E0000003: The request body was not well-formed: {0}</summary>
        public const string ReaderException = "E0000003";

        ///<summary>E0000004: Authentication failed</summary>
        public const string AuthenticationException = "E0000004";

        ///<summary>E0000005: Invalid session</summary>
        public const string InvalidSessionException = "E0000005";

        ///<summary>E0000006: You do not have permission to perform the requested action</summary>
        public const string AccessDeniedException = "E0000006";

        ///<summary>E0000007: Not found: {0}</summary>
        public const string ResourceNotFoundException = "E0000007";

        ///<summary>E0000008: The requested path was not found</summary>
        public const string NotFoundException = "E0000008";

        ///<summary>E0000009: Internal Server Error</summary>
        public const string InternalServerError = "E0000009";

        ///<summary>E0000010: Service is in read only mode</summary>
        public const string ReadOnlyDatabaseException = "E0000010";

        ///<summary>E0000011: Invalid token provided</summary>
        public const string InvalidTokenException = "E0000011";

        ///<summary>E0000012: Unsupported media type</summary>
        public const string UnsupportedMediaType = "E0000012";

        ///<summary>E0000013: Invalid client app id</summary>
        public const string InvalidClientAppException = "E0000013";

        ///<summary>E0000014: Update of credentials failed</summary>
        public const string UpdateCredentialsFailedException = "E0000014";

        ///<summary>E0000015: You do not have permission to access the feature you are requesting</summary>
        public const string FeatureNotEnabledException = "E0000015";

        ///<summary>E0000016: Activation failed because the user is already active</summary>
        public const string ActivateUserFailedException = "E0000016";

        ///<summary>E0000017: Password reset failed</summary>
        public const string ResetPasswordFailedException = "E0000017";

        ///<summary>E0000018: Bad request.  Accept and/or Content-Type headers are likely not set.</summary>
        public const string ServletRequestBindingException = "E0000018";

        ///<summary>E0000019: Bad request.  Accept and/or Content-Type headers likely do not match supported values.</summary>
        public const string HttpMediaTypeNotAcceptableException = "E0000019";

        ///<summary>E0000020: Bad request.</summary>
        public const string IllegalArgumentException = "E0000020";

        ///<summary>E0000021: Bad request.  Accept and/or Content-Type headers likely do not match supported values.</summary>
        public const string HttpMediaTypeNotSupportedException = "E0000021";

        ///<summary>E0000022: The endpoint does not support the provided HTTP method</summary>
        public const string HttpRequestMethodNotSupportedException = "E0000022";

        ///<summary>E0000023: Operation failed because user profile is mastered under another system</summary>
        public const string AppUserException = "E0000023";

        ///<summary>E0000024: Bad request.  This operation on app metadata is not yet supported.</summary>
        public const string UnsupportedAppMetadataOperationException = "E0000024";

        ///<summary>E0000025: App version assignment failed.</summary>
        public const string AssignAppVersionFailedException = "E0000025";

        ///<summary>E0000026: This endpoint has been deprecated.</summary>
        public const string ApiEndpointDeprecatedException = "E0000026";

        ///<summary>E0000027: Group push bad request.</summary>
        public const string GroupPushException = "E0000027";

        ///<summary>E0000028: The request is missing a required parameter.</summary>
        public const string MissingServletRequestParameterException = "E0000028";

        ///<summary>E0000029: Invalid paging request.</summary>
        public const string InvalidPagingException = "E0000029";

        ///<summary>E0000030: Bad request. Invalid date. Dates must be of the form yyyy-MM-dd''T''HH:mm:ss.SSSZZ, e.g. 2013-01-01T12:00:00.000-07:00.</summary>
        public const string InvalidDateException = "E0000030";

        ///<summary>E0000031: Bad request. Invalid filter parameter.</summary>
        public const string InvalidFilterParameterException = "E0000031";

        ///<summary>E0000032: Unlock is not allowed for this user.</summary>
        public const string UnlockForbiddenException = "E0000032";

        ///<summary>E0000033: Bad request. Can't specify a search query and filter in the same request.</summary>
        public const string SearchRequestException = "E0000033";

        ///<summary>E0000034: Forgot password not allowed on specified user.</summary>
        public const string ForgotPasswordNotAllowedException = "E0000034";

        ///<summary>E0000035: Change password not allowed on specified user.</summary>
        public const string ChangePasswordNotAllowedException = "E0000035";

        ///<summary>E0000036: Change recovery question not allowed on specified user.</summary>
        public const string ChangeRecoveryQuestionNotAllowedException = "E0000036";

        ///<summary>E0000037: Type mismatch exception: {0}</summary>
        public const string TypeMismatchException = "E0000037";

        ///<summary>E0000038: This operation is not allowed in the user''s current status.</summary>
        public const string UserOperationForbiddenException = "E0000038";

        ///<summary>E0000039: Operation on application settings failed.</summary>
        public const string ChangeAppInstanceFailedException = "E0000039";

        ///<summary>E0000040: Application label must not be the same as an existing application label.</summary>
        public const string DuplicateInstanceLabelException = "E0000040";

        ///<summary>E0000041: Credentials should not be set on this resource based on the scheme.</summary>
        public const string PasswordOptionArgumentException = "E0000041";

        ///<summary>E0000042: Setting the error page redirect URL failed.</summary>
        public const string SetRedirectUrlFailedException = "E0000042";

        ///<summary>E0000043: Self service application assignment is not enabled.</summary>
        public const string SelfAssignOrgAppsNotEnabledException = "E0000043";

        ///<summary>E0000044: Self service application assignment is not supported.</summary>
        public const string SelfAssignNotSupportedException = "E0000044";

        ///<summary>E0000045: Field mapping bad request.</summary>
        public const string FieldMappingApiException = "E0000045";

        ///<summary>E0000046: Deactivate application for user forbidden.</summary>
        public const string DeactivateAppUserForbiddenException = "E0000046";

        ///<summary>E0000047: API call exceeded rate pageSize due to too many requests.</summary>
        public const string TooManyRequestsException = "E0000047";

        ///<summary>E0000048: Entity not found exception.</summary>
        public const string OppEntityNotFoundException = "E0000048";

        ///<summary>E0000049: Invalid SCIM data from SCIM implementation.</summary>
        public const string OppInvalidScimDataFromScimImplementationException = "E0000049";

        ///<summary>E0000050: Invalid SCIM data from client.</summary>
        public const string OppInvalidScimDataFromClientException = "E0000050";

        ///<summary>E0000051: No response from SCIM implementation.</summary>
        public const string OppNoResponseFromScimImplementationException = "E0000051";

        ///<summary>E0000052: Endpoint not implemented.</summary>
        public const string OppEndpointNotImplementedException = "E0000052";

        ///<summary>E0000053: Invalid SCIM filter.</summary>
        public const string OppInvalidScimFilter = "E0000053";

        ///<summary>E0000054: Invalid pagination properties.</summary>
        public const string OppInvalidPaginationProperties = "E0000054";

        ///<summary>E0000055: Duplicate group.</summary>
        public const string OppDuplicateGroup = "E0000055";

        ///<summary>E0000056: Delete application forbidden.</summary>
        public const string DeleteAppInstanceForbiddenException = "E0000056";

        ///<summary>E0000057: Access to this application is denied due to a policy.</summary>
        public const string PolicyDenyException = "E0000057";

        ///<summary>E0000058: Access to this application requires MFA: {0}</summary>
        public const string PolicyFactorRequiredException = "E0000058";

        ///<summary>E0000059: The connector configuration could not be tested. Make sure that the URL, Authentication Parameters are correct and that there is an implementation available at the URL provided.</summary>
        public const string OppConnectorSettingsTestFailure = "E0000059";

        ///<summary>E0000060: Unsupported operation: {0}</summary>
        public const string UnsupportedOperation = "E0000060";

        ///<summary>E0000061: Tab error: {0}</summary>
        public const string TabException = "E0000061";

        ///<summary>E0000062: The specified user is already assigned to the application.</summary>
        public const string DuplicateAppAssignment = "E0000062";

        ///<summary>E0000063: Invalid combination of parameters specified.</summary>
        public const string InvalidParameterCombinationException = "E0000063";

        ///<summary>E0000064: Password is expired and must be changed.</summary>
        public const string PasswordExpiredException = "E0000064";

        ///<summary>E0000065: Internal error processing app metadata.</summary>
        public const string AppMetadataInternalServerException = "E0000065";

        ///<summary>E0000066: APNS is not configured, contact your admin</summary>
        public const string MimApnsNotConfiguredException = "E0000066";

        ///<summary>E0000067: Factors Service Error.</summary>
        public const string FactorServiceTimeoutException = "E0000067";

        ///<summary>E0000068: Invalid Passcode/Answer</summary>
        public const string FactorInvalidCodeException = "E0000068";

        ///<summary>E0000069: User Locked</summary>
        public const string FactorUserLockedException = "E0000069";

        ///<summary>E0000070: Waiting for ACK</summary>
        public const string FactorWaitingForAckException = "E0000070";

        ///<summary>E0000071: Unsupported OS Version: {0}</summary>
        public const string MimUnsupportedVersionException = "E0000071";

        ///<summary>E0000072: MIM policy settings have disallowed enrollment for this user</summary>
        public const string MimEnrollmentDisallowedException = "E0000072";

        ///<summary>E0000073: User rejected authentication</summary>
        public const string FactorUserRejectedCodeException = "E0000073";

        ///<summary>E0000074: Factor Service Error</summary>
        public const string FactorServiceException = "E0000074";

        ///<summary>E0000075: Cannot modify the {0} attribute because it has a field mapping and profile push is enabled.</summary>
        public const string AppUserProfilePushConstraintException = "E0000075";

        ///<summary>E0000076: Cannot modify the app user because it is mastered by an external app.</summary>
        public const string AppUserProfileMasteringConstraintException = "E0000076";

        ///<summary>E0000077: Cannot modify the {0} attribute because it is read-only.</summary>
        public const string ReadOnlyAttributeException = "E0000077";

        ///<summary>E0000078: Cannot modify the {0} attribute because it is immutable.</summary>
        public const string ImmutableAttributeException = "E0000078";

        ///<summary>E0000079: This operation is not allowed in the current authentication state.</summary>
        public const string IllegalAuthStateException = "E0000079";

        ///<summary>E0000080: The password does meet the complexity requirements of the current password policy.</summary>
        public const string PasswordPolicyViolationException = "E0000080";

        ///<summary>E0000081: Cannot modify the {0} attribute because it is a reserved attribute for this application.</summary>
        public const string SystemScopeAttributeException = "E0000081";

        ///<summary>E0000082: Each code can only be used once. Please wait for a new code and try again.</summary>
        public const string FactorPasscodeReplayedException = "E0000082";

        ///<summary>E0000083: PassCode is valid but exceeded time window.</summary>
        public const string FactorTimeWindowExceededException = "E0000083";

        ///<summary>E0000084: App evaluation error.</summary>
        public const string AppEvaluationException = "E0000084";

        ///<summary>E0000085: You do not have permission to access your account at this time.</summary>
        public const string SignOnDeniedException = "E0000085";

        ///<summary>E0000086: This policy cannot be activated at this time.</summary>
        public const string PolicyActivationException = "E0000086";

        ///<summary>E0000087: The recovery question answer did not match our records.</summary>
        public const string InvalidRecoveryAnswerException = "E0000087";
    }
}
