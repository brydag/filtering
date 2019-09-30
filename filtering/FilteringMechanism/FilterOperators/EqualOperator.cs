using System.Linq.Expressions;
using filtering;

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