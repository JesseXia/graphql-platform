using HotChocolate.Language;
using HotChocolate.Types;

namespace HotChocolate.Data.Filters;

public interface IFilterFieldDescriptor
    : IDescriptor<FilterFieldConfiguration>
    , IFluent
{
    IFilterFieldDescriptor Name(string value);

    IFilterFieldDescriptor Description(string value);

    IFilterFieldDescriptor Type<TInputType>()
        where TInputType : IInputType;

    IFilterFieldDescriptor Type<TInputType>(TInputType inputType)
        where TInputType : class, IInputType;

    IFilterFieldDescriptor Type(ITypeNode typeNode);

    IFilterFieldDescriptor Type(Type type);

    IFilterFieldDescriptor Ignore(bool ignore = true);

    IFilterFieldDescriptor DefaultValue(IValueNode value);

    IFilterFieldDescriptor DefaultValue(object value);

    IFilterFieldDescriptor Directive<T>(T directiveInstance)
        where T : class;

    IFilterFieldDescriptor Directive<T>()
        where T : class, new();

    IFilterFieldDescriptor Directive(
        string name,
        params ArgumentNode[] arguments);
}
