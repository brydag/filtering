using System;
using System.Linq;
using System.Linq.Expressions;

namespace FilteringMechanism
{
    public static class FilteringExtension
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, IFilterElement filterElement)
        {
            var paramExpression = Expression.Parameter(typeof(T), "param");
            var expr = filterElement.CreateExpression(paramExpression);
            var lambda = Expression.Lambda<Func<T, bool>>(expr, (ParameterExpression)paramExpression);
            return query.Where(lambda);
        }
    }
}