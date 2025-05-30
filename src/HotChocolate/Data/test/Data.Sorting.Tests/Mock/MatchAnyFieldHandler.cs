using HotChocolate.Configuration;
using HotChocolate.Data.Sorting.Expressions;

namespace HotChocolate.Data.Sorting;

public class MatchAnyQueryableFieldHandler
    : SortFieldHandler<QueryableSortContext, QueryableSortOperation>
{
    public override bool CanHandle(
        ITypeCompletionContext context,
        ISortInputTypeConfiguration typeConfiguration,
        ISortFieldConfiguration fieldConfiguration) => true;
}
