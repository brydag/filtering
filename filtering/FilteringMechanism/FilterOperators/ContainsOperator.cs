using System;
using System.Linq.Expressions;
using filtering;

namespace FilteringMechanism.FilterOperators
{
    public class ContainsOperator : IFilteringOperator
    {
        public Expression CreateExpression(Expression left, Expression right)
        {
            const string methodName = "Contains";
            var containsMethod = left.Type.GetMethod(methodName, new[] { typeof(string) });

            if (containsMethod == null)
            {
                throw new ArgumentException(methodName, left.Type.Name);
            }
            
            return Expression.Call(left, containsMethod, right);
        }
    }
}