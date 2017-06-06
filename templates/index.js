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

const propertySkipList = [
  { path: 'FactorDevice.links', reason: 'Not currently supported' },
  { path: 'Link.hints', reason: 'Not currently supported' },
  { path: 'User._links', reason: 'Not currently supported' },
  { path: 'UserGroup._embedded', reason: 'Not currently supported' },
  { path: 'UserGroup._links', reason: 'Not currently supported' },
  { path: 'UserGroupStats._links', reason: 'Not currently supported' },
];

const propertyRenameList = [
  { path: 'ActivationToken.activationToken', new: 'token', reason: '.NET type name and member name cannot be identical' }
];

const operationSkipList = [];

const modelMethodSkipList = [
  { path: 'User.changePassword', reason: 'Implemented as a custom method' },
  { path: 'User.changeRecoveryQuestion', reason: 'Implemented as a custom method'},
  { path: 'User.forgotPasswordWithRecoveryAnswer', reason: 'Implemented as a custom method'},
  { path: 'User.assignRoleToUser', reason: 'Implemented as a custom method'},
];

const getType = (specType) => {
  switch(specType) {
    case 'boolean': return 'bool?';
    case 'integer': return 'int?';
    case 'dateTime': return 'DateTimeOffset?';
    default: return specType;
  }
};

function paramToCLRType(param) {
  return getType(param.type);
}

function propToCLRType(prop) {
  switch (prop.commonType) {
    case 'array': return `IList<${getType(prop.model)}>`;
    case 'object': return prop.model;
    case 'hash': return `IDictionary<string, ${getType(prop.model)}>`;
    default: return getType(prop.commonType);
  }
}

function getterName(prop) {
  if (prop.commonType === 'array') {
    return `GetArrayProperty<${getType(prop.model)}>`;
  }

  const clrType = propToCLRType(prop);

  switch (clrType) {
    case 'bool?': return 'GetBooleanProperty';
    case 'int?': return 'GetIntegerProperty';
    case 'DateTimeOffset?': return 'GetDateTimeProperty';
    case 'string': return 'GetStringProperty';
    default: return `GetResourceProperty<${clrType}>`;
  }
}

function getMappedArgName(method, argName) {
  let mapping = method.arguments.find(x => x.dest === argName);
  if (!mapping) return null;
  return mapping.src;
}

csharp.process = ({spec, operations, models, handlebars}) => {

  handlebars.registerHelper({
    paramToCLRType,
    propToCLRType,
    getterName,
    getMappedArgName
  });

  const templates = [];

  // add all the models
  for (let model of models) {
    model.specVersion = spec.info.version;

    if (partialUpdateList.has(model.modelName)) {
      model.supportsPartialUpdates = true;
    }

    for (let property of model.properties) {
      let fullPath = `${model.modelName}.${property.propertyName}`;

      if (property.model && property.model === 'object') {
        console.log('Skipping object property', fullPath);
        property.hidden = true;
        continue;
      }

      if (typeof property.commonType === 'undefined') {
        console.log('Skipping property without commonType', fullPath);
        property.hidden = true;
        continue;
      }

      let skipRule = propertySkipList.find(x => x.path === fullPath);
      if (skipRule) {
        console.log('Skipping property', fullPath, `(Reason: ${skipRule.reason})`);
        property.hidden = true;
        continue;
      }

      let renameRule = propertyRenameList.find(x => x.path === fullPath);
      if (renameRule) {
        console.log(`Renaming property ${fullPath} to ${renameRule.new}`, `(Reason: ${renameRule.reason})`);
        property.displayName = renameRule.new;
      }
    }

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

    templates.push({
      src: 'IModel.cs.hbs',
      dest: `Generated/I${model.modelName}.Generated.cs`,
      context: model
    });

    templates.push({
      src: 'Model.cs.hbs',
      dest: `Generated/${model.modelName}.Generated.cs`,
      context: model
    });
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
      src: 'IClient.cs.hbs',
      dest: `Generated/I${tag}Client.Generated.cs`,
      context: {
        tag,
        spec,
        operations: taggedOperations[tag]
      }
    });

    templates.push({
      src: 'Client.cs.hbs',
      dest: `Generated/${tag}Client.Generated.cs`,
      context: {
        tag,
        spec,
        operations: taggedOperations[tag]
      }
    });
  }

  return templates;
}
