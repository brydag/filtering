using System.Linq.Expressions;
using FilteringMechanism.FilterOperators.Interfaces;

namespace FilteringMechanism.FilterOperators
{
    public class GreaterThanOperator: IFilteringOperator
    {
        public Expression CreateExpression(Expression left, Expression right)
        {
            return Expression.GreaterThan(left, right);
        }
    }
}