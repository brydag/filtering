using System.Linq.Expressions;
using filtering;

namespace FilteringMechanism.FilterOperators
{
    public class GreaterThanOrEqualOperator: IFilteringOperator
    {
        public Expression CreateExpression(Expression left, Expression right)
        {
            return Expression.GreaterThanOrEqual(left, right);
        }
    }
}