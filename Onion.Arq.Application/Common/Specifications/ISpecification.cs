using System.Linq.Expressions;

namespace Onion.Arq.Application.Common.Specifications
{
    public interface ISpecification<E>
    {
        Expression<Func<E, bool>> Criteria { get; }
        Expression<Func<E, object>> OrderBy { get; }
        Expression<Func<E, object>> OrderByDescending { get; }
        List<Expression<Func<E, object>>> Includes { get; }
        List<string> IncludeStrings { get; }

        int PageSize { get; }
        int PageNumber { get; }

        bool IsPagingEnabled { get; }

        bool IgnoreQueryFilters { get; }
    }
}
