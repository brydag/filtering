using System.Linq.Expressions;
using FilteringMechanism.FilterOperators.Interfaces;

namespace FilteringMechanism.FilterOperators
{
    public class NotEqualOperator:IFilteringOperator
    {
        public Expression CreateExpression(Expression left, Expression right)
        {
            return Expression.NotEqual(left, right);
        }
    }
}
