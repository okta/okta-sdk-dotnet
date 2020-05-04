const _ = require('lodash');

function pascalCase(str) {
  return _.upperFirst(_.camelCase(str))
}

function camelCase(str) {
  return _.camelCase(str);
}

function getType(specType) {
  
  switch(specType) {
    case 'boolean': return 'bool?';
    case 'integer': return 'int?';
    case 'dateTime': return 'DateTimeOffset?';
    case 'double': return 'double?';
    case 'password': return 'string';
    default: return specType;
  }
};

function paramToCLRType(param) {
  if (param.model) {
    return param.model;
  }
  
  return getType(param.type);
}

function propToCLRType(prop, isInterface) {
  switch (prop.commonType) {
    case 'array': return `IList<${isInterface ? `I${prop.model}` : getType(prop.model)}>`;
    case 'object': return isInterface ? `I${prop.model}` : prop.model;
    case 'enum': return prop.model;
    case 'hash': return `Resource`;
    default: return getType(prop.commonType);
  }
}

function getterName(prop, isInterface) {
  if (prop.commonType === 'array') {
    return `GetArrayProperty<${isInterface ? `I${prop.model}` : getType(prop.model)}>`;
  }

  if (prop.commonType === 'enum') {
    return `GetEnumProperty<${prop.model}>`;
  }

  let clrType = propToCLRType(prop);

  switch (clrType) {
    case 'bool?': return 'GetBooleanProperty';
    case 'int?': return 'GetIntegerProperty';
    case 'DateTimeOffset?': return 'GetDateTimeProperty';
    case 'string': return 'GetStringProperty';
    case 'double?': return 'GetDoubleProperty';
    default: return `GetResourceProperty<${clrType}>`;
  }
}

function getMappedArgName(methodArguments, argName) {
  let mapping = methodArguments.find(x => x.dest === argName);
  if (!mapping) return null;
  return mapping.src;
}

function isNullOrUndefined(variable) {
  return variable === null || typeof variable === 'undefined';
}

function createMethodSignatureLiteral(operation, args) {
  let parameters = [];

  for (let param of operation.allParams) {
    let alreadyMapped = args && getMappedArgName(args, param.name);
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

function createParametersLiteral(operation, args) {
  let parametersInfo = {};
  let parameters = [];

  let hasBodyArgument = !!operation.bodyModel;
  if (hasBodyArgument) {
      // grab param name from parameter list
      let bodyModelParams = operation.parameters.filter(x => x.in == 'body');
      if(bodyModelParams != null){
        let bodyModelParam = bodyModelParams[0];
        bodyModelParamName = bodyModelParam.name;
      }

    let parameterName = bodyModelParamName;
    parameters.push(parameterName);
  }

  for (let param of operation.allParams) {
    let isMappedParameter = args && getMappedArgName(args, param.name);
    let parameterName = isMappedParameter
      ? pascalCase(getMappedArgName(args, param.name))
      : param.name;

    parameters.push(parameterName);
  }
  
  if (!operation.isArray) {
    parameters.push('cancellationToken');
  }

  parametersInfo.parametersLiteral = parameters.join(', ');
  parametersInfo.parametersCount = (parameters.length > 1) ? true : false;

  return parametersInfo;
}

function getPluralName(name) {
  let pluralName = `${name}s`;
  let lastChar = name.charAt(name.length - 1);
  
  if(lastChar == 'y') {
    // Remove y
    let auxName = name.slice(0, name.length - 1);
    pluralName = `${auxName}ies`;
  }

  return pluralName;
}

function getTypeForMember(memberType, memberTypeFormat){
  if(memberType == "string" ) {

    if (memberTypeFormat && memberTypeFormat == 'binary') {
      return 'byte[]';
    }
    
    return memberType;
  }

  return `I${memberType}`;
}

module.exports.pascalCase = pascalCase;
module.exports.camelCase = camelCase;
module.exports.paramToCLRType = paramToCLRType;
module.exports.propToCLRType = propToCLRType;
module.exports.getterName = getterName;
module.exports.getMappedArgName = getMappedArgName;
module.exports.isNullOrUndefined = isNullOrUndefined;
module.exports.createMethodSignatureLiteral = createMethodSignatureLiteral;
module.exports.createParametersLiteral = createParametersLiteral;
module.exports.getPluralName = getPluralName;
module.exports.getTypeForMember = getTypeForMember;
