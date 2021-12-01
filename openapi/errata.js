const propertyErrata = [
  { path: 'FactorDevice.links', skip: true, skipReason: 'Not currently supported' },
  { path: 'Link.hints', skip: true, skipReason: 'Not currently supported' },
  
  { path: '*._embedded', skip: true, skipReason: 'Not currently supported'},
  { path: '*._links', skip: true, skipReason: 'Not currently supported'},

  { path: 'ActivationToken.activationToken', rename: 'token', renameReason: '.NET type name and member name cannot be identical' },
  { path: 'TempPassword.tempPassword', rename: 'password', renameReason: '.NET type name and member name cannot be identical' },
  { path: 'Csr.csr', rename: 'CsrValue', renameReason: '.NET type name and member name cannot be identical' },

  { path: 'CallFactor.profile', hidesBaseMember: true },
  { path: 'EmailFactor.profile', hidesBaseMember: true },
  { path: 'HardwareFactor.profile', hidesBaseMember: true },
  { path: 'PushFactor.profile', hidesBaseMember: true },
  { path: 'SecurityQuestionFactor.profile', hidesBaseMember: true },
  { path: 'SmsFactor.profile', hidesBaseMember: true },
  { path: 'TokenFactor.profile', hidesBaseMember: true },
  { path: 'TotpFactor.profile', hidesBaseMember: true },
  { path: 'WebFactor.profile', hidesBaseMember: true },

  { path: 'AutoLoginApplication.credentials', hidesBaseMember: true },
  { path: 'AutoLoginApplication.settings', hidesBaseMember: true },

  { path: 'BasicAuthApplication.credentials', hidesBaseMember: true },
  {
    path: 'BasicAuthApplication.name',
    hidesBaseMember: true,
    type: 'string',
    typeReason: 'Spec does not define type for this property'
   },
   { path: 'BasicAuthApplication.settings', hidesBaseMember: true },
   { path: 'BasicApplicationSettings.app', hidesBaseMember: true },

   {
    path: 'BookmarkApplication.name',
    hidesBaseMember: true,
    type: 'string',
    typeReason: 'Spec does not define type for this property'
   },
   { path: 'BookmarkApplication.settings', hidesBaseMember: true },
   { path: 'BookmarkApplicationSettings.app', hidesBaseMember: true },

   { path: 'BrowserPluginApplication.credentials', hidesBaseMember: true },

   {
    path: 'OpenIdConnectApplication.name',
    hidesBaseMember: true,
    type: 'string',
    typeReason: 'Spec does not define type for this property'
   },
   { path: 'OpenIdConnectApplication.credentials', hidesBaseMember: true },
   { path: 'OpenIdConnectApplication.settings', hidesBaseMember: true },

   { path: 'SamlApplication.settings', hidesBaseMember: true },

   {
    path: 'SecurePasswordStoreApplication.name',
    hidesBaseMember: true,
    type: 'string',
    typeReason: 'Spec does not define type for this property'
   },
   { path: 'SecurePasswordStoreApplicationSettings.app', hidesBaseMember: true },

   {
    path: 'SwaApplication.name',
    hidesBaseMember: true,
    type: 'string',
    typeReason: 'Spec does not define type for this property'
   },
   { path: 'SwaApplication.settings', hidesBaseMember: true },
   { path: 'SwaApplicationSettings.app', hidesBaseMember: true },

   {
    path: 'SwaThreeFieldApplication.name',
    hidesBaseMember: true,
    type: 'string',
    typeReason: 'Spec does not define type for this property'
   },
   { path: 'SwaThreeFieldApplication.settings', hidesBaseMember: true },

   { path: 'SwaThreeFieldApplicationSettings.app', hidesBaseMember: true },

   { path: 'SecurePasswordStoreApplication.credentials', hidesBaseMember: true },
   { path: 'SecurePasswordStoreApplication.settings', hidesBaseMember: true },

   { path: 'SchemeApplicationCredentials.signing', hidesBaseMember: true },

   {
    path: 'WsFederationApplication.name',
    hidesBaseMember: true,
    type: 'string',
    typeReason: 'Spec does not define type for this property'
   },
   { path: 'WsFederationApplication.settings', hidesBaseMember: true },
   { path: 'WsFederationApplicationSettings.app', hidesBaseMember: true },

   { path: 'U2fFactor.profile', hidesBaseMember: true },

   { path: 'ApplicationVisibility.appLinks', skip: true, skipReason: 'Not currently supported' },
   { path: 'OpenIdConnectApplicationSettingsClient.tos_uri', rename: 'termsOfServiceUri', renameReason: 'Legibility' },
   { path: 'OpenIdConnectApplicationSettings.oauthClient', rename: 'oAuthClient', renameReason: 'Legibility' },
   { path: 'SamlApplicationSettingsSignOn.authnContextClassRef', rename: 'authenticationContextClassName', renameReason: 'Legibility' },
   { path: 'WsFederationApplicationSettingsApplication.authnContextClassRef', rename: 'authenticationContextClassName', renameReason: 'Legibility' },
   { path: 'SamlApplicationSettingsSignOn.honorForceAuthn', rename: 'honorForceAuthentication', renameReason: 'Legibility' },
   { path: 'SwaThreeFieldApplicationSettingsApplication.targetUrl', binding: 'targetURL', renameReason: 'Matching the API' },
   { path: 'ApplicationGroupAssignment.profile', skip: true, skipReason: 'Not currently supported' },
   { path: 'LogGeolocation.lat', rename: 'latitude', renameReason: 'Legibility' },
   { path: 'LogGeolocation.lon', rename: 'longitude', renameReason: 'Legibility' },
   { path: 'LogUserAgent.os', rename: 'operatingSystem', renameReason: 'Legibility' },
   { path: 'LogEvent.client', rename: 'clientInfo', renameReason: 'Convention', model: 'LogClientInfo', modelReason: 'Convention' },
   { path: 'Session.amr', rename: 'authenticationMethodReference', renameReason: 'Legibility' },
   { path: 'Domain.domain', rename: 'DomainName', renameReason: '.NET type name and member name cannot be identical' },   
   { path: 'Domain.dnsRecords', model: 'DnsRecord', modelReason: 'Match the changed type name'},
   { path: 'DnsRecord.recordType', model: 'DnsRecordType', modelReason: 'Match the changed type name'},
   { path: 'PolicyRuleActions.signon', rename: 'SignOn', renameReason: 'Pattern consistency'},
   { path: 'ApplicationSettingsNotes.enduser', rename: 'EndUser', renameReason: 'Pattern consistency'},
   { path: 'UserSchemaAttribute.type', type: 'string', typeReason: 'Avoiding breaking change. Think about another approach in a next major version!!!!' },
   { path: 'UserSchemaAttribute.scope', type: 'string', typeReason: 'Avoiding breaking change. Think about another approach in a next major version!!!!' },
  ];

