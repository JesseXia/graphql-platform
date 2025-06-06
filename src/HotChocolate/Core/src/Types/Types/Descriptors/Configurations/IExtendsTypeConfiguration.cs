#nullable enable

namespace HotChocolate.Types.Descriptors.Definitions;

public interface IExtendsTypeConfiguration
{
    /// <summary>
    /// If this is a type configuration extension
    /// this is the type we want to extend.
    /// </summary>
    Type? ExtendsType { get; }
}
