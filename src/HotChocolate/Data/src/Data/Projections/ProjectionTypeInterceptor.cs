using HotChocolate.Configuration;
using HotChocolate.Language;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors.Definitions;
using static HotChocolate.Data.Projections.ProjectionConvention;
using static HotChocolate.Execution.Processing.OperationCompilerOptimizerHelper;

namespace HotChocolate.Data.Projections;

internal sealed class ProjectionTypeInterceptor : TypeInterceptor
{
    private ITypeCompletionContext? _queryContext;

    public override void OnAfterResolveRootType(
        ITypeCompletionContext completionContext,
        ObjectTypeConfiguration configuration,
        OperationType operationType)
    {
        if (operationType is OperationType.Query)
        {
            _queryContext = completionContext;
        }
    }

    public override void OnAfterMakeExecutable(
        ITypeCompletionContext completionContext,
        TypeSystemConfiguration configuration)
    {
        if (ReferenceEquals(completionContext, _queryContext) &&
            completionContext.Type is ObjectType { Fields: var fields, })
        {
            var foundNode = false;
            var foundNodes = false;

            foreach (var field in fields)
            {
                if (field.Name is not ("node" or "nodes"))
                {
                    continue;
                }

                switch (field.Name)
                {
                    case "node":
                        foundNode = true;
                        break;

                    case "nodes":
                        foundNodes = true;
                        break;
                }

                var selectionOptimizer = completionContext.DescriptorContext
                    .GetProjectionConvention()
                    .CreateOptimizer();

                if (field.ContextData is not ExtensionData extensionData)
                {
                    throw ThrowHelper.ProjectionConvention_NodeFieldWasInInvalidState();
                }

                RegisterOptimizer(
                    extensionData,
                    new NodeSelectionSetOptimizer(selectionOptimizer));

                if (foundNode && foundNodes)
                {
                    break;
                }
            }
        }
    }

    public override void OnAfterCompleteName(
        ITypeCompletionContext completionContext,
        TypeSystemConfiguration configuration)
    {
        if (configuration is ObjectTypeConfiguration objectTypeDefinition)
        {
            List<string>? alwaysProjected = null;
            foreach (var field in objectTypeDefinition.Fields)
            {
                alwaysProjected ??= [];
                if (field.GetContextData().TryGetValue(IsProjectedKey, out var value) &&
                    value is true)
                {
                    alwaysProjected.Add(field.Name);
                }
            }

            if (alwaysProjected?.Count > 0)
            {
                configuration.ContextData[AlwaysProjectedFieldsKey] = alwaysProjected.ToArray();
            }
        }
    }
}