const enumErrata = [
  { path: 'ApplicationSignOnMode.openidConnect', rename: 'openIdConnect', renameReason: 'Convention' },
  { path: 'ApplicationSignOnMode.saml20', rename: 'saml2', renameReason: 'Legibility' },
  { path: 'SessionAuthenticationMethod.pwd', rename: 'password', renameReason: 'Legibility' },
  { path: 'SessionAuthenticationMethod.swk', rename: 'softwareKey', renameReason: 'Legibility' },
  { path: 'SessionAuthenticationMethod.hwk', rename: 'hardwareKey', renameReason: 'Legibility' },
  { path: 'SessionAuthenticationMethod.otp', rename: 'oneTimePassword', renameReason: 'Legibility' },
  { path: 'SessionAuthenticationMethod.tel', rename: 'telephone', renameReason: 'Legibility' },
  { path: 'SessionAuthenticationMethod.geo', rename: 'geolocation', renameReason: 'Legibility' },
  { path: 'SessionAuthenticationMethod.fpt', rename: 'fingerprint', renameReason: 'Legibility' },
  { path: 'SessionAuthenticationMethod.kba', rename: 'knowledgeBased', renameReason: 'Legibility' },
  { path: 'SessionAuthenticationMethod.mfa', rename: 'multifactor', renameReason: 'Legibility' },
  { path: 'LogCredentialProvider.oktaAuthenticationProvider', rename: 'okta', renameReason: 'Legibility' },
  { path: 'FactorType.webauthn', rename: 'webAuthentication', renameReason: 'Legibility' },
  { path: 'PolicyType.oauthAuthorizationPolicy', rename: 'oAuthAuthorizationPolicy', renameReason: 'Convention' },
];

const modelErrata = [
  { path: 'LogClient', rename: 'LogClientInfo', renameReason: 'Legibility' },
  { path: 'DNSRecord', rename: 'DnsRecord', renameReason: 'Pattern consistency' },
  { path: 'DNSRecordType', rename: 'DnsRecordType', renameReason: 'Pattern consistency' }, 
  { path: 'CSR', rename: 'Csr', renameReason: 'Pattern consistency' },
  { path: 'CSRMetadata', rename: 'CsrMetadata', renameReason: 'Pattern consistency' },
  { path: 'CSRMetadataSubject', rename: 'CsrMetadataSubject', renameReason: 'Pattern consistency' },
  { path: 'CSRMetadataSubjectAltNames', rename: 'CsrMetadataSubjectAltNames', renameReason: 'Pattern consistency' },
  { path: 'UserSchema', includeNullValues: true },
  { path: 'GroupSchema', includeNullValues: true },
  { path: 'AuthenticatorProviderConfigurationUserNamePlate', rename: 'AuthenticatorProviderConfigurationUserNameTemplate', renameReason: 'Fix typo' },
  { path: 'User', includeNullValues: true },
];

