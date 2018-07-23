const propertyErrata = [
  { path: 'FactorDevice.links', skip: true, skipReason: 'Not currently supported' },
  { path: 'Link.hints', skip: true, skipReason: 'Not currently supported' },
  
  { path: '*._embedded', skip: true, skipReason: 'Not currently supported'},
  { path: '*._links', skip: true, skipReason: 'Not currently supported'},

  { path: 'ActivationToken.activationToken', rename: 'token', renameReason: '.NET type name and member name cannot be identical' },
  { path: 'TempPassword.tempPassword', rename: 'password', renameReason: '.NET type name and member name cannot be identical' },

  { path: 'CallFactor.profile', hidesBaseMember: true },
  { path: 'EmailFactor.profile', hidesBaseMember: true },
  { path: 'HardwareFactor.profile', hidesBaseMember: true },
  { path: 'PushFactor.profile', hidesBaseMember: true },
  { path: 'SecurityQuestionFactor.profile', hidesBaseMember: true },
  { path: 'SmsFactor.profile', hidesBaseMember: true },
  { path: 'TokenFactor.profile', hidesBaseMember: true },
  { path: 'TotpFactor.profile', hidesBaseMember: true },
  { path: 'WebFactor.profile', hidesBaseMember: true },

  { path: 'BasicAuthApplication.credentials', hidesBaseMember: true },
  {
    path: 'BasicAuthApplication.name',
    hidesBaseMember: true,
    type: 'string',
    typeReason: 'Spec does not define type for this property'
   },
   { path: 'BasicAuthApplication.settings', hidesBaseMember: true },

   {
    path: 'BookmarkApplication.name',
    hidesBaseMember: true,
    type: 'string',
    typeReason: 'Spec does not define type for this property'
   },

   {
    path: 'OpenIdConnectApplication.name',
    hidesBaseMember: true,
    type: 'string',
    typeReason: 'Spec does not define type for this property'
   },

   {
    path: 'SecurePasswordStoreApplication.name',
    hidesBaseMember: true,
    type: 'string',
    typeReason: 'Spec does not define type for this property'
   },

   {
    path: 'SwaApplication.name',
    hidesBaseMember: true,
    type: 'string',
    typeReason: 'Spec does not define type for this property'
   },

   {
    path: 'SwaThreeFieldApplication.name',
    hidesBaseMember: true,
    type: 'string',
    typeReason: 'Spec does not define type for this property'
   },

   {
    path: 'WsFederationApplication.name',
    hidesBaseMember: true,
    type: 'string',
    typeReason: 'Spec does not define type for this property'
   },

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
   { path: 'LogEvent.client', rename: 'clientInfo', renameReason: 'Convention' },
   { path: 'Session.amr', rename: 'authenticationMethodReference', renameReason: 'Legibility' },
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
  
];

const modelErrata = [
  { path: 'LogClient', rename: 'LogClientInfo', renameReason: 'Legibility' },
];

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
  if (!errata) return existingProperty;

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

function applyModelErrata(existingModel, infoLogger) {
  let errata = modelErrata.find(x => x.path === existingModel.modelName);
  if (!errata) return existingModel;

  if (errata.rename) {
    existingModel.modelName = errata.rename;
    infoLogger(`Errata: Renaming model ${existingModel.path} to ${errata.rename}`, `(Reason: ${errata.renameReason})`);
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
  { path: 'User.removeRole', reason: 'Add back in alpha2 (#64)' },
  { path: 'User.listGroupTargetsForRole', reason: 'Too complex for IUser, leave on IUserClient' },
  { path: 'User.addGroupTargetToRole', reason: 'Too complex for IUser, leave on IUserClient' },
  { path: 'User.removeGroupTargetFromRole', reason: 'Too complex for IUser, leave on IUserClient' },
  { path: 'User.resetPassword', reason: 'Simplified as IUser.ResetPasswordAsync(bool)' },
  { path: 'Group.listUsers', reason: 'Implemented as IGroup.Users' },
  { path: 'Application.generateApplicationKey', reason: 'Operation is not defined' },
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
