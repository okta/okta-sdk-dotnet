const { 
  pascalCase,
  camelCase,
  propToCLRType,
  paramToCLRType,
  getMappedArgName,
  getterName,
  isNullOrUndefined,
  createMethodSignatureLiteral,
  createParametersLiteral,
  getPluralName
} = require('./utils');

const {
  isPropertyUnsupported,
  applyPropertyErrata,
  applyModelErrata,
  shouldSkipModelMethod
} = require('./errata');

const { createContextForEnum } = require('./processEnum');
const { createContextForResolver } = require('./processResolver');

function getTemplatesforModels(models, infoLogger, errorLogger) {
  // baseModels are types that have child/inherited
  // types somewhere else in the spec
  let baseModelsList = new Set(models
    .filter(model => model.extends)
    .map(model => model.extends));

  // strictModelList are types that will be generated as pure classes (i.e StringEnum is not part of this list)
  let strictModelList = new Set(models.filter(model => model.enum == null).map(model => model.modelName));

  // Preprocess all the models, apply errata, and enrich with extra data
  // This is only step 1; the next step is createContextForModel() below
  models = models.map(model => {
    if (baseModelsList.has(model.modelName)) {
      model.isBaseModel = true;
    }
    model = applyModelErrata(model, strictModelList, infoLogger);
    model.properties = model.properties || [];
    model.properties = model.properties.map(property =>
    {
      property.fullPath = `${model.modelName}.${property.propertyName}`;

      property = applyPropertyErrata(property, infoLogger); // See errata.js

      let unsupported = isPropertyUnsupported(property);
      if (unsupported) {
        infoLogger(`Skipping unsupported property ${property.fullPath}`, `Reason: ${unsupported.reason}`);
        property.hidden = true;
      }

      return property;
    });

    model.methods = model.methods || [];
    model.methods = model.methods.map(method =>
    {
      method.fullPath = `${model.modelName}.${method.alias}`;
      let shouldSkip = shouldSkipModelMethod(method.fullPath);
      if (shouldSkip) {
        method.hidden = true;
        infoLogger(`Skipping model method ${method.fullPath} (Reason: ${shouldSkip.reason})`);
      }
    
      if(method.operation != null) {
        method.operation.pathParams = method.operation.pathParams || [];
        method.operation.queryParams = method.operation.queryParams || [];
        method.operation.allParams = method.operation.pathParams
        .concat(method.operation.queryParams);
      }
      else {
        infoLogger(`Method operation undefined ${method.fullPath}`);
      }

      return method;
    });

    return model;
  });

  // Assign handlebars templates to each model
  let modelTemplates = [];
  for (let model of models) {
    if (model.enum) {
      modelTemplates.push({
        src: 'templates/Enum.cs.hbs',
        dest: `Generated/${model.modelName}.Generated.cs`,
        context: createContextForEnum(model, errorLogger, infoLogger)
      });

      // Don't do anything else for enums
      continue;
    }

    if (model.requiresResolution) {
      modelTemplates.push({
        src: 'templates/Resolver.cs.hbs',
        dest: `Generated/${model.modelName}Resolver.Generated.cs`,
        context: createContextForResolver(model, errorLogger)
      });
    }

    modelTemplates.push({
      src: 'templates/IModel.cs.hbs',
      dest: `Generated/I${model.modelName}.Generated.cs`,
      context: createContextForModel(model, strictModelList, errorLogger)
    });

    modelTemplates.push({
      src: 'templates/Model.cs.hbs',
      dest: `Generated/${model.modelName}.Generated.cs`,
      context: createContextForModel(model, strictModelList, errorLogger)
    });
  }

  return modelTemplates;
}

/*
Creates the context that the handlebars template is bound to:

{
  memberName: 'User',
  baseClass: 'Resource',
  isBaseModel: false,
  properties: [
    {
      type: 'IUserCredentials',
      memberName: 'Credentials',
      getterLiteral: 'GetResource<IUserCredentials>("credentials")'
      propertyName: 'credentials',
      readOnly: true,
      hidesBaseMember: false
    }
  ],
  methods: [
    returnTypeLiteral: 'Task<IFactor>',
    memberName: 'AddFactorAsync',
    methodSignatureLiteral: 'Factor factor, bool? updatePhone = false, string templateId = null, CancellationToken cancellationToken = default(CancellationToken)',
    parametersLiteral: 'factor, updatePhone, templateId, cancellationToken',
    client: {
      memberName: 'Users'
    }
  ]
}
*/

function isModelInterface(property, strictModelList) {
  return (property.model != null && strictModelList.has(property.model) );
}

function createContextForModel(model, strictModelList, errFunc) {
  let context = {
    memberName: model.modelName,
    baseClass: model.extends || 'Resource',
    isBaseModel: model.isBaseModel,
    properties: [],
    methods: []
  };

  for (let property of model.properties) {
    if (property.hidden) continue;

    let isInterface = isModelInterface(property, strictModelList);
    let type = propToCLRType(property, isInterface);

    let memberName = pascalCase(property.displayName || property.propertyName);

    let getterLiteral = `${getterName(property, isInterface)}("${property.propertyName}")`;

    context.properties.push({
      type, memberName, getterLiteral,
      propertyName: property.propertyName,
      readOnly: property.readOnly,
      hidesBaseMember: property.hidesBaseMember
    });
  }

  for (let method of model.methods) {
    if (method.hidden) continue;

    let methodContext = {};

    if (method.operation.bodyModel) {
      methodContext.bodyModel = {
        type: { 
          memberName: method.operation.bodyModel
        },
        parameterName: camelCase(method.operation.bodyModel)
      };
    }
    
    if (method.operation.isArray) {
      methodContext.returnTypeLiteral = `ICollectionClient<I${method.operation.responseModel}>`;
    } else if (method.operation.responseModel) {
      methodContext.returnTypeLiteral = `Task<I${method.operation.responseModel}>`;
    } else {
      methodContext.returnTypeLiteral = 'Task'
    }

    methodContext.memberName = pascalCase(method.alias);
    if (!method.operation.isArray)
      methodContext.memberName += 'Async';

    methodContext.client = {};
    methodContext.client.memberName = getPluralName(method.operation.tags[0]);

    methodContext.methodOperation = {};
    methodContext.methodOperation.memberName = pascalCase(method.operation.operationId);
    if (!method.operation.isArray) methodContext.methodOperation.memberName += 'Async';

    methodContext.methodSignatureLiteral = createMethodSignatureLiteral(
      method.operation,
      method.arguments);

    methodContext.parametersLiteral = createParametersLiteral(
      method.operation,
      method.arguments);

    context.methods.push(methodContext);
  }

  return context;
}

module.exports.getTemplatesforModels = getTemplatesforModels;

