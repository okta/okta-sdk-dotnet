const {
  camelCase,
  pascalCase,
  createMethodSignatureLiteral,
  createParametersLiteral
} = require('./utils');

/*
Creates the context that the handlebars template is bound to:

{
  memberName: 'Users',
  resourceName: 'User',
  operations: [
    {
      memberName: 'ListUsers',
      description: 'Lists users in your organization with pagination in most cases.',
      hasCancellationToken: false,
      returnTypeLiteral = 'IAsyncEnumerable<IUser>',
      returnDocumentationLiteral = 'A collection of <see cref="IUser"/> that can be enumerated asynchronously.'
      methodSignatureLiteral: '',
      parametersLiteral: '',
      bodyModel: {
        type: {
          memberName: 'User'
        },
        parameterName: 'user'
      },
      pathParams: [
        { name: 'id', description: 'The user ID' }
      ],
      queryParams: [
        { name: 'q', description: 'Finds a user that matches firstName, lastName, and email properties' }
      ],
    }
  ]
}
*/
function createContextForClient(tag, spec, operations) {
  let context = {
    memberName: `${tag}s`,
    resourceName: tag,
    operations: []
  };

  for (let operation of operations) {
    if (operation.hidden) continue;

    let operationContext = {
      description: operation.description,
      pathParameters: operation.pathParams,
      queryParameters: operation.queryParams,
      hasCancellationToken: !operation.isArray,
      responseType: {
        memberName: operation.responseModel
      }
    }

    operationContext.memberName = pascalCase(operation.operationId);
    if (!operation.isArray) operationContext.memberName += 'Async';

    if (operation.bodyModel) {
      operationContext.bodyModel = {
        type: { 
          memberName: operation.bodyModel
        },
        parameterName: camelCase(operation.bodyModel)
      };
    }

    if (operation.isArray) {
      operationContext.returnTypeLiteral = `IAsyncEnumerable<I${operationContext.responseType.memberName}>`;
      operationContext.returnDocumentationLiteral = `A collection of <see cref="I${operationContext.responseType.memberName}"/> that can be enumerated asynchronously.`;
    } else if (operation.responseModel) {
      operationContext.returnTypeLiteral = `Task<I${operationContext.responseType.memberName}>`;
      operationContext.returnDocumentationLiteral = `The <see cref="I${operationContext.responseType.memberName}"/> response.`;
    } else {
      operationContext.returnTypeLiteral = 'Task';
      operationContext.returnDocumentationLiteral = 'A Task that represents the asynchronous operation.';
    }

    operationContext.methodSignatureLiteral
      = createMethodSignatureLiteral(operation);

    operationContext.parametersLiteral
      = createParametersLiteral(operation);

    context.operations.push(operationContext);
  }

  return context;
}

// {{~nbsp 0}}(
//   {{~#if bodyModel}}
//       {{~nbsp 0}}I{{bodyModel}} {{camelCase bodyModel}},{{nbsp}}
//   {{~/if}}

//   {{~#each allParams}}
//       {{~paramToCLRType this}}{{nbsp}}
//       {{~name}}
//       {{~#if (exists this "default")}}
//           {{~nbsp}}= {{#if (eq this.type "string")}}"{{/if}}
//           {{~nbsp 0}}{{default}}
//           {{~nbsp 0}}{{#if (eq this.type "string")}}"{{/if}}
//       {{~else}}
//           {{~#unless required}} = null{{/unless}}
//       {{~/if}}
//       {{~#unless @last}},{{nbsp}}{{/unless}}
//   {{~/each}}
//   {{~#unless isArray}}
//       {{~#if allParams.length}},{{nbsp}}{{/if}}
//       {{~nbsp 0}}CancellationToken cancellationToken = default(CancellationToken)
//   {{~/unless}}
// {{~nbsp 0}});


module.exports.createContextForClient = createContextForClient;
