const _ = require('lodash');
const js = module.exports;
const generatorLangVersion = "0.0.1";

js.process = (spec, handlebars) => {

  // Helper functions
  let toValidName = (original) => toPascalCase(replaceIllegalChars(original));

  function toPascalCase(original) {
      if (!original) return original;
      return original[0].toUpperCase() + original.slice(1);
  }

  function replaceIllegalChars(original) {
      if (!original) return original;
      
      return original
        .replace('$', '')
        .replace('#', '');
  }

  function toClrFriendlyTypeName(prop) {
    const mapping = {
      "boolean": "bool",
      "integer": "int",

      // todo object? (FactoryAuthenticationContext)
    }

    let mapName = (original) => {
      let rewritten = mapping[original];
      return rewritten ? rewritten : original;
    }

    let mapped = mapName(prop.type);

    if (prop.type === 'array') {
      mapped = mapName(prop.items.type) + '[]';
    }

    return mapped;
  }

  // A map of operation Id's do their definition, so that
  // we can reference them when building out methods for x-okta-links
  const operationIdMap = {};

  // Collect all the operations
  spec.easyOperations = [];
  for (let pathName in spec.paths) {
    const path = spec.paths[pathName];
    for (let methodName in path) {
      const method = path[methodName];

      // List of query params definitions for this method
      const easyQueryParams = method.parameters.filter(param => param.in === 'query');

      // List of positional path arguments for this method
      const arguments = method.parameters.filter(param => param.in === 'path');

      // Determine the return type
      const easySuccessSchema = _.get(method, 'responses["200"].schema');
      if (easySuccessSchema) {
        if (easySuccessSchema.items && easySuccessSchema.items['$ref']) {
          easySuccessSchema.items.type = _.last(easySuccessSchema.items['$ref'].split('/'));
        } else if (easySuccessSchema['$ref']) {
          easySuccessSchema.type = _.last(easySuccessSchema['$ref'].split('/'));
        }
      }

      const operation = Object.assign({
        easyQueryParams,
        arguments,
        easySuccessSchema,
        path: pathName,
        method: methodName
      }, method);
      operationIdMap[method.operationId] = operation;
      spec.easyOperations.push(operation);
    }
  }

  // make models easier to loop through
  spec.easyModels = Object.entries(spec.definitions)
    .map(([modelName, model]) => {
      model.className = toValidName(modelName);

      model.easyLinks = model['x-okta-links'];
      if (model.easyLinks) {
        model.easyLinks.forEach(link => {
          link.operation = operationIdMap[link.operationId];
          link.operationName = toValidName(link.operationId);

          if (link.operation.easySuccessSchema.type) {
            link.returnType = toClrFriendlyTypeName(link.operation.easySuccessSchema);
          }
        });
      }

      if (model.properties) {
          model.easyProperties = Object.entries(model.properties)
            .map(([propName, prop]) => {
              if (propName[0] === '_') {
                prop.internal = true;
              }

              // Make sure properties are PascalCase
              prop.propName = toValidName(propName);
              
              // Handle reference types
              let ref = prop['$ref']
              if (ref) {
                let refModelName = _.last(ref.split('/'));
                refModelName = toValidName(refModelName);
                prop.type = refModelName;
              }

              prop.type = toClrFriendlyTypeName(prop);

              return prop;
            });
      }

      model.specVersion = spec.info.version;
      model.generatorLangVersion = generatorLangVersion;

      return model;
    });

  const templates = [];

  // add all the models
  for (let model of spec.easyModels) {
    templates.push({
      src: 'ModelInterface.cs.hbs',
      dest: `src/models/I${model.className}.cs`,
      context: model
    });

    // TODO also return all of the concrete implementations
  }

  // Handlebars helpers

  handlebars.registerHelper('getOperationArgs', (linkDefinition, operation) => {
    // TODO! This needs to return a list of arguments like:
    // string foo, int bar...
    return {};
  });

  handlebars.registerHelper('getOperationArgsCount', (linkDefinition, operation) => {
    // TODO! This needs to return a list of arguments like:
    // string foo, int bar...
    return 0;
  });

  return templates;
};