const operationErrata = [
  { tag: 'User', operationId: 'createUser', queryParamName: 'nextLogin', type: 'object', typeReason: 'StringEnum\'s must be object',  default: 'null', defaultReason: 'Implicit string operator cannot be used as default parameter'},
  /* Description errata must be removed when the https://github.com/okta/openapi/issues/180 is fixed */
  { tag: 'User', operationId: 'listGroupTargetsForRole', descriptionReason: 'Wrong description',  description: 'List all group targets given a role id.'},
  { tag: 'User', operationId: 'removeGroupTargetFromRole', descriptionReason: 'Wrong description',  description: 'Removes a group target from a role assigned to a user.'},
  { tag: 'User', operationId: 'addGroupTargetToRole', descriptionReason: 'Wrong description',  description: 'Adds a group target for a role assigned to a user.'},
  { tag: 'Group', operationId: 'updateRule', descriptionReason: 'Wrong description',  description: 'Updates a rule.'},
];

function applyOperationErrata(tag, existingOperation, infoLogger) {
  let errata = operationErrata.find(x => x.tag === tag && x.operationId == existingOperation.operationId);

  if(errata) {
    if(errata.queryParamName) {
      let queryParam = existingOperation.queryParams.find(x => x.name == errata.queryParamName);

      if(!queryParam) return existingOperation;

      if(errata.default) {
        queryParam.default = errata.default;
        infoLogger(`Errata: Changing default for query parameter in ${tag} > ${existingOperation.operationId} to ${errata.default}`, `(Reason: ${errata.defaultReason})`);
      }

      if(errata.type) {
        queryParam.type = errata.type;
        infoLogger(`Errata: Changing type for query parameter in ${tag} > ${existingOperation.operationId} to ${errata.type}`, `(Reason: ${errata.typeReason})`);
      }
    }

    if(errata.description){
          existingOperation.description = errata.description;
          infoLogger(`Errata: Changing description for operation ${existingOperation.operationId} to ${errata.description}`, `(Reason: ${errata.descriptionReason})`);
    }
  }

  // Check for model rename
  let errataBodyModel = modelErrata.find(x => x.path == existingOperation.bodyModel);

  if(errataBodyModel) {
    if(errataBodyModel.rename){
      existingOperation.bodyModel = errataBodyModel.rename;
    }
  }

  let errataResponseModel = modelErrata.find(x => x.path == existingOperation.responseModel);

  if(errataResponseModel) {
    if(errataResponseModel.rename){
      existingOperation.responseModel = errataResponseModel.rename;
    }
  }

  return existingOperation;
}

function applyEnumErrata(existingMember, infoLogger) {
  let exists = existingMember && existingMember.fullPath;
  if (!exists) return existingMember;

  let errata = enumErrata.find(x => x.path === existingMember.fullPath);
  if(!errata) return existingMember;

  if (errata.rename) {
    existingMember.memberName = errata.rename;
    infoLogger(`Errata: Renaming property ${existingMember.fullPath} to ${errata.rename}`, `(Reason: ${errata.renameReason})`);
  }

  return existingMember;
}

function applyPropertyErrata(existingProperty, infoLogger) {
  let exists = existingProperty && existingProperty.fullPath;
  if (!exists) return existingProperty;

  let errata = propertyErrata.find(x => x.path === existingProperty.fullPath || (x.path === `*.${existingProperty.propertyName}`));
  if (errata) {
 
    if (errata.rename) {
      existingProperty.displayName = errata.rename;
      infoLogger(`Errata: Renaming property ${existingProperty.fullPath} to ${errata.rename}`, `(Reason: ${errata.renameReason})`);
    }

    if(errata.binding) {
      existingProperty.propertyName = errata.binding;
      infoLogger(`Errata: Renaming binding of property ${existingProperty.fullPath} to ${errata.binding}`, `(Reason: ${errata.renameReason})`);
    }

    if (errata.hidesBaseMember) {
      existingProperty.hidesBaseMember = true;
    }

    if (errata.skip) {
      existingProperty.hidden = true;
      infoLogger(`Errata: Hiding property ${existingProperty.fullPath}`, `Reason: ${errata.skipReason}`)
    }

    if (errata.type) {
      existingProperty.commonType = errata.type;
      infoLogger(`Errata: Explicitly setting type of ${existingProperty.fullPath} to '${errata.type}'`, `(Reason: ${errata.typeReason})`)
    }

    if(errata.readOnly != null) {
      existingProperty.readOnly = errata.readOnly;
      infoLogger(`Errata: ReadOnly changed for property ${existingProperty.fullPath}`)
    }

    if(errata.model) {
      existingProperty.model = errata.model;
      infoLogger(`Errata: Explicitly setting model type for property ${existingProperty.fullPath}`)
    }
  }

  if(existingProperty.isObject && existingProperty.model) {
    
    let errataModel = modelErrata.find(x => x.path == existingProperty.model);

    if(errataModel) {
      if(errataModel.rename){
        existingProperty.model = errataModel.rename;
      }
    }

  }

  return existingProperty;
}

