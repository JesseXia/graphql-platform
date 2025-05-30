using System.Linq.Expressions;
using System.Reflection;
using HotChocolate.Types.Descriptors.Definitions;

namespace HotChocolate.Data.Filters;

public class FilterFieldConfiguration
    : InputFieldConfiguration
    , IFilterFieldConfiguration
{
    public MemberInfo? Member { get; set; }

    public IFilterFieldHandler? Handler { get; set; }

    public Expression? Expression { get; set; }

    internal IFilterMetadata? Metadata { get; set; }

    public string? Scope { get; set; }

    internal void CopyTo(FilterFieldConfiguration target)
    {
        base.CopyTo(target);

        target.Member = Member;
        target.Handler = Handler;
        target.Scope = Scope;
    }

    internal void MergeInto(FilterFieldConfiguration target)
    {
        base.MergeInto(target);

        if (Member is not null)
        {
            target.Member = Member;
        }

        if (Handler is not null)
        {
            target.Handler = Handler;
        }

        if (Scope is not null)
        {
            target.Scope = Scope;
        }
    }
}
