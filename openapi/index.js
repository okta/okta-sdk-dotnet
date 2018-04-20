/**
 * This file is used by the @okta/openapi generator.  It defines language-specific
 * post-processing of the JSON spec, as well as handebars helpers.  This file is meant
 * to give you control over the data that handlebars uses when processing your templates
 */

const { 
  paramToCLRType,
  propToCLRType,
  getterName,
  getMappedArgName
 } = require('./utils');

const { createContextForEnum } = require('./processEnum');
const { createContextForResolver } = require('./processResolver');
const { createContextForModel } = require('./processModel');
const { createContextForClient } = require('./processClient')

const {
  partialUpdateList,
  propertyDetailsList,
  operationSkipList,
  modelMethodSkipList
} = require('./constants');

function errorLogger(message, model) {
  console.error(model);
  throw new Error(message);
}

module.exports.process = ({spec, operations, models, handlebars}) => {

  handlebars.registerHelper({
    paramToCLRType,
    propToCLRType,
    getterName,
    getMappedArgName
  });

  const templates = [];

  let baseModels = new Set(models
    .filter(model => model.extends)
    .map(model => model.extends));

  // add all the models
  for (let model of models) {
    model.specVersion = spec.info.version;

    if (model.enum) {
      templates.push({
        src: 'templates/Enum.cs.hbs',
        dest: `Generated/${model.modelName}.Generated.cs`,
        context: createContextForEnum(model, errorLogger)
      });

      // Don't do anything else for enums
      continue;
    }

    // TODO remove
    if (partialUpdateList.has(model.modelName)) {
      model.supportsPartialUpdates = true;
    }

    if (baseModels.has(model.modelName)) {
      model.isBaseModel = true;
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
        context: createContextForResolver(model, errorLogger)
      });
    }

    templates.push({
      src: 'templates/IModel.cs.hbs',
      dest: `Generated/I${model.modelName}.Generated.cs`,
      context: createContextForModel(model, errorLogger)
    });

    templates.push({
      src: 'templates/Model.cs.hbs',
      dest: `Generated/${model.modelName}.Generated.cs`,
      context: createContextForModel(model, errorLogger)
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
      src: 'templates/IClient.cs.hbs',
      dest: `Generated/I${tag}sClient.Generated.cs`,
      context: createContextForClient(tag, spec, taggedOperations[tag])
    });

    templates.push({
      src: 'templates/Client.cs.hbs',
      dest: `Generated/${tag}sClient.Generated.cs`,
      context: {
        tag, spec,
        operations: taggedOperations[tag]
      },
      context: createContextForClient(tag, spec, taggedOperations[tag])
    });
  }

  return templates;
}
