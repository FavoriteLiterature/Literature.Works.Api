using System.Linq.Expressions;

namespace Literature.Works.Api.Extensions;

public static class OrderByExtension
{
    public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>
    (this IQueryable<TSource> source,
        Expression<Func<TSource, TKey>> keySelector,
        bool descending)
    {
        return descending
            ? source.OrderByDescending(keySelector)
            : source.OrderBy(keySelector);
    }
}