const { 
  pascalCase,
  camelCase,
  propToCLRType,
  paramToCLRType,
  getMappedArgName,
  getterName,
  isNullOrUndefined,
  createMethodSignatureLiteral,
  createParametersLiteral
 } = require('./utils');

/*
Creates the context that the handlebars template is bound to:

{
  parentType: {
    memberName: 'Factor'
  },
  resolvingProperty: {
    memberName: 'FactorType',
    name: 'factorType'
  },
  namesToValues: [
    { value: 'call', resolvedType: { memberName: 'CallFactor' } }
  ]
}
*/
function createContextForResolver(model, errFunc) {
  let context = {
    parentType: {
      memberName: model.modelName
    },
    resolvingProperty: {
      name: model.resolutionStrategy.propertyName,
      memberName: pascalCase(model.resolutionStrategy.propertyName)
    },
    namesToValues: []
  };

  for (let name of Object.keys(model.resolutionStrategy.valueToModelMapping)) {
    context.namesToValues.push({
      value: name,
      resolvedType: {
        memberName: model.resolutionStrategy.valueToModelMapping[name]
      }
    });
  }

  return context;
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
function createContextForModel(model, errFunc) {
  let context = {
    memberName: model.modelName,
    baseClass: model.extends || 'Resource',
    isBaseModel: model.isBaseModel,
    properties: [],
    methods: []
  };

  for (let property of model.properties) {
    if (property.hidden) continue;

    let type = propToCLRType(property, true);

    let memberName = pascalCase(property.displayName || property.propertyName);

    let getterLiteral = `${getterName(property)}("${property.propertyName}")`;

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
      methodContext.returnTypeLiteral = `IAsyncEnumerable<I${method.operation.responseModel}>`;
    } else if (method.operation.responseModel) {
      methodContext.returnTypeLiteral = `Task<I${method.operation.responseModel}>`;
    } else {
      methodContext.returnTypeLiteral = 'Task'
    }

    methodContext.memberName = pascalCase(method.alias);
    if (!method.operation.isArray)
      methodContext.memberName += 'Async';

    methodContext.client = {};
    methodContext.client.memberName = `${method.operation.tags[0]}s`;

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

module.exports.createContextForResolver = createContextForResolver;
module.exports.createContextForModel = createContextForModel;
