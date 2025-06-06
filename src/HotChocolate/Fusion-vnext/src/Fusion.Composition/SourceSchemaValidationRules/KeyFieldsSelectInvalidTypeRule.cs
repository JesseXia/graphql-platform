using HotChocolate.Fusion.Events;
using HotChocolate.Fusion.Events.Contracts;
using HotChocolate.Types;
using HotChocolate.Types.Mutable;
using static HotChocolate.Fusion.Logging.LogEntryHelper;

namespace HotChocolate.Fusion.SourceSchemaValidationRules;

/// <summary>
/// The <c>@key</c> directive is used to define the set of fields that uniquely identify an entity.
/// These fields must reference scalars or object types to ensure a valid and consistent
/// representation of the entity across subgraphs. Fields of types <c>List</c>, <c>Interface</c>, or
/// <c>Union</c> cannot be part of a <c>@key</c> because they do not have a well-defined unique
/// value.
/// </summary>
/// <seealso href="https://graphql.github.io/composite-schemas-spec/draft/#sec-Key-Fields-Select-Invalid-Type">
/// Specification
/// </seealso>
internal sealed class KeyFieldsSelectInvalidTypeRule : IEventHandler<KeyFieldEvent>
{
    public void Handle(KeyFieldEvent @event, CompositionContext context)
    {
        var (keyField, keyFieldDeclaringType, keyDirective, type, schema) = @event;

        var fieldType = keyField.Type.NullableType();

        if (fieldType is MutableInterfaceTypeDefinition or ListType or MutableUnionTypeDefinition)
        {
            context.Log.Write(
                KeyFieldsSelectInvalidType(
                    keyField.Name,
                    keyFieldDeclaringType.Name,
                    keyDirective,
                    type.Name,
                    schema));
        }
    }
}
