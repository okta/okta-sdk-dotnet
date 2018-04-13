const { 
  paramToCLRType,
  propToCLRType,
  getterName
 } = require('./utils');

 const { makeEnumFromModel } = require('./enumProcessor.js');

const csharp = module.exports;

/**
 * This file is used by the @okta/openapi generator.  It defines language-specific
 * post-processing of the JSON spec, as well as handebars helpers.  This file is meant
 * to give you control over the data that handlebars uses when processing your templates
 */

const partialUpdateList = new Set([
  'User',
  'UserProfile'
]);

const propertyDetailsList = [
  { path: 'FactorDevice.links', skip: true, skipReason: 'Not currently supported' },
  { path: 'Link.hints', skip: true, skipReason: 'Not currently supported' },
  { path: 'User._links', skip: true, skipReason: 'Not currently supported' },
  { path: 'UserGroup._embedded', skip: true, skipReason: 'Not currently supported' },
  { path: 'UserGroup._links', skip: true, skipReason: 'Not currently supported' },
  { path: 'UserGroupStats._links', skip: true, skipReason: 'Not currently supported' },
  
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
];

const operationSkipList = [
  { id: 'forgotPassword', reason: 'Revisit in alpha2 (#62)'},
  { id: 'addRoleToUser', reason: 'Revisit in alpha2 (#102)'},
];

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



function getMappedArgName(method, argName) {
  let mapping = method.arguments.find(x => x.dest === argName);
  if (!mapping) return null;
  return mapping.src;
}

function errorLogger(message, model) {
  console.error(model);
  throw new Error(message);
}

csharp.process = ({spec, operations, models, handlebars}) => {

  handlebars.registerHelper({
    paramToCLRType,
    propToCLRType,
    getterName,
    getMappedArgName
  });

  const templates = [];

  let baseModels = new Set();

  // add all the models
  for (let model of models) {
    model.specVersion = spec.info.version;

    if (model.enum) {
      templates.push({
        src: 'templates/Enum.cs.hbs',
        dest: `Generated/${model.modelName}.Generated.cs`,
        context: makeEnumFromModel(model, errorLogger)
      });

      // Don't do anything else for enums
      continue;
    }

    if (partialUpdateList.has(model.modelName)) {
      model.supportsPartialUpdates = true;
    }

    if (model.extends && !baseModels.has(model.extends)) {
      baseModels.add(model.extends);
    }

    model.properties = model.properties || [];

    for (let property of model.properties) {
      let fullPath = `${model.modelName}.${property.propertyName}`;

      if (property.model && property.model === 'object') {
        console.log('Skipping property', fullPath, '(Reason: object properties are not supported)');
        property.hidden = true;
        continue;
      }

      if (typeof property.commonType === 'undefined') {
        console.log('Skipping property', fullPath, '(Reason: properties without commonType are not supported)');
        property.hidden = true;
        continue;
      }

      let propertyDetails = propertyDetailsList.find(x => x.path == fullPath);
      if (!propertyDetails) continue;

      if (propertyDetails.skip) {
        console.log('Skipping property', fullPath, `(Reason: ${propertyDetails.skipReason})`);
        property.hidden = true;
        continue;
      }

      if (propertyDetails.rename) {
        console.log(`Renaming property ${fullPath} to ${propertyDetails.rename}`, `(Reason: ${propertyDetails.renameReason})`);
        property.displayName = propertyDetails.rename;
      }

      if (propertyDetails.hidesBaseMember) {
        property.hidesBaseMember = true;
      }
    }

    model.methods = model.methods || [];

    for (let method of model.methods) {
      let fullPath = `${model.modelName}.${method.alias}`;

      let skipRule = modelMethodSkipList.find(x => x.path === fullPath);
      if (skipRule) {
        console.log('Skipping model method', fullPath, `(Reason: ${skipRule.reason})`);
        method.hidden = true;
        continue;
      }

      method.operation.allParams = (method.operation.pathParams || []).concat(method.operation.queryParams || []);
    }

    if (model.requiresResolution) {
      templates.push({
        src: 'templates/Resolver.cs.hbs',
        dest: `Generated/${model.modelName}Resolver.Generated.cs`,
        context: model
      });
    }

    templates.push({
      src: 'templates/IModel.cs.hbs',
      dest: `Generated/I${model.modelName}.Generated.cs`,
      context: model
    });

    templates.push({
      src: 'templates/Model.cs.hbs',
      dest: `Generated/${model.modelName}.Generated.cs`,
      context: model
    });
  }

  // Second pass to mark base models (models that are inherited from other models)
  for (let name of baseModels) {
    let foundModel = models.find(x => x.modelName === name);

    if (!foundModel) {
      console.warn(`Could not mark ${name} as a base model`);
      continue;
    }

    foundModel.isBaseModel = true;
  }

  const taggedOperations = {};

  // pre-process the operations and split into tags
  for (let operation of operations) {
      let skipRule = operationSkipList.find(x => x.id === operation.operationId);
      if (skipRule) {
        console.log('Skipping operation', operation.operationId, `(Reason: ${skipRule.reason})`);
        operation.hidden = true;
        continue;
      }

      operation.allParams = (operation.pathParams || []).concat(operation.queryParams || []);

      if (!operation.tags) {
        operation.tags = [];
      }

      if (operation.tags.length === 0) {
        operation.tags.push('Okta');
        console.log(`Adding default tag to ${operation.operationId}`);
      }

      if (operation.tags.length > 1) {
        console.log(`Warning: more than one tag on ${operation.operationId}`);
      }

      if (!taggedOperations[operation.tags[0]]) {
        taggedOperations[operation.tags[0]] = []; 
      }

      taggedOperations[operation.tags[0]].push(operation);
  }

  for (let tag of Object.keys(taggedOperations)) {
    templates.push({
      src: 'templates/IClient.cs.hbs',
      dest: `Generated/I${tag}sClient.Generated.cs`,
      context: {
        tag,
        spec,
        operations: taggedOperations[tag]
      }
    });

    templates.push({
      src: 'templates/Client.cs.hbs',
      dest: `Generated/${tag}sClient.Generated.cs`,
      context: {
        tag,
        spec,
        operations: taggedOperations[tag]
      }
    });
  }

  return templates;
}
