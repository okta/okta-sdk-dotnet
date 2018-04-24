/**
 * This file is called by the @okta/openapi generator (npm run generate).
 * 
 * The input (JSON spec from @okta/openapi) is kind of messy, so this do some
 * pre-processing before handing the spec data to the below createContextFor*
 * methods. Each of those methods create the object ("context") that each
 * handlebars template is bound to. The handlebars templates are purposefully
 * light on logic. Most logic is performed in the createContextFor* methods.
 */

const {
  shouldSkipProperty,
  shouldSkipMethod,
} = require('./errata');

const { createContextForEnum } = require('./processEnum');
const { createContextForResolver } = require('./processResolver');
const { createContextForModel } = require('./processModel');
const { createContextForClient } = require('./processClient')

const {
  propertyErrata,
  operationSkipList
} = require('./constants');

function infoLogger() {
  console.log(...arguments);
}

function errorLogger(message, model) {
  console.error(model);
  throw new Error(message);
}

module.exports.process = ({spec, operations, models, handlebars}) => {
  const templates = [];

  // baseModels are types that have child/inherited
  // types somewhere else in the spec
  let baseModelsList = new Set(models
    .filter(model => model.extends)
    .map(model => model.extends));

  // Preprocess all the models and enrich with extra data
  models = models.map(model => {
    model.specVersion = spec.info.version;

    if (baseModelsList.has(model.modelName)) {
      model.isBaseModel = true;
    }

    model.properties = model.properties || [];
    model.properties = model.properties.map(property =>
    {
      property.fullPath = `${model.modelName}.${property.propertyName}`;

      property.hidden = shouldSkipProperty(property, infoLogger);

      let propertyDetails = propertyErrata.find(x => x.path == property.fullPath);
      if (propertyDetails) {
        if (propertyDetails.rename) {
          console.log(`Renaming property ${property.fullPath} to ${propertyDetails.rename}`, `(Reason: ${propertyDetails.renameReason})`);
          property.displayName = propertyDetails.rename;
        }
  
        if (propertyDetails.hidesBaseMember) {
          property.hidesBaseMember = true;
        }
      }

      return property;
    });

    model.methods = model.methods || [];
    model.methods = model.methods.map(method =>
    {
      method.fullPath = `${model.modelName}.${method.alias}`;

      method.hidden = shouldSkipMethod(method, infoLogger);

      method.operation.allParams = (method.operation.pathParams || [])
        .concat(method.operation.queryParams || []);

      return method;
    });

    return model;
  });

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

  for (let model of models)
  {
    if (model.enum) {
      templates.push({
        src: 'templates/Enum.cs.hbs',
        dest: `Generated/${model.modelName}.Generated.cs`,
        context: createContextForEnum(model, errorLogger)
      });

      // Don't do anything else for enums
      continue;
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

  for (let tag of Object.keys(taggedOperations)) {
    templates.push({
      src: 'templates/IClient.cs.hbs',
      dest: `Generated/I${tag}sClient.Generated.cs`,
      context: createContextForClient(tag, taggedOperations[tag])
    });

    templates.push({
      src: 'templates/Client.cs.hbs',
      dest: `Generated/${tag}sClient.Generated.cs`,
      context: createContextForClient(tag, taggedOperations[tag])
    });
  }

  return templates;
}
