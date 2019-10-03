using System.Linq.Expressions;
using FilteringMechanism.FilterOperators.Interfaces;

namespace FilteringMechanism.FilterOperators
{
    public class EqualOperator : IFilteringOperator
    {
        public Expression CreateExpression(Expression left, Expression right)
        {
            return Expression.Equal(left, right);
        }
    }
}