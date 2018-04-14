const { 
  pascalCase,
  camelCase,
  propToCLRType,
  paramToCLRType,
  getMappedArgName,
  isNullOrUndefined
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
  properties: [
    {
      type: 'IUserCredentials',
      memberName: 'Credentials',
      getterSetterLiteral: '{ get; set; }',
      hidesBaseMember: false
    }
  ],
  methods: [
    returnTypeLiteral: 'Task<IFactor>',
    memberName: 'AddFactorAsync',
    parametersLiteral: 'Factor factor, bool? updatePhone = false, string templateId = null, CancellationToken cancellationToken = default(CancellationToken)'
  ]
}
*/
function createContextForModelInterface(model, errFunc) {
  let context = {
    memberName: model.modelName,
    baseClass: model.extends || 'Resource',
    properties: [],
    methods: []
  };

  for (let property of model.properties) {
    if (property.hidden) continue;

    let type = propToCLRType(property, true);

    let memberName = pascalCase(property.displayName || property.propertyName);

    let getterSetterLiteral = property.readOnly
      ? '{ get; }'
      : '{ get; set; }';

    context.properties.push({
      type, memberName, getterSetterLiteral,
      hidesBaseMember: property.hidesBaseMember
    });
  }

  for (let method of model.methods) {
    if (method.hidden) continue;

    let methodContext = {};
    
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

    methodContext.parametersLiteral = createParametersLiteral(
      method.operation,
      method.arguments);

    context.methods.push(methodContext);
  }

  return context;
}

function createContextForModel(model, errFunc) {
  return model;
}

function createParametersLiteral(operation, arguments) {
  let parameters = [];

  let hasBodyArgument = !!operation.bodyModel;
  if (hasBodyArgument) {
    let typeMemberName = operation.bodyModel;
    let parameterName = camelCase(operation.bodyModel);
    parameters.push(`${typeMemberName} ${parameterName}`);
  }

  for (let param of operation.allParams) {
    let alreadyMapped = getMappedArgName(arguments, param.name);
    if (alreadyMapped) continue;

    let typeMemberName = paramToCLRType(param);
    let parameterName = param.name;

    let parameterLiteral = `${typeMemberName} ${parameterName}`;

    let hasDefaultValue = !isNullOrUndefined(param.default);
    if (hasDefaultValue) {
      parameterLiteral += ' = ';
      parameterLiteral += param.type === 'string'
        ? `"${param.default}"`
        : param.default;
    }

    let optionalAndNoDefaultValue = !hasDefaultValue && !param.required;
    if (optionalAndNoDefaultValue) {
      parameterLiteral += ' = null';
    }

    parameters.push(parameterLiteral);
  }
  
  if (!operation.isArray) {
    parameters.push('CancellationToken cancellationToken = default(CancellationToken)');
  }

  return parameters.join(', ');
}

module.exports.createContextForResolver = createContextForResolver;
module.exports.createContextForModelInterface = createContextForModelInterface;
module.exports.createContextForModel = createContextForModel;
