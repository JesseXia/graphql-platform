using HotChocolate.Types;
using HotChocolate.Types.Descriptors.Definitions;

namespace HotChocolate.Data.Sorting;

public class SortEnumTypeConfiguration
    : EnumTypeConfiguration,
      IHasScope
{
    public string? Scope { get; set; }

    public Type EntityType { get; set; } = default!;
}
