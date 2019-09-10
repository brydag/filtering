using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace filtering
{
    public static class FilteringExtension
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, IFilterElement filterElement)
        {
            //param
            var paramExpression = Expression.Parameter(typeof(T), "param");
            var expr = (Expression<Func<T, bool>>)filterElement.CreateExpression(paramExpression);

            return query.Where(expr);
        }

        public static MethodInfo GetContainsMethod(Expression left)
        {
            const string methodName = "Contains";
            var containsMethod = left.Type.GetMethod(methodName, new[] { typeof(string) });

            if (containsMethod == null)
            {
                throw new ArgumentException(methodName, left.Type.Name);
            }

            return containsMethod;
        }
    }
}