const {
  propertyErrata
} = require('./constants');


function shouldSkipProperty(property, infoLogger) {
  if (property.model && property.model === 'object') {
    infoLogger('Skipping property', property.fullPath, '(Reason: object properties are not supported)');
    return true;
  }

  if (typeof property.commonType === 'undefined') {
    infoLogger('Skipping property', property.fullPath, '(Reason: properties without commonType are not supported)');
    return true;
  }

  let propertyDetails = propertyErrata.find(x => x.path == property.fullPath);
  if (!propertyDetails) return false;
  if (!propertyDetails.skip) return false;

  infoLogger('Skipping property', property.fullPath, `(Reason: ${propertyDetails.skipReason})`);
  return true;
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
];

function shouldSkipMethod(method, infoLogger) {
  let skipRule = modelMethodSkipList.find(x => x.path === method.fullPath);
  if (!skipRule) return false;

  infoLogger('Skipping model method', method.fullPath, `(Reason: ${skipRule.reason})`);
  return true;
}

module.exports.shouldSkipProperty = shouldSkipProperty;
module.exports.shouldSkipMethod = shouldSkipMethod;