function isPropertyUnsupported(property) {
  if (typeof property.commonType === 'undefined') {
    return {
      reason: 'properties without commonType are not supported'
    };
  }

  return false;
}

function applyModelErrata(existingModel, strictModelList, infoLogger) {
  let errata = modelErrata.find(x => x.path === existingModel.modelName);
  if (!errata) return existingModel;

  if (errata.rename) {
    // Updating model name in the model list
    strictModelList.add(errata.rename);
    strictModelList.delete(existingModel.modelName);

    existingModel.modelName = errata.rename;
    infoLogger(`Errata: Renaming model ${existingModel.path} to ${errata.rename}`, `(Reason: ${errata.renameReason})`);
  }

  if (errata.includeNullValues) {
    existingModel.includeNullValues = errata.includeNullValues;
    infoLogger(`Errata: Adding includeNullValues prop to model ${existingModel.modelName}`);
  }

  return existingModel;
}

const modelMethodSkipList = [
  { path: 'User.changePassword', reason: 'Implemented as ChangePasswordAsync(options)' },
  { path: 'User.changeRecoveryQuestion', reason: 'Implemented as ChangeRecoveryQuestionAsync(options)'},
  { path: 'User.forgotPassword', reason: 'Revisit in alpha2 (#64)'},
  { path: 'User.addRole', reason: 'Implemented as a custom method'},
  { path: 'User.listAppLinks', reason: 'Implemented as IUser.AppLinks' },
  { path: 'User.listRoles', reason: 'Implemented as IUser.Roles' },
  { path: 'User.listGroups', reason: 'Implemented as IUser.Groups' },
  { path: 'User.resetPassword', reason: 'Simplified as IUser.ResetPasswordAsync(bool)' },
  { path: 'Group.listUsers', reason: 'Implemented as IGroup.Users' },
  { path: 'Theme.updateBrandThemeBackgroundImage', reason: 'Implemented manually' },
  { path: 'Theme.updateBrandThemeFavicon', reason: 'Implemented manually' },
  { path: 'Theme.uploadBrandThemeLogo', reason: 'Implemented manually' },
  { path: 'OrgSetting.updateOrgLogo', reason: 'Implemented manually' }
];

function shouldSkipModelMethod(fullPath) {
  let skipRule = modelMethodSkipList.find(x => x.path === fullPath);
  if (!skipRule) return null;

  return {
    reason: skipRule.reason
  };
}

const operationSkipList = [
  { id: 'forgotPassword', reason: 'Revisit in alpha2 (#62)'},
  { id: 'addRoleToUser', reason: 'Revisit in alpha2 (#102)'},
  { id: 'previewSamlMetadataForApplication', reason: 'Operation defined manually' },
  { id: 'publishCerCert', reason: 'Operation defined manually' },
  { id: 'publishBinaryCerCert', reason: 'Operation defined manually' },
  { id: 'publishDerCert', reason: 'Operation defined manually' },
  { id: 'publishBinaryDerCert', reason: 'Operation defined manually' },
  { id: 'publishBinaryPemCert', reason: 'Operation defined manually' },
  { id: 'uploadBrandThemeBackgroundImage', reason: 'Operation defined manually'},
  { id: 'uploadBrandThemeFavicon', reason: 'Operation defined manually'},
  { id: 'uploadBrandThemeLogo', reason: 'Operation defined manually'},
  { id: 'updateOrgLogo', reason: 'Operation defined manually'}
];

function shouldSkipOperation(operationId) {
  let skipRule = operationSkipList.find(x => x.id === operationId);
  if (!skipRule) return null;

  return {
    reason: skipRule.reason
  };
}

module.exports.applyPropertyErrata = applyPropertyErrata;
module.exports.applyEnumErrata = applyEnumErrata;
module.exports.applyModelErrata = applyModelErrata;
module.exports.isPropertyUnsupported = isPropertyUnsupported;
module.exports.shouldSkipModelMethod = shouldSkipModelMethod;
module.exports.shouldSkipOperation = shouldSkipOperation;
module.exports.applyOperationErrata = applyOperationErrata;
