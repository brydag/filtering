using System;
using System.Linq.Expressions;
using filtering;

namespace FilteringMechanism.FilterOperators
{
    public class CountOperator:IFilteringOperator
    {
        public Expression CreateExpression(Expression left, Expression right)
        {
            const string methodName = "Count";
            var countMethod = left.Type.GetMethod(methodName);

            if (countMethod == null)
            {
                throw new ArgumentException(methodName, left.Type.Name);
            }

            return Expression.Call(left, countMethod, right);
        }
    }
}