using System.Linq.Expressions;
using FilteringMechanism.FilterOperators.Interfaces;

namespace FilteringMechanism.FilterOperators
{
    public class LessThanOrEqualOperator: IFilteringOperator
    {
        public Expression CreateExpression(Expression left, Expression right)
        {
            return Expression.LessThanOrEqual(left, right);
        }
    }
}